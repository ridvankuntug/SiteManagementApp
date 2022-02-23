using System;

namespace SiteManagementApplication.Operations.DebtOperations.Queries.GetDebt
{
    public class GetDebtModel
    {
        public float DebtBill { get; set; }
        public float DebtDue { get; set; }
        public int DebtYear { get; set; }
        public int DebtMonth { get; set; }
        public bool IsPaid { get; set; }

        public float DebtTotal
        {
            get { return DebtBill + DebtDue; }
        }

        public int User_Id { get; set; }
    }
}
