using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using CapaNegocio;

namespace Capa_Presentacion
{
    public partial class Inicio : Form
    {
        // =============================================
        // CAMPOS DE CLASE
        // =============================================
        UsuarioBLL negocio = new UsuarioBLL();

        Color colorFondoFormulario = Color.FromArgb(245, 240, 238);
        Color colorTarjeta = Color.White;
        Color colorBoton = Color.FromArgb(140, 79, 94);
        Color colorTexto = Color.FromArgb(92, 68, 67);

        // =============================================
        // CONSTRUCTOR
        // =============================================
        public Inicio()
        {
            InitializeComponent();
        }

        // =============================================
        // CARGA DEL FORMULARIO
        // =============================================
        private void Inicio_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = colorFondoFormulario;

            if (PicFondo != null)
                PicFondo.SizeMode = PictureBoxSizeMode.StretchImage;

            AplicarDiseno();
            InicializarPlaceholders();
            CargarRoles();

            panelFormulario.Paint += DibujarBordesRedondeados;
            panelFormulario.Invalidate();

            btnInicioSesion.Click += btnInicioSesion_Click;
            linkOlvidoPassword.Click += linkOlvidoPassword_Click;
        }

        // =============================================
        // INICIO DE SESIÓN
        // =============================================
        private void btnInicioSesion_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            string correo = txtCorreo.Text.Trim();
            string password = txtContraseña.Text.Trim();
            string rol = cmbRol.SelectedItem.ToString();

            try
            {
                DataTable resultado = negocio.Login(correo, password);

                if (resultado.Rows.Count == 0)
                {
                    MostrarAlerta("Correo o contraseña incorrectos.", "Acceso denegado", MessageBoxIcon.Error);
                    return;
                }

                DataRow fila = resultado.Rows[0];
                string rolBD = fila["nombre_rol"].ToString();
                string nombre = fila["nombre"].ToString() + " " + fila["apellido"].ToString();

                if (!rolBD.Equals(rol, StringComparison.OrdinalIgnoreCase))
                {
                    MostrarAlerta("El rol seleccionado no coincide con su cuenta.", "Rol incorrecto", MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show("Bienvenido(a) " + nombre, "Inicio correcto",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                FrmPrincipal frm = new FrmPrincipal();
                frm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MostrarAlerta(ex.Message, "Error de conexión", MessageBoxIcon.Error);
            }
        }

        // =============================================
        // CARGAR ROLES
        // =============================================
        private void CargarRoles()
        {
            try
            {
                DataTable roles = negocio.ListarRoles();
                cmbRol.Items.Clear();

                foreach (DataRow fila in roles.Rows)
                    cmbRol.Items.Add(fila["nombre_rol"].ToString());

                cmbRol.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MostrarAlerta("Error al cargar los roles: " + ex.Message,
                              "Alerta del sistema", MessageBoxIcon.Error);
            }
        }

        // =============================================
        // OLVIDÉ MI CONTRASEÑA
        // =============================================
        private void linkOlvidoPassword_Click(object sender, EventArgs e)
        {
            string correo = (txtCorreo.Text != "Correo electrónico o usuario")
                            ? txtCorreo.Text : "";

            MessageBox.Show(
                "Se ha enviado un enlace de restablecimiento al correo: " + correo +
                "\n\nSi el campo está vacío, escríbalo antes de presionar este enlace.",
                "Restablecer contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // =============================================
        // VALIDACIONES
        // =============================================
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtCorreo.Text) || txtCorreo.Text == "Correo electrónico o usuario")
            {
                MostrarAlerta("Debe ingresar su correo electrónico.", "Campo requerido", MessageBoxIcon.Warning);
                txtCorreo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtContraseña.Text) || txtContraseña.Text == "Contraseña")
            {
                MostrarAlerta("Debe ingresar su contraseña.", "Campo requerido", MessageBoxIcon.Warning);
                txtContraseña.Focus();
                return false;
            }

            if (cmbRol.SelectedIndex == -1)
            {
                MostrarAlerta("Debe seleccionar su rol.", "Campo requerido", MessageBoxIcon.Warning);
                cmbRol.Focus();
                return false;
            }

            return true;
        }

        private void MostrarAlerta(string mensaje, string titulo, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, icono);
        }

        // =============================================
        // PLACEHOLDERS
        // =============================================
        private void InicializarPlaceholders()
        {
            txtCorreo.Text = "Correo electrónico o usuario";
            txtCorreo.ForeColor = Color.Gray;

            txtContraseña.Text = "Contraseña";
            txtContraseña.ForeColor = Color.Gray;
            txtContraseña.UseSystemPasswordChar = false;

            txtCorreo.Enter += (s, e) => {
                if (txtCorreo.Text == "Correo electrónico o usuario")
                { txtCorreo.Text = ""; txtCorreo.ForeColor = colorTexto; }
            };

            txtCorreo.Leave += (s, e) => {
                if (string.IsNullOrWhiteSpace(txtCorreo.Text))
                { txtCorreo.Text = "Correo electrónico o usuario"; txtCorreo.ForeColor = Color.Gray; }
            };

            txtContraseña.Enter += (s, e) => {
                if (txtContraseña.Text == "Contraseña")
                { txtContraseña.Text = ""; txtContraseña.ForeColor = colorTexto; txtContraseña.UseSystemPasswordChar = true; }
            };

            txtContraseña.Leave += (s, e) => {
                if (string.IsNullOrWhiteSpace(txtContraseña.Text))
                { txtContraseña.UseSystemPasswordChar = false; txtContraseña.Text = "Contraseña"; txtContraseña.ForeColor = Color.Gray; }
            };
        }

        // =============================================
        // DISEÑO VISUAL
        // =============================================
        private void AplicarDiseno()
        {
            this.BackColor = colorFondoFormulario;
            panelFormulario.BackColor = colorTarjeta;

            btnInicioSesion.FlatStyle = FlatStyle.Flat;
            btnInicioSesion.FlatAppearance.BorderSize = 0;
            btnInicioSesion.BackColor = colorBoton;
            btnInicioSesion.ForeColor = Color.White;
            btnInicioSesion.Font = new Font("Segoe UI", 12F, FontStyle.Bold);

            AplicarEstiloTextbox(txtCorreo);
            AplicarEstiloTextbox(txtContraseña);
        }

        private void AplicarEstiloTextbox(TextBox txt)
        {
            txt.BorderStyle = BorderStyle.None;
            txt.BackColor = Color.White;
            txt.Font = new Font("Segoe UI", 11F);
        }

        private void DibujarBordesRedondeados(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);

            using (GraphicsPath path = ObtenerRutaRedondeada(rect, 25))
            {
                panel.Region = new Region(path);
                using (SolidBrush brush = new SolidBrush(Color.White))
                    e.Graphics.FillPath(brush, path);
            }
        }

        private GraphicsPath ObtenerRutaRedondeada(Rectangle rect, int radio)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radio * 2;

            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            return path;
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
        }
    }
}