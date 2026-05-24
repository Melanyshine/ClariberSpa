using CapaNegocio;
using CapaEntidades;
using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Capa_Presentacion
{
    public partial class FrmCliente : Form
    {
        public int IdCliente { get; set; } = 0;

        ClientesBLL bll = new ClientesBLL();

        // =========================
        // COLORES
        // =========================
        private readonly Color colorPrincipal =
            Color.FromArgb(169, 127, 84);

        private readonly Color fondo =
            Color.FromArgb(248, 246, 242);

        // =========================
        // BORDES REDONDOS
        // =========================
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

        public FrmCliente()
        {
            InitializeComponent();

            this.FormBorderStyle =
                FormBorderStyle.None;

            Region = Region.FromHrgn(
                CreateRoundRectRgn(
                    0,
                    0,
                    Width,
                    Height,
                    40,
                    40));

            DiseñarFormulario();

            ConfigurarPlaceholders();

            this.Load += FrmCliente_Load;
        }

        public FrmCliente(int id)
        {
            InitializeComponent();

            this.IdCliente = id;

            this.FormBorderStyle =
                FormBorderStyle.None;

            Region = Region.FromHrgn(
                CreateRoundRectRgn(
                    0,
                    0,
                    Width,
                    Height,
                    40,
                    40));

            DiseñarFormulario();

            ConfigurarPlaceholders();

            this.Load += FrmCliente_Load;
        }

        // =========================
        // LOAD
        // =========================
        private void FrmCliente_Load(
            object sender,
            EventArgs e)
        {
            if (IdCliente != 0)
            {
                CargarDatosCliente(IdCliente);
            }
        }

        // =========================
        // DISEÑO
        // =========================
        private void DiseñarFormulario()
        {
            // FORM
            this.BackColor = fondo;

            this.StartPosition =
                FormStartPosition.CenterScreen;

            // TITULO
            lblTitulo.Text =
                "Nuevo Cliente";

            lblTitulo.Font =
                new Font(
                    "Georgia",
                    24,
                    FontStyle.Bold);

            lblTitulo.ForeColor =
                Color.FromArgb(92, 45, 45);

            // LABELS
            foreach (Control c in this.Controls)
            {
                if (c is Label &&
                    c.Name != "lblTitulo")
                {
                    c.Font =
                        new Font(
                            "Segoe UI",
                            11);

                    c.ForeColor =
                        Color.FromArgb(
                            60,
                            60,
                            60);
                }
            }

            // TEXTBOX
            DiseñarTextBox(txtNombre);
            DiseñarTextBox(txtApellido);
            DiseñarTextBox(txtCorreo);
            DiseñarTextBox(txtTelefono);

            // BOTON GUARDAR
            btnGuardar.BackColor =
                colorPrincipal;

            btnGuardar.ForeColor =
                Color.White;

            btnGuardar.FlatStyle =
                FlatStyle.Flat;

            btnGuardar.FlatAppearance.BorderSize =
                0;

            btnGuardar.Font =
                new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Bold);

            // BOTON CANCELAR
            btnCancelar.BackColor =
                Color.White;

            btnCancelar.ForeColor =
                colorPrincipal;

            btnCancelar.FlatStyle =
                FlatStyle.Flat;

            btnCancelar.FlatAppearance.BorderColor =
                colorPrincipal;

            btnCancelar.FlatAppearance.BorderSize =
                1;

            btnCancelar.Font =
                new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Bold);
        }

        // =========================
        // TEXTBOX
        // =========================
        private void DiseñarTextBox(
            TextBox txt)
        {
            txt.Font =
                new Font(
                    "Segoe UI",
                    11);

            txt.BackColor =
                Color.White;

            txt.ForeColor =
                Color.Gray;

            txt.BorderStyle =
                BorderStyle.FixedSingle;

            txt.Region =
                Region.FromHrgn(
                    CreateRoundRectRgn(
                        0,
                        0,
                        txt.Width,
                        txt.Height,
                        15,
                        15));
        }

        // =========================
        // PLACEHOLDERS
        // =========================
        private void ConfigurarPlaceholders()
        {
            Placeholder(
                txtNombre,
                "Ingrese el nombre");

            Placeholder(
                txtApellido,
                "Ingrese el apellido");

            Placeholder(
                txtCorreo,
                "Ingrese el correo");

            Placeholder(
                txtTelefono,
                "Ingrese el teléfono");
        }

        private void Placeholder(
            TextBox txt,
            string texto)
        {
            txt.Text = texto;

            txt.ForeColor =
                Color.Gray;

            txt.Enter += (s, e) =>
            {
                if (txt.Text == texto)
                {
                    txt.Text = "";

                    txt.ForeColor =
                        Color.Black;
                }
            };

            txt.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = texto;

                    txt.ForeColor =
                        Color.Gray;
                }
            };
        }

        // =========================
        // CARGAR DATOS
        // =========================
        private void CargarDatosCliente(
            int id)
        {
            DataTable dt =
                bll.Listar();

            DataRow[] fila =
                dt.Select(
                    "id_cliente = " + id);

            if (fila.Length > 0)
            {
                txtNombre.Text =
                    fila[0]["nombre"].ToString();

                txtNombre.ForeColor =
                    Color.Black;

                txtApellido.Text =
                    fila[0]["apellido"].ToString();

                txtApellido.ForeColor =
                    Color.Black;

                txtCorreo.Text =
                    fila[0]["correo"].ToString();

                txtCorreo.ForeColor =
                    Color.Black;

                txtTelefono.Text =
                    fila[0]["telefono"].ToString();

                txtTelefono.ForeColor =
                    Color.Black;
            }
        }

        // =========================
        // VALIDAR
        // =========================
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text)
                || txtNombre.Text == "Ingrese el nombre")
            {
                MessageBox.Show(
                    "Debes ingresar el nombre");

                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text)
                || txtApellido.Text == "Ingrese el apellido")
            {
                MessageBox.Show(
                    "Debes ingresar el apellido");

                return false;
            }

            return true;
        }

        // =========================
        // GUARDAR
        // =========================
        private void btnGuardar_Click(
            object sender,
            EventArgs e)
        {
            if (!ValidarCampos())
                return;

            Clientes c =
                new Clientes
                {
                    id_cliente =
                        IdCliente,

                    nombre =
                        txtNombre.Text.Trim(),

                    apellido =
                        txtApellido.Text.Trim(),

                    correo =
                        txtCorreo.Text.Trim(),

                    telefono =
                        txtTelefono.Text.Trim(),

                    fecha_registro =
                        DateTime.Now
                };

            bll.Guardar(c);

            MessageBox.Show(
                IdCliente == 0
                ? "Cliente creado correctamente"
                : "Cliente actualizado correctamente");

            this.Close();
        }

        // =========================
        // CANCELAR
        // =========================
        private void btnCancelar_Click(
            object sender,
            EventArgs e)
        {
            this.Close();
        }
    }
}