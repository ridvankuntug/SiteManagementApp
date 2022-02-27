namespace SiteManagementUi.Entities
{
    public class Apartment
    {
        public int ApartmentId { get; set; }
        public string ApartmentBlock { get; set; }
        public int ApartmentFloor { get; set; }
        public int ApartmentNo { get; set; }
        public string ApartmentType { get; set; }

        public string OwnerName { get; set; }
    }
}
