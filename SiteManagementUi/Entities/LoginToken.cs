namespace SiteManagementUi.Entities
{
    public class LoginToken
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string UserFullName { get; set; }
        public bool IsAdmin { get; set; }
        public string Token { get; set; }
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
