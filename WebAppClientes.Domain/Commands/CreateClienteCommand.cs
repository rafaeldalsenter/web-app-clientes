using MediatR;
using WebAppClientes.Infra.CrossCutting.Dtos;

namespace WebAppClientes.Domain.Commands
{
    public class CreateClienteCommand : IRequest<CommandReturnDto>
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Rua { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Observacoes { get; private set; }

        public CreateClienteCommand(string nome, string cpf, string rua, string bairro, string cidade, string obs)
        {
            Nome = nome;
            Cpf = cpf;
            Rua = rua;
            Bairro = bairro;
            Cidade = cidade;
            Observacoes = obs;
        }
    }
}