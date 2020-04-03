using System;

namespace WebAppClientes.Domain.Builders
{
    public class ClienteBuilder : IClienteBuilder
    {
        private string _nome;
        private string _cpf;
        private string _rua;
        private string _bairro;
        private string _cidade;
        private string _observacoes;
        private int _id;

        public Cliente Build() => new Cliente(_id, _nome, _cpf, _rua, _bairro, _cidade, _observacoes);

        public IClienteBuilder WithBairro(string bairro)
        {
            _bairro = bairro;
            return this;
        }

        public IClienteBuilder WithCidade(string cidade)
        {
            _cidade = cidade;
            return this;
        }

        public IClienteBuilder WithCpf(string cpf)
        {
            _cpf = cpf;
            return this;
        }

        public IClienteBuilder WithId(int id)
        {
            _id = id;
            return this;
        }

        public IClienteBuilder WithNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public IClienteBuilder WithObservacoes(string observacoes)
        {
            _observacoes = observacoes;
            return this;
        }

        public IClienteBuilder WithRua(string rua)
        {
            _rua = rua;
            return this;
        }
    }
}