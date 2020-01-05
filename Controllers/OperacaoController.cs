using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MDF.Models.ClassesDeDominio;
using MDF.Models;
using MDF.Models.DTO;
using System.Collections.Generic;
using MDF.Models.Repositorios;
using Microsoft.AspNetCore.Cors;

namespace MDF.Controllers
{
    [Route("api/Operacao")]
    [EnableCors("IT3Client")]
    [ApiController]
    public class OperacaoController : ControllerBase
    {
        public OperacaoRepositorio repositorio;

        public OperacaoController(MDFContext context)
        {
            repositorio = new OperacaoRepositorio(context);
        }

        // GET: api/Operacao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OperacaoDTO>> GetOperacao(long id)
        {
            var operacao = await repositorio.getOperacaoById(id);
            if (operacao.Value == null)
            {
                return NotFound("Operacao não existe!");
            }
            return operacao.Value.toDTO();
        }

        // GET: api/Operacao/
        [HttpGet()]
        public async Task<ActionResult<List<OperacaoDTO>>> GetAllOperacao()
        {
            List<OperacaoDTO> listaMaquinasDTO = obterListaOperacaosDTO((await repositorio.getAllOperacao()).Value);
            return listaMaquinasDTO;
        }

        private List<OperacaoDTO> obterListaOperacaosDTO(List<Operacao> listaOperacaos)
        {
            List<OperacaoDTO> listaOperacaosDTO = new List<OperacaoDTO>();
            foreach (Operacao operacao in listaOperacaos)
            {
                listaOperacaosDTO.Add(operacao.toDTO());
            }
            return listaOperacaosDTO;
        }

        // POST: api/Operacao
        [HttpPost()]
        public async Task<ActionResult<Operacao>> PostOperacao(OperacaoDTO update_operacao)
        {
            repositorio.addOperacao(new Operacao(update_operacao.id, update_operacao.descricaoOperacao, update_operacao.duracaoOperacao.Split(":")[0], update_operacao.duracaoOperacao.Split(":")[1], update_operacao.duracaoOperacao.Split(":")[2], update_operacao.id_ferramenta, update_operacao.duracaoFerramenta.Split(":")[0], update_operacao.duracaoFerramenta.Split(":")[1], update_operacao.duracaoFerramenta.Split(":")[2]));
            return CreatedAtAction(nameof(GetOperacao), new { id = update_operacao.id }, update_operacao);
        }

        // PUT: api/Todo
        [HttpPut()]
        public async Task<IActionResult> PutOperacao(OperacaoDTO update_operacao)
        {
            var operacaoDTO = await repositorio.getOperacaoById(update_operacao.id);

            if (operacaoDTO == null)
            {
                return NotFound("Operação não existe!");
            }

            operacaoDTO.Value.descricaoOperacao = new Models.ValueObjects.Descricao(update_operacao.descricaoOperacao);
            operacaoDTO.Value.duracaoOperacao = new Models.ValueObjects.DuracaoOperacao(update_operacao.duracaoOperacao.Split(":")[0], update_operacao.duracaoOperacao.Split(":")[1], update_operacao.duracaoOperacao.Split(":")[2]);
            operacaoDTO.Value.ferramentaOperacao = new Models.ValueObjects.Ferramenta(update_operacao.id_ferramenta, update_operacao.duracaoFerramenta.Split(":")[0], update_operacao.duracaoFerramenta.Split(":")[1], update_operacao.duracaoFerramenta.Split(":")[2]);

            repositorio.updateOperacao(operacaoDTO.Value);
            return NoContent();
        }

        // DELETE: api/Operacao/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OperacaoDTO>> DeleteOperacao(long id)
        {
            var operacao = await GetOperacao(id);

            if (operacao.Value == null)
            {
                return NotFound("Operação não existe!");
            }

            repositorio.deleteOperacao(id);

            return NoContent();
        }
    }
}