using AutoMapper;
using SiteManagementInfrastructure.DatabaseContext;
using System;
using System.Linq;


namespace SiteManagementApplication.Operations.ApartmentOperations.Commands.DeleteApartment
{
    public class DeleteApartmentCommand
    {
        private readonly ApplicationDbContext _dataBase;

        public string newApartmentBlock;
        public int newApartmentFloor;
        public int newApartmentNo;

        public DeleteApartmentCommand(ApplicationDbContext dataBase)
        {
            _dataBase = dataBase;
        }

        public void Handle()
        {
            var apartment = _dataBase.Apartments
                .FirstOrDefault(a => a.ApartmentBlock == newApartmentBlock && a.ApartmentFloor == newApartmentFloor && a.ApartmentNo == newApartmentNo);
            if(apartment is not null)
            {
                _dataBase.Apartments.Remove(apartment);
                _dataBase.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Daire bulunamadı.");
            }
        }
    }
}
