using CapaEntidades;
using CapaNegocio;
using CapaPresentacion;
using Presentacion;
using System;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
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
        // CONEXIÓN Y RUTA BACKUP (GLOBAL)
        // =========================================
        string conexion =
        @"Server=localhost;Database=ClaribetSpa;Integrated Security=true";

        string rutaBackup =
        @"C:\Backups";

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

            // BOTONES MENU
            DiseñoBoton(btnClientes);
            DiseñoBoton(btnServicios);
            DiseñoBoton(btnUsuario);
            DiseñoBoton(btnCitas);
            DiseñoBoton(btnDisponibilidad);
            DiseñoBoton(btnFactura);
            DiseñoBoton(btnInicio);
            DiseñoBoton(btnCerrarSesion);

            // BOTONES BACKUP
            DiseñoBoton(btnBackupFull);
            DiseñoBoton(btnBackupDifferential);
            DiseñoBoton(btnBackupLog);
            DiseñoBoton(btnRestoreBackup);
            DiseñoBoton(btnSeleccionarCarpt);

            // TEXTOS MENU
            btnClientes.Text = "👤 Clientes";
            btnServicios.Text = "🌸 Servicios";
            btnInicio.Text = "🌸 Servicios";
            btnUsuario.Text = "👥 Usuarios";
            btnCitas.Text = "📅 Citas";
            btnDisponibilidad.Text = "🕒 Disponibilidad";
            btnFactura.Text = "🧾 Factura";
            btnCerrarSesion.Text = "↩ Cerrar Sesión";


            // TEXTOS BACKUP
            btnBackupFull.Text = "💾 Backup Full";
            btnBackupDifferential.Text = "🗂 Backup Differential";
            btnBackupLog.Text = "📦 Backup Incremental";
            btnRestoreBackup.Text = "♻ Restaurar Backup";
            btnSeleccionarCarpt.Text = "📁 Seleccionar Carpeta";

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
        // BACKUP GENERAL
        // =========================================
        private void EjecutarBackup(string query, string mensaje)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show(mensaje, "BACKUP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // =========================================
        // FULL BACKUP
        // =========================================
        private void btnBackupFull_Click(object sender, EventArgs e)
        {
            string ruta = $@"{rutaBackup}\FULL_{DateTime.Now:yyyyMMdd_HHmmss}.bak";

            string query = $@"
BACKUP DATABASE ClaribetSpa
TO DISK = '{ruta}'
WITH FORMAT, INIT";

            EjecutarBackup(query, "Backup FULL realizado");
        }

        // =========================================
        // DIFFERENTIAL
        // =========================================
        private void btnBackupDifferential_Click(object sender, EventArgs e)
        {
            string ruta = $@"{rutaBackup}\DIFF_{DateTime.Now:yyyyMMdd_HHmmss}.bak";

            string query = $@"
BACKUP DATABASE ClaribetSpa
TO DISK = '{ruta}'
WITH DIFFERENTIAL";

            EjecutarBackup(query, "Backup DIFFERENTIAL realizado");
        }

        // =========================================
        // LOG (INCREMENTAL)
        // =========================================
        private void btnBackupLog_Click(object sender, EventArgs e)
        {
            string ruta = $@"{rutaBackup}\LOG_{DateTime.Now:yyyyMMdd_HHmmss}.trn";

            string query = $@"
BACKUP LOG ClaribetSpa
TO DISK = '{ruta}'";

            EjecutarBackup(query, "Backup LOG realizado");
        }

        // =========================================
        // RESTAURAR BACKUP
        // =========================================
        private void btnRestoreBackup_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Backup (*.bak)|*.bak";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string query = $@"
USE master;
ALTER DATABASE ClaribetSpa SET SINGLE_USER WITH ROLLBACK IMMEDIATE;

RESTORE DATABASE ClaribetSpa
FROM DISK = '{ofd.FileName}'
WITH REPLACE;

ALTER DATABASE ClaribetSpa SET MULTI_USER;";

                EjecutarBackup(query, "Restauración completada");
            }
        }

        // =========================================
        // CAMBIAR CARPETA
        // =========================================
        private void btnSelectBackupFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                rutaBackup = fbd.SelectedPath;
                MessageBox.Show("Carpeta seleccionada: " + rutaBackup);
            }
        }

        // =========================================
        // FORMULARIOS
        // =========================================
        private void AbrirFormulario(Form frm)
        {
            panelContenido.Controls.Clear();

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            panelContenido.Controls.Add(frm);
            frm.Show();
            frm.BringToFront();
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

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBackupFull_Click_1(object sender, EventArgs e)
        {

        }

        private void btnBackupDifferential_Click_1(object sender, EventArgs e)
        {

        }

        private void btnBackupLog_Click_1(object sender, EventArgs e)
        {

        }

        private void btnRestoreBackup_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSeleccionarCarpt_Click(object sender, EventArgs e)
        {

        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmPrincipal());
        }
    }
}