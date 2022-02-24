namespace SiteManagementApplication.Operations.UserOperations.Queries.GetUser
{
    public class GetUserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserFullName { get; set; }
        public long UserTc { get; set; }
        public string Email { get; set; }
        public string UserVehicle { get; set; }

        public string Apartment { get; set; }
    }
}
