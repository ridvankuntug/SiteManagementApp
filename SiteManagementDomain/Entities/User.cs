using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteManagementDomain.Entities
{
    public class User : IdentityUser<int>
    {
        public string UserFullName { get; set; }
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
        private new string NormalizedUserName;
        [NotMapped]
        [Ignore]
        private new string NormalizedEmail;
        [NotMapped]
        [Ignore]
        private new string EmailConfirmed;
        [NotMapped]
        [Ignore]
        private new string SecurityStamp;
        [NotMapped]
        [Ignore]
        private new string ConcurrencyStamp;
        [NotMapped]
        [Ignore]
        private new string PhoneNumberConfirmed;
        [NotMapped]
        [Ignore]
        private new string TwoFactorEnabled;
        [NotMapped]
        [Ignore]
        private new string LockoutEnd;
        [NotMapped]
        [Ignore]
        private new string LockoutEnabled;
        [NotMapped]
        [Ignore]
        private new string AccessFailedCount;
        #endregion
    }

}
