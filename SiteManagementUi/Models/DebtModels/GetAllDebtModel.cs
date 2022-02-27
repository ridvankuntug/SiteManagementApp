namespace SiteManagementUi.Models.DebtModels
{
    public class GetAllDebtModel
    {
        public int DebtId { get; set; }
        public float DebtBill { get; set; }
        public float DebtDue { get; set; }
        public int DebtYear { get; set; }
        public int DebtMonth { get; set; }
        public bool IsPaid { get; set; }

        public float DebtTotal { get; set; }

        public int User_Id { get; set; }
        public string UserName { get; set; }
    }
}
