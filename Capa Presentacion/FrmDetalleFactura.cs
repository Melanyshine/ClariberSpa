using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CapaNegocio;

namespace Capa_Presentacion
{
    public partial class FrmDetalleFactura : Form
    {
        // =========================
        // COLORES
        // =========================
        private readonly Color colorVino = Color.RosyBrown;
        private readonly Color colorFondo = Color.FromArgb(250, 248, 246);
        private readonly Color colorBeige = Color.FromArgb(242, 235, 231);

        // =========================
        // BLL
        // =========================
        Detalle_FacturaBLL detalleBLL = new Detalle_FacturaBLL();
        FacturaBLL facturaBLL = new FacturaBLL();

        // ID de la factura seleccionada
        private int _idFactura;

        // =========================
        // CONSTRUCTOR
        // =========================
        public FrmDetalleFactura(int idFactura)
        {
            InitializeComponent();
            _idFactura = idFactura;
        }

        // =========================
        // LOAD
        // =========================
        private void FrmDetalleFactura_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            AplicarDiseno();
            CargarDetalle();
        }

        // =========================
        // CARGAR DETALLE
        // =========================
        void CargarDetalle()
        {
            // Carga los detalles y filtra por factura
            DataTable todos = detalleBLL.Listar();
            DataView vista = todos.DefaultView;
            vista.RowFilter = $"id_factura = {_idFactura}";
            dgvDetalle.DataSource = vista.ToTable();
            OcultarColumnas();

            // Carga el encabezado de la factura
            DataTable facturas = facturaBLL.Listar();
            DataView vf = facturas.DefaultView;
            vf.RowFilter = $"id_factura = {_idFactura}";

            if (vf.Count == 0) return;

            DataRow f = vf.ToTable().Rows[0];

            lblNumFactura.Text = "Factura #" + _idFactura;
            lblFecha.Text = "Fecha: " + Convert.ToDateTime(f["fecha_factura"]).ToString("dd/MM/yyyy");
            lblMetodo.Text = "Método de Pago: " + f["metodo_pago"].ToString();
            lblEstado.Text = "Estado: " + f["estado_pago"].ToString();
            lblTotal.Text = "Total: RD$ " + Convert.ToDecimal(f["total"]).ToString("N2");
        }

        // =========================
        // OCULTAR COLUMNAS
        // =========================
        void OcultarColumnas()
        {
            if (dgvDetalle.Columns.Contains("id_detalle_factura"))
                dgvDetalle.Columns["id_detalle_factura"].Visible = false;

            if (dgvDetalle.Columns.Contains("id_factura"))
                dgvDetalle.Columns["id_factura"].Visible = false;

            if (dgvDetalle.Columns.Contains("id_servicio"))
                dgvDetalle.Columns["id_servicio"].Visible = false;
        }

        // =========================
        // CERRAR
        // =========================
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // =========================
        // DISEÑO
        // =========================
        private void AplicarDiseno()
        {
            this.BackColor = colorFondo;

            lblNumFactura.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            lblNumFactura.ForeColor = colorVino;

            foreach (Label lbl in new[] { lblFecha, lblMetodo, lblEstado, lblTotal })
            {
                lbl.Font = new Font("Segoe UI", 10F);
                lbl.ForeColor = Color.FromArgb(60, 40, 40);
            }

            lblTotal.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            lblTotal.ForeColor = colorVino;

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
            };

            btnCerrar.BackColor = colorBeige;
            btnCerrar.ForeColor = colorVino;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.Font = new Font("Segoe UI Semibold", 10F);
            btnCerrar.Cursor = Cursors.Hand;
        }
    }
}