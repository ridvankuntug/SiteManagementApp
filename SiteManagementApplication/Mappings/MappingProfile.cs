﻿using AutoMapper;
using SiteManagementApplication.Operations.ApartmentOperations.Commands.AddApartment;
using SiteManagementApplication.Operations.ApartmentOperations.Commands.ChangeApartment;
using SiteManagementApplication.Operations.ApartmentOperations.Queries.GetApatment;
using SiteManagementDomain.Entities;

namespace SiteManagementApplication.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddApartmentModel, Apartment>();

            CreateMap<Apartment, GetApartmentModel>()
                /*.ForMember(dest => dest.OwnerName, 
                opt => opt.MapFrom(src => src.User.Id > 1 ? "Ev Boş" : src.User.UserName))*/;

        }
    }
}
