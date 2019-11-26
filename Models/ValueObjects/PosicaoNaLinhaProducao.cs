namespace MDF.Models.ValueObjects
{

    public class PosicaoNaLinhaProducao
    {

        public int x { get; set; }
        public int y { get; set; }

        public PosicaoNaLinhaProducao() { }
        public PosicaoNaLinhaProducao(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}