using AutoMapper;
using SiteManagementApplication.Operations.ApartmentOperations.Commands.AddApartment;
using SiteManagementApplication.Operations.ApartmentOperations.Commands.ChangeApartment;
using SiteManagementApplication.Operations.ApartmentOperations.Queries.GetApatment;
using SiteManagementApplication.Operations.DebtOperations.Commands.AddDebt;
using SiteManagementApplication.Operations.DebtOperations.Queries.GetDebt;
using SiteManagementApplication.Operations.MessageOperations.Commands.AddMessage;
using SiteManagementApplication.Operations.MessageOperations.Queries.GetMeesage;
using SiteManagementApplication.Operations.UserOperations.Commands.AddUser;
using SiteManagementApplication.Operations.UserOperations.Queries.GetUser;
using SiteManagementApplication.Operations.UserOperations.Queries.LoginUser;
using SiteManagementDomain.Entities;

namespace SiteManagementApplication.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Apartments haritalamaları
            CreateMap<AddApartmentModel, Apartment>();
            CreateMap<Apartment, GetApartmentModel>();

            //Users haritalamaları
            CreateMap<AddUserModel, User>();
            CreateMap<User, GetUserModel>();

            //login haritalaması
            CreateMap<User, LoginUserModel>();

            //Debt haritalamaları
            CreateMap<AddDebtModel, Debt>();
            CreateMap<Debt, GetDebtModel>()
                .ForMember(dest => dest.UserName, opt => opt
                    .MapFrom(src => src.User.UserFullName));

            //Message haritalamaları
            CreateMap<AddMessageModel, Message>();
            CreateMap<Message, GetMessageModel>()
                .ForMember(dest => dest.SenderName, opt => opt
                    .MapFrom(src => src.Sender_User.UserFullName))
                .ForMember(dest => dest.ReciverName, opt => opt
                    .MapFrom(src => src.Reciver_User.UserFullName));

        }
    }
}
