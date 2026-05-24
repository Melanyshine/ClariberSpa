using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;

namespace Capa_Presentacion
{
    public partial class FrmDisponibilidad : Form
    {
        DisponibilidadBLL bll =
            new DisponibilidadBLL();

        public FrmDisponibilidad()
        {
            InitializeComponent();

            this.WindowState =
                FormWindowState.Maximized;

            dgvDisponibilidad.CellClick +=
                dgvDisponibilidad_CellClick;

            AplicarDiseno();
        }

        // ======================================
        // LOAD
        // ======================================
        private void FrmDisponibilidad_Load(
            object sender,
            EventArgs e)
        {
            txtIdDisponibilidad.Visible =
                false;

            dgvDisponibilidad.ReadOnly =
                true;

            dgvDisponibilidad.AllowUserToAddRows =
                false;

            dgvDisponibilidad.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvDisponibilidad.MultiSelect =
                false;

            CargarUsuarios();

            MostrarDisponibilidad();

            Limpiar();
        }

        // ======================================
        // CARGAR USUARIOS
        // ======================================
        private void CargarUsuarios()
        {
            cbUsuario.DataSource =
                bll.ListarUsuarios();

            cbUsuario.DisplayMember =
                "Usuario";

            cbUsuario.ValueMember =
                "id_usuario";

            cbUsuario.SelectedIndex =
                -1;
        }

        // ======================================
        // MOSTRAR
        // ======================================
        private void MostrarDisponibilidad()
        {
            dgvDisponibilidad.DataSource =
                bll.Listar();

            if (dgvDisponibilidad.Columns["id_disponibilidad"] != null)
                dgvDisponibilidad.Columns["id_disponibilidad"].Visible = false;

            if (dgvDisponibilidad.Columns["id_usuario"] != null)
                dgvDisponibilidad.Columns["id_usuario"].Visible = false;

            // FORMATO HORA
            if (dgvDisponibilidad.Columns["hora_inicio"] != null)
            {
                dgvDisponibilidad.Columns["hora_inicio"]
                    .DefaultCellStyle.Format = "hh\\:mm";
            }

            if (dgvDisponibilidad.Columns["hora_fin"] != null)
            {
                dgvDisponibilidad.Columns["hora_fin"]
                    .DefaultCellStyle.Format = "hh\\:mm";
            }
        }
        
        // ======================================
        // LIMPIAR
        // ======================================
        private void Limpiar()
        {
            txtIdDisponibilidad.Clear();

            cbUsuario.SelectedIndex =
                -1;

            dtFecha.Value =
                DateTime.Now;

            dtHoraInicio.Value =
                DateTime.Now;

            dtHoraFin.Value =
                DateTime.Now;

            dgvDisponibilidad.ClearSelection();
        }

        // ======================================
        // GUARDAR
        // ======================================
        private void btnGuardar_Click(
            object sender,
            EventArgs e)
        {
            if (cbUsuario.SelectedValue == null)
            {
                MessageBox.Show(
                    "Seleccione un usuario");

                return;
            }

            Disponibilidad d =
                new Disponibilidad();

            d.id_usuario =
                Convert.ToInt32(
                    cbUsuario.SelectedValue);

            d.fecha =
                dtFecha.Value.Date;

            d.hora_inicio =
                dtHoraInicio.Value.TimeOfDay;

            d.hora_fin =
                dtHoraFin.Value.TimeOfDay;

            bll.Guardar(d);

            MessageBox.Show(
                "Disponibilidad guardada");

            MostrarDisponibilidad();

            Limpiar();
        }

        // ======================================
        // EDITAR
        // ======================================
        private void btnEditar_Click(
            object sender,
            EventArgs e)
        {
            if (txtIdDisponibilidad.Text == "")
            {
                MessageBox.Show(
                    "Seleccione un registro");

                return;
            }

            Disponibilidad d =
                new Disponibilidad();

            d.id_disponibilidad =
                Convert.ToInt32(
                    txtIdDisponibilidad.Text);

            d.id_usuario =
                Convert.ToInt32(
                    cbUsuario.SelectedValue);

            d.fecha =
                dtFecha.Value.Date;

            d.hora_inicio =
                dtHoraInicio.Value.TimeOfDay;

            d.hora_fin =
                dtHoraFin.Value.TimeOfDay;

            bll.Guardar(d);

            MessageBox.Show(
                "Disponibilidad actualizada");

            MostrarDisponibilidad();

            Limpiar();
        }

        // ======================================
        // ELIMINAR
        // ======================================
        private void btnEliminar_Click(
            object sender,
            EventArgs e)
        {
            if (txtIdDisponibilidad.Text == "")
            {
                MessageBox.Show(
                    "Seleccione un registro");

                return;
            }

            DialogResult r =
                MessageBox.Show(
                    "¿Desea eliminar?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {
                int id =
                    Convert.ToInt32(
                        txtIdDisponibilidad.Text);

                bll.Eliminar(id);

                MessageBox.Show(
                    "Disponibilidad eliminada");

                MostrarDisponibilidad();

                Limpiar();
            }
        }

        // ======================================
        // LIMPIAR BUTTON
        // ======================================
        private void btnLimpiar_Click(
            object sender,
            EventArgs e)
        {
            Limpiar();
        }

        // ======================================
        // CLICK DGV
        // ======================================
        private void dgvDisponibilidad_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            txtIdDisponibilidad.Text =
                dgvDisponibilidad.Rows[e.RowIndex]
                .Cells["id_disponibilidad"]
                .Value.ToString();

            cbUsuario.SelectedValue =
                dgvDisponibilidad.Rows[e.RowIndex]
                .Cells["id_usuario"]
                .Value;

            dtFecha.Value =
                Convert.ToDateTime(
                    dgvDisponibilidad.Rows[e.RowIndex]
                    .Cells["fecha"]
                    .Value);

            dtHoraInicio.Value =
                DateTime.Today.Add(
                    (TimeSpan)dgvDisponibilidad
                    .Rows[e.RowIndex]
                    .Cells["hora_inicio"]
                    .Value);

            dtHoraFin.Value =
                DateTime.Today.Add(
                    (TimeSpan)dgvDisponibilidad
                    .Rows[e.RowIndex]
                    .Cells["hora_fin"]
                    .Value);
        }

        // ======================================
        // DISEÑO
        // ======================================
        // ======================================
        // DISEÑO ESTILO SERVICIO
        // ======================================
        private void AplicarDiseno()
        {
            // ======================================
            // FORM
            // ======================================
            this.BackColor =
                Color.FromArgb(249, 245, 242);

            // ======================================
            // TITULO
            // ======================================
            lblTitulo.Font =
                new Font(
                    "Georgia",
                    22F,
                    FontStyle.Regular);

            lblTitulo.ForeColor =
                Color.FromArgb(70, 50, 48);

            // ======================================
            // DESCRIPCION
            // ======================================
            lblDescripcion.Font =
                new Font(
                    "Segoe UI",
                    10F);

            lblDescripcion.ForeColor =
                Color.FromArgb(120, 110, 110);

            // ======================================
            // GROUPBOX
            // ======================================
            gbDisponibilidad.BackColor =
                Color.White;

            gbListado.BackColor =
                Color.White;

            gbDisponibilidad.ForeColor =
                Color.FromArgb(70, 50, 48);

            gbListado.ForeColor =
                Color.FromArgb(70, 50, 48);

            gbDisponibilidad.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold);

            gbListado.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold);

            // ======================================
            // LABELS
            // ======================================
            Label[] labels =
            {
        lblUsuario,
        lblFecha,
        lblHoraInicio,
        lblHoraFin
    };

            foreach (Label lbl in labels)
            {
                lbl.ForeColor =
                    Color.FromArgb(70, 50, 48);

                lbl.Font =
                    new Font(
                        "Segoe UI",
                        9.5F);
            }

            // ======================================
            // COMBOBOX
            // ======================================
            cbUsuario.BackColor =
                Color.White;

            cbUsuario.ForeColor =
                Color.FromArgb(70, 50, 48);

            cbUsuario.FlatStyle =
                FlatStyle.Flat;

            cbUsuario.Font =
                new Font(
                    "Segoe UI",
                    9.5F);

            // ======================================
            // DATETIME
            // ======================================
            dtFecha.Font =
                new Font(
                    "Segoe UI",
                    9.5F);

            dtHoraInicio.Font =
                new Font(
                    "Segoe UI",
                    9.5F);

            dtHoraFin.Font =
                new Font(
                    "Segoe UI",
                    9.5F);

            // ======================================
            // BOTON GUARDAR
            // ======================================
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

   

            // ======================================
            // BOTONES SECUNDARIOS
            // ======================================
            Button[] botones =
            {
        btnEditar,
        btnEliminar,
        btnLimpiar,

    };

            foreach (Button btn in botones)
            {
                btn.BackColor =
                    Color.White;

                btn.ForeColor =
                    Color.FromArgb(70, 50, 48);

                btn.FlatStyle =
                    FlatStyle.Flat;

                btn.FlatAppearance.BorderColor =
                    Color.FromArgb(230, 220, 215);

                btn.FlatAppearance.BorderSize =
                    1;

                btn.Font =
                    new Font(
                        "Segoe UI",
                        9F,
                        FontStyle.Regular);


            }

            // ======================================
            // DATAGRIDVIEW
            // ======================================
            dgvDisponibilidad.BackgroundColor =
                Color.White;

            dgvDisponibilidad.BorderStyle =
                BorderStyle.None;

            dgvDisponibilidad.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvDisponibilidad.GridColor =
                Color.FromArgb(245, 240, 238);

            dgvDisponibilidad.EnableHeadersVisualStyles =
                false;

            dgvDisponibilidad.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            // CABECERA
            dgvDisponibilidad.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(245, 238, 234);

            dgvDisponibilidad.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.FromArgb(70, 50, 48);

            dgvDisponibilidad.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            dgvDisponibilidad.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                Color.FromArgb(245, 238, 234);

            dgvDisponibilidad.ColumnHeadersHeight =
                45;

            // FILAS
            dgvDisponibilidad.DefaultCellStyle.BackColor =
                Color.White;

            dgvDisponibilidad.DefaultCellStyle.ForeColor =
                Color.FromArgb(70, 50, 48);

            dgvDisponibilidad.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9.5F,
                    FontStyle.Regular);

            dgvDisponibilidad.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(250, 245, 242);

            dgvDisponibilidad.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(70, 50, 48);

            dgvDisponibilidad.RowTemplate.Height =
                45;

            dgvDisponibilidad.RowHeadersVisible =
                false;

            dgvDisponibilidad.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvDisponibilidad.AllowUserToAddRows =
                false;
        }


        // ======================================
        // BOTON PRINCIPAL
        // ======================================
        private void BotonPrincipal(Button btn)
        {
            btn.BackColor =
                Color.FromArgb(170, 105, 120);

            btn.ForeColor =
                Color.White;

            btn.FlatStyle =
                FlatStyle.Flat;

            btn.FlatAppearance.BorderSize =
                0;

            btn.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold);

            btn.Height =
                40;
        }

        // ======================================
        // BOTONES SECUNDARIOS
        // ======================================
        private void BotonSecundario(Button btn)
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
                    10F);

            btn.Height =
                40;
        }

        // ======================================
        // NUEVO
        // ======================================
        private void btnNuevo_Click(
            object sender,
            EventArgs e)
        {
            Limpiar();
        }
    }
}