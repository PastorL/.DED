using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class AlumnoInscripcion : BusinessEntity
    {
        private string Condicion { get; set; }
        private int IDAlumno { get; set; }
        private int IDCurso { get; set; }
        private int Nota { get; set; }

    }
}
