using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class ModuloUsuario : BusinessEntity
    {
        private int IdUsuario { get; set; }
        private int IdModulo { get; set; }
        private bool PermiteAlta { get; set; }
        private bool PermiteBaja { get; set; }
        private bool PermiteModificacion { get; set; }
        private bool PermiteConsulta { get; set; }

    }
}
