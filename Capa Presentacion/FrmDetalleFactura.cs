using CapaEntidades;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Capa_Presentacion
{
    public partial class FrmDetalleFactura : Form
    {
        // =====================================================================
        // COLORES
        // =====================================================================
        private readonly Color COLOR_VINO = Color.RosyBrown;
        private readonly Color COLOR_FONDO = Color.FromArgb(250, 248, 246);
        private readonly Color COLOR_BEIGE = Color.FromArgb(242, 235, 231);

        // =====================================================================
        // BLL
        // =====================================================================
        private readonly Detalle_FacturaBLL detalleBLL = new Detalle_FacturaBLL();
        private readonly FacturaBLL facturaBLL = new FacturaBLL();
        private readonly CitasBLL citasBLL = new CitasBLL();
        private readonly DetalleCitas_BLL detalleCitasBLL = new DetalleCitas_BLL();

        // =====================================================================
        // ESTADO
        // =====================================================================
        private int _idFactura;
        private bool _modoNueva;
        private DataTable tablaDetalle = new DataTable();

        private List<decimal> _preciosPorServicio = new List<decimal>();
        private List<int> _idsPorServicio = new List<int>();

        // =====================================================================
        // CONSTRUCTOR — MODO NUEVA FACTURA
        // =====================================================================
        public FrmDetalleFactura()
        {
            InitializeComponent();
            _idFactura = 0;
            _modoNueva = true;
        }

        // =====================================================================
        // CONSTRUCTOR — MODO VER DETALLE
        // =====================================================================
        public FrmDetalleFactura(int idFactura)
        {
            InitializeComponent();
            _idFactura = idFactura;
            _modoNueva = false;
        }

        // =====================================================================
        // LOAD
        // =====================================================================
        private void FrmDetalleFactura_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            AplicarDiseno();
            SuscribirEventos();
            CargarFiltro();

            btnActualizar.Visible = false;
            btnEliminar.Visible = false;

            if (_modoNueva)
            {
                lblTitulo.Text = "Nueva Factura";
                panelDetalle.Visible = true;
                btnGuardar.Visible = true;
                btnLimpiar.Visible = true;
                CargarClientes();
                CargarMetodosPago();
                CargarEstados();
                tablaDetalle = new DataTable();
                dgvDetalle.DataSource = tablaDetalle;
            }
            else
            {
                lblTitulo.Text = "Detalle de Factura #" + _idFactura;
                panelDetalle.Visible = false;
                btnActualizar.Visible = !_modoNueva;
                btnEliminar.Visible = !_modoNueva;
                MostrarDetalle();
            }
        }

        // =====================================================================
        // SUSCRIBIR EVENTOS
        // =====================================================================
        private void SuscribirEventos()
        {
            cbCliente.SelectedIndexChanged += cbCliente_SelectedIndexChanged;
            checkedListBox1.ItemCheck += checkedListBox1_ItemCheck;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            btnBuscar.Click += btnBuscar_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            btnCerrar.Click += btnCerrar_Click;
            btnMostrar.Click += btnMostrar_Click;
        }

        // =====================================================================
        // CARGAR COMBOS
        // =====================================================================
        private void CargarClientes()
        {
            cbCliente.SelectedIndexChanged -= cbCliente_SelectedIndexChanged;

            DataTable dt = citasBLL.Listar();
            DataView vista = dt.DefaultView;
            vista.RowFilter = "nombre_estado = 'Completada' OR nombre_estado = 'Confirmada'";

            cbCliente.DataSource = vista.ToTable();
            cbCliente.DisplayMember = "cliente";
            cbCliente.ValueMember = "id_cita";
            cbCliente.SelectedIndex = -1;

            cbCliente.SelectedIndexChanged += cbCliente_SelectedIndexChanged;
        }

        private void CargarMetodosPago()
        {
            cbMetodoPago.Items.Clear();
            cbMetodoPago.Items.AddRange(new object[] { "Efectivo", "Tarjeta", "Transferencia" });
            cbMetodoPago.SelectedIndex = -1;
        }

        private void CargarEstados()
        {
            cbEstado.Items.Clear();
            cbEstado.Items.AddRange(new object[] { "Pagado", "Pendiente", "Cancelado" });
            cbEstado.SelectedIndex = 0;
        }

        private void CargarFiltro()
        {
            cbFiltro.Items.Clear();
            cbFiltro.Items.AddRange(new object[] { "Factura", "Servicio", "Descripcion" });
            cbFiltro.SelectedIndex = 0;
        }

        // =====================================================================
        // EVENTO: SELECCIONAR CLIENTE → AUTO-RELLENA CAMPOS Y SERVICIOS
        // =====================================================================
        private void cbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCliente.SelectedValue == null) return;

            int idCita = Convert.ToInt32(cbCliente.SelectedValue);
            DataTable dt = citasBLL.ObtenerPorId(idCita);

            if (dt.Rows.Count == 0) return;

            DataRow fila = dt.Rows[0];
            txtEmpleado.Text = fila["empleado"].ToString();
            txtCita.Text     = "Cita #" + idCita;

            CargarServiciosDeCita(idCita);
        }

        // =====================================================================
        // CARGAR SERVICIOS DE LA CITA EN EL CHECKEDLISTBOX
        // =====================================================================
        private void CargarServiciosDeCita(int idCita)
        {
            checkedListBox1.ItemCheck -= checkedListBox1_ItemCheck;
            checkedListBox1.Items.Clear();
            _preciosPorServicio.Clear();
            _idsPorServicio.Clear();

            foreach (DataRow f in detalleCitasBLL.ObtenerPorCita(idCita).Rows)
            {
                checkedListBox1.Items.Add(
                    $"{f["nombre_servicio"]}  —  RD$ {Convert.ToDecimal(f["precio"]):N2}",
                    Convert.ToBoolean(f["en_cita"]));
                _preciosPorServicio.Add(Convert.ToDecimal(f["precio"]));
                _idsPorServicio.Add(Convert.ToInt32(f["id_servicio"]));
            }

            checkedListBox1.ItemCheck += checkedListBox1_ItemCheck;
            RecalcularMonto();
        }
        // =====================================================================
        // EVENTO: MARCAR / DESMARCAR SERVICIO → RECALCULA MONTO
        // =====================================================================
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                RecalcularMonto();
            });
        }

        private void RecalcularMonto()
        {
            decimal total = 0;
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                    total += _preciosPorServicio[i];
            }

            txtMonto.Text    = total.ToString("N2");
            lblSubtotal.Text = "RD$ " + total.ToString("N2");
        }

        // =====================================================================
        // GUARDAR NUEVA FACTURA
        // =====================================================================
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                int idCita    = Convert.ToInt32(cbCliente.SelectedValue);
                DataTable dtCita = citasBLL.ObtenerPorId(idCita);
                int idCliente = Convert.ToInt32(dtCita.Rows[0]["id_cliente"]);

                decimal total = decimal.TryParse(txtMonto.Text, out decimal t) ? t : 0;

                Factura f = new Factura
                {
                    id_cliente    = idCliente,
                    fecha_factura = dtpFecha.Value,
                    total         = total,
                    metodo_pago   = cbMetodoPago.SelectedItem.ToString(),
                    estado_pago   = cbEstado.SelectedItem.ToString()
                };

                int idNuevaFactura = facturaBLL.Guardar(f);

                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (!checkedListBox1.GetItemChecked(i)) continue;

                    detalleBLL.Guardar(new Detalle_Factura
                    {
                        id_factura  = idNuevaFactura,
                        id_servicio = _idsPorServicio[i],
                        descripcion = checkedListBox1.Items[i].ToString(),
                        cantidad    = 1,
                        subtotal    = _preciosPorServicio[i]
                    });
                }

                MessageBox.Show("✅ Factura registrada correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                _idFactura = idNuevaFactura;
                lblTitulo.Text = "Detalle de Factura #" + _idFactura;
                MostrarDetalle();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =====================================================================
        // VALIDACIONES
        // =====================================================================
        private bool ValidarCampos()
        {
            if (cbCliente.SelectedValue == null)
            {
                MessageBox.Show("⚠️ Selecciona un cliente.", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbCliente.Focus();
                return false;
            }
            if (checkedListBox1.CheckedItems.Count == 0)
            {
                MessageBox.Show("⚠️ Selecciona al menos un servicio.", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                checkedListBox1.Focus();
                return false;
            }
            if (cbMetodoPago.SelectedIndex < 0)
            {
                MessageBox.Show("⚠️ Selecciona el método de pago.", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbMetodoPago.Focus();
                return false;
            }
            if (cbEstado.SelectedIndex < 0)
            {
                MessageBox.Show("⚠️ Selecciona el estado.", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbEstado.Focus();
                return false;
            }
            return true;
        }

        // =====================================================================
        // LIMPIAR CAMPOS
        // =====================================================================
        private void btnLimpiar_Click(object sender, EventArgs e) => LimpiarCampos();

        private void LimpiarCampos()
        {
            cbCliente.SelectedIndex = -1;
            txtEmpleado.Text = "";
            txtCita.Text     = "";
            checkedListBox1.Items.Clear();
            _preciosPorServicio.Clear();
            _idsPorServicio.Clear();
            txtMonto.Text    = "0.00";
            cbMetodoPago.SelectedIndex = -1;
            cbEstado.SelectedIndex = 0;
            dtpFecha.Value   = DateTime.Today;
            lblSubtotal.Text = "RD$ 0.00";
            txtNotas.Clear();
            dgvDetalle.ClearSelection();
        }

        // =====================================================================
        // MOSTRAR DETALLE EN EL GRID
        // =====================================================================
        private void MostrarDetalle()
        {
            if (_idFactura == 0) return;

            tablaDetalle = detalleBLL.ObtenerPorFactura(_idFactura);
            dgvDetalle.DataSource = tablaDetalle;
            OcultarColumnas();
        }

        // =====================================================================
        // BUSCAR
        // =====================================================================
        private void BuscarDetalle()
        {
            if (tablaDetalle == null || tablaDetalle.Rows.Count == 0) return;

            string texto = txtBuscar.Text.Trim().Replace("'", "''");

            if (texto == "")
            {
                dgvDetalle.DataSource = tablaDetalle;
                OcultarColumnas();
                return;
            }

            DataView dv = tablaDetalle.DefaultView;

            if (cbFiltro.Text == "Factura")
                dv.RowFilter = $"Convert(id_factura, 'System.String') LIKE '%{texto}%'";
            else if (cbFiltro.Text == "Servicio")
                dv.RowFilter = $"servicio LIKE '%{texto}%'";
            else if (cbFiltro.Text == "Descripcion")
                dv.RowFilter = $"descripcion LIKE '%{texto}%'";

            dgvDetalle.DataSource = dv;
            OcultarColumnas();
        }

        private void btnBuscar_Click(object sender, EventArgs e) => BuscarDetalle();
        private void txtBuscar_TextChanged(object sender, EventArgs e) => BuscarDetalle();

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            MostrarDetalle();
            if (cbFiltro.Items.Count > 0) cbFiltro.SelectedIndex = 0;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            FrmPrincipal principal = (FrmPrincipal)Application.OpenForms["FrmPrincipal"];
            principal.AbrirFormulario(new FrmFactura());
        }

        // =====================================================================
        // OCULTAR COLUMNAS Y ESTILO GRID
        // =====================================================================
        private void OcultarColumnas()
        {
            if (dgvDetalle.Columns.Contains("id_servicio"))
                dgvDetalle.Columns["id_servicio"].Visible = false;

            if (dgvDetalle.Columns.Contains("id_factura"))
                dgvDetalle.Columns["id_factura"].HeaderText = "Factura";
            if (dgvDetalle.Columns.Contains("servicio"))
                dgvDetalle.Columns["servicio"].HeaderText = "Servicio";
            if (dgvDetalle.Columns.Contains("descripcion"))
                dgvDetalle.Columns["descripcion"].HeaderText = "Descripción";
            if (dgvDetalle.Columns.Contains("cantidad"))
                dgvDetalle.Columns["cantidad"].HeaderText = "Cantidad";
            if (dgvDetalle.Columns.Contains("subtotal"))
            {
                dgvDetalle.Columns["subtotal"].HeaderText = "Subtotal";
                dgvDetalle.Columns["subtotal"].DefaultCellStyle.Format = "N2";
            }

            dgvDetalle.EnableHeadersVisualStyles = false;
            dgvDetalle.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvDetalle.ColumnHeadersDefaultCellStyle.BackColor = COLOR_VINO;
            dgvDetalle.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDetalle.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            dgvDetalle.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        // =====================================================================
        // DISEÑO VISUAL
        // =====================================================================
        private void AplicarDiseno()
        {
            this.BackColor = COLOR_FONDO;

            panelDetalle.BackColor = Color.White;
            AgregarSombra(panelDetalle);

            lblTitulo.ForeColor = COLOR_VINO;
            lblTitulo.Font = new Font("Georgia", 22F, FontStyle.Regular);

            foreach (Label lbl in new[] { lblCita, lblEmpleado, lblServicio,
                                          lblMonto, lblMetodoPago, lblFecha, lblEstado,
                                          lblNotas, lblBuscar, lblFiltro })
            {
                lbl.ForeColor = Color.FromArgb(70, 50, 48);
                lbl.Font = new Font("Segoe UI", 10F);
            }

            lblSubtotal.ForeColor = COLOR_VINO;
            lblSubtotal.Font = new Font("Georgia", 12F, FontStyle.Bold);

            foreach (ComboBox cb in new[] { cbCliente, cbMetodoPago, cbEstado })
            {
                cb.BackColor = Color.White;
                cb.ForeColor = Color.FromArgb(70, 50, 48);
                cb.FlatStyle = FlatStyle.Flat;
                cb.Font = new Font("Segoe UI", 10F);
            }

            cbFiltro.BackColor = Color.White;
            cbFiltro.ForeColor = Color.FromArgb(70, 50, 48);
            cbFiltro.FlatStyle = FlatStyle.Flat;
            cbFiltro.Font = new Font("Segoe UI", 10F);

            foreach (TextBox txt in new[] { txtEmpleado, txtCita,
                                            txtMonto, txtBuscar, txtNotas })
            {
                txt.BackColor = Color.White;
                txt.ForeColor = Color.FromArgb(70, 50, 48);
                txt.BorderStyle = BorderStyle.FixedSingle;
                txt.Font = new Font("Segoe UI", 10F);
            }

            foreach (TextBox txt in new[] { txtEmpleado, txtCita, txtMonto })
            {
                txt.BackColor = Color.FromArgb(245, 245, 245);
                txt.ForeColor = Color.DimGray;
            }

            checkedListBox1.BackColor = Color.White;
            checkedListBox1.ForeColor = Color.FromArgb(70, 50, 48);
            checkedListBox1.Font = new Font("Segoe UI", 10F);
            checkedListBox1.BorderStyle = BorderStyle.FixedSingle;
            checkedListBox1.CheckOnClick = true;

            dtpFecha.Font = new Font("Segoe UI", 10F);

            EstilarBoton(btnGuardar, COLOR_VINO, Color.White, true);
            EstilarBoton(btnLimpiar, COLOR_BEIGE, COLOR_VINO, false);
            EstilarBoton(btnBuscar, COLOR_VINO, Color.White, true);
            EstilarBoton(btnMostrar, COLOR_BEIGE, COLOR_VINO, false);
            EstilarBoton(btnCerrar, COLOR_VINO, Color.White, true);

            dgvDetalle.BackgroundColor = Color.White;
            dgvDetalle.BorderStyle = BorderStyle.None;
            dgvDetalle.RowHeadersVisible = false;
            dgvDetalle.GridColor = Color.FromArgb(235, 230, 228);
            dgvDetalle.RowTemplate.Height = 42;
            dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalle.MultiSelect = false;
            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.AllowUserToDeleteRows = false;
            dgvDetalle.AllowUserToResizeRows = false;
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalle.ReadOnly = true;
            dgvDetalle.ColumnHeadersHeight = 45;
            dgvDetalle.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvDetalle.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 210, 215);
            dgvDetalle.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvDetalle.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 244, 242);
            dgvDetalle.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDetalle.Anchor = AnchorStyles.Top | AnchorStyles.Left |
                                AnchorStyles.Right | AnchorStyles.Bottom;
        }

        private void EstilarBoton(Button btn, Color fondo, Color texto, bool negrita)
        {
            btn.BackColor = fondo;
            btn.ForeColor = texto;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = ControlPaint.Dark(fondo, 0.10f);
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.MouseOverBackColor = ControlPaint.Dark(fondo, 0.08f);
            btn.Font = new Font("Segoe UI", 9.5F, negrita ? FontStyle.Bold : FontStyle.Regular);
            btn.Height = 36;
            btn.Cursor = Cursors.Hand;
        }

        private void AgregarSombra(Panel panel)
        {
            panel.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                var rc = panel.ClientRectangle;
                for (int i = 4; i >= 1; i--)
                {
                    var rcS = new Rectangle(rc.X + i, rc.Y + i,
                                            rc.Width - i * 2, rc.Height - i * 2);
                    using (var pen = new Pen(Color.FromArgb(12 * i, 0, 0, 0), 1))
                        g.DrawRectangle(pen, rcS);
                }
            };
        }
    }
}