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

        // =====================================
        // LOAD
        // =====================================
        private void FrmMenu_Load(
            object sender,
            EventArgs e)
        {
            this.WindowState =
                FormWindowState.Maximized;

            // =================================
            // PANEL
            // =================================
            panelMenu.BackColor =
                Color.FromArgb(
                    120, 84, 72);

            // =================================
            // TITULO
            // =================================
            lblTitulo.Text =
                "CLARIBER SPA";

            lblTitulo.ForeColor =
                Color.Beige;

            lblTitulo.Font =
                new Font(
                    "Georgia",
                    18,
                    FontStyle.Bold);

            // =================================
            // BOTONES
            // =================================

            DiseñoBoton(btnClientes);

            DiseñoBoton(btnServicios);

            DiseñoBoton(btnUsuarios);

            DiseñoBoton(btnCitas);

            DiseñoBoton(btnDisponibilidad);

            DiseñoBoton(btnHistorial);

            DiseñoBoton(btnCerrarSesion);

            // =================================
            // TEXTO BOTONES
            // =================================
  

            btnClientes.Text =
                "👤 Clientes";

            btnServicios.Text =
                "🌸 Servicios";

            btnUsuarios.Text =
                "👥 Empleados";

            btnCitas.Text =
                "📅 Citas";

            btnDisponibilidad.Text =
                "🕒 Disponibilidad";

            btnHistorial.Text =
                "📋 Historial";


            btnCerrarSesion.Text =
                "↩ Cerrar Sesión";
        }

        // =====================================
        // DISEÑO BOTONES
        // =====================================
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
                    11,
                    FontStyle.Regular);

            btn.TextAlign =
                ContentAlignment.MiddleLeft;

            btn.Cursor =
                Cursors.Hand;

            btn.MouseEnter +=
                Btn_MouseEnter;

            btn.MouseLeave +=
                Btn_MouseLeave;
        }

        // =====================================
        // HOVER
        // =====================================
        private void Btn_MouseEnter(
            object sender,
            EventArgs e)
        {
            Button btn =
                (Button)sender;

            btn.BackColor =
                Color.FromArgb(
                    166, 117, 102);
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

        // =====================================
        // CLIENTES
        // =====================================
        private void btnClientes_Click(
            object sender,
            EventArgs e)
        {
            Clientes frm =
                new Clientes();

            frm.Show();
        }

        // =====================================
        // SERVICIOS
        // =====================================
        private void btnServicios_Click(
            object sender,
            EventArgs e)
        {
            FrmServicio frm =
                new FrmServicio();

            frm.Show();
        }

        // =====================================
        // EMPLEADOS
        // =====================================
        private void btnEmpleados_Click(
            object sender,
            EventArgs e)
        {
            FrmEmpleado frm =
                new FrmEmpleado();

            frm.Show();
        }

        // =====================================
        // CITAS
        // =====================================
        private void btnCitas_Click(
            object sender,
            EventArgs e)
        {
            FrmCitas frm =
                new FrmCitas();

            frm.Show();
        }

        // =====================================
        // DISPONIBILIDAD
        // =====================================
        private void btnDisponibilidad_Click(
            object sender,
            EventArgs e)
        {
            FrmDisponibilidad frm =
                new FrmDisponibilidad();

            frm.Show();
        }

        // =====================================
        // PAGOS
        // =====================================


        // =====================================
        // HISTORIAL
        // =====================================
        private void btnHistorial_Click(
            object sender,
            EventArgs e)
        {
            FrmHistorialCitas frm =
                new FrmHistorialCitas();

            frm.Show();
        }

        // =====================================
        // REPORTES
        // =====================================
   

        // =====================================
        // CONFIGURACION
        // =====================================

        // =====================================
        // CERRAR SESION
        // =====================================
        private void btnCerrarSesion_Click(
            object sender,
            EventArgs e)
        {
            this.Close();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
