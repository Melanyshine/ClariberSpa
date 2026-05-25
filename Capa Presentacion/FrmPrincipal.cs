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
        private void FrmPrincipal_Load(
            object sender,
            EventArgs e)
        {
            // =========================================
            // FORM
            // =========================================

            this.WindowState =
                FormWindowState.Maximized;

            this.BackColor =
                Color.FromArgb(
                    230,
                    223,
                    220);

            // =========================================
            // PANEL MENU
            // =========================================

            panelMenu.BackColor =
                Color.FromArgb(
                    126,
                    90,
                    78);

            panelMenu.Width =
                280;

            // =========================================
            // PANEL CONTENIDO
            // =========================================

            panelContenido.BackColor =
                Color.White;

            panelContenido.Dock =
                DockStyle.Fill;

            // =========================================
            // TITULO
            // =========================================

            lblTitulo.Text =
                "CLARIBER SPA";

            lblTitulo.ForeColor =
                Color.Beige;

            lblTitulo.Font =
                new Font(
                    "Georgia",
                    20,
                    FontStyle.Bold);

            lblTitulo.AutoSize =
                true;

            lblTitulo.BackColor =
                Color.Transparent;

            // =========================================
            // BOTONES
            // =========================================

            DiseñoBoton(btnClientes);
            DiseñoBoton(btnServicios);
            DiseñoBoton(btnUsuario);
            DiseñoBoton(btnCitas);
            DiseñoBoton(btnDisponibilidad);
            DiseñoBoton(btnFactura);
            DiseñoBoton(btnCerrarSesion);

            // =========================================
            // TEXTOS
            // =========================================

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
                "🧾 Factura";

            btnCerrarSesion.Text =
                "↩ Cerrar Sesión";
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
                    FontStyle.Regular);

            btn.TextAlign =
                ContentAlignment.MiddleLeft;

            btn.ImageAlign =
                ContentAlignment.MiddleLeft;

            btn.Padding =
                new Padding(15, 0, 0, 0);

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
        // EFECTO HOVER
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
        // ABRIR FORMS EN PANEL
        // =========================================

        private void AbrirFormulario(
            Form frm)
        {
            panelContenido.Controls.Clear();

            frm.TopLevel =
                false;

            frm.FormBorderStyle =
                FormBorderStyle.None;

            frm.Dock =
                DockStyle.Fill;

            panelContenido.Controls.Add(frm);

            panelContenido.Tag =
                frm;

            frm.Show();

            frm.BringToFront();
        }

        // =========================================
        // CLIENTES
        // =========================================

        private void btnClientes_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(
                new FrmClientes());
        }

        // =========================================
        // SERVICIOS
        // =========================================

        private void btnServicios_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(
                new Servicio());
        }

        // =========================================
        // USUARIOS
        // =========================================

        // =========================================
        // USUARIOS / EMPLEADOS
        // =========================================

        private void btnUsuario_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(
                new FrmEmpleado());
        }

        // =========================================
        // CITAS
        // =========================================

        private void btnCitas_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(
                new FrmCitas());
        }

        // =========================================
        // DISPONIBILIDAD
        // =========================================

        private void btnDisponibilidad_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(
                new FrmDisponibilidad());
        }

        // =========================================
        // HISTORIAL
        // =========================================

        private void btnFactura_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(
                new FrmFactura());
        }

        // =========================================
        // CERRAR SESION
        // =========================================

        private void btnCerrarSesion_Click(
            object sender,
            EventArgs e)
        {
            this.Close();
        }
    }
}