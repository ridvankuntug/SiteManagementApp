using AutoMapper;
using SiteManagementInfrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.UserOperations.Queries.GetUser
{
    public class GetUserByIdQuery
    {
        public GetUserModel Model { get; set; }

        private readonly ApplicationDbContext _dataBase;
        private readonly IMapper _mapper;
        public int newUserId { get; set; }

        public GetUserByIdQuery(ApplicationDbContext dataBase, IMapper mapper)
        {
            _dataBase = dataBase;
            _mapper = mapper;
        }

        public GetUserModel Handle()
        {
            var user = _dataBase.Users.FirstOrDefault(u => u.Id == newUserId);

            if(user is not null)
            {
                GetUserModel userObj = _mapper.Map<GetUserModel>(user);
                return userObj;
            }
            else
            {
                throw new InvalidOperationException("Kullanıcı mevcut değil.");
            }
        }
    }
}
