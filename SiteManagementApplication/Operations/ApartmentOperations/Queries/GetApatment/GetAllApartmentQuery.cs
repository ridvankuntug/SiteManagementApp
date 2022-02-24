using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SiteManagementApplication.Operations.UserOperations.Queries.GetUser;
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
            
            if (apartment is not null)
            {
                GetAllUserQuery query = new GetAllUserQuery(_dataBase, _mapper);
                var userObj = query.Handle();


                List<GetApartmentModel> apartmentList = _mapper.Map<List<GetApartmentModel>>(apartment);
                foreach(GetApartmentModel ap in apartmentList)
                {
                    if (ap.User_Id is not null)
                    {
                        apartmentList.Where(a => a.ApartmentBlock == ap.ApartmentBlock
                            && a.ApartmentFloor == ap.ApartmentFloor
                            && a.ApartmentNo == ap.ApartmentNo).FirstOrDefault().OwnerName
                        =
                        userObj.Where(a => a.Id == ap.User_Id).FirstOrDefault().UserFullName;
                    }
                    else
                    {
                        apartmentList.Where(a => a.ApartmentBlock == ap.ApartmentBlock
                        && a.ApartmentFloor == ap.ApartmentFloor
                        && a.ApartmentNo == ap.ApartmentNo).FirstOrDefault().OwnerName
                        = "Daire Boş";
                    }
                }
                return apartmentList;
            }
            else
            {
                throw new InvalidOperationException("Daire yok.");
            }
        }

    }
}
