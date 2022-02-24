using SiteManagementInfrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.MessageOperations.Commands.ChangeMessage
{
    public class ReadMessageCommand
    {

        private readonly ApplicationDbContext _dataBase;

        public int newMessageId;

        public ReadMessageCommand(ApplicationDbContext dbContext)
        {
            _dataBase = dbContext;
        }

        public void Handle()
        {
            var message = _dataBase.Messages.Where(x => x.MessageId == newMessageId).FirstOrDefault();

            if (message is not null && message.IsRead is false)
            {
                message.IsRead = true;

                _dataBase.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Bu mesaj bulunamadı.");
            }
        }
    }
}