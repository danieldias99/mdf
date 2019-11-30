using MDF.Models.ClassesDeDominio;
using MDF.Models.DTO;
using MDF.Associations;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MDF.Models.Repositorios
{

    public class MaquinaRepositorio
    {

        private readonly MDFContext _context;

        public MaquinaRepositorio(MDFContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<Maquina>> getMaquinaById(long Id)
        {
            var maquina = await _context.Maquinas.FindAsync(Id);
            maquina.tipoMaquina = (await _context.TiposMaquina.FindAsync(maquina.id_tipoMaquina));
            maquina.linhaProducao = (await _context.LinhasProducao.FindAsync(maquina.id_linhaProducao));
            return maquina;
        }

        public async Task<ActionResult<List<Maquina>>> getAllMaquinas()
        {
            return await _context.Maquinas.ToListAsync();
        }

        public void addMaquina(Maquina newMaquina)
        {
            _context.Maquinas.Add(newMaquina);
            _context.SaveChanges();
        }

        public async Task<ActionResult<Maquina>> updateMaquina(Maquina update_Maquina)
        {
            _context.Entry(update_Maquina).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return update_Maquina;
        }

        public async void deleteMaquina(long id)
        {
            var Maquina = await _context.Maquinas.FindAsync(id);
            _context.Maquinas.Remove(Maquina);
            _context.Entry(Maquina).State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}
