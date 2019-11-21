using MDF.Models.ClassesDeDominio;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MDF.Models.DTO;

namespace MDF.Models.Repositorios
{

    public class OperacaoRepositorio
    {

        public readonly MDFContext _context;

        public OperacaoRepositorio(MDFContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<Operacao>> getOperacaoById(long id)
        {
            var operacao = await _context.Operacoes.FindAsync(id);
            return operacao;
        }

        public async Task<ActionResult<List<Operacao>>> getAllOperacao()
        {
            return await _context.Operacoes.ToListAsync();
        }

        public void addOperacao(Operacao newOperacao)
        {
            _context.Operacoes.Add(newOperacao);
            _context.SaveChanges();
        }

        public void updateOperacao(Operacao update_operacao)
        {
            _context.Entry(update_operacao).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async void deleteOperacao(long id)
        {
            var operacao = await _context.Operacoes.FindAsync(id);
            _context.Operacoes.Remove(operacao);
            _context.SaveChanges();
        }
    }
}