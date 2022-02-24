using SiteManagementInfrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.DebtOperations.Commands.DelteDebt
{
    public class DeleteDebtCommand
    {
        private readonly ApplicationDbContext _dataBase;

        public int newDebtId;

        public DeleteDebtCommand(ApplicationDbContext dataBase)
        {
            _dataBase = dataBase;
        }

        public void Handle()
        {
            var debt = _dataBase.Debts
                .FirstOrDefault(a => a.DebtId == newDebtId);
            if (debt is not null)
            {
                _dataBase.Debts.Remove(debt);
                _dataBase.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Fatura bulunamadı.");
            }
        }
    }
}
