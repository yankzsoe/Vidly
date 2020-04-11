using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start {
    public class MappingProfile : Profile {
        public MappingProfile() {
            //Map Domain Model to Dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();

            //Map Dto to Domain Model
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(f => f.Id, opt => opt.Ignore());
            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(f => f.Id, opt => opt.Ignore());
        }
    }
}