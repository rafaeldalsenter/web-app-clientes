using AutoMapper;
using WebAppClientes.Domain.Commands;
using WebAppClientes.Infra.CrossCutting.Dtos;

namespace WebAppClientes.Infra.CrossCutting.AutoMapper
{
    public class UpdateClienteCommandFromClienteDtoConverter : ITypeConverter<ClienteDto, UpdateClienteCommand>
    {
        public UpdateClienteCommand Convert(ClienteDto source, UpdateClienteCommand destination, ResolutionContext context)
            => new UpdateClienteCommand(source.Id,
                source.Nome,
                source.Cpf,
                source.Rua,
                source.Bairro,
                source.Cidade,
                source.Observacoes);
    }
}