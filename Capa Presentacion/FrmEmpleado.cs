using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidades;

namespace Presentacion
{
    public partial class FrmEmpleado : Form
    {
        UsuarioBLL objBLL = new UsuarioBLL();

        public FrmEmpleado()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;

            dgvUsuarios.CellClick += dgvUsuarios_CellClick;

            AplicarDiseno();
        }

        private void FrmEmpleado_Load(object sender, EventArgs e)
        {
            
            txtIdUsuario.Visible = false;

            CargarRoles();

            dtFechaRegistro.Value = DateTime.Now;

            MostrarUsuarios();

            Limpiar();
        }

        // =========================
        // CARGAR ROLES
        // =========================
        private void CargarRoles()
        {
            DataTable dtRoles = objBLL.ListarRoles();

            cbRol.DataSource = dtRoles;
            cbRol.DisplayMember = "nombre_rol";
            cbRol.ValueMember = "id_rol";
            cbRol.SelectedIndex = -1;
        }

        // =========================
        // MOSTRAR USUARIOS
        // =========================
        private void MostrarUsuarios()
        {
            dgvUsuarios.DataSource = objBLL.Listar();

            if (dgvUsuarios.Columns["id_usuario"] != null)
                dgvUsuarios.Columns["id_usuario"].Visible = false;

            if (dgvUsuarios.Columns["id_rol"] != null)
                dgvUsuarios.Columns["id_rol"].Visible = false;

            dgvUsuarios.ClearSelection();
        }

        // =========================
        // LIMPIAR
        // =========================
        private void Limpiar()
        {
            txtIdUsuario.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtCorreo.Clear();
            txtTelefono.Clear();
            txtNombreUsuario.Clear();
            txtContraseña.Clear();
            txtBuscar.Clear();

            cbRol.SelectedIndex = -1;

            dtFechaRegistro.Value = DateTime.Now;

            dgvUsuarios.ClearSelection();

            txtNombre.Focus();
        }

        // =========================
        // NUEVO
        // =========================
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        // =========================
        // GUARDAR
        // =========================
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbRol.SelectedIndex == -1)
                {
                    MessageBox.Show(
                        "Seleccione un rol",
                        "Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                Usuario u = new Usuario();

                u.id_usuario = objBLL.ObtenerSiguienteId();

                u.id_rol =
                    Convert.ToInt32(cbRol.SelectedValue);

                u.nombre =
                    txtNombre.Text.Trim();

                u.apellido =
                    txtApellido.Text.Trim();

                u.correo =
                    txtCorreo.Text.Trim();

                u.telefono =
                    txtTelefono.Text.Trim();

                u.nombre_usuario =
                    txtNombreUsuario.Text.Trim();

                u.contraseña =
                    txtContraseña.Text.Trim();

                u.fecha_registro =
                    dtFechaRegistro.Value;

                objBLL.Guardar(u);

                MessageBox.Show(
                    "Usuario guardado correctamente",
                    "Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                MostrarUsuarios();

                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================
        // EDITAR
        // =========================
        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIdUsuario.Text == "")
                {
                    MessageBox.Show(
                        "Seleccione un usuario",
                        "Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                Usuario u = new Usuario();

                u.id_usuario =
                    Convert.ToInt32(txtIdUsuario.Text);

                u.id_rol =
                    Convert.ToInt32(cbRol.SelectedValue);

                u.nombre =
                    txtNombre.Text.Trim();

                u.apellido =
                    txtApellido.Text.Trim();

                u.correo =
                    txtCorreo.Text.Trim();

                u.telefono =
                    txtTelefono.Text.Trim();

                u.nombre_usuario =
                    txtNombreUsuario.Text.Trim();

                u.contraseña =
                    txtContraseña.Text.Trim();

                u.fecha_registro =
                    dtFechaRegistro.Value;

                objBLL.ActualizarUsuario(u);

                MessageBox.Show(
                    "Usuario actualizado correctamente",
                    "Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                MostrarUsuarios();

                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================
        // ELIMINAR
        // =========================
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIdUsuario.Text == "")
                {
                    MessageBox.Show(
                        "Seleccione un usuario",
                        "Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                DialogResult r =
                    MessageBox.Show(
                        "¿Desea eliminar este usuario?",
                        "Confirmación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    int id =
                        Convert.ToInt32(txtIdUsuario.Text);

                    objBLL.Eliminar(id);

                    MessageBox.Show(
                        "Usuario eliminado correctamente",
                        "Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    MostrarUsuarios();

                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================
        // CANCELAR
        // =========================
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        // =========================
        // SELECCIONAR FILA
        // =========================
        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvUsuarios.Rows[e.RowIndex];

                txtIdUsuario.Text =
                    fila.Cells["id_usuario"].Value.ToString();

                txtNombre.Text =
                    fila.Cells["nombre"].Value.ToString();

                txtApellido.Text =
                    fila.Cells["apellido"].Value.ToString();

                txtCorreo.Text =
                    fila.Cells["correo"].Value.ToString();

                txtTelefono.Text =
                    fila.Cells["telefono"].Value.ToString();

                txtNombreUsuario.Text =
                    fila.Cells["nombre_usuario"].Value.ToString();

                txtContraseña.Text =
                    fila.Cells["contrasena"].Value.ToString();

                cbRol.SelectedValue =
                    fila.Cells["id_rol"].Value;

                    Convert.ToDateTime(
                        fila.Cells["fecha_registro"].Value);
            }
        }

        // =========================
        // BUSCAR
        // =========================
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DataTable dt = objBLL.Listar();

            DataView dv = dt.DefaultView;

            dv.RowFilter =
                $"nombre LIKE '%{txtBuscar.Text}%'";

            dgvUsuarios.DataSource = dv.ToTable();
        }

        // =========================
        // DISEÑO
        // =========================
        private void AplicarDiseno()
        {
            this.BackColor =
                Color.FromArgb(248, 244, 240);

     

            lblTitulo.ForeColor =
                Color.FromArgb(90, 70, 70);

            lblTitulo.Font =
                new Font(
                    "Segoe UI Semibold",
                    22F,
                    FontStyle.Bold);

            lblDescripcion.ForeColor =
                Color.FromArgb(140, 120, 120);

            gbDatosUsuario.BackColor =
                Color.White;

            gbListadoUsuarios.BackColor =
                Color.White;

            dgvUsuarios.BackgroundColor =
                Color.White;

            dgvUsuarios.BorderStyle =
                BorderStyle.None;

            dgvUsuarios.RowHeadersVisible =
                false;

            dgvUsuarios.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvUsuarios.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvUsuarios.MultiSelect = false;

            dgvUsuarios.EnableHeadersVisualStyles = false;

            dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(235, 225, 220);

            dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.FromArgb(90, 70, 70);

            dgvUsuarios.ColumnHeadersHeight = 38;

            BotonPrincipal(btnGuardar);

            BotonSecundario(btnNuevo);
            BotonSecundario(btnEditar);
            BotonSecundario(btnEliminar);
            BotonSecundario(btnCancelar);
        }

        private void BotonPrincipal(Button btn)
        {
            btn.BackColor =
                Color.FromArgb(170, 105, 120);

            btn.ForeColor =
                Color.White;

            btn.FlatStyle =
                FlatStyle.Flat;

            btn.FlatAppearance.BorderSize = 0;

            btn.Font =
                new Font(
                    "Segoe UI Semibold",
                    9F);

            btn.Height = 38;
        }

        private void BotonSecundario(Button btn)
        {
            btn.BackColor =
                Color.FromArgb(245, 240, 235);

            btn.ForeColor =
                Color.FromArgb(100, 80, 80);

            btn.FlatStyle =
                FlatStyle.Flat;

            btn.FlatAppearance.BorderSize = 1;

            btn.Font =
                new Font(
                    "Segoe UI",
                    9F);

            btn.Height = 38;
        }
    }
}