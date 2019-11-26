using MDF.Associations;
using MDF.Models.ValueObjects;
using System.Collections.Generic;

namespace MDF.Models.DTO
{

    public class MaquinaDTO
    {

        public long Id { get; set; }
        public string nomeMaquina { get; set; }
        public string marcaMaquina { get; set; }
        public string modeloMaquina { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public long id_tipoMaquina { get; set; }
        public ICollection<LinhaProducaoMaquinas> linhasProducao { get; set; }

        public MaquinaDTO() { }

        public MaquinaDTO(long Id, NomeMaquina nomeMaquina, MarcaMaquina marcaMaquina, ModeloMaquina modeloMaquina, PosicaoNaLinhaProducao posicaoLinhaProducao, long tipoMaquina, ICollection<LinhaProducaoMaquinas> linhasProducao)
        {
            this.Id = Id;
            this.nomeMaquina = nomeMaquina.nomeMaquina;
            this.marcaMaquina = marcaMaquina.marca;
            this.modeloMaquina = modeloMaquina.modelo;
            this.x = posicaoLinhaProducao.x;
            this.y = posicaoLinhaProducao.y;
            this.id_tipoMaquina = tipoMaquina;
            this.linhasProducao = linhasProducao;
        }

        public MaquinaDTO(long Id, string nomeMaquina, string marca, string modelo, int x, int y, long tipoMaquina, ICollection<LinhaProducaoMaquinas> linhasProducao)
        {
            this.Id = Id;
            this.nomeMaquina = nomeMaquina;
            this.marcaMaquina = marca;
            this.modeloMaquina = modelo;
            this.x = x;
            this.y = y;
            this.id_tipoMaquina = tipoMaquina;
            this.linhasProducao = linhasProducao;
        }
    }
}
