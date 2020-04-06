using MediatR;

namespace WebAppClientes.Domain.Commands
{
    public class UpdateClienteCommand : IRequest<bool>
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Rua { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Observacoes { get; private set; }

        public UpdateClienteCommand(int id, string nome, string cpf, string rua, string bairro, string cidade, string obs)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Rua = rua;
            Bairro = bairro;
            Cidade = cidade;
            Observacoes = obs;
        }
    }
}