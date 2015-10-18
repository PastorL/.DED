using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Materia : BusinessEntity
    {
        private string Descripcion { get; set; }
        private int HSSemanalas { get; set; }
        private int HSTotales { get; set; }
        private int IDPlan { get; set; }

    }
}
