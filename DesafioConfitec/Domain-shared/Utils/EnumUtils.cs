using System.ComponentModel;
using System.Reflection;

namespace Domain_shared.Utils
{
    static class EnumUtils
    {
        public static string? ObterDescricao<TEnum>(this TEnum valor)
        {
            FieldInfo informacaoCampo = valor.GetType().GetField(valor.ToString());
            if (informacaoCampo == null) return null;

            var atributoDescricao = informacaoCampo.GetCustomAttribute<DescriptionAttribute>();
            return atributoDescricao != null ? atributoDescricao.Description : valor.ToString();
        }

        public static TEnum ObterValorPorDescricao<TEnum>(this string descricao)
        {
            foreach (TEnum valor in System.Enum.GetValues(typeof(TEnum)))
            {
                if (ObterDescricao(valor).Equals(descricao))
                {
                    return valor;
                }
            }

            return default(TEnum);
        }
    }
}
