using AutoMapper;
using WebAppClientes.Domain;
using WebAppClientes.Infra.CrossCutting.Dtos;

namespace WebAppClientes.Infra.CrossCutting.AutoMapper
{
    public class ClienteDtoFromClienteDomainConverter : ITypeConverter<Cliente, ClienteForQueryDto>
    {
        public ClienteForQueryDto Convert(Cliente source, ClienteForQueryDto destination, ResolutionContext context)
            => new ClienteForQueryDto
            {
                Id = source.Id,
                Bairro = source.Bairro,
                Cidade = source.Cidade,
                Cpf = source.Cpf,
                Nome = source.Nome,
                Observacoes = source.Observacoes,
                Rua = source.Rua
            };
    }
}