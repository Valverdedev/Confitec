using Domain_shared.Enums;

namespace Application.Dtos.UsuarioDtos
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public NivelEscolaridade Escolaridade { get; private set; }
    }
}
