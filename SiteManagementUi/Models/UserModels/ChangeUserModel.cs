namespace SiteManagementUi.Models.UserModels
{
    public class ChangeUserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserFullName { get; set; }
        public long UserTc { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserVehicle { get; set; }
        public string PasswordHash { get; set; }
        public bool IsAdmin { get; set; } = false;
    }
}
