using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SiteManagementInfrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiteManagementApplication.Operations.ApartmentOperations.Queries.GetApatment
{
    public class GetAllApartmentQuery
    {
        public GetApartmentModel Model { get; set; }

        private readonly ApplicationDbContext _dataBase;
        private readonly IMapper _mapper;

        public GetAllApartmentQuery(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dataBase = dbContext;
            _mapper = mapper;
        }

        public List<GetApartmentModel> Handle()
        {
            var apartment = _dataBase.Apartments/*.Include(a => a.User)*/.Where(a => a.ApartmentId > 0);
            if(apartment is not null)
            {
            List<GetApartmentModel> apartmentList = _mapper.Map<List<GetApartmentModel>>(apartment);
            return apartmentList;
            }
            else
            {
                throw new InvalidOperationException("Daire yok.");
            }
        }

    }
}
