using AutoMapper.Configuration.Annotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteManagementDomain.Entities
{
    public class Debt
    {
        public int DebtId { get; set; }
        public float DebtBill { get; set; }
        public float DebtDue { get; set; }
        public DateTime DebtPeriod { get; set; }

        [Ignore]
        [NotMapped]
        public float DebtTotal
        {
            get { return DebtBill + DebtDue; }
        }

        public int User_Id { get; set; }
        public User User { get; set; }

    }
}
