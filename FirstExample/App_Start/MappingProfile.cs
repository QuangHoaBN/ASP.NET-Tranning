using AutoMapper;
using FirstExample.Dtos;
using FirstExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstExample.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>();
        }
    }
}