using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.DebtOperations.Queries.GetDebt
{
    public class GetDebtModel
    {
        public float DebtBill { get; set; }
        public float DebtDue { get; set; }
        public DateTime DebtPeriod { get; set; }


        public int User_Id { get; set; }
    }
}
