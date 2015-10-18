using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class DocenteCurso : BusinessEntity
    {
        private TiposCargos Cargo { get; set; }
        private int IDCurso { get; set; }
        private int IDDocente { get; set; }
        public enum TiposCargos
        {
            Docente,
            Auxiliar
        }
    }
}
