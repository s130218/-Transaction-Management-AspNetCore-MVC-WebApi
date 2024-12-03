using FinancePortal.Dtos;
using FinancePortal.Enum;
using FinancePortal.Models;
using FinancePortal.Repositories;
using FinancePortal.Repositories.UOW;
using Newtonsoft.Json;
using System.Diagnostics;
using static FinancePortal.Dtos.ResponseDto;

namespace FinancePortal.Services
{
    public class TransactionService : ITransactionService
    {
        #region Ctor & Prop

        private readonly IBaseService _baseService;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUnitOfWork _unitOfWork;
        public TransactionService(IBaseService baseService, ITransactionRepository transactionRepository, IUnitOfWork unitOfWork)
        {
            _baseService = baseService;
            _transactionRepository = transactionRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Method

        public async Task<ServiceResult<Transaction>> AddTransactionAsync(Transaction transaction)
        {

            var resp = await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.POST,
                Url = "/v1/transaction",
                Data = transaction
            });


            if (resp.MessageType == "ConnectionRefused" || resp.MessageType == "Timeout")
            {
                var entity = new Transaction
                {
                    AccountNumber = transaction.AccountNumber,
                    Amount = transaction.Amount,
                    TransactionDate = DateTime.UtcNow,
                    CreatedBy = Guid.NewGuid(),
                    CreatedDate = DateTime.UtcNow,
                };

                if (resp.MessageType == "ConnectionRefused")
                {
                    entity.TransactionId = Guid.NewGuid();
                    entity.Status = TransactionStatus.FAILED;
                }
                else if (resp.MessageType == "Timeout")
                {
                    entity.TransactionId = transaction.TransactionId;
                    entity.Status = TransactionStatus.PENDING;
                }


                await _transactionRepository.AddAsync(entity).ConfigureAwait(false);
                await _unitOfWork.CommitAsync().ConfigureAwait(false);

                return new ServiceResult<Transaction>
                {
                    Status = false,
                    MessageType = "Failure",
                    Message = new List<string> { "Transaction is not scuccessfull." },
                    Data = entity
                };
            }

            if (resp.Data != null)
            {
                var transactionResponse = JsonConvert.DeserializeObject<TransactionResponseDto>(resp.Data.ToString());

                var sucessEntity = new Transaction
                {
                    TransactionId = transactionResponse.TransactionId,
                    AccountNumber = transaction.AccountNumber,
                    Amount = transaction.Amount,
                    TransactionDate = DateTime.UtcNow,
                    CreatedBy = Guid.NewGuid(),
                    CreatedDate = DateTime.UtcNow,
                };

                if (resp.Status == false)
                    sucessEntity.Status = TransactionStatus.FAILED;
                else
                    sucessEntity.Status = TransactionStatus.SUCCESS;

                await _transactionRepository.AddAsync(sucessEntity).ConfigureAwait(false);
                await _unitOfWork.CommitAsync().ConfigureAwait(false);

                return new ServiceResult<Transaction>
                {
                    Status = resp.Status,
                    MessageType = resp.MessageType,
                    Message = resp.Message,
                    Data = sucessEntity
                };
            }

            return new ServiceResult<Transaction>
            {
                Status = false,
                MessageType = "Failure",
                Message = new List<string> { "Invalid response data." },
                Data = null
            };
        }


        public async Task<ServiceResult<List<Transaction>>> GetAllAsync()
        {
            var resp = await _transactionRepository.GetAllAsync().ConfigureAwait(false);

            if (resp == null || !resp.Any())
                return new ServiceResult<List<Transaction>>
                {
                    Status = false,
                    MessageType = "Failed",
                    Data = null
                };

            return new ServiceResult<List<Transaction>>
            {
                Status = true,
                MessageType = "Success",
                Data = resp.ToList()
            };
        }

        public async Task<ServiceResult> CheckStatusAsync(CheckStatusDto dto)
        {
            var resp = await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = $"/v1/transaction/{dto.TransactionId}",
                Data = dto
            });

            if (resp.Data != null)
            {
                var transactionResponse = JsonConvert.DeserializeObject<Transaction>(resp.Data.ToString());

                var data = await _transactionRepository.GetAsync(x => x.TransactionId == transactionResponse.TransactionId).ConfigureAwait(false);

                if(data != null)
                {
                    data.Status = transactionResponse.Status;
                }

                _transactionRepository.Update(data);
                await _unitOfWork.CommitAsync().ConfigureAwait(false);
                return resp;
            }
            return resp;
        }

        #endregion

    }
}
