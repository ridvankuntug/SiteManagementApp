using AutoMapper;
using SiteManagementDomain.Entities;
using SiteManagementInfrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.MessageOperations.Commands.AddMessage
{
    public class AddMessageCommand
    {
        public AddMessageModel Model { get; set; }

        private readonly ApplicationDbContext _dataBase;
        private readonly IMapper _mapper;

        public AddMessageCommand(ApplicationDbContext dataBase, IMapper mapper)
        {
            _dataBase = dataBase;
            _mapper = mapper;
        }

        public void Handle()
        {
            var message = _dataBase.Messages.FirstOrDefault();

            try
            {
                message = _mapper.Map<Message>(Model);
                message.MessageEditTime = message.MessageSendTime = DateTime.UtcNow;
                message.IsRead = false;

                _dataBase.Messages.Add(message);
                _dataBase.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }

        }
    }
}
