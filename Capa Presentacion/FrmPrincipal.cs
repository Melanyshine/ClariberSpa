using CapaEntidades;
using CapaNegocio;
using CapaPresentacion;
using Presentacion;
using System;
using System.Drawing;
using System.Windows.Forms;

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
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.FromArgb(230, 223, 220);

            panelMenu.BackColor = Color.FromArgb(126, 90, 78);
            panelMenu.Width = 280;

            panelContenido.BackColor = Color.White;
            panelContenido.Dock = DockStyle.Fill;

            lblTitulo.Text = "CLARIBER SPA";
            lblTitulo.ForeColor = Color.Beige;
            lblTitulo.Font = new Font("Georgia", 20, FontStyle.Bold);
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = Color.Transparent;

            // =========================================
            // DISEÑO BOTONES
            // =========================================
            DiseñoBoton(btnInicio);
            DiseñoBoton(btnClientes);
            DiseñoBoton(btnServicios);
            DiseñoBoton(btnUsuario);
            DiseñoBoton(btnCitas);
            DiseñoBoton(btnDisponibilidad);
            DiseñoBoton(btnFactura);
            DiseñoBoton(btnConfiguracion);
            DiseñoBoton(btnCerrarSesion);

            // =========================================
            // TEXTOS BOTONES
            // =========================================
            btnInicio.Text = "🏠 Inicio";
            btnClientes.Text = "👤 Clientes";
            btnServicios.Text = "🌸 Servicios";
            btnUsuario.Text = "👥 Usuarios";
            btnCitas.Text = "📅 Citas";
            btnDisponibilidad.Text = "🕒 Disponibilidad";
            btnFactura.Text = "🧾 Factura";
            btnConfiguracion.Text = "⚙️ Configuración";
            btnCerrarSesion.Text = "↩ Cerrar Sesión";
        }

        // =========================================
        // DISEÑO BOTÓN
        // =========================================
        private void DiseñoBoton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.Transparent;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 12);
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(15, 0, 0, 0);
            btn.Height = 55;
            btn.Width = 260;
            btn.Cursor = Cursors.Hand;

            btn.MouseEnter += Btn_MouseEnter;
            btn.MouseLeave += Btn_MouseLeave;
        }

        private void Btn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.FromArgb(166, 117, 102);
        }

        private void Btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.Transparent;
        }

        // =========================================
        // ABRIR FORMULARIOS
        // =========================================
        public void AbrirFormulario(Form frm)
        {
            panelContenido.Controls.Clear();

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            panelContenido.Controls.Add(frm);

            frm.Show();
            frm.BringToFront();
        }

        // =========================================
        // BOTONES MENÚ
        // =========================================
        private void btnInicio_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmClientes());
        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Servicio());
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmEmpleado());
        }

        private void btnCitas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmCitas());
        }

        private void btnDisponibilidad_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmDisponibilidad());
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmFactura());
        }

        // =========================================
        // CONFIGURACIÓN
        // =========================================
        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmConfiguracion());
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Inicio login = new Inicio();
            login.Show();
            this.Hide();
        }
    }
}