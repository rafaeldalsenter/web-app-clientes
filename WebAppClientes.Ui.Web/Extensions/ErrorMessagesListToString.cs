using System.Collections.Generic;
using System.Linq;

namespace WebAppClientes.Ui.Web.Extensions
{
    public static class ErrorMessagesListToString
    {
        public static string ToErrorMessage(this IList<string> value)
        {
            if (value is null || !value.Any()) return string.Empty;

            var prefixo = value.Count().Equals(1) ? "Erro:" : "Erros:";

            return $"{prefixo} {string.Join(',', value)}.";
        }
    }
}