using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.DebtOperations.Commands.AddDebt
{
    public class AddDebtModel
    {
        public float DebtBill { get; set; }
        public float DebtDue { get; set; }
        public DateTime DebtPeriod { get; set; }

        public float DebtTotal
        {
            get { return DebtBill + DebtDue; }
        }

        public int User_Id { get; set; }

    }
}
