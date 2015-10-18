using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Negocio;
using System.Text.RegularExpressions;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {
        public Usuario UsuarioActual { get; set; }


        //Constructor por defecto, para altas y para los demas modos.
        public UsuarioDesktop()
        {
            InitializeComponent();
        }

        public UsuarioDesktop(ModoForm modo): this()
        {
            this.Modo = modo;
            this.txtID.Enabled = false;
        }

        public UsuarioDesktop(int ID, ModoForm modo): this()
        {
            this.Modo = modo;
            UsuarioLogic ul = new UsuarioLogic();
            try
            {
                UsuarioActual = ul.GetOne(ID);
            }
            catch (Exception Ex)
            {
                this.Notificar(Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.MapearDeDatos();
        }

        //Mapeo de los datos desde el DataSource a los textfields. Modificacion del boton de accion a realizar.
        public void MapearDeDatos()
        {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtEmail.Text = this.UsuarioActual.Email;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.txtConfirmarClave.Text = this.UsuarioActual.Clave;

            switch (this.Modo)
            {
                case ModoForm.Modificacion: btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Consulta: btnAceptar.Text = "Aceptar";
                    break;
                case ModoForm.Baja: btnAceptar.Text = "Eliminar";
                    break;
                default: break;
            }
        }

        //Seteo del estado del usuario. Mapeo de datos desde los textfields al DataSource en caso de Alta o Modificacion. 
        public void MapearADatos()
        {
            if (this.Modo == ModoForm.Alta)
            {
                UsuarioActual = new Usuario();
                UsuarioActual.State = Usuario.States.New;
            }
            else if (this.Modo == ModoForm.Modificacion)
            {
                UsuarioActual.State = Usuario.States.Modified;
            }
            else if (this.Modo == ModoForm.Baja)
            {
                UsuarioActual.State = Usuario.States.Deleted;
            }
            else
            {
                UsuarioActual.State = Usuario.States.Unmodified;
            }

            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                UsuarioActual.Nombre = this.txtNombre.Text;
                UsuarioActual.Apellido = this.txtApellido.Text;
                UsuarioActual.Email = this.txtEmail.Text;
                UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                UsuarioActual.Clave = this.txtClave.Text;
            }
        }

        //Realizando la accion.
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool validacion = this.Validar();
            if (validacion)
            {
                this.GuardarCambios();
                this.Close();
            }
            else
            {
                this.Notificar("Error en la carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void GuardarCambios()
        {
            this.MapearADatos();
            UsuarioLogic Usuario = new UsuarioLogic();
            try
            {
                Usuario.Save(UsuarioActual);
            }
            catch (Exception Ex)
            {
                this.Notificar(Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //Cancelando la accion.
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Validacion de los datos.
        public bool Validar() 
        {
            bool val = true;
            if (this.txtNombre.Text == "" || this.txtUsuario.Text == "" || this.txtApellido.Text == ""
                || this.txtClave.Text == "" || this.txtConfirmarClave.Text == "" || !this.chkHabilitado.Checked)
            {
                val = false;
            }
            if ((this.txtClave.Text.Length < 8 || this.txtClave.Text != this.txtConfirmarClave.Text) && val)
            {
                val = false;
            }
            if (!(Regex.IsMatch(this.txtEmail.Text, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))"
                + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250))))
            {
                val = false;
            }

            return val;
        }

        //Notificacion en caso de error en la validacion.
        public void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }

        public void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void UsuarioDesktop_Load(object sender, EventArgs e)
        {

        }

    }
}
