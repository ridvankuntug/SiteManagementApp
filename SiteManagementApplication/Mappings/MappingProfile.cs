using AutoMapper;
using SiteManagementApplication.Operations.ApartmentOperations.Commands.AddApartment;
using SiteManagementApplication.Operations.ApartmentOperations.Commands.ChangeApartment;
using SiteManagementApplication.Operations.ApartmentOperations.Queries.GetApatment;
using SiteManagementApplication.Operations.DebtOperations.Commands.AddDebt;
using SiteManagementApplication.Operations.DebtOperations.Queries.GetDebt;
using SiteManagementApplication.Operations.UserOperations.Commands.AddUser;
using SiteManagementApplication.Operations.UserOperations.Queries.GetUser;
using SiteManagementDomain.Entities;

namespace SiteManagementApplication.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Apartments haritalamaları
            CreateMap<AddApartmentModel, Apartment>();

            CreateMap<Apartment, GetApartmentModel>()
                /*.ForMember(dest => dest.OwnerName, 
                opt => opt.MapFrom(src => src.User.Id > 1 ? "Ev Boş" : src.User.UserName))*/;

            //Users haritalamaları
            CreateMap<AddUserModel, User>();
            CreateMap<User, GetUserModel>();

            //Debt haritalamaları
            CreateMap<AddDebtModel, Debt>();
            CreateMap<Debt, GetDebtModel>();

        }
    }
}
