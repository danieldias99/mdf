using MDF.Models.Shared;
using MDF.Models.ValueObjects;
using MDF.Models.DTO;
using MDF.Associations;
using System.Collections.Generic;

namespace MDF.Models
{
    public class Operacao : Entity, IAggregateRoot
    {
        public long id { get; set; }
        public Descricao descricaoOperacao { get; set; }
        public DuracaoOperacao duracaoOperacao { get; set; }
        public ICollection<TipoMaquinaOperacao> tiposMaquinas { get; set; }

        public Ferramenta ferramentaOperacao { get; set; }

        private Operacao() { }

        public Operacao(long id, string descricao, string id_ferramenta, string horaF, string minF, string segF, string hora, string min, string seg)
        {
            this.id = id;
            this.descricaoOperacao = new Descricao(descricao);
            this.duracaoOperacao = new DuracaoOperacao(hora, min, seg);
            this.ferramentaOperacao = new Ferramenta(id_ferramenta, horaF, minF,segF);
        }

        public Operacao(long id)
        {
            this.id = id;
        }

        public OperacaoDTO toDTO()
        {
            return new OperacaoDTO(id, descricaoOperacao.Id, duracaoOperacao.toString(), ferramentaOperacao.Id, ferramentaOperacao.tempoSetUptoString(), tiposMaquinas);
        }
    }
}