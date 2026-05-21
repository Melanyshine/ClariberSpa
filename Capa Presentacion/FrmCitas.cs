using CapaEntidades;
using CapaNegocio;
using CapaPresentacion;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Capa_Presentacion
{
    public partial class FrmCitas : Form
    {
        // 🎨 COLORES
        private readonly Color colorMenuLateral =
            Color.RosyBrown;

        private readonly Color colorFondoGeneral =
            Color.FromArgb(250, 248, 246);

        private readonly Color colorVinoBotones =
            Color.RosyBrown;

        CitasBLL citasBLL =
            new CitasBLL();

        ClientesBLL clientesBLL =
            new ClientesBLL();

        ServiciosBLL serviciosBLL =
            new ServiciosBLL();

        UsuarioBLL usuarioBLL =
            new UsuarioBLL();

        decimal totalActual = 0;

        public FrmCitas()
        {
            InitializeComponent();
        }

        private void FrmCitas_Load(
            object sender,
            EventArgs e)
        {
          
            this.WindowState =
                FormWindowState.Maximized;

            AplicarDiseno();

            dgvCitas.CellClick += dgvCitas_CellClick;

            clbServicios.ItemCheck +=
                clbServicios_ItemCheck;

            MostrarCitas();

            CargarClientes();

            CargarServicios();

            CargarEstados();

            MostrarPrecio();
        }

        // =========================
        // 📌 ESTADOS
        // =========================
        void CargarEstados()
        {
            cbEstado.Items.Clear();

            cbEstado.Items.Add("Pendiente");
            cbEstado.Items.Add("Confirmada");
            cbEstado.Items.Add("Completada");
            cbEstado.Items.Add("Cancelada");

            cbEstado.SelectedIndex = 0;
        }

        // =========================
        // 📦 MOSTRAR CITAS
        // =========================
        void MostrarCitas()
        {
            dgvCitas.DataSource =
                citasBLL.Listar();

            // 🔥 OCULTAR IDS
            if (dgvCitas.Columns.Contains("id_cita"))
                dgvCitas.Columns["id_cita"].Visible = false;

            if (dgvCitas.Columns.Contains("id_cliente"))
                dgvCitas.Columns["id_cliente"].Visible = false;

            if (dgvCitas.Columns.Contains("id_servicio"))
                dgvCitas.Columns["id_servicio"].Visible = false;

            if (dgvCitas.Columns.Contains("id_usuario"))
                dgvCitas.Columns["id_usuario"].Visible = false;
        }

        // =========================
        // 👤 CLIENTES
        // =========================
        void CargarClientes()
        {
            cbCliente.DataSource =
                clientesBLL.Listar();

            cbCliente.DisplayMember =
                "nombre";

            cbCliente.ValueMember =
                "id_cliente";

            cbCliente.SelectedIndex = -1;
        }

        // =========================
        // 💆 SERVICIOS
        // =========================
        void CargarServicios()
        {
            clbServicios.DataSource =
                serviciosBLL.Listar();

            clbServicios.DisplayMember =
                "nombre_servicio";

            clbServicios.ValueMember =
                "id_servicio";
        }

        // =========================
        // 💰 PRECIO
        // =========================
        void MostrarPrecio()
        {
            totalActual = 0;

            foreach (DataRowView fila
                in clbServicios.CheckedItems)
            {
                totalActual +=
                    Convert.ToDecimal(
                    fila["precio"]);
            }

            lblPrecio.Text =
                "RD$ " +
                totalActual.ToString("N2");
        }

        private void clbServicios_ItemCheck(
            object sender,
            ItemCheckEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                MostrarPrecio();
            });
        }

        // =========================
        // 🖱 CLICK GRID
        // =========================
        private void dgvCitas_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila =
                dgvCitas.Rows[e.RowIndex];

            // CLIENTE
            if (dgvCitas.Columns.Contains("id_cliente"))
            {
                cbCliente.SelectedValue =
                    fila.Cells["id_cliente"].Value;
            }

            // FECHA
            if (dgvCitas.Columns.Contains("fecha"))
            {
                dtFecha.Value =
                    Convert.ToDateTime(
                    fila.Cells["fecha"].Value);
            }

            // HORA
            if (dgvCitas.Columns.Contains("hora_inicio"))
            {
                TimeSpan hora =
                    TimeSpan.Parse(
                    fila.Cells["hora_inicio"]
                    .Value
                    .ToString());

                dtHora.Value =
                    DateTime.Today.Add(hora);
            }

            // DESCRIPCIÓN
            if (dgvCitas.Columns.Contains("descripcion"))
            {
                txtDescripcion.Text =
                    fila.Cells["descripcion"]
                    .Value
                    .ToString();
            }

            // ESTADO
            if (dgvCitas.Columns.Contains("nombre_estado"))
            {
                cbEstado.Text =
                    fila.Cells["nombre_estado"]
                    .Value
                    .ToString();
            }

            // PRECIO
            if (dgvCitas.Columns.Contains("precio"))
            {
                lblPrecio.Text =
                    "RD$ " +
                    fila.Cells["precio"]
                    .Value
                    .ToString();
            }

            // LIMPIAR CHECKS
            for (int i = 0; i < clbServicios.Items.Count; i++)
            {
                clbServicios.SetItemChecked(i, false);
            }

            // MARCAR SERVICIO
            if (dgvCitas.Columns.Contains("id_servicio"))
            {
                int idServicio =
                    Convert.ToInt32(
                    fila.Cells["id_servicio"].Value);

                for (int i = 0; i < clbServicios.Items.Count; i++)
                {
                    DataRowView item =
                        (DataRowView)clbServicios.Items[i];

                    if (Convert.ToInt32(item["id_servicio"]) == idServicio)
                    {
                        clbServicios.SetItemChecked(i, true);
                        break;
                    }
                }
            }
        }

        // =========================
        // 💾 GUARDAR
        // =========================
        // 💾 GUARDAR
        private void btnGuardar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (clbServicios.CheckedItems.Count == 0)
                {
                    MessageBox.Show(
                        "Seleccione al menos un servicio");

                    return;
                }

                DataRowView servicio =
                    (DataRowView)
                    clbServicios.CheckedItems[0];

                Citas c = new Citas();

                c.id_cliente =
                    Convert.ToInt32(
                    cbCliente.SelectedValue);

                c.id_servicio =
                    Convert.ToInt32(
                    servicio["id_servicio"]);

                // 🔥 SOLO ESTE CAMBIO
                c.id_usuario =
                    Convert.ToInt32(
                    dgvCitas.CurrentRow != null
                    ? dgvCitas.CurrentRow.Cells["id_usuario"].Value
                    : 1);

                c.fecha =
                    dtFecha.Value;

                c.hora_inicio =
                    dtHora.Value.TimeOfDay;

                c.precio =
                    totalActual;

                c.descripcion =
                    txtDescripcion.Text;

                c.nombre_estado =
                    cbEstado.Text;

                citasBLL.Guardar(c);

                MessageBox.Show(
                    "Cita guardada correctamente");

                MostrarCitas();

                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error: " + ex.Message);
            }
        }
        // =========================
        // 🗑 ELIMINAR
        // =========================
        private void btnEliminar_Click(
            object sender,
            EventArgs e)
        {
            if (dgvCitas.CurrentRow != null)
            {
                DialogResult r =
                    MessageBox.Show(
                    "¿Eliminar cita?",
                    "Confirmar",
                    MessageBoxButtons.YesNo);

                if (r == DialogResult.Yes)
                {
                    int id =
                        Convert.ToInt32(
                        dgvCitas.CurrentRow
                        .Cells["id_cita"]
                        .Value);

                    citasBLL.Eliminar(id);

                    MessageBox.Show(
                        "Cita eliminada");

                    MostrarCitas();

                    LimpiarCampos();
                }
            }
        }


        private void btnActualizar_Click(
   object sender,
   EventArgs e)
        {
            try
            {
                if (dgvCitas.CurrentRow == null)
                {
                    MessageBox.Show(
                        "Seleccione una cita");

                    return;
                }

                if (clbServicios.CheckedItems.Count == 0)
                {
                    MessageBox.Show(
                        "Seleccione al menos un servicio");

                    return;
                }

                DataRowView servicio =
                    (DataRowView)
                    clbServicios.CheckedItems[0];

                Citas c =
                    new Citas();

                c.id_cita =
                    Convert.ToInt32(
                    dgvCitas.CurrentRow
                    .Cells["id_cita"]
                    .Value);

                c.id_cliente =
                    Convert.ToInt32(
                    cbCliente.SelectedValue);

                c.id_servicio =
                    Convert.ToInt32(
                    servicio["id_servicio"]);
                c.id_cita =
    Convert.ToInt32(
    dgvCitas.CurrentRow.Cells["id_cita"].Value);

                c.id_cliente =
                    Convert.ToInt32(
                    cbCliente.SelectedValue);

                c.id_servicio =
                    Convert.ToInt32(
                    servicio["id_servicio"]);

                // ✅ AGREGAR ESTO
                c.id_usuario =
                    Convert.ToInt32(
                    dgvCitas.CurrentRow.Cells["id_usuario"].Value);

                c.fecha =
                    dtFecha.Value;

                c.fecha =
                    dtFecha.Value;

                c.hora_inicio =
                    dtHora.Value.TimeOfDay;

                c.precio =
                    totalActual;

                c.descripcion =
                    txtDescripcion.Text;

                c.nombre_estado =
                    cbEstado.Text;

                citasBLL.Actualizar(c);

                MessageBox.Show(
                    "Cita actualizada");

                MostrarCitas();

                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error: " + ex.Message);
            }
        }


        // =========================
        // 🧹 LIMPIAR
        // =========================
        private void btnLimpiar_Click(
            object sender,
            EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnHistorial_Click(
            object sender,
            EventArgs e)
        {
            FrmHistorialCitas frm =
                new FrmHistorialCitas();

            frm.Show();
        }

        private void LimpiarCampos()
        {
            cbCliente.SelectedIndex = -1;

            for (int i = 0;
                i < clbServicios.Items.Count;
                i++)
            {
                clbServicios.SetItemChecked(i, false);
            }

            dtFecha.Value =
                DateTime.Now;

            dtHora.Value =
                DateTime.Now;

            txtDescripcion.Clear();

            lblPrecio.Text =
                "RD$ 0.00";

            cbEstado.SelectedIndex = 0;

            dgvCitas.ClearSelection();
        }

        // =========================
        // 🎨 DISEÑO
        // =========================
        private void AplicarDiseno()
        {
            // FORM
            this.BackColor =
                colorFondoGeneral;

            // PANEL MENU
            panelMenu.BackColor =
                colorMenuLateral;

            // PANEL CITA
            panelCitas.BackColor =
                Color.White;

            // PANEL TABLA
            panelTabla.BackColor =
                Color.White;

            // TITULO
            lblTitulo.ForeColor =
                colorMenuLateral;

            lblTitulo.Font =
                new Font(
                    "Segoe UI Semibold",
                    20F,
                    FontStyle.Bold);

            // LABELS
            Label[] labels =
            {
                lblCliente,
                lblServicio,
                lblFecha,
                lblHora
            };

            foreach (Label lbl in labels)
            {
                lbl.ForeColor =
                    Color.Black;

                lbl.Font =
                    new Font(
                        "Segoe UI",
                        9F);
            }

            // COMBO CLIENTE
            cbCliente.BackColor =
                Color.White;

            cbCliente.ForeColor =
                Color.Black;

            cbCliente.FlatStyle =
                FlatStyle.Flat;

            cbCliente.Font =
                new Font(
                    "Segoe UI",
                    9F);

            // COMBO ESTADO
            cbEstado.BackColor =
                Color.White;

            cbEstado.ForeColor =
                Color.Black;

            cbEstado.FlatStyle =
                FlatStyle.Flat;

            cbEstado.Font =
                new Font(
                    "Segoe UI",
                    9F);

            cbEstado.Height = 35;

            // CHECKLIST SERVICIOS
            clbServicios.BackColor =
                Color.White;

            clbServicios.ForeColor =
                Color.Black;

            clbServicios.BorderStyle =
                BorderStyle.FixedSingle;

            clbServicios.Font =
                new Font(
                    "Segoe UI",
                    9F);

            clbServicios.CheckOnClick = true;

            // TEXTBOX
            txtDescripcion.BackColor =
                Color.White;

            txtDescripcion.ForeColor =
                colorMenuLateral;

            txtDescripcion.BorderStyle =
                BorderStyle.FixedSingle;

            txtDescripcion.Font =
                new Font(
                    "Segoe UI",
                    9F);

            // FECHA
            dtFecha.Font =
                new Font(
                    "Segoe UI",
                    9F);

            dtHora.Font =
                new Font(
                    "Segoe UI",
                    9F);

            // PRECIO
            lblPrecio.ForeColor =
                colorMenuLateral;

            lblPrecio.Font =
                new Font(
                    "Segoe UI Semibold",
                    18F,
                    FontStyle.Bold);

            // GUARDAR
            btnGuardar.BackColor =
                colorVinoBotones;

            btnGuardar.ForeColor =
                Color.White;

            btnGuardar.FlatStyle =
                FlatStyle.Flat;

            btnGuardar.FlatAppearance.BorderSize = 0;

            btnGuardar.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F);

            btnGuardar.Height = 40;

            // LIMPIAR
            btnLimpiar.BackColor =
                Color.FromArgb(242, 235, 231);

            btnLimpiar.ForeColor =
                colorMenuLateral;

            btnLimpiar.FlatStyle =
                FlatStyle.Flat;

            btnLimpiar.FlatAppearance.BorderSize = 0;

            btnLimpiar.Font =
                new Font(
                    "Segoe UI",
                    10F);

            btnLimpiar.Height = 40;

            // ELIMINAR
            btnEliminar.BackColor =
                Color.FromArgb(242, 235, 231);

            btnEliminar.ForeColor =
                colorMenuLateral;

            btnEliminar.FlatStyle =
                FlatStyle.Flat;

            btnEliminar.FlatAppearance.BorderSize = 0;

            btnEliminar.Height = 40;

            // TABLA
            dgvCitas.BackgroundColor =
                Color.White;

            dgvCitas.BorderStyle =
                BorderStyle.None;

            dgvCitas.RowHeadersVisible =
                false;

            dgvCitas.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvCitas.EnableHeadersVisualStyles =
                false;

            dgvCitas.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            dgvCitas.ColumnHeadersDefaultCellStyle.BackColor =
                colorVinoBotones;

            dgvCitas.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvCitas.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI Semibold",
                    9F);

            dgvCitas.ColumnHeadersHeight = 38;

            dgvCitas.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9F);

            dgvCitas.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(230, 210, 215);

            dgvCitas.DefaultCellStyle.SelectionForeColor =
                Color.Black;

            dgvCitas.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(248, 244, 242);

            dgvCitas.GridColor =
                Color.FromArgb(235, 230, 228);
        }
    }
}