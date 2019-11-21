using System.Collections.Generic;
using MDF.Associations;

namespace MDF.Models.DTO
{

    public class OperacaoDTO
    {
        public long id;
        public string descricaoOperacao { get; set; }
        public string duracaoOperacao { get; set; }
        public List<TipoMaquina> tiposMaquinas { get; set; }

        public OperacaoDTO(){}
        
        public OperacaoDTO(long id)
        {
            this.id = id;
        }

        public OperacaoDTO(long id, string descricaoOperacao, string duracaoOperacao, ICollection<TipoMaquinaOperacao> listTipoMaquinaOperacoes)
        {
            this.id = id;
            this.descricaoOperacao = descricaoOperacao;
            this.duracaoOperacao = duracaoOperacao;
        }

        public void setOperacoes(ICollection<TipoMaquinaOperacao> listTipoMaquinaOperacoes)
        {
            tiposMaquinas = new List<TipoMaquina>();
            foreach (TipoMaquinaOperacao tipoMaquinaOperacao in listTipoMaquinaOperacoes)
            {
                this.tiposMaquinas.Add(tipoMaquinaOperacao.tipoMaquina);
            }
        }
    }
}