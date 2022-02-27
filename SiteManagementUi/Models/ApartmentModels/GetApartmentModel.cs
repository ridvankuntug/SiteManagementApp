namespace SiteManagementUi.Models.ApartmentModels
{
    public class GetApartmentModel
    {
        public int ApartmentId { get; set; }
        public char ApartmentBlock { get; set; }
        public int ApartmentFloor { get; set; }
        public int ApartmentNo { get; set; }
        public string ApartmentType { get; set; }

        public int? User_Id { get; set; }

        //Ev sahibinin sistemdeki Id'si ile eşleşen ismi 
        //getirmek için yeni bir property tanımlıyoruz
        public string OwnerName { get; set; }
    }
}
