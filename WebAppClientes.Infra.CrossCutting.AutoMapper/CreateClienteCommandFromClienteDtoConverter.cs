using AutoMapper;
using WebAppClientes.Domain.Commands;
using WebAppClientes.Infra.CrossCutting.Dtos;

namespace WebAppClientes.Infra.CrossCutting.AutoMapper
{
    public class CreateClienteCommandFromClienteDtoConverter : ITypeConverter<ClienteDto, CreateClienteCommand>
    {
        public CreateClienteCommand Convert(ClienteDto source, CreateClienteCommand destination, ResolutionContext context)
            => new CreateClienteCommand(source.Nome,
                source.Cpf,
                source.Rua,
                source.Bairro,
                source.Cidade,
                source.Observacoes);
    }
}