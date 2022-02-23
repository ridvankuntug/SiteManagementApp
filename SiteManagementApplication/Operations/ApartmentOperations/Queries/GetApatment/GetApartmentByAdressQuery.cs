using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SiteManagementInfrastructure.DatabaseContext;
using System;
using System.Linq;

namespace SiteManagementApplication.Operations.ApartmentOperations.Queries.GetApatment
{
    public class GetApartmentByAdressQuery
    {
        public GetApartmentModel Model { get; set; }

        private readonly ApplicationDbContext _dataBase;
        private readonly IMapper _mapper;
        public string newApartmentBlock { get; set; }
        public int newApartmentFloor { get; set; }
        public int newApartmentNo { get; set; }


        public GetApartmentByAdressQuery(ApplicationDbContext dataBase, IMapper mapper)
        {
            _dataBase = dataBase;
            _mapper = mapper;
        }

        public GetApartmentModel Handle()
        {
            var apartment = _dataBase.Apartments/*.Include(g => g.User)*/
                .Where(x => x.ApartmentBlock == newApartmentBlock && x.ApartmentFloor == newApartmentFloor && x.ApartmentNo == newApartmentNo)
                .SingleOrDefault();

            if (apartment is null)
            {
                throw new InvalidOperationException("Daire mevcut değil.");
            }
            else
            {
                GetApartmentModel getApartmentModel = _mapper.Map<GetApartmentModel>(apartment);
                return getApartmentModel;
            }
        }
    }
}
