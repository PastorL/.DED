using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Personas : BusinessEntity
    {
        private string Apellido { get; set; }
        private string Direccion { get; set; }
        private string Email { get; set; }
        private DateTime FechaNacimiento { get; set; }
        private int IDPlan { get; set; }
        private int Legajo { get; set; }
        private string Nombre { get; set; }
        private string Telefono { get; set; }
        private TiposPersonas TipoPersona { get; set; }
        public enum TiposPersonas
        {
            Alumno,
            Docente,
            UsuarioAdmin
        }
    }
}
