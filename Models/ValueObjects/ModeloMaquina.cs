using MDF.Models.Shared;

namespace MDF.Models.ValueObjects
{

    public class ModeloMaquina : ValueObject
    {

        public string modelo { get; set; }

        public ModeloMaquina() { }

        public ModeloMaquina(string modelo)
        {
            this.modelo = modelo;
        }

    }
}