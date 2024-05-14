using AutoMapper;
using MyProject.Repositories.Entities;
using MyProject.Resources.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Services
{
    public class Mapping:Profile
    {
        public Mapping()
        {            
            //CreateMap<Claim, ClaimDTO>()
            //    .ForMember(dest=>dest.Policy,opt=>opt.MapFrom(src=>src.Policy))
            //    .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
            //    .ForMember(dest => dest.Permission, opt => opt.MapFrom(src => src.Permission))
            //    .ReverseMap();
            //CreateMap<Role, RoleDTO>().ReverseMap();
            //CreateMap<Permission, PermissionDTO>().ReverseMap();

            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Child, ChildDTO>()
                .ForMember(dest=>dest.Parent2,opt=>opt.MapFrom(src=>src.Parent2))
                .ForMember(dest => dest.Parent1, opt => opt.MapFrom(src => src.Parent1))
                .ReverseMap();
        }
    }
}
