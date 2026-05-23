using CapaEntidades;
using CapaNegocio;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Capa_Presentacion
{
    public partial class FrmFactura : Form
    {
        private readonly Color colorRosado = Color.RosyBrown;
        private readonly Color colorFondo = Color.FromArgb(250, 248, 246);
        private readonly Color colorVino = Color.RosyBrown;

        Detalle_FacturaBLL detalleBLL = new Detalle_FacturaBLL();
        FacturaBLL facturaBLL = new FacturaBLL();
        ServiciosBLL servicioBLL = new ServiciosBLL();

        public FrmFactura() { InitializeComponent(); }

        private void FrmFacturaPagos_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            AplicarDiseno();

            txtBuscar.TextChanged += txtBuscar_TextChanged;
            btnBuscar.Click += btnBuscar_Click;
            cbFiltroFactura.SelectedIndexChanged += cbFiltroFactura_SelectedIndexChanged;
            cbServicio.SelectedIndexChanged += cbServicio_SelectedIndexChanged;
            nudCantidad.ValueChanged += nudCantidad_ValueChanged;
            dgvDetalle.CellClick += dgvDetalle_CellClick;
            btnVerDetalle.Click += btnVerDetalle_Click;

            CargarFacturas();
            CargarServicios();
            CargarFiltro();
            MostrarDetalles();
        }

        // =========================
        // 📌 CARGAR COMBOS
        // =========================
        void CargarFacturas()
        {
            cbFactura.DataSource = facturaBLL.Listar();
            cbFactura.DisplayMember = "id_factura";
            cbFactura.ValueMember = "id_factura";
            cbFactura.SelectedIndex = -1;
        }

        void CargarServicios()
        {
            cbServicio.DataSource = servicioBLL.Listar();
            cbServicio.DisplayMember = "nombre_servicio";
            cbServicio.ValueMember = "id_servicio";
            cbServicio.SelectedIndex = -1;
        }

        void CargarFiltro()
        {
            cbFiltroFactura.Items.Clear();
            cbFiltroFactura.Items.Add("Todas");
            DataTable dt = facturaBLL.Listar();
            foreach (DataRow fila in dt.Rows)
                cbFiltroFactura.Items.Add(fila["id_factura"].ToString());
            cbFiltroFactura.SelectedIndex = 0;
        }

        // =========================
        // 💰 CALCULAR SUBTOTAL
        // =========================
        void Calcular()
        {
            if (cbServicio.SelectedValue == null) return;
            DataRowView fila = (DataRowView)cbServicio.SelectedItem;
            decimal precio = Convert.ToDecimal(fila["precio"]);
            lblSubtotal.Text = "RD$ " + (precio * nudCantidad.Value).ToString("N2");
        }

        private void cbServicio_SelectedIndexChanged(object sender, EventArgs e) => Calcular();
        private void nudCantidad_ValueChanged(object sender, EventArgs e) => Calcular();

        // =========================
        // 📦 MOSTRAR DETALLES
        // =========================
        void MostrarDetalles()
        {
            dgvDetalle.DataSource = detalleBLL.Listar();
            OcultarColumnas();
        }

        // =========================
        // 🔍 BUSCAR
        // =========================
        void BuscarDetalles()
        {
            DataView vista = detalleBLL.Listar().DefaultView;
            string filtro = "";

            if (cbFiltroFactura.SelectedIndex > 0)
                filtro = $"id_factura = {cbFiltroFactura.SelectedItem}";

            string texto = txtBuscar.Text.Trim();
            if (!string.IsNullOrEmpty(texto))
            {
                string tf = $"descripcion LIKE '%{texto}%'";
                filtro = string.IsNullOrEmpty(filtro) ? tf : filtro + " AND " + tf;
            }

            vista.RowFilter = filtro;
            dgvDetalle.DataSource = vista;
            OcultarColumnas();
        }

        void OcultarColumnas()
        {
            if (dgvDetalle.Columns.Contains("id_detalle_factura"))
                dgvDetalle.Columns["id_detalle_factura"].Visible = false;
            if (dgvDetalle.Columns.Contains("id_servicio"))
                dgvDetalle.Columns["id_servicio"].Visible = false;

            dgvDetalle.DataBindingComplete += (s, ev) =>
            {
                dgvDetalle.EnableHeadersVisualStyles = false;
                dgvDetalle.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                dgvDetalle.ColumnHeadersDefaultCellStyle.BackColor = colorVino;
                dgvDetalle.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvDetalle.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9F);
                dgvDetalle.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            };
        }

        // =========================
        // 🔍 EVENTOS BUSCADOR
        // =========================
        private void btnBuscar_Click(object sender, EventArgs e) => BuscarDetalles();
        private void txtBuscar_TextChanged(object sender, EventArgs e) => BuscarDetalles();
        private void cbFiltroFactura_SelectedIndexChanged(object sender, EventArgs e) => BuscarDetalles();

        // =========================
        // 🖱 CLICK GRID
        // =========================
        private void dgvDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow fila = dgvDetalle.Rows[e.RowIndex];

            if (dgvDetalle.Columns.Contains("id_factura") &&
                fila.Cells["id_factura"].Value != DBNull.Value)
                cbFactura.SelectedValue = fila.Cells["id_factura"].Value;

            if (dgvDetalle.Columns.Contains("id_servicio") &&
                fila.Cells["id_servicio"].Value != DBNull.Value)
                cbServicio.SelectedValue = fila.Cells["id_servicio"].Value;

            txtDescripcion.Text = (dgvDetalle.Columns.Contains("descripcion") &&
                fila.Cells["descripcion"].Value != DBNull.Value)
                ? fila.Cells["descripcion"].Value.ToString() : "";

            if (dgvDetalle.Columns.Contains("cantidad") &&
                fila.Cells["cantidad"].Value != DBNull.Value)
                nudCantidad.Value = Convert.ToDecimal(fila.Cells["cantidad"].Value);

            if (dgvDetalle.Columns.Contains("subtotal") &&
                fila.Cells["subtotal"].Value != DBNull.Value)
                lblSubtotal.Text = "RD$ " + Convert.ToDecimal(
                    fila.Cells["subtotal"].Value).ToString("N2");
        }

        // =========================
        // 🔗 ABRIR DETALLE FACTURA
        // =========================
        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            FrmDetalleFactura frm = new FrmDetalleFactura();
            frm.Show();
        }

        // =========================
        // ✅ VALIDACIONES
        // =========================
        bool ValidarCampos()
        {
            if (cbFactura.SelectedValue == null)
            {
                MessageBox.Show("⚠️ Selecciona una factura.", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbFactura.Focus(); return false;
            }
            if (cbServicio.SelectedValue == null)
            {
                MessageBox.Show("⚠️ Selecciona un servicio.", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (nudCantidad.Value <= 0)
            {
                MessageBox.Show("⚠️ La cantidad debe ser mayor a 0.", "Campo inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // =========================
        // 💾 GUARDAR
        // =========================
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;
            try
            {
                Detalle_Factura d = new Detalle_Factura
                {
                    id_factura = Convert.ToInt32(cbFactura.SelectedValue),
                    id_servicio = Convert.ToInt32(cbServicio.SelectedValue),
                    descripcion = txtDescripcion.Text,
                    cantidad = Convert.ToInt32(nudCantidad.Value),
                    subtotal = ObtenerSubtotal()
                };
                detalleBLL.Guardar(d);
                MessageBox.Show("Detalle guardado correctamente");
                MostrarDetalles();
                LimpiarCampos();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        // =========================
        // ✏️ ACTUALIZAR
        // =========================
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.CurrentRow == null)
            {
                MessageBox.Show("⚠️ Selecciona un detalle de la tabla.", "Sin selección",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidarCampos()) return;
            try
            {
                Detalle_Factura d = new Detalle_Factura
                {
                    id_detalle_factura = Convert.ToInt32(
                        dgvDetalle.CurrentRow.Cells["id_detalle_factura"].Value),
                    id_factura = Convert.ToInt32(cbFactura.SelectedValue),
                    id_servicio = Convert.ToInt32(cbServicio.SelectedValue),
                    descripcion = txtDescripcion.Text,
                    cantidad = Convert.ToInt32(nudCantidad.Value),
                    subtotal = ObtenerSubtotal()
                };
                detalleBLL.Actualizar(d);
                MessageBox.Show("Detalle actualizado");
                MostrarDetalles();
                LimpiarCampos();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        // =========================
        // 🗑 ELIMINAR
        // =========================
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.CurrentRow == null) return;
            if (MessageBox.Show("¿Eliminar este detalle?", "Confirmar",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                detalleBLL.Eliminar(Convert.ToInt32(
                    dgvDetalle.CurrentRow.Cells["id_detalle_factura"].Value));
                MessageBox.Show("Detalle eliminado");
                MostrarDetalles();
                LimpiarCampos();
            }
        }

        // =========================
        // 🧹 LIMPIAR
        // =========================
        private void btnLimpiar_Click(object sender, EventArgs e) => LimpiarCampos();

        void LimpiarCampos()
        {
            cbFactura.SelectedIndex = -1;
            cbServicio.SelectedIndex = -1;
            txtDescripcion.Clear();
            nudCantidad.Value = 1;
            lblSubtotal.Text = "RD$ 0.00";
            dgvDetalle.ClearSelection();
        }

        decimal ObtenerSubtotal()
        {
            string texto = lblSubtotal.Text.Replace("RD$", "").Trim();
            return decimal.TryParse(texto, out decimal val) ? val : 0;
        }

        // =========================
        // 🎨 DISEÑO
        // =========================
        void EstilarBoton(Button btn, Color fondo, Color texto, bool negrita = false)
        {
            btn.BackColor = fondo;
            btn.ForeColor = texto;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI" + (negrita ? " Semibold" : ""), 10F);
            btn.Height = 40;
            btn.Cursor = Cursors.Hand;
        }

        private void AplicarDiseno()
        {
            this.BackColor = colorFondo;
            panelDetalle.BackColor = Color.White;
            panelTabla.BackColor = Color.White;

            lblTabla.ForeColor = colorRosado;
            lblTabla.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);

            foreach (Label lbl in new[] { lblFactura, lblServicio, lblCantidad, lblDescripcion, lblSubtotalTexto })
            { lbl.ForeColor = Color.Black; lbl.Font = new Font("Segoe UI", 9F); }

            foreach (ComboBox cb in new[] { cbFactura, cbServicio })
            { cb.BackColor = Color.White; cb.ForeColor = Color.Black; cb.FlatStyle = FlatStyle.Flat; cb.Font = new Font("Segoe UI", 9F); }

            txtDescripcion.BackColor = Color.White;
            txtDescripcion.ForeColor = colorRosado;
            txtDescripcion.BorderStyle = BorderStyle.FixedSingle;
            txtDescripcion.Font = new Font("Segoe UI", 9F);

            nudCantidad.Font = new Font("Segoe UI", 9F);
            nudCantidad.Minimum = 1;
            nudCantidad.Maximum = 100;

            lblSubtotal.ForeColor = colorRosado;
            lblSubtotal.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            lblSubtotal.Text = "RD$ 0.00";

            txtBuscar.BackColor = Color.White;
            txtBuscar.ForeColor = Color.Gray;
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            txtBuscar.Font = new Font("Segoe UI", 9F);
            txtBuscar.Height = 28;

            cbFiltroFactura.BackColor = Color.White;
            cbFiltroFactura.ForeColor = Color.Black;
            cbFiltroFactura.FlatStyle = FlatStyle.Flat;
            cbFiltroFactura.Font = new Font("Segoe UI", 9F);
            cbFiltroFactura.Height = 28;

            Color beige = Color.FromArgb(242, 235, 231);
            EstilarBoton(btnGuardar, colorVino, Color.White, negrita: true);
            EstilarBoton(btnActualizar, colorVino, Color.White, negrita: true);
            EstilarBoton(btnEliminar, beige, colorRosado);
            EstilarBoton(btnLimpiar, beige, colorRosado);
            EstilarBoton(btnBuscar, colorVino, Color.White, negrita: true);
            btnBuscar.Height = 28;
            EstilarBoton(btnVerDetalle, beige, colorRosado, negrita: true);
            btnVerDetalle.Height = 28;

            dgvDetalle.BackgroundColor = Color.White;
            dgvDetalle.BorderStyle = BorderStyle.None;
            dgvDetalle.RowHeadersVisible = false;
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalle.ColumnHeadersHeight = 38;
            dgvDetalle.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvDetalle.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 210, 215);
            dgvDetalle.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvDetalle.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 244, 242);
            dgvDetalle.GridColor = Color.FromArgb(235, 230, 228);
            dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalle.MultiSelect = false;
            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.AllowUserToDeleteRows = false;

            dgvDetalle.DataBindingComplete += (s, ev) =>
            {
                dgvDetalle.EnableHeadersVisualStyles = false;
                dgvDetalle.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                dgvDetalle.ColumnHeadersDefaultCellStyle.BackColor = colorVino;
                dgvDetalle.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvDetalle.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9F);
                dgvDetalle.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            };
        }
    }
}