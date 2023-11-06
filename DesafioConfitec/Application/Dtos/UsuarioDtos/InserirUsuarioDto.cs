using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.UsuarioDtos
{
    public class InserirUsuarioDto
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Sobrenome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Escolaridade { get; set; }


    }
}
