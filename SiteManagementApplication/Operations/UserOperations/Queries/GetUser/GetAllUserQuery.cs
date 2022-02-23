using AutoMapper;
using SiteManagementInfrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.UserOperations.Queries.GetUser
{
    public class GetAllUserQuery
    {
        public GetUserModel Model { get; set; }
        private readonly ApplicationDbContext _dataBase;
        private readonly IMapper _mapper;

        public GetAllUserQuery(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dataBase = dbContext;
            _mapper = mapper;
        }

        public List<GetUserModel> Handle()
        {
            var user = _dataBase.Users.Where(u => u.Id > 0);
            if (user is not null)
            {
                List<GetUserModel> userList = _mapper.Map<List<GetUserModel>>(user);
                return userList;
            }
            else
            {
                throw new InvalidOperationException("Daire mevcut değil.");
            }

        }
    }
}
