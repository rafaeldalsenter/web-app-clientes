namespace WebAppClientes.Domain
{
    public class Cliente : BaseDomain
    {
        public Cliente(int id, string nome, string cpf, string rua, string bairro, string cidade, string obs)
        {
            SetId(id);
            SetNome(nome);
            SetCpf(cpf);
            SetRua(rua);
            SetBairro(bairro);
            SetCidade(cidade);
            SetObservacoes(obs);
        }

        public void SetId(int id) => Id = id;

        public void SetNome(string nome) => Nome = nome;

        public void SetCpf(string cpf) => Cpf = cpf;

        public void SetRua(string rua) => Rua = rua;

        public void SetBairro(string bairro) => Bairro = bairro;

        public void SetCidade(string cidade) => Cidade = cidade;

        public void SetObservacoes(string obs) => Observacoes = obs;

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Rua { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Observacoes { get; private set; }
    }
}