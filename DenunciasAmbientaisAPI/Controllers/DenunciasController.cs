using DenunciasAmbientaisAPI.Enums;
using DenunciasAmbientaisAPI.Helpers;
using DenunciasAmbientaisAPI.Models;
using DenunciasAmbientaisAPI.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.IdentityModel.Tokens;

namespace DenunciasAmbientaisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DenunciasController : ControllerBase
    {
        private readonly IDenunciasRepositorio _denunciasRepositorio;

        public DenunciasController(IDenunciasRepositorio denunciasRepositorio)
        {
            _denunciasRepositorio = denunciasRepositorio;
        }

        [HttpGet("TodasDenuncias")]
        public async Task<ActionResult<List<DenunciasModel>>> BuscarTodasDenuncias()
        {
            List<DenunciasModel> denuncias = await _denunciasRepositorio.BuscarTodasDenuncias();
            return Ok(denuncias);
        }

        [HttpGet("DetalhesDenuncia/{id}")]
        public async Task<ActionResult<DenunciasModel>> BuscarDenunciaPorId(int id)
        {
            DenunciasModel denuncia = await _denunciasRepositorio.BuscarDenunciaPorId(id);
            return Ok(denuncia);
        }



        [HttpPost("adicionarDenuncia")]
        public async Task<ActionResult<DenunciasModel>> AdicionarDenuncia(
            [FromForm] string descricao,
            [FromForm] int tipo,
            [FromForm] string local,
            [FromForm] IFormFile foto)
        {
            // Converta a imagem para base64 ou manipule conforme necessário
            HelpersGerais helpersGerais = new();
            string fotoBase64 = helpersGerais.ConvertToBase64(foto);

            DenunciasModel denuncia = new();
            denuncia.DescricaoDenuncia = descricao;

            TipoDenuncia tipoDenuncia = (TipoDenuncia)tipo;
            denuncia.Tipo = tipoDenuncia;

            denuncia.LocalDenuncia = local;

            denuncia.DataDenuncia = DateTime.Now;

            denuncia.FotoDenuncia = fotoBase64;

            DenunciasModel denunciasModel = await _denunciasRepositorio.AdicionarDenuncia(denuncia);
            return Ok(denuncia);
        }

        [HttpPost("adicionarDenunciaDesktop")]
        public async Task<ActionResult<DenunciasModel>> AdicionarDenunciaDesktop(
            [FromForm] string descricao,
            [FromForm] int tipo,
            [FromForm] string local,
            [FromForm] string foto)
        {
            // Converta a imagem para base64 ou manipule conforme necessário
            //HelpersGerais helpersGerais = new();
            //string fotoBase64 = helpersGerais.ConvertToBase64(foto);
            string fotoBase64 = foto;

            DenunciasModel denuncia = new();
            denuncia.DescricaoDenuncia = descricao;

            TipoDenuncia tipoDenuncia = (TipoDenuncia)tipo;
            denuncia.Tipo = tipoDenuncia;

            denuncia.LocalDenuncia = local;

            denuncia.DataDenuncia = DateTime.Now;

            denuncia.FotoDenuncia = fotoBase64;

            DenunciasModel denunciasModel = await _denunciasRepositorio.AdicionarDenuncia(denuncia);
            return Ok(denuncia);
        }



        [HttpGet("atualizarDenuncia/{id}")]
        public async Task<ActionResult<DenunciasModel>> AtualizarDenuncia(int id, string quemEncaminhada, bool denunciaEncaminhada, bool denunciaVerificada)
        {
            DenunciasModel denuncia = new();

            denuncia.Id = id;

            if (denunciaVerificada == true)
            {
                denuncia.DenunciaVerificada = true;
            }
            else
            {
                denuncia.DenunciaVerificada = false;
            }

            if (denunciaEncaminhada == true)
            {
                denuncia.DenunciaEncaminhadaParaAutoridades = true;
            }
            else
            {
                denuncia.DenunciaEncaminhadaParaAutoridades = false;
            }

            if (quemEncaminhada.IsNullOrEmpty())
            {
                quemEncaminhada = "Sem informação!";
            }


            denuncia.DenunciaEncaminhadaParaAutoridades = denunciaEncaminhada;

            denuncia.QualAutoridadeFoiEncaminhada = quemEncaminhada;

            denuncia.DataVerificacao = DateTime.Now;

            DenunciasModel denunciasModel = await _denunciasRepositorio.AtualizarDenuncia(denuncia, id);
            return Ok(denuncia);
        }


        [HttpGet("DeletarDenuncia/{id}")]
        public async Task<ActionResult<List<DenunciasModel>>> DeletarDenuncia(int id)
        {
            bool denunciaDeletada = await _denunciasRepositorio.ApagarDenuncia(id);
            return Ok(denunciaDeletada);
        }


    }
}
