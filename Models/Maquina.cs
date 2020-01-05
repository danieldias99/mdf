using MDF.Models.Shared;
using MDF.Models.ValueObjects;
using MDF.Models.DTO;

namespace MDF.Models
{

    public class Maquina : Entity, IAggregateRoot
    {
        public long Id { get; set; }
        public NomeMaquina nomeMaquina { get; set; }
        public MarcaMaquina marcaMaquina { get; set; }
        public ModeloMaquina modeloMaquina { get; set; }
        public PosicaoAbsoluta posicaoLinhaProducao { get; set; }
        public PosicaoRelativa posicaoRelativa { get; set; }
        public long id_tipoMaquina { get; set; }
        public TipoMaquina tipoMaquina { get; set; }
        public long id_linhaProducao { get; set; }
        public LinhaProducao linhaProducao { get; set; }

        public bool estado{ get; set; }

        public Maquina() { }

        public Maquina(NomeMaquina nomeMaquina, PosicaoAbsoluta posicaoLinhaProducao, TipoMaquina tipoMaquina)
        {
            this.nomeMaquina = nomeMaquina;
            this.tipoMaquina = tipoMaquina;
            this.posicaoLinhaProducao = posicaoLinhaProducao;
        }

        public Maquina(long id_maquina, string nomeMaquina, string marca, string modelo, int x, int y, int posicaoRelativa, long id_tipoMaquina, TipoMaquina tipoMaquina, long id_linhaProducao, bool estado)
        {
            this.Id = id_maquina;
            this.nomeMaquina = new NomeMaquina(nomeMaquina);
            this.marcaMaquina = new MarcaMaquina(marca);
            this.modeloMaquina = new ModeloMaquina(modelo);
            this.id_tipoMaquina = id_tipoMaquina;
            this.tipoMaquina = tipoMaquina;
            this.id_linhaProducao = id_linhaProducao;
            this.posicaoLinhaProducao = new PosicaoAbsoluta(x, y);
            this.posicaoRelativa = new PosicaoRelativa(posicaoRelativa);
            this.estado = estado;
        }

        public bool alterarIdTipoMaquina(TipoMaquina tipoMaquina)
        {
            if (tipoMaquina == null)
            {
                return false;
            }
            this.tipoMaquina = tipoMaquina;
            this.id_tipoMaquina = tipoMaquina.id_tipoMaquina;
            return true;
        }


        public MaquinaDTO toDTO()
        {
            return new MaquinaDTO(Id, nomeMaquina, marcaMaquina, modeloMaquina, posicaoLinhaProducao, posicaoRelativa, id_tipoMaquina, id_linhaProducao, estado);
        }
    }
}
