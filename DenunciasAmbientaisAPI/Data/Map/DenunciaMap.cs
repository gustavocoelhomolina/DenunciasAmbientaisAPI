using DenunciasAmbientaisAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DenunciasAmbientaisAPI.Data.Map
{
    public class DenunciaMap : IEntityTypeConfiguration<DenunciasModel>
    {
        public void Configure(EntityTypeBuilder<DenunciasModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DescricaoDenuncia).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.LocalDenuncia).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Tipo).IsRequired();
            builder.Property(x => x.DataDenuncia).IsRequired();
            builder.Property(x => x.FotoDenuncia);
            builder.Property(x => x.DataVerificacao);
            builder.Property(x => x.DenunciaVerificada);
            builder.Property(x => x.DenunciaEncaminhadaParaAutoridades);
            builder.Property(x => x.QualAutoridadeFoiEncaminhada);
        }
    }
}
