using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace Capa_Presentacion
{
    public partial class FrmReportes : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        public FrmReportes()
        {
            InitializeComponent();

            this.Load += FrmReportes_Load;

            this.AutoScroll = true;

            this.DoubleBuffered = true;

            this.BackColor = Color.FromArgb(247, 243, 241);
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {
            DiseñarFormulario();
        }

        private void DiseñarFormulario()
        {
            this.Controls.Clear();

            // =====================================================
            // COLORES SUAVES
            // =====================================================

            Color fondo = Color.FromArgb(247, 243, 241);

            Color marron = Color.FromArgb(168, 120, 120);

            Color marronOscuro = Color.FromArgb(145, 100, 100);

            Color texto = Color.FromArgb(130, 120, 120);

            Color borde = Color.FromArgb(235, 228, 228);

            Color fondoIcono = Color.FromArgb(250, 245, 245);

            this.BackColor = fondo;

            // =====================================================
            // PANEL PRINCIPAL
            // =====================================================

            Panel contenedor = new Panel();

            contenedor.Size = new Size(980, 520);

            contenedor.Location = new Point(335, 70);

            contenedor.BackColor = Color.Transparent;

            this.Controls.Add(contenedor);

            // =====================================================
            // TITULO
            // =====================================================

            Label lblTitulo = new Label();

            lblTitulo.Text = "MÓDULO DE REPORTES";

            lblTitulo.Font = new Font("Segoe UI", 18, FontStyle.Bold);

            lblTitulo.ForeColor = Color.FromArgb(70, 60, 60);

            lblTitulo.AutoSize = true;

            lblTitulo.Location = new Point(10, 0);

            contenedor.Controls.Add(lblTitulo);

            Label linea = new Label();

            linea.BackColor = marron;

            linea.Size = new Size(80, 4);

            linea.Location = new Point(12, 40);

            contenedor.Controls.Add(linea);

            Label lblSub = new Label();

            lblSub.Text = "Seleccione el reporte que desea generar.";

            lblSub.Font = new Font("Segoe UI", 9);

            lblSub.ForeColor = texto;

            lblSub.AutoSize = true;

            lblSub.Location = new Point(12, 52);

            contenedor.Controls.Add(lblSub);

            // =====================================================
            // TABLA
            // =====================================================

            TableLayoutPanel tabla = new TableLayoutPanel();

            tabla.ColumnCount = 3;

            tabla.RowCount = 2;

            tabla.Size = new Size(920, 420);

            tabla.Location = new Point(0, 90);

            tabla.BackColor = Color.Transparent;

            tabla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tabla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tabla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));

            tabla.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tabla.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

            contenedor.Controls.Add(tabla);

            // =====================================================
            // DATOS
            // =====================================================

            string[] titulos =
            {
                "Reporte de Citas",
                "Reporte de Clientes",
                "Reporte de Servicios",
                "Reporte de Empleados",
                "Reporte de Ingresos",
                "Reporte de Disponibilidad"
            };

            string[] descripciones =
            {
                "Muestra todas las citas registradas.",
                "Lista de clientes registrados.",
                "Servicios ofrecidos en el spa.",
                "Información de empleados.",
                "Resumen de ingresos del spa.",
                "Disponibilidad por empleado."
            };

            string[] iconos =
            {
                "📅",
                "👤",
                "🌸",
                "👥",
                "💰",
                "🕒"
            };

            // =====================================================
            // TARJETAS
            // =====================================================

            for (int i = 0; i < 6; i++)
            {
                int index = i;

                Panel card = new Panel();

                card.Dock = DockStyle.Fill;

                card.Margin = new Padding(10);

                card.BackColor = Color.White;

                card.Region = Region.FromHrgn(CreateRoundRectRgn
                (
                    0,
                    0,
                    300,
                    190,
                    20,
                    20
                ));

                card.Paint += (s, e) =>
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                    e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                    e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    ControlPaint.DrawBorder
                    (
                        e.Graphics,
                        card.ClientRectangle,
                        borde,
                        ButtonBorderStyle.Solid
                    );
                };

                // =====================================================
                // ICONO
                // =====================================================

                Panel panelIcono = new Panel();

                panelIcono.Size = new Size(60, 60);

                panelIcono.Location = new Point(15, 15);

                panelIcono.BackColor = fondoIcono;

                panelIcono.Region = Region.FromHrgn(CreateRoundRectRgn
                (
                    0,
                    0,
                    60,
                    60,
                    60,
                    60
                ));

                card.Controls.Add(panelIcono);

                Label lblIcono = new Label();

                lblIcono.Text = iconos[i];

                lblIcono.Font = new Font("Segoe UI Emoji", 18);

                lblIcono.AutoSize = false;

                lblIcono.Dock = DockStyle.Fill;

                lblIcono.TextAlign = ContentAlignment.MiddleCenter;

                lblIcono.ForeColor = marron;

                panelIcono.Controls.Add(lblIcono);

                // =====================================================
                // TITULO
                // =====================================================

                Label lblNombre = new Label();

                lblNombre.Text = titulos[i];

                lblNombre.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                lblNombre.ForeColor = Color.FromArgb(55, 55, 55);

                lblNombre.AutoSize = false;

                lblNombre.Size = new Size(190, 25);

                lblNombre.Location = new Point(85, 18);

                card.Controls.Add(lblNombre);

                // =====================================================
                // DESCRIPCION
                // =====================================================

                Label lblDesc = new Label();

                lblDesc.Text = descripciones[i];

                lblDesc.Font = new Font("Segoe UI", 8);

                lblDesc.ForeColor = texto;

                lblDesc.AutoSize = false;

                lblDesc.Size = new Size(190, 45);

                lblDesc.Location = new Point(85, 48);

                card.Controls.Add(lblDesc);

                // =====================================================
                // BOTON
                // =====================================================

                Button btn = new Button();

                btn.Text = "📄 Generar";

                btn.Font = new Font("Segoe UI", 8, FontStyle.Bold);

                btn.Size = new Size(135, 34);

                btn.Location = new Point(85, 120);

                btn.BackColor = marron;

                btn.ForeColor = Color.White;

                btn.FlatStyle = FlatStyle.Flat;

                btn.FlatAppearance.BorderSize = 0;

                btn.Cursor = Cursors.Hand;

                btn.Region = Region.FromHrgn(CreateRoundRectRgn
                (
                    0,
                    0,
                    135,
                    34,
                    15,
                    15
                ));

                btn.Tag = index;

                btn.MouseEnter += (s, ev) =>
                {
                    btn.BackColor = marronOscuro;
                };

                btn.MouseLeave += (s, ev) =>
                {
                    btn.BackColor = marron;
                };

                btn.Click += BtnGenerar_Click;

                card.Controls.Add(btn);

                tabla.Controls.Add(card, i % 3, i / 3);
            }
        }

        // =====================================================
        // BOTONES
        // =====================================================

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            int index = (int)btn.Tag;

            switch (index)
            {
                case 0:
                    MessageBox.Show("Reporte de Citas");
                    break;

                case 1:
                    MessageBox.Show("Reporte de Clientes");
                    break;

                case 2:
                    MessageBox.Show("Reporte de Servicios");
                    break;

                case 3:
                    MessageBox.Show("Reporte de Empleados");
                    break;

                case 4:
                    FrmReporteIngresos frm = new FrmReporteIngresos();
                    frm.ShowDialog();
                    break;

                case 5:
                    MessageBox.Show("Reporte de Disponibilidad");
                    break;
            }
        }
    }
}