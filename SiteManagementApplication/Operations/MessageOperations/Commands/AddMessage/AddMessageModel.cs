using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.MessageOperations.Commands.AddMessage
{
    public class AddMessageModel
    {
        public string MessageText { get; set; }

        public int Sender_Id { get; set; }

        public int Reciver_Id { get; set; }
    }
}
