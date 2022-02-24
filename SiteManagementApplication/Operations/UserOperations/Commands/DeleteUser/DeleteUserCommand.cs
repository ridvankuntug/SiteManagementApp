using SiteManagementInfrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.UserOperations.Commands.DeleteUser
{
    public class DeleteUserCommand
    {
        private readonly ApplicationDbContext _dataBase;
                
        public int newUserId;

        public DeleteUserCommand(ApplicationDbContext dataBase)
        {
            _dataBase = dataBase;
        }

        public void Handle()
        {
            var user = _dataBase.Users
                .FirstOrDefault(a =>a.Id == newUserId);
            if (user is not null)
            {
                _dataBase.Users.Remove(user);
                _dataBase.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Kullanıcı bulunamadı.");
            }
        }
    }
}
