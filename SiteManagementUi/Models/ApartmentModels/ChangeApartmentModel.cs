namespace SiteManagementUi.Models.ApartmentModels
{
    public class ChangeApartmentModel
    {
        public int ApartmentId { get; set; }
        public string ApartmentBlock { get; set; }
        public int ApartmentFloor { get; set; }
        public int ApartmentNo { get; set; }
        public string ApartmentType { get; set; }
        public int? User_Id { get; set; }
    }
}
