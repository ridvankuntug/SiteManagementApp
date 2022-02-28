using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SiteManagementDomain.Entities;
using SiteManagementInfrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.UserOperations.Commands.AddUser
{
    public class SeedAdminCommand
    {
        private readonly ApplicationDbContext _dataBase;
        private readonly IMapper _mapper;

        public SeedAdminCommand(ApplicationDbContext dataBase, IMapper mapper)
        {
            _dataBase = dataBase;
            _mapper = mapper;

        }

        public void Handle()
        {
            AddUserModel Model = new AddUserModel();

            Model.IsAdmin = true;
            Model.UserName = "Admin";
            Model.UserFullName = "Admin Admin";
            Model.Email = "admin@admin.com";
            Model.UserTc = 12345678901;
            Model.PhoneNumber = "1234567890";
            Model.UserVehicle = "yok";
            Model.PasswordHash = "123456";

            var user = _dataBase.Users.FirstOrDefault(x =>
                x.UserName == Model.UserName ||
                x.UserTc == Model.UserTc ||
                x.Email == Model.Email ||
                x.PhoneNumber == Model.PhoneNumber);
            if (user is null)
            {
                PasswordHasher<string> pw = new PasswordHasher<string>();
                Model.PasswordHash = pw.HashPassword(Model.UserName, Model.PasswordHash);

                user = _mapper.Map<User>(Model);
                _dataBase.Users.Add(user);
                _dataBase.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Bilgiler başka kullanıcı ile çakışıyor.");
            }
        }
    }
}
