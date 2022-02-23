using SiteManagementInfrastructure.DatabaseContext;
using System;
using System.Linq;

namespace SiteManagementApplication.Operations.UserOperations.Commands.ChangeUser
{
    public class ChangeUserCommand
    {
        public ChangeUserModel Model { get; set; }

        private readonly ApplicationDbContext _dataBase;

        public int newUserId;

        //public string newUserName;
        //public long   newUserTc;
        //public string newEmail;
        //public string newPhoneNumber;
        //public string newPasswordHash;
        //public string newUserVehicle;
        //public bool   newIsAdmin;


        public ChangeUserCommand(ApplicationDbContext dbContext)
        {
            _dataBase = dbContext;
        }

        public void Handle()
        {
            var user = _dataBase.Users
                .Where(x => x.Id == newUserId)
                .SingleOrDefault();

            if (user is not null)
            {
                user.UserName = string.IsNullOrEmpty(Model.UserName.Trim()) ? user.UserName: Model.UserName;
                user.UserTc = Model.UserTc;
                user.Email = string.IsNullOrEmpty(Model.Email.Trim()) ? user.Email : Model.Email;
                user.PhoneNumber = string.IsNullOrEmpty(Model.PhoneNumber.Trim()) ? user.PhoneNumber : Model.PhoneNumber;
                user.PasswordHash = string.IsNullOrEmpty(Model.PasswordHash.Trim()) ? user.PasswordHash : Model.PasswordHash;
                user.UserVehicle = string.IsNullOrEmpty(Model.UserVehicle.Trim()) ? user.UserVehicle : Model.UserVehicle;
                user.IsAdmin = Model.IsAdmin;

                _dataBase.SaveChanges();

            }
            else
            {
                throw new InvalidOperationException("Bu daire bulunamadı.");
            }
        }
    }
}
