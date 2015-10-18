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

namespace UI.Desktop
{
    public partial class Usuarios : Form
    {
        //Constructor del formulario y generacion de las columnas.
        public Usuarios()
        {
            InitializeComponent();
            this.dgvUsuarios.AutoGenerateColumns = false;
            this.GenerarColumnas();
        }

        //Listado del DataSource.
        public void Listar()
        {
            UsuarioLogic ul = new UsuarioLogic();
            try
            {
                this.dgvUsuarios.DataSource = ul.GetAll();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        //Acciones del formulario.
        private void Usuarios_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Creacion de las columnas.
        private void GenerarColumnas()
        {
            DataGridViewTextBoxColumn colID = new DataGridViewTextBoxColumn();
            colID.Name = "id";
            colID.HeaderText = "ID";
            colID.DataPropertyName = "ID";
            this.dgvUsuarios.Columns.Add(colID);

            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.Name = "nombre";
            colNombre.HeaderText = "Nombre";
            colNombre.DataPropertyName = "Nombre";
            this.dgvUsuarios.Columns.Add(colNombre);

            DataGridViewTextBoxColumn colApellido = new DataGridViewTextBoxColumn();
            colApellido.Name = "apellido";
            colApellido.HeaderText = "Apellido";
            colApellido.DataPropertyName = "Apellido";
            this.dgvUsuarios.Columns.Add(colApellido);

            DataGridViewTextBoxColumn colUsuario = new DataGridViewTextBoxColumn();
            colUsuario.Name = "usuario";
            colUsuario.HeaderText = "Usuario";
            colUsuario.DataPropertyName = "NombreUsuario";
            this.dgvUsuarios.Columns.Add(colUsuario);

            DataGridViewTextBoxColumn colEmail = new DataGridViewTextBoxColumn();
            colEmail.Name = "email";
            colEmail.HeaderText = "EMail";
            colEmail.DataPropertyName = "Email";
            this.dgvUsuarios.Columns.Add(colEmail);

            DataGridViewCheckBoxColumn colHabilitado = new DataGridViewCheckBoxColumn();
            colHabilitado.Name = "habilitado";
            colHabilitado.HeaderText = "Habilitado";
            colHabilitado.DataPropertyName = "Habilitado";
            this.dgvUsuarios.Columns.Add(colHabilitado);
        }

        //Formulario de alta de usuario.
        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            UsuarioDesktop formUsuario = new UsuarioDesktop(ApplicationForm.ModoForm.Alta);
            formUsuario.ShowDialog();
            this.Listar();
        }

        //Formulario de modificacion de usuario.
        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvUsuarios.SelectedRows.Count != 0)
            {
                int ID = ((Business.Entities.Usuario) this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                UsuarioDesktop formUsuario = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formUsuario.ShowDialog();
                this.Listar();
            }

        }

        //Formulario de eliminacion de usuario.
        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvUsuarios.SelectedRows.Count != 0)
            {
                int ID = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                UsuarioDesktop formUsuario = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Baja);
                formUsuario.ShowDialog();
                this.Listar();
            }
        }

        //Formulario de consulta de usuario.
        private void tsbConsultar_Click(object sender, EventArgs e)
        {
            if (this.dgvUsuarios.SelectedRows.Count != 0)
            {
                int ID = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                UsuarioDesktop formUsuario = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Consulta);
                formUsuario.ShowDialog();
            }
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
