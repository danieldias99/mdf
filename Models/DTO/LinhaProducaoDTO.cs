using System.Collections.Generic;
using MDF.Associations;

namespace MDF.Models.DTO
{

    public class LinhaProducaoDTO
    {

        public long id { get; set; }
        public List<MaquinaDTO> maquinas { get; set; }

        public LinhaProducaoDTO() { }

        public LinhaProducaoDTO(long id, List<LinhaProducaoMaquinas> lista)
        {
            this.id = id;
            this.maquinas = new List<MaquinaDTO>();
            setMaquinas(lista);
        }

        public void setMaquinas(List<LinhaProducaoMaquinas> linhasProducaoMaquinas)
        {
            foreach (LinhaProducaoMaquinas linhaProducaoMaquinas in linhasProducaoMaquinas)
            {
                maquinas.Add(linhaProducaoMaquinas.maquina.toDTO());
            }

        }
    }
}