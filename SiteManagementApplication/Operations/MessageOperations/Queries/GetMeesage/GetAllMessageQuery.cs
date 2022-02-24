using AutoMapper;
using SiteManagementApplication.Operations.ApartmentOperations.Queries.GetApatment;
using SiteManagementApplication.Operations.UserOperations.Queries.GetUser;
using SiteManagementInfrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.MessageOperations.Queries.GetMeesage
{
    public class GetAllMessageQuery
    {
        public GetMessageModel Model { get; set; }

        private readonly ApplicationDbContext _dataBase;
        private readonly IMapper _mapper;

        public GetAllMessageQuery(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dataBase = dbContext;
            _mapper = mapper;
        }

        public List<GetMessageModel> Handle()
        {
            var message = _dataBase.Messages.Where(a => a.MessageId > 0);

            if (message is not null)
            {
                GetAllUserQuery query = new GetAllUserQuery(_dataBase, _mapper);
                var userObj = query.Handle();


                List<GetMessageModel> messageList = _mapper.Map<List<GetMessageModel>>(message);
                foreach (GetMessageModel msj in messageList)
                {
                    //Sender_Id ile eşleşen kişinin adını SenderName e yazıyoruz
                    messageList.Where(a => a.Sender_Id == msj.Sender_Id).FirstOrDefault().SenderName
                        =
                        userObj.Where(a => a.Id == msj.Sender_Id).FirstOrDefault().UserFullName;

                    //Reciver_Id ile eşleşen kişinin adını ReciverName e yazıyoruz
                    messageList.Where(a => a.Reciver_Id == msj.Reciver_Id).FirstOrDefault().ReciverName
                        =
                        userObj.Where(a => a.Id == msj.Reciver_Id).FirstOrDefault().UserFullName;

                }
                return messageList;
            }
            else
            {
                throw new InvalidOperationException("Daire yok.");
            }
        }
    }
}
