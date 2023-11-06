using Domain;
using Domain_shared.Enums;
using System.Text.RegularExpressions;

namespace Domain_shared.Utils
{
    public static class ValidacaoUtil
    {
        public static void ValidarCampoNaoVazio(string valor, string nomeDoCampo)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                throw new RegrasDeNegocioException($"O campo {nomeDoCampo} não pode estar em branco.");
            }
        }

        public static void ValidarEmail(string email)
        {           
            if (!EmailEhValido(email))
            {
                throw new RegrasDeNegocioException("O Email é inválido.");
            }
        }

        public static void ValidarEscolaridade(NivelEscolaridade escolaridade)
        {
            if (!Enum.IsDefined(typeof(NivelEscolaridade), escolaridade))
            {
                throw new RegrasDeNegocioException("O valor da Escolaridade não é válido.");
            }
        }

        public static void ValidarDataNascimento(DateTime dataNascimento)
        {
            if (dataNascimento > DateTime.Today)
            {
                throw new RegrasDeNegocioException("A Data de Nascimento não pode ser maior que a data atual.");
            }
        }

        private static bool EmailEhValido(string email)
        {           
            string padraoEmail = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, padraoEmail);
        }

    }
}
