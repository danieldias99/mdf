using MDF.Models.Shared;

namespace MDF.Models.ValueObjects
{
    public class Dimensao : ValueObject
    {
        public int comprimento { get; set; }
        public int largura { get; set; }

        public Dimensao() { }

        public Dimensao(int comprimento, int largura)
        {
            this.comprimento = comprimento;
            this.largura = largura;
        }

    }
}