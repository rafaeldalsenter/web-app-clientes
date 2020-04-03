namespace WebAppClientes.Domain.Builders
{
    public interface IClienteBuilder
    {
        Cliente Build();

        IClienteBuilder WithId(int id);

        IClienteBuilder WithNome(string nome);

        IClienteBuilder WithCpf(string cpf);

        IClienteBuilder WithRua(string rua);

        IClienteBuilder WithBairro(string bairro);

        IClienteBuilder WithCidade(string cidade);

        IClienteBuilder WithObservacoes(string observacoes);
    }
}