using System.ComponentModel.DataAnnotations;

namespace WebAppClientes.Ui.Web.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Cpf { get; set; }

        [Required]
        public string Rua { get; set; }

        [Required]
        public string Bairro { get; set; }

        [Required]
        public string Cidade { get; set; }

        public string Observacoes { get; set; }
    }
}