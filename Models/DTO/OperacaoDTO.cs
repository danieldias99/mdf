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

        public string id_ferramenta { get; set; }

        public string duracaoFerramenta { get; set; }

        public OperacaoDTO(){}
        
        public OperacaoDTO(long id)
        {
            this.id = id;
        }

        public OperacaoDTO(long id, string descricaoOperacao, string duracaoOperacao, string  id_ferramenta, string duracaoFerramenta, ICollection<TipoMaquinaOperacao> listTipoMaquinaOperacoes)
        {
            this.id = id;
            this.descricaoOperacao = descricaoOperacao;
            this.id_ferramenta = id_ferramenta;
            this.duracaoFerramenta = duracaoFerramenta;
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