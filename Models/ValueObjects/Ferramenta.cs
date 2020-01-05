using MDF.Models.Shared;

namespace MDF.Models.ValueObjects
{
    public class Ferramenta : ValueObject
    {
        public string Id{ get; set; }

        public string hora { get; set; }
        public string min { get; set; }
        public string seg { get; set; }


        public Ferramenta() { }

        public Ferramenta(string id, string hora, string min, string seg) { 
            this.Id =  id;
            this.hora = hora; 
            this.min = min; 
            this.seg = seg;
        }

        public string tempoSetUptoString()
        {
            return hora + ":" + min + ":" + seg;
        }

    }
}