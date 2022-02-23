namespace SiteManagementApplication.Operations.UserOperations.Commands.ChangeUser
{
    public class ChangeUserModel
    {
        public string UserName { get; set; }
        public long UserTc { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public string UserVehicle { get; set; }
        public bool IsAdmin { get; set; } = false;
    }
}
