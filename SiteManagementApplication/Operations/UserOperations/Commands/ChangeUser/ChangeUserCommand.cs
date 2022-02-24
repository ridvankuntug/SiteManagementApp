using Microsoft.AspNetCore.Identity;
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

        public ChangeUserCommand(ApplicationDbContext dbContext)
        {
            _dataBase = dbContext;
        }

        public void Handle()
        {

            var user = _dataBase.Users
                .Where(x => x.Id == newUserId)
                .FirstOrDefault();

            if (user is not null)
            {
                Model.PasswordHash =
                    string.IsNullOrEmpty(Model.PasswordHash.Trim())
                    ? user.PasswordHash : Model.PasswordHash.Trim();

                PasswordHasher<string> pw = new PasswordHasher<string>();
                user.PasswordHash = pw.HashPassword(Model.UserName, Model.PasswordHash);

                user.UserName = string.IsNullOrEmpty(Model.UserName.Trim()) ? user.UserName : Model.UserName.Trim();
                user.UserFullName = string.IsNullOrEmpty(Model.UserFullName.Trim()) ? user.UserFullName : Model.UserFullName.Trim();
                user.UserTc = Model.UserTc;
                user.Email = string.IsNullOrEmpty(Model.Email.Trim()) ? user.Email : Model.Email.Trim();
                user.PhoneNumber = string.IsNullOrEmpty(Model.PhoneNumber.Trim()) ? user.PhoneNumber : Model.PhoneNumber.Trim();
                user.UserVehicle = string.IsNullOrEmpty(Model.UserVehicle.Trim()) ? user.UserVehicle : Model.UserVehicle.Trim();
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
