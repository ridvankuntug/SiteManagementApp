using AutoMapper;
using FluentValidation;
using SiteManagementApplication.Operations.UserOperations.Queries.GetUser;
using SiteManagementInfrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.MessageOperations.Queries.GetMeesage
{
    public class GetMessageByIdQuery
    {
        public GetMessageModel Model { get; set; }

        private readonly ApplicationDbContext _dataBase;
        private readonly IMapper _mapper;
        public int newMessageId { get; set; }

        public GetMessageByIdQuery(ApplicationDbContext dataBase, IMapper mapper)
        {
            _dataBase = dataBase;
            _mapper = mapper;
        }

        public GetMessageModel Handle()
        {
            var message = _dataBase.Messages.Where(x => x.MessageId == newMessageId).FirstOrDefault();

            if (message is not null)
            {
                GetMessageModel messageObj = _mapper.Map<GetMessageModel>(message);

                //Mesaj göndericisini ve alıcısını diğer tablodan çekiyoruz
                GetUserByIdQuery query = new GetUserByIdQuery(_dataBase, _mapper);
                GetUserByIdValidator validator = new GetUserByIdValidator();
                query.newUserId = message.Sender_Id;
                validator.ValidateAndThrow(query);
                messageObj.SenderName = query.Handle().UserFullName;

                query.newUserId = message.Reciver_Id;
                validator.ValidateAndThrow(query);
                messageObj.ReciverName = query.Handle().UserFullName;

                return messageObj;
            }

            else
            {
                throw new InvalidOperationException("Mesaj mevcut değil.");
            }
        }
    }
}
