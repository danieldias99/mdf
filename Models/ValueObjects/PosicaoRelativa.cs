using MDF.Models.Shared;

namespace MDF.Models.ValueObjects
{

    public class PosicaoRelativa : ValueObject
    {

        public int posicao { get; set; }

        public PosicaoRelativa() { }
        public PosicaoRelativa(int posicao)
        {
            this.posicao = posicao;
        }
    }
}