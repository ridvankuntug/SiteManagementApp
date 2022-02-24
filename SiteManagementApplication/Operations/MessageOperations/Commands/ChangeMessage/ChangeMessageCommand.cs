using SiteManagementInfrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.MessageOperations.Commands.ChangeMessage
{
    public class ChangeMessageCommand
    {
        public ChangeMessageModel Model { get; set; }

        private readonly ApplicationDbContext _dataBase;

        public int newMessageId;

        public ChangeMessageCommand(ApplicationDbContext dbContext)
        {
            _dataBase = dbContext;
        }

        public void Handle()
        {
            var message = _dataBase.Messages.Where(x => x.MessageId == newMessageId).FirstOrDefault();

            if (message is null)
            {
                throw new InvalidOperationException("Bu mesaj bulunamadı.");
            }
            else if (message.IsRead)
            {
                throw new InvalidOperationException("Bu mesaj okunmuş, değiştirilemez.");
            }
            else
            {
                message.MessageText = string.IsNullOrEmpty(Model.MessageText.Trim())
                    ? message.MessageText : Model.MessageText;

                _dataBase.SaveChanges();
            }
        }
    }
}
