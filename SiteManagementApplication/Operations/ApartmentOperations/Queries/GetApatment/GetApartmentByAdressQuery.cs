using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SiteManagementApplication.Operations.UserOperations.Queries.GetUser;
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
                if (apartment.User_Id is not null)
                {
                    GetUserByIdQuery query = new GetUserByIdQuery(_dataBase, _mapper);
                    query.newUserId = (int)apartment.User_Id;
                    GetUserByIdValidator validator = new GetUserByIdValidator();
                    validator.ValidateAndThrow(query);


                    apartment.OwnerName
                        =
                    query.Handle().UserName;
                }
                else
                {
                    apartment.OwnerName = "Daire Boş";
                }

                GetApartmentModel getApartmentModel = _mapper.Map<GetApartmentModel>(apartment);
                return getApartmentModel;
            }
        }
    }
}
