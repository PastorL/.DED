using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Curso : BusinessEntity
    {
        private int AnioCalendario { get; set; }
        private int Cupo { get; set; }
        private string Descripcion { get; set; }
        private int IDComision { get; set; }
        private int IDMateria { get; set; }
    }
}
