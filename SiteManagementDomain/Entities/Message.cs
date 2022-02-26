using System;

namespace SiteManagementDomain.Entities
{
    public class Message
    {
        public int MessageId { get; set; }
        public string MessageText { get; set; }
        public bool IsRead { get; set; } = false;
        public DateTime MessageSendTime { get; set; } = DateTime.UtcNow;
        public DateTime MessageEditTime { get; set; } = DateTime.UtcNow;


        public int Sender_Id { get; set; }
        public User Sender_User { get; set; }

        public int Reciver_Id { get; set; }
        public User Reciver_User { get; set; }
    }
}
