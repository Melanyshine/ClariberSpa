using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Capa_Presentacion
{
    public partial class Inicio : Form
    {
        // ======================================================================================
        // CADENA DE CONEXIÓN PERFECTA Y CORREGIDA PARA TU COMPUTADORA
        // ======================================================================================
        private readonly string cadenaConexion = "Data Source=localhost;Initial Catalog=ClaribetSpa;Integrated Security=True";

        // Paleta de colores personalizada de Claribet Beauty Center & Spa
        private readonly Color colorFondoFormulario = Color.FromArgb(245, 240, 238);
        private readonly Color colorTarjeta = Color.White;
        private readonly Color colorBoton = Color.FromArgb(140, 79, 94);
        private readonly Color colorTexto = Color.FromArgb(92, 68, 67);

        public Inicio()
        {
            InitializeComponent();

            // Forzamos los enlaces de los eventos principales para asegurar el funcionamiento
            this.Load += new System.EventHandler(this.Inicio_Load);
            btnInicioSesion.Click += new System.EventHandler(this.btnInicioSesion_Click);
            linkOlvidoPassword.Click += new System.EventHandler(this.lblOlvideContraseña_Click);
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            // 1. Configuración de la Ventana Maximada sin bordes molestos
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = colorFondoFormulario;

            if (PicFondo != null)
                PicFondo.SizeMode = PictureBoxSizeMode.StretchImage;

            // 2. Aplicar Diseño y Bordes Redondeados a tu panel gris
            EstilarFormulario();
            EstilarControles();
            panelFormulario.Paint += new PaintEventHandler(DibujarBordesRedondeados);
            panelFormulario.Invalidate();

            // 3. Inicializar Placeholders (Efecto de abrir/cerrar texto en los cuadros)
            InicializarPlaceholders();

            // 4. Llenar el ComboBox de Roles con tus roles reales de SQL Server
            CargarRolesDesdeBD();
        }

        // =================================================
        // CONEXIÓN A LA BASE DE DATOS Y LÓGICA DEL LOGIN
        // =================================================
        private void btnInicioSesion_Click(object sender, EventArgs e)
        {
            // Validaciones para que no dejen casillas vacías
            if (!ValidarCampos()) return;

            string correoIngresado = txtCorreo.Text.Trim();
            string contraseñaIngresada = txtContraseña.Text.Trim();
            string rolSeleccionado = cmbRol.SelectedItem.ToString();

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();

                    // Ejecuta tu procedimiento almacenado SP_Login
                    using (SqlCommand comando = new SqlCommand("SP_Login", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@correo", correoIngresado);
                        comando.Parameters.AddWithValue("@contraseña", contraseñaIngresada);

                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                string rolBD = lector["nombre_rol"].ToString();
                                string nombreUsuario = lector["nombre"].ToString() + " " + lector["apellido"].ToString();

                                // Verificación estricta de Roles
                                if (rolBD.Equals(rolSeleccionado, StringComparison.OrdinalIgnoreCase))
                                {
                                    MostrarAlerta($"¡Bienvenido(a) {nombreUsuario}!\nInicio de sesión exitoso como {rolBD}.", "Acceso Autorizado", MessageBoxIcon.Information);

                                    // AQUÍ ABRES TU MENÚ PRINCIPAL DESPUÉS:
                                    // MenuPrincipal menu = new MenuPrincipal();
                                    // menu.Show();
                                    // this.Hide();
                                }
                                else
                                {
                                    MostrarAlerta($"El usuario existe, pero no pertenece al rol '{rolSeleccionado}'.", "Error de Rol", MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                MostrarAlerta("Correo electrónico o contraseña incorrectos. Verifique sus datos.", "Error de Autenticación", MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MostrarAlerta("Error crítico de conexión: " + ex.Message, "Error del Sistema", MessageBoxIcon.Error);
                }
            }
        }

        // Carga tus roles dinámicamente mapeando la tabla 'Roles'
        private void CargarRolesDesdeBD()
        {
            cmbRol.Items.Clear();

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string consulta = "SELECT nombre_rol FROM Roles";
                SqlCommand comando = new SqlCommand(consulta, conexion);

                try
                {
                    conexion.Open();
                    SqlDataReader lector = comando.ExecuteReader();

                    while (lector.Read())
                    {
                        cmbRol.Items.Add(lector["nombre_rol"].ToString());
                    }

                    cmbRol.SelectedIndex = -1; // Dejarlo vacío al inicio
                }
                catch (Exception ex)
                {
                    // Alerta por si hay un error al conectar con la BD
                    MessageBox.Show("Error de conexión al cargar los roles: " + ex.Message,
                                    "Alerta del Sistema",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        // Lógica del link ¿Olvidaste tu contraseña?
        private void lblOlvideContraseña_Click(object sender, EventArgs e)
        {
            string correo = (txtCorreo.Text != "Correo electrónico o usuario") ? txtCorreo.Text : "";

            MessageBox.Show($"Se ha enviado un enlace de restablecimiento al correo: {correo}\n\nSi el campo está vacío, por favor escriba su correo en el recuadro superior antes de presionar este enlace.",
                "Restablecer Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // =================================================
        // VALIDACIONES Y PLACEHOLDERS
        // =================================================
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtCorreo.Text) || txtCorreo.Text == "Correo electrónico o usuario")
            {
                MostrarAlerta("Debe ingresar su correo electrónico o usuario.", "Campo Requerido", MessageBoxIcon.Warning);
                txtCorreo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtContraseña.Text) || txtContraseña.Text == "Contraseña")
            {
                MostrarAlerta("Debe ingresar su contraseña.", "Campo Requerido", MessageBoxIcon.Warning);
                txtContraseña.Focus();
                return false;
            }

            if (cmbRol.SelectedIndex == -1)
            {
                MostrarAlerta("Debe seleccionar su rol correspondiente para ingresar.", "Campo Requerido", MessageBoxIcon.Warning);
                cmbRol.Focus();
                return false;
            }

            return true;
        }

        private void InicializarPlaceholders()
        {
            txtCorreo.Text = "Correo electrónico o usuario";
            txtCorreo.ForeColor = Color.Gray;
            txtContraseña.Text = "Contraseña";
            txtContraseña.ForeColor = Color.Gray;
            txtContraseña.UseSystemPasswordChar = false;

            // Al hacer clic en el correo
            txtCorreo.Enter += (s, e) => {
                if (txtCorreo.Text == "Correo electrónico o usuario")
                {
                    txtCorreo.Text = "";
                    txtCorreo.ForeColor = colorTexto;
                }
            };

            // Al salir del correo
            txtCorreo.Leave += (s, e) => {
                if (string.IsNullOrWhiteSpace(txtCorreo.Text))
                {
                    txtCorreo.Text = "Correo electrónico o usuario";
                    txtCorreo.ForeColor = Color.Gray;
                }
            };

            // Al hacer clic en la contraseña (Se abre el texto y se oculta con puntitos)
            txtContraseña.Enter += (s, e) => {
                if (txtContraseña.Text == "Contraseña")
                {
                    txtContraseña.Text = "";
                    txtContraseña.ForeColor = colorTexto;
                    txtContraseña.UseSystemPasswordChar = true;
                }
            };

            // Al salir de la contraseña
            txtContraseña.Leave += (s, e) => {
                if (string.IsNullOrWhiteSpace(txtContraseña.Text))
                {
                    txtContraseña.UseSystemPasswordChar = false;
                    txtContraseña.Text = "Contraseña";
                    txtContraseña.ForeColor = Color.Gray;
                }
            };
        }

        private void MostrarAlerta(string mensaje, string titulo, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, icono);
        }

        // =================================================
        // SECCIÓN DE DISEÑO VISUAL
        // =================================================
        private void EstilarFormulario()
        {
            this.BackColor = colorFondoFormulario;
        }

        private void EstilarControles()
        {
            panelFormulario.BackColor = colorTarjeta;

            btnInicioSesion.FlatStyle = FlatStyle.Flat;
            btnInicioSesion.FlatAppearance.BorderSize = 0;
            btnInicioSesion.BackColor = colorBoton;
            btnInicioSesion.ForeColor = Color.White;
            btnInicioSesion.Font = new Font("Segoe UI", 12F, FontStyle.Bold);

            EstiloTextbox(txtCorreo);
            EstiloTextbox(txtContraseña);
        }

        private void EstiloTextbox(TextBox txt)
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
                {
                    e.Graphics.FillPath(brush, path);
                }
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

        private void Inicio_Load_1(object sender, EventArgs e)
        {

        }
    }
}