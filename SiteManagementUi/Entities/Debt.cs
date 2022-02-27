namespace SiteManagementUi.Entities
{
    public class Debt
    {
        public int DebtId { get; set; }
        public float DebtBill { get; set; }
        public float DebtDue { get; set; }
        public int DebtYear { get; set; }
        public int DebtMonth { get; set; }
        public bool IsPaid { get; set; } = false;

        public int User_Id { get; set; }
    }
}
