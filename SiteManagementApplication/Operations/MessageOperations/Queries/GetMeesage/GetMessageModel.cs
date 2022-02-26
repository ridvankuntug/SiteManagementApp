using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.MessageOperations.Queries.GetMeesage
{
    public class GetMessageModel
    {
        public string MessageText { get; set; }
        public bool IsRead { get; set; } = false;
        public DateTime MessageSendTime { get; set; } = DateTime.UtcNow;
        public DateTime MessageEditTime { get; set; } = DateTime.UtcNow;


        public int Sender_Id { get; set; }
        public string SenderName { get; set; }

        public int Reciver_Id { get; set; }
        public string ReciverName { get; set; }
    }
}
