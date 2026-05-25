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
        private readonly Color colorMenuLateral = Color.RosyBrown;
        private readonly Color colorFondoGeneral = Color.FromArgb(250, 248, 246);
        private readonly Color colorVinoBotones = Color.RosyBrown;

        CitasBLL citasBLL = new CitasBLL();
        ClientesBLL clientesBLL = new ClientesBLL();
        ServiciosBLL serviciosBLL = new ServiciosBLL();
        UsuarioBLL usuarioBLL = new UsuarioBLL();

        decimal totalActual = 0;

        public FrmCitas() { InitializeComponent(); }

        private void FrmCitas_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            AplicarDiseno();

            // eventos que sí estaban
            dgvCitas.CellClick += dgvCitas_CellClick;
            clbServicios.ItemCheck += clbServicios_ItemCheck;

            // ✅ AGREGAR ESTOS — conectan el buscador y filtro
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            btnBuscar.Click += btnBuscar_Click;
            btnVerTodos.Click += btnVerTodos_Click;
            cbFiltroEstado.SelectedIndexChanged += cbFiltroEstado_SelectedIndexChanged;

            MostrarCitas();
            CargarClientes();
            CargarServicios();
            CargarEstados();
            MostrarPrecio();
        }


        void CargarEstados()
        {
            cbEstado.Items.Clear();
            cbEstado.Items.AddRange(new object[] { "Pendiente", "Confirmada", "Completada", "Cancelada" });
            cbEstado.SelectedIndex = 0;

            cbFiltroEstado.Items.Clear();
            cbFiltroEstado.Items.AddRange(new object[] { "Todos", "Pendiente", "Confirmada" });
            cbFiltroEstado.SelectedIndex = 0;
        }

        void MostrarCitas()
        {
            DataTable dt = citasBLL.Listar();
            DataView vista = dt.DefaultView;
            vista.RowFilter = "nombre_estado <> 'Completada' AND nombre_estado <> 'Cancelada'";
            dgvCitas.DataSource = vista;
            OcultarColumnas();
        }


        void BuscarCitas()
        {
            DataView vista = citasBLL.Listar().DefaultView;
            string filtro = "nombre_estado <> 'Completada' AND nombre_estado <> 'Cancelada'";

            if (cbFiltroEstado.SelectedIndex > 0)
                filtro += $" AND nombre_estado = '{cbFiltroEstado.SelectedItem}'";

            string texto = txtBuscar.Text.Trim();
            if (!string.IsNullOrEmpty(texto))
                filtro += $" AND (cliente LIKE '%{texto}%' OR descripcion LIKE '%{texto}%')";
            // ↑ este es el único cambio

            vista.RowFilter = filtro;
            dgvCitas.DataSource = vista;
            OcultarColumnas();
        }
       


        void OcultarColumnas()
        {
            foreach (string col in new[] { "id_cita", "id_cliente", "id_usuario" })
                if (dgvCitas.Columns.Contains(col))
                    dgvCitas.Columns[col].Visible = false;

            // ✅ FORMATO DE HORA
            if (dgvCitas.Columns.Contains("hora_inicio"))
                dgvCitas.Columns["hora_inicio"].DefaultCellStyle.Format = "hh\\:mm";
        }


        private void btnBuscar_Click(object sender, EventArgs e) => BuscarCitas();
        private void txtBuscar_TextChanged(object sender, EventArgs e) => BuscarCitas();
        private void cbFiltroEstado_SelectedIndexChanged(object sender, EventArgs e) => BuscarCitas();
        private void btnVerTodos_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            cbFiltroEstado.SelectedIndex = 0;
            MostrarCitas();
        }

      
        void CargarClientes()
        {
            cbCliente.DataSource = clientesBLL.Listar();
            cbCliente.DisplayMember = "nombre";
            cbCliente.ValueMember = "id_cliente";
            cbCliente.SelectedIndex = -1;
        }

        void CargarServicios()
        {
            clbServicios.DataSource = serviciosBLL.Listar();
            clbServicios.DisplayMember = "nombre_servicio";
            clbServicios.ValueMember = "id_servicio";
        }

      
        void MostrarPrecio()
        {
            totalActual = 0;
            foreach (DataRowView fila in clbServicios.CheckedItems)
                totalActual += Convert.ToDecimal(fila["precio"]);
            lblPrecio.Text = "RD$ " + totalActual.ToString("N2");
        }

        private void clbServicios_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate { MostrarPrecio(); });
        }

        // =========================
        // ✅ VALIDACIONES (reutilizable)
        // =========================
        bool ValidarCampos()
        {
            if (cbCliente.SelectedValue == null)
            {
                MessageBox.Show("⚠️ Debes seleccionar un cliente.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbCliente.Focus(); return false;
            }
            if (clbServicios.CheckedItems.Count == 0)
            {
                MessageBox.Show("⚠️ Selecciona al menos un servicio.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dtFecha.Value.Date < DateTime.Today)
            {
                MessageBox.Show("⚠️ La fecha no puede ser en el pasado.", "Fecha inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dtFecha.Value.Date == DateTime.Today && dtHora.Value.TimeOfDay < DateTime.Now.TimeOfDay)
            {
                MessageBox.Show("⚠️ La hora ya pasó para hoy.", "Hora inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("⚠️ Selecciona un estado.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // =========================
        // 🖱 CLICK GRID
        // =========================
        private void dgvCitas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow fila = dgvCitas.Rows[e.RowIndex];

            if (dgvCitas.Columns.Contains("id_cliente") && fila.Cells["id_cliente"].Value != DBNull.Value)
                cbCliente.SelectedValue = fila.Cells["id_cliente"].Value;

            if (dgvCitas.Columns.Contains("fecha") && fila.Cells["fecha"].Value != DBNull.Value)
                dtFecha.Value = Convert.ToDateTime(fila.Cells["fecha"].Value);

            if (dgvCitas.Columns.Contains("hora_inicio") && fila.Cells["hora_inicio"].Value != DBNull.Value)
                dtHora.Value = DateTime.Today.Add(TimeSpan.Parse(fila.Cells["hora_inicio"].Value.ToString()));

            txtDescripcion.Text = (dgvCitas.Columns.Contains("descripcion") && fila.Cells["descripcion"].Value != DBNull.Value)
                ? fila.Cells["descripcion"].Value.ToString() : "";

            if (dgvCitas.Columns.Contains("nombre_estado") && fila.Cells["nombre_estado"].Value != DBNull.Value)
                cbEstado.Text = fila.Cells["nombre_estado"].Value.ToString();

            if (dgvCitas.Columns.Contains("precio") && fila.Cells["precio"].Value != DBNull.Value)
                lblPrecio.Text = "RD$ " + Convert.ToDecimal(fila.Cells["precio"].Value).ToString("N2");

            // LIMPIAR Y MARCAR SERVICIOS
            for (int i = 0; i < clbServicios.Items.Count; i++)
                clbServicios.SetItemChecked(i, false);

            if (dgvCitas.Columns.Contains("id_cita") && fila.Cells["id_cita"].Value != DBNull.Value)
            {
                int idCita = Convert.ToInt32(fila.Cells["id_cita"].Value);
                DataTable detalles = new DetalleCitas_BLL().ObtenerPorCita(idCita);

                foreach (DataRow detalle in detalles.Rows)
                {
                    int idServicio = Convert.ToInt32(detalle["id_servicio"]);
                    for (int i = 0; i < clbServicios.Items.Count; i++)
                    {
                        DataRowView item = (DataRowView)clbServicios.Items[i];
                        if (Convert.ToInt32(item["id_servicio"]) == idServicio)
                        { clbServicios.SetItemChecked(i, true); break; }
                    }
                }
            }
        }

      

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;
            try
            {
                Citas c = new Citas
                {
                    id_cliente = Convert.ToInt32(cbCliente.SelectedValue),
                    id_usuario = 1,
                    fecha = dtFecha.Value,
                    hora_inicio = dtHora.Value.TimeOfDay,
                    precio = totalActual,
                    descripcion = txtDescripcion.Text,
                    nombre_estado = cbEstado.Text
                };
                citasBLL.Guardar(c, clbServicios.CheckedItems);
                MessageBox.Show("Cita guardada correctamente");
                MostrarCitas(); LimpiarCampos();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

      

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCitas.CurrentRow == null) return;
            if (MessageBox.Show("¿Eliminar cita?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                citasBLL.Eliminar(Convert.ToInt32(dgvCitas.CurrentRow.Cells["id_cita"].Value));
                MessageBox.Show("Cita eliminada");
                MostrarCitas(); LimpiarCampos();
            }
        }

      

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvCitas.CurrentRow == null)
            {
                MessageBox.Show("⚠️ Selecciona una cita de la tabla para actualizar.", "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidarCampos()) return;
            try
            {
                Citas c = new Citas
                {
                    id_cita = Convert.ToInt32(dgvCitas.CurrentRow.Cells["id_cita"].Value),
                    id_cliente = Convert.ToInt32(cbCliente.SelectedValue),
                    id_usuario = Convert.ToInt32(dgvCitas.CurrentRow.Cells["id_usuario"].Value),
                    fecha = dtFecha.Value,
                    hora_inicio = dtHora.Value.TimeOfDay,
                    precio = totalActual,
                    descripcion = txtDescripcion.Text,
                    nombre_estado = cbEstado.Text
                };
                citasBLL.Actualizar(c, clbServicios.CheckedItems);
                MessageBox.Show("Cita actualizada");
                MostrarCitas(); LimpiarCampos();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

      

        private void btnLimpiar_Click(object sender, EventArgs e) => LimpiarCampos();

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            new FrmHistorialCitas().Show();
        }

        private void BtnHistorial_Click(object sender, EventArgs e)
        {
            new FrmHistorialCitas().ShowDialog();
        }

        private void LimpiarCampos()
        {
            cbCliente.SelectedIndex = -1;
            for (int i = 0; i < clbServicios.Items.Count; i++)
                clbServicios.SetItemChecked(i, false);
            dtFecha.Value = DateTime.Now;
            dtHora.Value = DateTime.Now;
            txtDescripcion.Clear();
            lblPrecio.Text = "RD$ 0.00";
            cbEstado.SelectedIndex = 0;
            dgvCitas.ClearSelection();
        }

     
        void EstilarBoton(Button btn, Color fondo, Color texto, bool negrita = false)
        {
            btn.BackColor = fondo;
            btn.ForeColor = texto;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI" + (negrita ? " Semibold" : ""), 10F);
            btn.Height = 40;
        }

        private void AplicarDiseno()
        {
            this.BackColor = colorFondoGeneral;

            panelCitas.BackColor =
                Color.White;

            panelTabla.BackColor =
                Color.White;

            // =========================================
            // TITULO
            // =========================================

            lblTitulo.ForeColor =
                colorMenuLateral;

            lblTitulo.Font =
                new Font(
                    "Georgia",
                    22,
                    FontStyle.Regular);

            // =========================================
            // LABELS
            // =========================================

            foreach (Label lbl in new[]
            {
        lblCliente,
        lblServicio,
        lblFecha,
        lblHora
    })
            {
                lbl.ForeColor =
                    Color.FromArgb(70, 50, 48);

                lbl.Font =
                    new Font(
                        "Segoe UI",
                        10F,
                        FontStyle.Regular);
            }

            // =========================================
            // COMBOBOX
            // =========================================

            foreach (ComboBox cb in new[]
            {
        cbCliente,
        cbEstado,
        cbFiltroEstado
    })
            {
                cb.BackColor =
                    Color.White;

                cb.ForeColor =
                    Color.FromArgb(70, 50, 48);

                cb.FlatStyle =
                    FlatStyle.Flat;

                cb.Font =
                    new Font(
                        "Segoe UI",
                        10F,
                        FontStyle.Regular);
            }

            // =========================================
            // CHECKLIST
            // =========================================

            clbServicios.BackColor =
                Color.White;

            clbServicios.ForeColor =
                Color.FromArgb(70, 50, 48);

            clbServicios.BorderStyle =
                BorderStyle.FixedSingle;

            clbServicios.Font =
                new Font(
                    "Segoe UI",
                    9.5F,
                    FontStyle.Regular);

            // =========================================
            // TEXTBOXES
            // =========================================

            txtDescripcion.BackColor =
                Color.White;

            txtDescripcion.ForeColor =
                Color.FromArgb(70, 50, 48);

            txtDescripcion.BorderStyle =
                BorderStyle.FixedSingle;

            txtDescripcion.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Regular);

            txtBuscar.BackColor =
                Color.White;

            txtBuscar.ForeColor =
                Color.FromArgb(70, 50, 48);

            txtBuscar.BorderStyle =
                BorderStyle.FixedSingle;

            txtBuscar.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Regular);

            // =========================================
            // DATE TIME PICKER
            // =========================================

            dtFecha.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Regular);

            dtHora.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Regular);

            // =========================================
            // PRECIO
            // =========================================

            lblPrecio.ForeColor =
                colorMenuLateral;

            lblPrecio.Font =
                new Font(
                    "Georgia",
                    16F,
                    FontStyle.Bold);

            // =========================================
            // BOTONES
            // =========================================

            Color beige =
                Color.FromArgb(242, 235, 231);

            EstilarBoton(
                btnGuardar,
                colorVinoBotones,
                Color.White,
                true);

            EstilarBoton(
                btnActualizar,
                colorVinoBotones,
                Color.White,
                true);

            EstilarBoton(
                btnBuscar,
                colorVinoBotones,
                Color.White,
                true);

            EstilarBoton(
                btnVerTodos,
                beige,
                colorMenuLateral);

            EstilarBoton(
                btnLimpiar,
                beige,
                colorMenuLateral);

            EstilarBoton(
                btnEliminar,
                beige,
                colorMenuLateral);

            EstilarBoton(
                btnHistorial,
                beige,
                colorMenuLateral,
                true);

            // =========================================
            // DATAGRIDVIEW
            // =========================================

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
                Color.FromArgb(245, 238, 234);

            dgvCitas.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.FromArgb(70, 50, 48);

            dgvCitas.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            dgvCitas.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                Color.FromArgb(245, 238, 234);

            dgvCitas.ColumnHeadersHeight =
                45;

            dgvCitas.DefaultCellStyle.BackColor =
                Color.White;

            dgvCitas.DefaultCellStyle.ForeColor =
                Color.FromArgb(70, 50, 48);

            dgvCitas.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9.5F,
                    FontStyle.Regular);

            dgvCitas.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(250, 245, 242);

            dgvCitas.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(70, 50, 48);

            dgvCitas.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(248, 244, 242);

            dgvCitas.GridColor =
                Color.FromArgb(235, 230, 228);

            dgvCitas.RowTemplate.Height =
                42;
        }
    }
}