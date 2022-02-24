using SiteManagementInfrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.MessageOperations.Commands.DeleteMessage
{
    public class DeleteMessageCommand
    {
        private readonly ApplicationDbContext _dataBase;

        public int newMessageId;

        public DeleteMessageCommand(ApplicationDbContext dataBase)
        {
            _dataBase = dataBase;
        }

        public void Handle()
        {
            var message = _dataBase.Messages
                .FirstOrDefault(a => a.MessageId == newMessageId);
            if (message is null)
            {
                throw new InvalidOperationException("Mesaj bulunamadı.");
            }
            else if (message.IsRead)
            {
                throw new InvalidOperationException("Mesaj okunmuş, silinemez.");
            }
            else
            {
                _dataBase.Messages.Remove(message);
                _dataBase.SaveChanges();
            }
        }
    }
}
