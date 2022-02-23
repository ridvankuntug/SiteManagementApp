using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.DebtOperations.Commands.ChangeDebt
{
    public class ChangeDebtModel
    {
        public float DebtBill { get; set; }
        public float DebtDue { get; set; }
        public int DebtYear { get; set; }
        public int DebtMonth { get; set; }
        public bool IsPaid { get; set; }

    }
}
