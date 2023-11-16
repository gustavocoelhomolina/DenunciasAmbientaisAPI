using DenunciasAmbientaisAPI.Enums;

namespace DenunciasAmbientaisAPI.Models
{
    public class DenunciasModel
    {
        public int Id { get; set; }
        public string DescricaoDenuncia { get; set; }
        public string LocalDenuncia { get; set; }
        
        public TipoDenuncia Tipo { get; set; }
        public DateTime DataDenuncia { get; set; }
        public string? FotoDenuncia { get; set; }


        public DateTime DataVerificacao { get; set; }
        public bool? DenunciaVerificada { get; set; }
        public bool? DenunciaEncaminhadaParaAutoridades { get; set; }
        public string? QualAutoridadeFoiEncaminhada { get; set; }

    }
}
