using Domain_shared.Enums;
using Domain_shared.Utils;

namespace Domain.Entidades
{
    public class Usuario : EntidadeBase
    {   

        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public NivelEscolaridade Escolaridade { get; private set; }

        public Usuario(string nome, string sobrenome, string email, DateTime dataNascimento, NivelEscolaridade escolaridade)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = dataNascimento;
            Escolaridade = escolaridade;

            Validar();
        }

        private void Validar()
        {
            ValidacaoUtil.ValidarCampoNaoVazio(Nome, nameof(Nome));
            ValidacaoUtil.ValidarCampoNaoVazio(Sobrenome, nameof(Sobrenome));
            ValidacaoUtil.ValidarCampoNaoVazio(Email, nameof(Email));
            ValidacaoUtil.ValidarCampoNaoVazio(DataNascimento.ToString(), nameof(DataNascimento));
            ValidacaoUtil.ValidarCampoNaoVazio(Escolaridade.ToString(), nameof(Escolaridade));
            ValidacaoUtil.ValidarEmail(Email);
            ValidacaoUtil.ValidarEscolaridade(Escolaridade);
            ValidacaoUtil.ValidarDataNascimento(DataNascimento);
        }
    }
}
