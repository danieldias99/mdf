using MDF.Models.Shared;

namespace MDF.Models.ValueObjects
{

    public class MarcaMaquina : ValueObject
    {

        public string marca { get; set; }

        public MarcaMaquina() { }

        public MarcaMaquina(string marca)
        {
            this.marca = marca;
        }

    }
}