namespace WebAppClientes.Infra.CrossCutting.Dtos
{
    public class ClienteDto : BaseDto
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Observacoes { get; set; }
    }
}