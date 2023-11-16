using DenunciasAmbientaisAPI.Models;

namespace DenunciasAmbientaisAPI.Repositorios.Interfaces
{
    public interface IDenunciasRepositorio
    {
        Task<List<DenunciasModel>> BuscarTodasDenuncias();
        Task<DenunciasModel> BuscarDenunciaPorId(int id);
        Task<DenunciasModel> AdicionarDenuncia(DenunciasModel denuncia);
        Task<DenunciasModel> AtualizarDenuncia(DenunciasModel denuncia, int id);
        Task<bool> ApagarDenuncia(int id);
    }
}
