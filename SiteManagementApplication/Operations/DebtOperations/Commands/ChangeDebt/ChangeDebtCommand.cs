using SiteManagementInfrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.DebtOperations.Commands.ChangeDebt
{
    public class ChangeDebtCommand
    {
        public ChangeDebtModel Model { get; set; }

        private readonly ApplicationDbContext _dataBase;

        public int newDebtId;


        public ChangeDebtCommand(ApplicationDbContext dbContext)
        {
            _dataBase = dbContext;
        }

        public void Handle()
        {
            var debt = _dataBase.Debts
                .Where(x => x.DebtId == newDebtId)
                .FirstOrDefault();

            if (debt is not null)
            {
                debt.DebtBill  = Model.DebtBill;
                debt.DebtDue   = Model.DebtDue;
                debt.DebtYear  = Model.DebtYear  == 0 ? debt.DebtYear : Model.DebtYear;
                debt.DebtMonth = Model.DebtMonth == 0 ? debt.DebtMonth : Model.DebtMonth;
                debt.IsPaid = Model.IsPaid;

                _dataBase.SaveChanges();

            }
            else
            {
                throw new InvalidOperationException("Bu fatura bulunamadı.");
            }
        }
    }
}
