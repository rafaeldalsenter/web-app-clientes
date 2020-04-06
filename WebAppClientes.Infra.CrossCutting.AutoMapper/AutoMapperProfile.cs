using AutoMapper;
using WebAppClientes.Domain;
using WebAppClientes.Infra.CrossCutting.Dtos;

namespace WebAppClientes.Infra.CrossCutting.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Cliente, ClienteForQueryDto>().ConvertUsing<ClienteDtoFromClienteDomainConverter>();
        }
    }
}