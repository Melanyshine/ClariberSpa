using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace Capa_Presentacion
{
    public partial class FrmConfiguracion : Form
    {
        SqlConnection cn = new SqlConnection(
        "Server=localhost;Database=ClaribetSpa;Integrated Security=true;");

        public FrmConfiguracion()
        {
            InitializeComponent();
        }

        // BACKUP COMPLETO
        private void btnBackupCompleto_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"BACKUP DATABASE ClaribetSpa
                TO DISK='C:\\ClariberSpaBackup\\ClaribetSpa_Full.bak'
                WITH FORMAT, INIT";

                SqlCommand cmd = new SqlCommand(query, cn);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                MessageBox.Show(
                "Backup completo realizado correctamente");

                lblFechaBackup.Text =
                DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");

                lblEstadoBackup.Text =
                "Backup completo generado correctamente.";

                Process.Start(
                "explorer.exe",
                @"C:\ClariberSpaBackup");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // BACKUP DIFERENCIAL
        private void btnBackupDiferencial_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"BACKUP DATABASE ClaribetSpa
                TO DISK='C:\\ClariberSpaBackup\\ClaribetSpa_Diferencial.bak'
                WITH DIFFERENTIAL, INIT";

                SqlCommand cmd = new SqlCommand(query, cn);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                MessageBox.Show(
                "Backup diferencial realizado correctamente");

                lblFechaBackup.Text =
                DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");

                lblEstadoBackup.Text =
                "Backup diferencial generado correctamente.";

                Process.Start(
                "explorer.exe",
                @"C:\ClariberSpaBackup");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // BACKUP LOG / INCREMENTAL
        private void btnBackupLog_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"BACKUP LOG ClaribetSpa
                TO DISK='C:\\ClariberSpaBackup\\ClaribetSpa_Log.trn'
                WITH INIT";

                SqlCommand cmd = new SqlCommand(query, cn);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                MessageBox.Show(
                "Backup incremental realizado correctamente");

                lblFechaBackup.Text =
                DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");

                lblEstadoBackup.Text =
                "Backup incremental generado correctamente.";

                Process.Start(
                "explorer.exe",
                @"C:\ClariberSpaBackup");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ABRIR CARPETA
        private void btnAbrirCarpeta_Click(object sender, EventArgs e)
        {
            Process.Start(
            "explorer.exe",
            @"C:\ClariberSpaBackup");
        }

        // RESTAURAR BACKUP
        private void btnRestaurarBackup_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open =
                new OpenFileDialog();

                open.Filter =
                "Backup Files|*.bak";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    string query = $@"
                    USE master

                    ALTER DATABASE ClaribetSpa
                    SET SINGLE_USER
                    WITH ROLLBACK IMMEDIATE

                    RESTORE DATABASE ClaribetSpa
                    FROM DISK='{open.FileName}'
                    WITH REPLACE

                    ALTER DATABASE ClaribetSpa
                    SET MULTI_USER";

                    SqlCommand cmd =
                    new SqlCommand(query, cn);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();

                    MessageBox.Show(
                    "Base de datos restaurada correctamente");

                    lblEstadoBackup.Text =
                    "Backup restaurado correctamente.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}