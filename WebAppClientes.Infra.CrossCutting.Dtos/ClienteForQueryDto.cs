namespace WebAppClientes.Infra.CrossCutting.Dtos
{
    public class ClienteForQueryDto : BaseDto
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Rua { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Observacoes { get; private set; }
    }
}