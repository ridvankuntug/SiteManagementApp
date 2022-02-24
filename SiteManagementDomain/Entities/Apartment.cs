using System.ComponentModel.DataAnnotations.Schema;

namespace SiteManagementDomain.Entities
{
    public class Apartment
    {
        public int ApartmentId { get; set; }
        public string ApartmentBlock { get; set; }
        public int ApartmentFloor { get; set; }
        public int ApartmentNo { get; set; }
        public string ApartmentType { get; set; }

        public string OwnerName { get; set; }

        public int? User_Id { get; set; }
        public User User { get; set; }


    }
}
