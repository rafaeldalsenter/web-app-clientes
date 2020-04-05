using System.ComponentModel.DataAnnotations;

namespace WebAppClientes.Domain
{
    public class Cliente : BaseDomain
    {
        protected Cliente()
        {
        }

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

        public void SetNome(string nome) => Nome = nome;

        public void SetCpf(string cpf) => Cpf = cpf;

        public void SetRua(string rua) => Rua = rua;

        public void SetBairro(string bairro) => Bairro = bairro;

        public void SetCidade(string cidade) => Cidade = cidade;

        public void SetObservacoes(string obs) => Observacoes = obs;

        [Required]
        [MaxLength(100)]
        public string Nome { get; private set; }

        [Required]
        [MaxLength(14)]
        public string Cpf { get; private set; }

        [MaxLength(200)]
        public string Rua { get; private set; }

        [MaxLength(100)]
        public string Bairro { get; private set; }

        [MaxLength(100)]
        public string Cidade { get; private set; }

        [MaxLength(1000)]
        public string Observacoes { get; private set; }
    }
}