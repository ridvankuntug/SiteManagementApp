using AutoMapper;
using SiteManagementInfrastructure.DatabaseContext;
using System;
using System.Linq;

namespace SiteManagementApplication.Operations.ApartmentOperations.Commands.ChangeApartment
{
    public class ChangeApartmentCommand
    {
        public ChangeApartmentModel Model { get; set; }

        private readonly ApplicationDbContext _dataBase;

        public string newApartmentBlock;
        public int newApartmentFloor;
        public int newApartmentNo;

        public ChangeApartmentCommand(ApplicationDbContext dbContext)
        {
            _dataBase = dbContext;
        }

        public void Handle()
        {
            var apartment = _dataBase.Apartments
                .Where(x => x.ApartmentBlock == newApartmentBlock && x.ApartmentFloor == newApartmentFloor && x.ApartmentNo == newApartmentNo)
                .FirstOrDefault();

            if (apartment is not null)
            {
                apartment.ApartmentType = string.IsNullOrEmpty(Model.ApartmentType.Trim()) ? apartment.ApartmentType : Model.ApartmentType;
                
                apartment.User_Id = Model.User_Id;
                _dataBase.SaveChanges();

            }
            else
            {
                throw new InvalidOperationException("Bu daire bulunamadı.");
            }
        }
    }
}
