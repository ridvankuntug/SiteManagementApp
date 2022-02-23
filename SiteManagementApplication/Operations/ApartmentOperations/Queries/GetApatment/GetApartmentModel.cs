

namespace SiteManagementApplication.Operations.ApartmentOperations.Queries.GetApatment
{
    public class GetApartmentModel
    {
        public char ApartmentBlock { get; set; }
        public int ApartmentFloor { get; set; }
        public int ApartmentNo { get; set; }
        public string ApartmentType { get; set; }

        //Ev sahibinin sistemdeki Id'si ile eşleşen ismi
        //mapping sayesinde getirmek için bir property tanımlıyoruz
        //public string OwnerName { get; set; }

        public int? User_Id{ get; set; }
    }
}
