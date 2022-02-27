using Microsoft.AspNetCore.Mvc;
using SiteManagementUi.Models.DebtModels;
using SiteManagementUi.Services;
using System.Collections.Generic;

namespace SiteManagementUi.Controllers
{
    public class DebtController : Controller
    {
        public IActionResult GetAllPaidDebt()
        {
            List<GetAllDebtModel> getAllDebtModel = DebtService.GetAllDebts(true);

            return View(getAllDebtModel);
        }
        public IActionResult GetAllNotPaidDebt()
        {
            List<GetAllDebtModel> getAllDebtModel = DebtService.GetAllDebts(false);

            return View(getAllDebtModel);
        }

        public IActionResult GetPaidDebtByPeriod()
        {
            return View();
        }

        public IActionResult GetPaidDebtByPeriodCheck(int debtMonth, int debtYear, bool isPaid)
        {
            if (debtMonth > 0)
            {
                List<GetAllDebtModel> debtModel = DebtService.GetAllDebtByPeriod(debtMonth, debtYear, isPaid);
                return View(debtModel);
            }
            return View();
        }

        public IActionResult AddDebtToAll(float debtBill, float debtDue, int debtYear, int debtMonth)
        {
            if (debtBill < 1) { return View(); }

            AddDebtToAllModel debtModel = new AddDebtToAllModel();
            debtModel.DebtBill = debtBill;
            debtModel.DebtDue = debtDue;
            debtModel.DebtYear = debtYear;
            debtModel.DebtMonth = debtMonth;

            DebtService.PostDebt(debtModel);
            return View();
        }

    }
}
