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

                dtFechaRegistro.Value =
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
            // FORMULARIO
            this.BackColor =
                Color.FromArgb(249, 245, 242);

            // TÍTULO
            lblTitulo.ForeColor =
                Color.FromArgb(70, 50, 48);

            lblTitulo.Font =
                new Font(
                    "Georgia",
                    22F,
                    FontStyle.Regular);

            // DESCRIPCIÓN
            lblDescripcion.ForeColor =
                Color.FromArgb(120, 110, 110);

            lblDescripcion.Font =
                new Font(
                    "Segoe UI",
                    10F);

            // GROUPBOX
            gbDatosUsuario.BackColor =
                Color.White;

            gbListadoUsuarios.BackColor =
                Color.White;

            gbDatosUsuario.ForeColor =
                Color.FromArgb(90, 70, 70);

            gbListadoUsuarios.ForeColor =
                Color.FromArgb(90, 70, 70);

            gbDatosUsuario.Font =
                new Font(
                    "Segoe UI Semibold",
                    11F,
                    FontStyle.Bold);

            gbListadoUsuarios.Font =
                new Font(
                    "Segoe UI Semibold",
                    11F,
                    FontStyle.Bold);

            // LABELS
            Label[] labels =
            {
                lblNombre,
                lblApellido,
                lblCorreo,
                lblTelefono,
                lblNombreUsuario,
                lblContraseña,
                lblRol,
                lblFecha
            };

            foreach (Label lbl in labels)
            {
                lbl.ForeColor =
                    Color.FromArgb(100, 80, 80);

                lbl.Font =
                    new Font(
                        "Segoe UI",
                        9F);
            }

            // TEXTBOX
            TextBox[] textos =
            {
                txtNombre,
                txtApellido,
                txtCorreo,
                txtTelefono,
                txtNombreUsuario,
                txtContraseña,
                txtBuscar
            };

            foreach (TextBox txt in textos)
            {
                txt.Font =
                    new Font(
                        "Segoe UI",
                        9F);

                txt.BorderStyle =
                    BorderStyle.FixedSingle;

                txt.BackColor =
                    Color.White;

                txt.ForeColor =
                    Color.FromArgb(70, 50, 48);
            }

            // COMBOBOX
            cbRol.Font =
                new Font(
                    "Segoe UI",
                    9F);

            cbRol.BackColor =
                Color.White;

            cbRol.ForeColor =
                Color.FromArgb(70, 50, 48);

            cbRol.FlatStyle =
                FlatStyle.Flat;

            // DATETIME
            dtFechaRegistro.Font =
                new Font(
                    "Segoe UI",
                    9F);

            // BOTÓN PRINCIPAL
            btnGuardar.BackColor =
                Color.FromArgb(143, 94, 104);

            btnGuardar.ForeColor =
                Color.White;

            btnGuardar.FlatStyle =
                FlatStyle.Flat;

            btnGuardar.FlatAppearance.BorderSize =
                0;

            btnGuardar.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Regular);

            btnGuardar.Height = 40;

            // BOTONES SECUNDARIOS
            Button[] botones =
            {
                btnNuevo,
                btnEditar,
                btnEliminar,
                btnCancelar,
                btnBuscar
            };

            foreach (Button btn in botones)
            {
                btn.BackColor =
                    Color.FromArgb(245, 240, 235);

                btn.ForeColor =
                    Color.FromArgb(100, 80, 80);

                btn.FlatStyle =
                    FlatStyle.Flat;

                btn.FlatAppearance.BorderColor =
                    Color.FromArgb(220, 210, 205);

                btn.FlatAppearance.BorderSize =
                    1;

                btn.Font =
                    new Font(
                        "Segoe UI",
                        9F);

                btn.Height = 38;
            }

            // DATAGRIDVIEW
            dgvUsuarios.BackgroundColor =
                Color.White;

            dgvUsuarios.BorderStyle =
                BorderStyle.None;

            dgvUsuarios.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvUsuarios.GridColor =
                Color.FromArgb(245, 240, 238);

            dgvUsuarios.RowHeadersVisible =
                false;

            dgvUsuarios.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvUsuarios.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvUsuarios.MultiSelect =
                false;

            dgvUsuarios.EnableHeadersVisualStyles =
                false;

            dgvUsuarios.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            // CABECERA
            dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(245, 238, 234);

            dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.FromArgb(70, 50, 48);

            dgvUsuarios.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            dgvUsuarios.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                Color.FromArgb(245, 238, 234);

            dgvUsuarios.ColumnHeadersHeight =
                45;

            // FILAS
            dgvUsuarios.DefaultCellStyle.BackColor =
                Color.White;

            dgvUsuarios.DefaultCellStyle.ForeColor =
                Color.FromArgb(70, 50, 48);

            dgvUsuarios.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9.5F,
                    FontStyle.Regular);

            dgvUsuarios.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(250, 245, 242);

            dgvUsuarios.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(70, 50, 48);

            dgvUsuarios.RowTemplate.Height =
                45;

            dgvUsuarios.AlternatingRowsDefaultCellStyle.BackColor =
                Color.White;
        }
    }
}