using MDF.Models.Shared;
using System.Collections.Generic;
using MDF.Models.DTO;
using MDF.Models.ValueObjects;

namespace MDF.Models
{
    public class LinhaProducao : Entity, IAggregateRoot
    {
        public long id { get; set; }
        public Descricao descricao { get; set; }
        public PosicaoAbsoluta posicaoAbsolutaLinhaProducao { get; set; }
        public Orientacao orientacaoLinhaProducao { get; set; }
        public Dimensao dimensaoLinhaProducao { get; set; }
        public List<Maquina> maquinas { get; set; }

        public LinhaProducao() { }
        public LinhaProducao(long id)
        {
            this.id = id;
        }

        public LinhaProducao(long id, List<Maquina> maquinas)
        {
            this.id = id;
            this.maquinas = maquinas;
        }

        public LinhaProducao(long id, string descricao, int x, int y, string orientacao, int comprimento, int largura)
        {
            this.id = id;
            this.descricao = new Descricao(descricao);
            this.posicaoAbsolutaLinhaProducao = new PosicaoAbsoluta(x, y);
            this.orientacaoLinhaProducao = new Orientacao(orientacao);
            this.dimensaoLinhaProducao = new Dimensao(comprimento, largura);
            this.maquinas = new List<Maquina>();
        }

        public void addMaquina(Maquina maquina)
        {
            maquinas.Add(maquina);
        }

        public bool update_linhaProducao(List<Maquina> maquinas)
        {
            if (maquinas == null)
            {
                return false;
            }
            this.maquinas = maquinas;
            return true;
        }

        public bool isInsideFabrica()
        {
            return posicaoAbsolutaLinhaProducao.x + this.dimensaoLinhaProducao.comprimento/2 < Fabrica.dimensaoFabrica.comprimento && posicaoAbsolutaLinhaProducao.y + this.dimensaoLinhaProducao.largura/2 < Fabrica.dimensaoFabrica.largura;
        }

        public LinhaProducaoDTO toDTO()
        {
            return new LinhaProducaoDTO(id, descricao.Id, posicaoAbsolutaLinhaProducao.x, posicaoAbsolutaLinhaProducao.y, orientacaoLinhaProducao.orientacao, dimensaoLinhaProducao.comprimento, dimensaoLinhaProducao.largura, maquinas);
        }

    }
}