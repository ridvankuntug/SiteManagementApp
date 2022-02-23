using AutoMapper;
using SiteManagementInfrastructure.DatabaseContext;
using System;
using System.Linq;
using SiteManagementDomain.Entities;

namespace SiteManagementApplication.Operations.ApartmentOperations.Commands.AddApartment
{
    public class AddApartmentCommand
    {
        public AddApartmentModel Model { get; set; }

        private readonly ApplicationDbContext _dataBase;
        private readonly IMapper _mapper;

        public AddApartmentCommand(ApplicationDbContext dataBase, IMapper mapper)
        {
            _dataBase = dataBase;
            _mapper = mapper;
        }

        public void Handle()
        {
            var apartment = _dataBase.Apartments.SingleOrDefault(x =>
                x.ApartmentBlock == Model.ApartmentBlock &&
                x.ApartmentFloor == Model.ApartmentFloor &&
                x.ApartmentNo == Model.ApartmentNo);

            if (apartment is not null)
            {
                throw new InvalidOperationException("Daire zaten mevcut.");
            }
            else
            {
                apartment = _mapper.Map<Apartment>(Model);
                _dataBase.Apartments.Add(apartment);
                _dataBase.SaveChanges();
            }

        }

    }
}
