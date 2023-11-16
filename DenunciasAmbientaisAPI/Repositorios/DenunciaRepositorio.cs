using DenunciasAmbientaisAPI.Data;
using DenunciasAmbientaisAPI.Models;
using DenunciasAmbientaisAPI.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DenunciasAmbientaisAPI.Repositorios
{
    public class DenunciaRepositorio : IDenunciasRepositorio
    {
        private readonly SistemaDenunciasDBContext _dbContext;
        public DenunciaRepositorio(SistemaDenunciasDBContext sistemaDenunciasDBContext)
        {
            _dbContext = sistemaDenunciasDBContext;
        }


        public async Task<DenunciasModel> BuscarDenunciaPorId(int id)
        {
            return await _dbContext.Denuncias.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<DenunciasModel>> BuscarTodasDenuncias()
        {
            return await _dbContext.Denuncias.ToListAsync();
        }

        public async Task<DenunciasModel> AdicionarDenuncia(DenunciasModel denuncia)
        {          
            _dbContext.Denuncias.Add(denuncia);
            await _dbContext.SaveChangesAsync();

            return denuncia;
        }

        public async Task<DenunciasModel> AtualizarDenuncia(DenunciasModel denuncia, int id)
        {
            DenunciasModel denunciaPorId = await BuscarDenunciaPorId(id);

            if (denunciaPorId == null)
            {
                throw new Exception($"Denúncia com o ID: {id} não foi encontrada!");
            }
            denunciaPorId.Id = id;
            denunciaPorId.DataVerificacao = DateTime.Now;
            denunciaPorId.DenunciaEncaminhadaParaAutoridades = denuncia.DenunciaEncaminhadaParaAutoridades;
            denunciaPorId.QualAutoridadeFoiEncaminhada = denuncia.QualAutoridadeFoiEncaminhada;
            denunciaPorId.DenunciaVerificada = denuncia.DenunciaVerificada;


            _dbContext.Denuncias.Update(denunciaPorId);
            await _dbContext.SaveChangesAsync();

            return denunciaPorId;
        }

        public async Task<bool> ApagarDenuncia(int id)
        {
            DenunciasModel denunciaPorId = await BuscarDenunciaPorId(id);

            if (denunciaPorId == null)
            {
                throw new Exception($"Denúncia com o ID: {id} não foi encontrada!");
            }

            _dbContext.Denuncias.Remove(denunciaPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
