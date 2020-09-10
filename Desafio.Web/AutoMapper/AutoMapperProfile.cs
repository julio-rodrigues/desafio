using AutoMapper;
using Desafio.Domain.Entities;
using Desafio.Web.Models;

namespace Desafio.Web.AutoMapper {
    public class AutoMapperProfile : Profile{
        public AutoMapperProfile() {
            CreateMap<Client, ClientViewModel>();
            CreateMap<ClientViewModel, Client>();
        }
    }
}