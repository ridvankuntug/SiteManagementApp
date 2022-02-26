namespace SiteManagementUi.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }
        public string Role
        {
            get
            {
                if (IsAdmin) { return "Admin"; }
                else { return "User"; }
            }
        }
    }
}
