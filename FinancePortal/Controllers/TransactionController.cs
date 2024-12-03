using FinancePortal.Dtos;
using FinancePortal.Enum;
using FinancePortal.Factories;
using FinancePortal.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FinancePortal.Controllers
{
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
        public IActionResult CreateTransaction()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction(TransactionDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var mappedData = _transactionFactory.MapCreateDtoToEntity(dto);
            var resp = await _transactionService.AddTransactionAsync(mappedData).ConfigureAwait(false);

            if (resp.Data != null)
            {
                var transactionData = resp.Data;
                if (transactionData.Status == TransactionStatus.PENDING)
                {
                    TempData["TransactionId"] = transactionData.TransactionId;
                    return RedirectToAction("CheckStatus");
                }
            }

            if (resp.Status)
            {
                TempData["success"] = "Transaction done successfully";
                return View("Index");
            }
            else
            {
                TempData["error"] = "Transaction failed.";
                return View("Index");
            }
        }


        public IActionResult CheckStatus()
        {
            var transactionId = TempData["TransactionId"] as Guid?;
            ViewBag.TransactionId = transactionId;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CheckStatus(CheckStatusDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var resp = await _transactionService.CheckStatusAsync(dto).ConfigureAwait(false);

            if (resp.MessageType == "ConnectionRefused")
            {
                TempData["error"] = "Sorry, Unable to process the request due to connection error !!!";
                TempData["TransactionId"] = dto.TransactionId;
                return View();
            }

            TempData["success"] = "Updated Successfully";
            return View("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Detail()
        {
            var response = await _transactionService.GetAllAsync().ConfigureAwait(false);

            if (response.Status)
            {
                var orderedTransactions = response.Data.OrderByDescending(t => t.Id).ToList();
                return View(orderedTransactions);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        #endregion

    }
}
