using System.ComponentModel;

namespace DenunciasAmbientaisAPI.Enums
{
    public enum TipoDenuncia
    {
        [Description("Desmatamento")]
        Desmatamento = 1,

        [Description("Poluição do Ar")]
        PoluicaoAr = 2,

        [Description("Poluição da Água")]
        PoluicaoAgua = 3,

        [Description("Caça Ilegal")]
        CacaIlegal = 4,

        [Description("Tráfico de Animais")]
        TraficoAnimais = 5,

        [Description("Descarte Irregular de Resíduos")]
        DescarteIrregular = 6,

        [Description("Pesca Predatória")]
        PescaPredatoria = 7,

        [Description("Queimadas Ilegais")]
        QueimadasIlegais = 8,

        [Description("Potencial de Enchentes")]
        PotencialEnchentes = 9,

        [Description("Abuso de animais")]
        AbusoAnimais = 10,

        [Description("Outras denúncias (especifique)")]
        OutrasDenuncias = 11,
    }
}

