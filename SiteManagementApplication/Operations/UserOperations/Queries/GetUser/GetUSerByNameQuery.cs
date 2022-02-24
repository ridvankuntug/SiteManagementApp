using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SiteManagementInfrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.UserOperations.Queries.GetUser
{
    public class GetUserByNameQuery
    {
        public GetUserModel Model { get; set; }

        private readonly ApplicationDbContext _dataBase;
        private readonly IMapper _mapper;
        public string newUserName{ get; set; }

        public GetUserByNameQuery(ApplicationDbContext dataBase, IMapper mapper)
        {
            _dataBase = dataBase;
            _mapper = mapper;
        }

        public List<GetUserModel> Handle()
        {
            var user = from e in _dataBase.Users
                       where EF.Functions.Like(e.UserFullName, "%" + newUserName + "%")
                       select e;

            if (user is not null)
            {
                List<GetUserModel> userObj = _mapper.Map<List<GetUserModel>>(user);
                return userObj;
            }
            else
            {
                throw new InvalidOperationException("Daire mevcut değil.");
            }
        }
    }
}
