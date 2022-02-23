using AutoMapper;
using SiteManagementDomain.Entities;
using SiteManagementInfrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.UserOperations.Commands.AddUser
{
    public class AddUserCommand
    {
        public AddUserModel Model { get; set; }

        private readonly ApplicationDbContext _dataBase;
        private readonly IMapper _mapper;

        public AddUserCommand(ApplicationDbContext dataBase, IMapper mapper)
        {
            _dataBase = dataBase;
            _mapper = mapper;
        }

        public void Handle()
        {
            var user = _dataBase.Users.SingleOrDefault(x =>
                x.UserTc == Model.UserTc ||
                x.Email == Model.Email ||
                x.PhoneNumber == Model.PhoneNumber);

            if (user is not null)
            {
                throw new InvalidOperationException("Bilgiler başka kullanıcı ile çakışıyor.");
            }
            else
            {
                user = _mapper.Map<User>(Model);
                _dataBase.Users.Add(user);
                _dataBase.SaveChanges();
            }

        }

    }
}
