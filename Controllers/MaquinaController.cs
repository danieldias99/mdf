using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MDF.Models.ClassesDeDominio;
using MDF.Models;
using MDF.Models.DTO;
using MDF.Models.Repositorios;
using MDF.Models.ValueObjects;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;

namespace MDF.Controllers
{

    [Route("api/Maquina")]
    [EnableCors("IT3Client")]
    [ApiController]
    public class MaquinaController : ControllerBase
    {

        public MaquinaRepositorio repositorioMaquina;
        public TipoMaquinaRepositorio repositorioTipoMaquina;

        public MaquinaController(MDFContext context)
        {
            repositorioMaquina = new MaquinaRepositorio(context);
            repositorioTipoMaquina = new TipoMaquinaRepositorio(context);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MaquinaDTO>> getMaquina(long Id)
        {
            var Maquina = await repositorioMaquina.getMaquinaById(Id);

            if (Maquina == null)
            {
                return NotFound();
            }

            return Maquina.Value.toDTO();
        }


        // GET: api/TipoMaquina/
        [HttpGet]
        public async Task<ActionResult<List<MaquinaDTO>>> GetAllTipoMaquina()
        {
            List<MaquinaDTO> listaMaquinasDTO = obterListaMaquinasDTO((await repositorioMaquina.getAllMaquinas()).Value);
            return listaMaquinasDTO;
        }

        private List<MaquinaDTO> obterListaMaquinasDTO(List<Maquina> listaMaquinas)
        {
            List<MaquinaDTO> listaMaquinasDTO = new List<MaquinaDTO>();
            foreach (Maquina maquina in listaMaquinas)
            {
                listaMaquinasDTO.Add(maquina.toDTO());
            }
            return listaMaquinasDTO;
        }

        [HttpPost]
        public async Task<ActionResult<Maquina>> postMaquina(MaquinaDTO newMaquina)
        {
            var tipo_maquina = await repositorioTipoMaquina.getTipoMaquinaById(newMaquina.id_tipoMaquina);
            repositorioMaquina.addMaquina(new Maquina(newMaquina.Id, newMaquina.nomeMaquina, newMaquina.marcaMaquina, newMaquina.modeloMaquina, newMaquina.x, newMaquina.y, newMaquina.posicaoRelativa, newMaquina.id_tipoMaquina, tipo_maquina.Value, newMaquina.id_linhaProducao, true));
            return CreatedAtAction(nameof(getMaquina), new Maquina { nomeMaquina = new NomeMaquina(newMaquina.nomeMaquina) }, newMaquina);
        }

        // PUT: api/Todo/5
        [HttpPut()]
        public async Task<IActionResult> PutMaquina(MaquinaDTO update_maquina)
        {
            var maquina = (await repositorioMaquina.getMaquinaById(update_maquina.Id)).Value;
            if (maquina == null)
            {
                return NotFound("A máquina escolhida não existe!");
            }

            maquina.nomeMaquina = new NomeMaquina(update_maquina.nomeMaquina);
            maquina.posicaoLinhaProducao = new PosicaoAbsoluta(update_maquina.x, update_maquina.y);
            maquina.posicaoRelativa = new PosicaoRelativa(update_maquina.posicaoRelativa);
            maquina.marcaMaquina = new MarcaMaquina(update_maquina.marcaMaquina);
            maquina.modeloMaquina = new ModeloMaquina(update_maquina.modeloMaquina);

            var tipoMaquina = (await repositorioTipoMaquina.getTipoMaquinaById(update_maquina.id_tipoMaquina)).Value;
            if (tipoMaquina == null)
            {
                return NotFound("O tipo de máquina escolhido não existe!");
            }

            if (!maquina.alterarIdTipoMaquina(tipoMaquina))
            {
                return BadRequest("Não foi possivel alterar o tipo de máquina!");
            }

            await repositorioMaquina.updateMaquina(maquina);

            //return Ok("Maquina Atualizada com sucesso!");
            return NoContent();
        }

        // PUT: api/Todo/5
        [HttpPut()]
        public async Task<IActionResult> ativarMaquina(MaquinaDTO update_maquina)
        {
            var maquina = (await repositorioMaquina.getMaquinaById(update_maquina.Id)).Value;
            if (maquina == null)
            {
                return NotFound("A máquina escolhida não existe!");
            }

            maquina.estado = true;

            await repositorioMaquina.updateMaquina(maquina);

            //return Ok("Maquina Atualizada com sucesso!");
            return NoContent();
        }

        // PUT: api/Todo/5
        [HttpPut()]
        public async Task<IActionResult> desativarMaquina(MaquinaDTO update_maquina)
        {
            var maquina = (await repositorioMaquina.getMaquinaById(update_maquina.Id)).Value;
            if (maquina == null)
            {
                return NotFound("A máquina escolhida não existe!");
            }

            maquina.estado = false;

            await repositorioMaquina.updateMaquina(maquina);

            //return Ok("Maquina Atualizada com sucesso!");
            return NoContent();
        }
        

        // DELETE: api/Maquina/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MaquinaDTO>> DeleteMaquina(long id)
        {
            var Maquina = await getMaquina(id);

            if (Maquina == null)
            {
                return NotFound();
            }

            repositorioMaquina.deleteMaquina(id);

            return NoContent();
        }
    }
}
