using CapaEntidades;
using CapaNegocio;
using CapaPresentacion;
using Presentacion;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Capa_Presentacion
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        // =========================================
        // LOAD
        // =========================================
        private void FrmPrincipal_Load(
            object sender,
            EventArgs e)
        {
            this.WindowState =
                FormWindowState.Maximized;

            this.BackColor =
                Color.FromArgb(
                    245,
                    238,
                    235);

            // =====================================
            // PANEL MENU
            // =====================================

            panelMenu.BackColor =
                Color.FromArgb(
                    126,
                    90,
                    78);

            panelMenu.Width =
                280;

            // =====================================
            // PANEL CONTENIDO
            // =====================================

            panelContenido.BackColor =
                Color.FromArgb(
                    255,
                    250,
                    248);

            panelContenido.Dock =
                DockStyle.Fill;

            // =====================================
            // TITULO
            // =====================================

            lblTitulo.Text =
                "✨ CLARIBER SPA ✨";

            lblTitulo.ForeColor =
                Color.Beige;

            lblTitulo.Font =
                new Font(
                    "Georgia",
                    22,
                    FontStyle.Bold);

            lblTitulo.AutoSize =
                true;

            // =====================================
            // DISEÑO BOTONES
            // =====================================

            DiseñoBoton(btnInicio);
            DiseñoBoton(btnClientes);
            DiseñoBoton(btnServicios);
            DiseñoBoton(btnUsuario);
            DiseñoBoton(btnCitas);
            DiseñoBoton(btnDisponibilidad);
            DiseñoBoton(btnFactura);
            DiseñoBoton(btnConfiguracion);
            DiseñoBoton(btnReportes);
            DiseñoBoton(btnCerrarSesion);

            // =====================================
            // TEXTOS BOTONES
            // =====================================

            btnInicio.Text =
                "🏠 Inicio";

            btnClientes.Text =
                "👤 Clientes";

            btnServicios.Text =
                "🌸 Servicios";

            btnUsuario.Text =
                "👥 Usuarios";

            btnCitas.Text =
                "📅 Citas";

            btnDisponibilidad.Text =
                "🕒 Disponibilidad";

            btnFactura.Text =
                "🧾 Facturas";

            btnConfiguracion.Text =
                "⚙️ Configuración";

            btnReportes.Text =
                "📊 Reportes";

            btnCerrarSesion.Text =
                "↩ Cerrar Sesión";

            // =====================================
            // MOSTRAR DASHBOARD
            // =====================================

            MostrarInicio();
        }

        // =========================================
        // DISEÑO BOTONES
        // =========================================
        private void DiseñoBoton(
            Button btn)
        {
            btn.FlatStyle =
                FlatStyle.Flat;

            btn.FlatAppearance.BorderSize =
                0;

            btn.BackColor =
                Color.Transparent;

            btn.ForeColor =
                Color.White;

            btn.Font =
                new Font(
                    "Segoe UI",
                    12,
                    FontStyle.Bold);

            btn.TextAlign =
                ContentAlignment.MiddleLeft;

            btn.Padding =
                new Padding(
                    20,
                    0,
                    0,
                    0);

            btn.Height =
                55;

            btn.Width =
                260;

            btn.Cursor =
                Cursors.Hand;

            btn.MouseEnter +=
                Btn_MouseEnter;

            btn.MouseLeave +=
                Btn_MouseLeave;
        }

        // =========================================
        // EFECTOS BOTONES
        // =========================================
        private void Btn_MouseEnter(
            object sender,
            EventArgs e)
        {
            Button btn =
                (Button)sender;

            btn.BackColor =
                Color.FromArgb(
                    166,
                    117,
                    102);
        }

        private void Btn_MouseLeave(
            object sender,
            EventArgs e)
        {
            Button btn =
                (Button)sender;

            btn.BackColor =
                Color.Transparent;
        }

        // =========================================
        // DASHBOARD INICIO
        // =========================================
        private void MostrarInicio()
        {
            panelContenido.Controls.Clear();

            // =====================================
            // TITULO
            // =====================================

            Label lblBienvenida =
                new Label();

            lblBienvenida.Text =
                "Bienvenida, Administradora ✨";

            lblBienvenida.Font =
                new Font(
                    "Segoe UI",
                    26,
                    FontStyle.Bold);

            lblBienvenida.ForeColor =
                Color.FromArgb(
                    80,
                    60,
                    60);

            lblBienvenida.Location =
                new Point(
                    40,
                    30);

            lblBienvenida.AutoSize =
                true;

            panelContenido.Controls.Add(
                lblBienvenida);

            // =====================================
            // SUBTITULO
            // =====================================

            Label lblSub =
                new Label();

            lblSub.Text =
                "Panel principal del sistema Clariber Spa Beauty";

            lblSub.Font =
                new Font(
                    "Segoe UI",
                    12);

            lblSub.ForeColor =
                Color.Gray;

            lblSub.Location =
                new Point(
                    45,
                    80);

            lblSub.AutoSize =
                true;

            panelContenido.Controls.Add(
                lblSub);

            // =====================================
            // TARJETAS
            // =====================================

            Panel card1 =
                CrearTarjeta(
                    "Clientes Registrados",
                    "125",
                    new Point(40, 140));

            Panel card2 =
                CrearTarjeta(
                    "Servicios Activos",
                    "18",
                    new Point(340, 140));

            Panel card3 =
                CrearTarjeta(
                    "Citas de Hoy",
                    "12",
                    new Point(640, 140));

            Panel card4 =
                CrearTarjeta(
                    "Ingresos del Mes",
                    "RD$45,680",
                    new Point(940, 140));

            panelContenido.Controls.Add(card1);
            panelContenido.Controls.Add(card2);
            panelContenido.Controls.Add(card3);
            panelContenido.Controls.Add(card4);

            // =====================================
            // TABLA CITAS
            // =====================================

            DataGridView dgv =
                new DataGridView();

            dgv.Location =
                new Point(
                    40,
                    350);

            dgv.Size =
                new Size(
                    650,
                    250);

            dgv.BackgroundColor =
                Color.White;

            dgv.BorderStyle =
                BorderStyle.None;

            dgv.AllowUserToAddRows =
                false;

            dgv.RowHeadersVisible =
                false;

            dgv.Font =
                new Font(
                    "Segoe UI",
                    10);

            dgv.ColumnCount = 4;

            dgv.Columns[0].Name =
                "Hora";

            dgv.Columns[1].Name =
                "Cliente";

            dgv.Columns[2].Name =
                "Servicio";

            dgv.Columns[3].Name =
                "Empleado";

            dgv.Rows.Add(
                "10:00 AM",
                "Maria Gonzalez",
                "Masaje Relajante",
                "Laura");

            dgv.Rows.Add(
                "11:00 AM",
                "Ana Rodriguez",
                "Limpieza Facial",
                "Sofia");

            dgv.Rows.Add(
                "12:00 PM",
                "Carlos Ramirez",
                "Pedicure",
                "Juan");

            dgv.Rows.Add(
                "2:00 PM",
                "Lucia Martinez",
                "Manicure",
                "Sofia");

            panelContenido.Controls.Add(
                dgv);

            // =====================================
            // GRAFICO
            // =====================================

            Chart grafico =
                new Chart();

            grafico.Location =
                new Point(
                    760,
                    330);

            grafico.Size =
                new Size(
                    500,
                    320);

            ChartArea area =
                new ChartArea();

            area.BackColor =
                Color.White;

            grafico.ChartAreas.Add(
                area);

            Series serie =
                new Series();

            serie.ChartType =
                SeriesChartType.Column;

            serie.IsValueShownAsLabel =
                true;

            serie.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold);

            serie.Points.AddXY(
                "Ingresos",
                45680);

            serie.Points.AddXY(
                "Citas",
                78);

            serie.Points.AddXY(
                "Clientes",
                23);

            serie.Points.AddXY(
                "Servicios",
                56);

            serie.Color =
                Color.FromArgb(
                    214,
                    140,
                    158);

            grafico.Series.Add(
                serie);

            panelContenido.Controls.Add(
                grafico);
        }

        // =========================================
        // CREAR TARJETAS
        // =========================================
        private Panel CrearTarjeta(
            string titulo,
            string valor,
            Point posicion)
        {
            Panel card =
                new Panel();

            card.Size =
                new Size(
                    250,
                    140);

            card.Location =
                posicion;

            card.BackColor =
                Color.White;

            card.BorderStyle =
                BorderStyle.FixedSingle;

            Label lblTitulo =
                new Label();

            lblTitulo.Text =
                titulo;

            lblTitulo.Font =
                new Font(
                    "Segoe UI",
                    12,
                    FontStyle.Bold);

            lblTitulo.ForeColor =
                Color.Gray;

            lblTitulo.Location =
                new Point(
                    20,
                    20);

            lblTitulo.AutoSize =
                true;

            Label lblValor =
                new Label();

            lblValor.Text =
                valor;

            lblValor.Font =
                new Font(
                    "Segoe UI",
                    26,
                    FontStyle.Bold);

            lblValor.ForeColor =
                Color.FromArgb(
                    126,
                    90,
                    78);

            lblValor.Location =
                new Point(
                    20,
                    60);

            lblValor.AutoSize =
                true;

            card.Controls.Add(
                lblTitulo);

            card.Controls.Add(
                lblValor);

            return card;
        }

        // =========================================
        // ABRIR FORMULARIOS
        // =========================================
        public void AbrirFormulario(
            Form frm)
        {
            panelContenido.Controls.Clear();

            frm.TopLevel =
                false;

            frm.FormBorderStyle =
                FormBorderStyle.None;

            frm.Dock =
                DockStyle.Fill;

            panelContenido.Controls.Add(
                frm);

            frm.Show();

            frm.BringToFront();
        }

        // =========================================
        // BOTONES
        // =========================================

        private void btnInicio_Click(
            object sender,
            EventArgs e)
        {
            MostrarInicio();
        }

        private void btnClientes_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(
                new FrmClientes());
        }

        private void btnServicios_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(
                new Servicio());
        }

        private void btnUsuario_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(
                new FrmEmpleado());
        }

        private void btnCitas_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(
                new FrmCitas());
        }

        private void btnDisponibilidad_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(
                new FrmDisponibilidad());
        }

        private void btnFactura_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(
                new FrmFactura());
        }

        private void btnConfiguracion_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(
                new FrmConfiguracion());
        }

        private void btnReportes_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(
                new FrmReportes());
        }

        private void btnCerrarSesion_Click(
            object sender,
            EventArgs e)
        {
            Inicio login =
                new Inicio();

            login.Show();

            this.Hide();
        }

        private void panelContenido_Paint(
          object sender,
          PaintEventArgs e)
        {

        }
    }
}