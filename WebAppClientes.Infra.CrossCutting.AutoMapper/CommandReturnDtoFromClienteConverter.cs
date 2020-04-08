using AutoMapper;
using WebAppClientes.Domain;
using WebAppClientes.Infra.CrossCutting.Dtos;

namespace WebAppClientes.Infra.CrossCutting.AutoMapper
{
    public class CommandReturnDtoFromClienteConverter : ITypeConverter<Cliente, CommandReturnDto>
    {
        public CommandReturnDto Convert(Cliente source, CommandReturnDto destination, ResolutionContext context)
            => new CommandReturnDto
            {
                ErrorMessages = source.ErrorMessages
            };
    }
}