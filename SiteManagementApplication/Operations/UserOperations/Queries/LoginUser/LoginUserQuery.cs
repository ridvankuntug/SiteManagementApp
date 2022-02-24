using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SiteManagementApplication.Services;
using SiteManagementInfrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.UserOperations.Queries.LoginUser
{
    public class LoginUserQuery
    {
        public LoginUserModel Model { get; set; }

        private readonly ApplicationDbContext _dataBase;
        private readonly IMapper _mapper;
        public string newUserName { get; set; }
        public string newPassword { get; set; }

        public LoginUserQuery(ApplicationDbContext dataBase, IMapper mapper)
        {
            _dataBase = dataBase;
            _mapper = mapper;
        }

        public LoginUserModel Handle()
        {
            var user = _dataBase.Users.FirstOrDefault(u => u.UserName == newUserName);

            if (user is not null)
            {
                PasswordHasher<string> pw = new PasswordHasher<string>();
                var result = pw.VerifyHashedPassword(newUserName, user.PasswordHash, newPassword);

                if (result == PasswordVerificationResult.Failed)
                {
                    throw new InvalidOperationException("Şifre yanlış.");
                }
                else
                {
                    LoginUserModel userObj = _mapper.Map<LoginUserModel>(user);
                    userObj.Token = TokenService.CreateToken(userObj);
                    return userObj;
                }

            }
            else
            {
                throw new InvalidOperationException("Kullanıcı mevcut değil.");
            }
        }

    }
}
