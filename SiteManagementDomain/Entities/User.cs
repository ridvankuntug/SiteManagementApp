using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteManagementDomain.Entities
{
    public class User : IdentityUser<int>
    {
        public override string UserName { get; set; }
        public long UserTc { get; set; }
        public string UserVehicle { get; set; }
        public bool IsAdmin { get; set; } = false;

        public Apartment Apartment { get; set; }
        public List<Debt> Debt { get; set; }
        public List<Message> Sender_Message { get; set; }
        public List<Message> Reciver_Message { get; set; }

        #region Ignore Region
        [NotMapped]
        [Ignore]
        public string NormalizedUserName;
        [NotMapped]
        [Ignore]
        public string NormalizedEmail;
        [NotMapped]
        [Ignore]
        public string EmailConfirmed;
        [NotMapped]
        [Ignore]
        public string SecurityStamp;
        [NotMapped]
        [Ignore]
        public string ConcurrencyStamp;
        [NotMapped]
        [Ignore]
        public string PhoneNumberConfirmed;
        [NotMapped]
        [Ignore]
        public string TwoFactorEnabled;
        [NotMapped]
        [Ignore]
        public string LockoutEnd;
        [NotMapped]
        [Ignore]
        public string LockoutEnabled;
        [NotMapped]
        [Ignore]
        public string AccessFailedCount;
        #endregion
    }

}
