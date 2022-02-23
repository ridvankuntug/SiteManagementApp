using SiteManagementInfrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.DebtOperations.Commands.ChangeDebt
{
    public class PayDebtCommand
    {
        private readonly ApplicationDbContext _dataBase;

        public int newDebtId;


        public PayDebtCommand(ApplicationDbContext dbContext)
        {
            _dataBase = dbContext;
        }

        public void Handle()
        {
            var debt = _dataBase.Debts
                .Where(x => x.DebtId == newDebtId)
                .SingleOrDefault();

            if (debt is not null)
            {                
                debt.IsPaid = true;

                _dataBase.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Bu borç bulunamadı.");
            }
        }
    }
}
