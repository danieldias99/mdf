using MDF.Models.ValueObjects;

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
        public int posicaoRelativa { get; set; }
        public long id_tipoMaquina { get; set; }
        public long id_linhaProducao { get; set; }

        public bool estado { get; set; }

        public MaquinaDTO() { }

        public MaquinaDTO(long Id, NomeMaquina nomeMaquina, MarcaMaquina marcaMaquina, ModeloMaquina modeloMaquina, PosicaoAbsoluta posicaoLinhaProducao, PosicaoRelativa posicaoRelativa, long tipoMaquina, long linhaProducao, bool estado)
        {
            this.Id = Id;
            this.nomeMaquina = nomeMaquina.nomeMaquina;
            this.marcaMaquina = marcaMaquina.marca;
            this.modeloMaquina = modeloMaquina.modelo;
            this.x = posicaoLinhaProducao.x;
            this.y = posicaoLinhaProducao.y;
            this.posicaoRelativa = posicaoRelativa.posicao;
            this.id_tipoMaquina = tipoMaquina;
            this.id_linhaProducao = linhaProducao;
            this.estado = estado;
        }

        public MaquinaDTO(long Id, string nomeMaquina, string marca, string modelo, int x, int y, int posicaoRelativa, long tipoMaquina, long linhaProducao)
        {
            this.Id = Id;
            this.nomeMaquina = nomeMaquina;
            this.marcaMaquina = marca;
            this.modeloMaquina = modelo;
            this.x = x;
            this.y = y;
            this.posicaoRelativa = posicaoRelativa;
            this.id_tipoMaquina = tipoMaquina;
            this.id_linhaProducao = linhaProducao;
            this.estado = true;
        }
    }
}
