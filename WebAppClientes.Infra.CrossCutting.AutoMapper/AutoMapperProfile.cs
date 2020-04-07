using AutoMapper;
using WebAppClientes.Domain;
using WebAppClientes.Domain.Commands;
using WebAppClientes.Infra.CrossCutting.Dtos;

namespace WebAppClientes.Infra.CrossCutting.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Cliente, ClienteDto>().ConvertUsing<ClienteDtoFromClienteDomainConverter>();
            CreateMap<ClienteDto, CreateClienteCommand>().ConvertUsing<CreateClienteCommandFromClienteDtoConverter>();
            CreateMap<ClienteDto, UpdateClienteCommand>().ConvertUsing<UpdateClienteCommandFromClienteDtoConverter>();
        }
    }
}