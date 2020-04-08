using System.Collections.Generic;
using System.Linq;

namespace WebAppClientes.Infra.CrossCutting.Dtos
{
    public class CommandReturnDto
    {
        public IList<string> ErrorMessages { get; set; }

        public void AddError(string message)
        {
            ErrorMessages ??= new List<string>();
            ErrorMessages.Add(message);
        }

        public bool IsValid() => !ErrorMessages?.Any() ?? true;
    }
}