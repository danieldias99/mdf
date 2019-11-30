using MDF.Models.ClassesDeDominio;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MDF.Associations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MDF.Models.Repositorios
{

    public class LinhaProducaoRepositorio
    {

        private readonly MDFContext _context;

        public LinhaProducaoRepositorio(MDFContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<LinhaProducao>> getLinhaProducaoById(long id)
        {
            var linhaOp = await _context.LinhasProducao.FindAsync(id);
            setMaquinasLinhaProducao(linhaOp);
            return linhaOp;
        }

        public async Task<ActionResult<List<LinhaProducao>>> getAllLinhasProducao()
        {
            return await _context.LinhasProducao.ToListAsync();
        }

        public bool addLinhaProducao(LinhaProducao newLinhaProducao)
        {
            if (newLinhaProducao.isInsideFabrica())
            {
                _context.LinhasProducao.Add(newLinhaProducao);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void setMaquinasLinhaProducao(LinhaProducao linhaProducao)
        {
            var all_maquinas = _context.Maquinas;

            foreach (Maquina maquina in all_maquinas)
            {
                if (maquina.id_linhaProducao == linhaProducao.id)
                {
                    linhaProducao.addMaquina(maquina);
                }
            }
        }

        public void updateLinhaProducao(LinhaProducao update_linha)
        {
            _context.Entry(update_linha).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async void deleteLinhaProducao(long id)
        {
            var linha = await _context.LinhasProducao.FindAsync(id);
            _context.LinhasProducao.Remove(linha);
            _context.Entry(linha).State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}