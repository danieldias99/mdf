using System.Collections.Generic;
using MDF.Associations;

namespace MDF.Models.DTO
{

    public class LinhaProducaoDTO
    {

        public long id { get; set; }
        public string descricao { get; set; }
        public int posicao_x { get; set; }
        public int posicao_y { get; set; }
        public string orientacao { get; set; }
        public int comprimento { get; set; }
        public int largura { get; set; }
        public List<MaquinaDTO> maquinas { get; set; }

        public LinhaProducaoDTO() { }

        public LinhaProducaoDTO(long id, string descricao, int posicao_x, int posicao_y, string orientacao, int comprimento, int largura, List<Maquina> lista)
        {
            this.id = id;
            this.descricao = descricao;
            this.posicao_x = posicao_x;
            this.posicao_y = posicao_y;
            this.orientacao = orientacao;
            this.comprimento = comprimento;
            this.largura = largura;
            this.maquinas = new List<MaquinaDTO>();
            setMaquinas(lista);
        }

        public void setMaquinas(List<Maquina> linhasProducaoMaquinas)
        {
            if (linhasProducaoMaquinas != null)
            {
                foreach (Maquina linhaProducaoMaquinas in linhasProducaoMaquinas)
                {
                    maquinas.Add(linhaProducaoMaquinas.toDTO());
                }
            }
        }
    }
}