using DenunciasAmbientaisAPI.Data.Map;
using DenunciasAmbientaisAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace DenunciasAmbientaisAPI.Data
{
    public class SistemaDenunciasDBContext : DbContext
    {
        public SistemaDenunciasDBContext(DbContextOptions<SistemaDenunciasDBContext> options)
            :base(options)
        {
            
        }

        public DbSet<DenunciasModel> Denuncias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DenunciaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
