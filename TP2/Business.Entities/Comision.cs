using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Comision : BusinessEntity
    {
        private int AnioEspecialidad { get; set; }
        private string Descripcion { get; set; }
        private int IDPlan { get; set; }
    }
}
