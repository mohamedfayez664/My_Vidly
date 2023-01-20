
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {


            Mapper.CreateMap<Customer, CustomerDto>().ReverseMap().ForMember(m=>m.Id, opt=>opt.Ignore()) ;


            Mapper.CreateMap<Movie, MovieDto>().ReverseMap().ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<Genre, GenreDto>().ReverseMap();
            
            Mapper.CreateMap<MembershipType, MembershipTypeDto>().ReverseMap();
            


        }
        
    }
}