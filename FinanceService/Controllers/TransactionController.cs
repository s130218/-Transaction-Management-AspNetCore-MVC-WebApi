using FinanceService.Dtos;
using FinanceService.Factories;
using FinanceService.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinanceService.Controllers
{
    [Route("v1/")]
    [ApiController]
    public class TransactionController : Controller
    {
        #region Ctor & Properties
        private readonly ITransactionService _transactionService;
        private readonly ITransactionFactory _transactionFactory;
        public TransactionController(ITransactionService transactionService, ITransactionFactory transactionFactory)
        {
            _transactionService = transactionService;
            _transactionFactory = transactionFactory;
        }

        #endregion

        #region Method
        /// <summary>
        /// Create Transaction
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("transaction")]
        [HttpPost]
        public async Task<ActionResult> AddTransactionAsync([FromBody] TransactionCreateDto dto)
        {
            var mappedData = _transactionFactory.MapCreateDtoToEntity(dto);
            var response = await _transactionService.AddTransactionAsync(mappedData).ConfigureAwait(false);
            return Ok(response);
        }

        /// <summary>
        /// Get Transation
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        [Route("transaction/{transactionId}")]
        [HttpGet]
        public async Task<ActionResult<TransactionLogsDto>> CheckStatusByTransactionAsync(Guid transactionId)
        {
            var response = await _transactionService.CheckStatusByTransactionIdAsync(transactionId).ConfigureAwait(false);
            return Ok(response);
        }

        #endregion
    }
}
