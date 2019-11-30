using MDF.Models.Shared;

namespace MDF.Models.ValueObjects
{

    public class PosicaoAbsoluta : ValueObject
    {

        public int x { get; set; }
        public int y { get; set; }

        public PosicaoAbsoluta() { }
        public PosicaoAbsoluta(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}