using System.ComponentModel;

namespace Domain_shared.Enums
{
    public enum NivelEscolaridade
    {
        [Description("Infantil")]
        Infantil = 1,

        [Description("Fundamental")]
        Fundamental = 2,

        [Description("Médio")]
        Medio = 3,

        [Description("Superior")]
        Superior = 4
    }
}
