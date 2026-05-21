using CapaEntidades;
using CapaNegocio;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Capa_Presentacion
{
    public partial class FrmServicio : Form
    {
        public int IdServicio { get; set; } = 0;

        ServiciosBLL bll = new ServiciosBLL();

        // =========================
        // BORDES REDONDOS FORM
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

        public FrmServicio()
        {
            InitializeComponent();

            // =========================
            // FORMULARIO REDONDO
            // =========================
            this.FormBorderStyle = FormBorderStyle.None;

            Region = Region.FromHrgn(
                CreateRoundRectRgn(
                    0,
                    0,
                    Width,
                    Height,
                    40,
                    40));

            CargarCategorias();

            txtDescripcion.KeyPress += txtDescripcion_KeyPress;

            DiseñarFormulario();
            ConfigurarPlaceholders();
        }

        private void FrmServicio_Load(object sender, EventArgs e)
        {
            if (IdServicio != 0)
            {
                CargarDatos(IdServicio);
            }
        }

        // =========================
        // DISEÑO SPA
        // =========================
        private void DiseñarFormulario()
        {
            // FORMULARIO
            this.BackColor = Color.FromArgb(248, 246, 242);
            this.StartPosition = FormStartPosition.CenterScreen;

            // TITULO
            lblTitulo.Text = "Nuevo Servicio";
            lblTitulo.Font = new Font("Georgia", 24, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(92, 45, 45);

            // LABELS
            foreach (Control c in this.Controls)
            {
                if (c is Label && c.Name != "lblTitulo")
                {
                    c.Font = new Font("Segoe UI", 11);
                    c.ForeColor = Color.FromArgb(60, 60, 60);
                }
            }

            // =========================
            // TEXTBOXES
            // =========================
            DiseñarTextBox(txtNombreServicio);
            DiseñarTextBox(txtPrecio);
            DiseñarTextBox(txtDescripcion);

            // =========================
            // COMBOBOX
            // =========================
            cmbCategoria.Font = new Font("Segoe UI", 11);
            cmbCategoria.BackColor = Color.White;
            cmbCategoria.ForeColor = Color.FromArgb(92, 45, 45);
            cmbCategoria.FlatStyle = FlatStyle.Flat;

            cmbCategoria.Region = Region.FromHrgn(
                CreateRoundRectRgn(
                    0,
                    0,
                    cmbCategoria.Width,
                    cmbCategoria.Height,
                    20,
                    20));

            // =========================
            // BOTON GUARDAR
            // =========================
            btnGuardarServicio.BackColor = Color.FromArgb(169, 127, 84);
            btnGuardarServicio.ForeColor = Color.White;
            btnGuardarServicio.FlatStyle = FlatStyle.Flat;
            btnGuardarServicio.FlatAppearance.BorderSize = 0;
            btnGuardarServicio.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            // =========================
            // BOTON CANCELAR
            // =========================
            btnCancelar.BackColor = Color.White;
            btnCancelar.ForeColor = Color.FromArgb(169, 127, 84);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.FlatAppearance.BorderColor = Color.FromArgb(169, 127, 84);
            btnCancelar.FlatAppearance.BorderSize = 1;
            btnCancelar.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            // ❌ SIN BORDES REDONDOS EN BOTONES
            btnGuardarServicio.Region = null;
            btnCancelar.Region = null;
        }

        // =========================
        // DISEÑAR TEXTBOX
        // =========================
        private void DiseñarTextBox(TextBox txt)
        {
            txt.Font = new Font("Segoe UI", 11);
            txt.BackColor = Color.White;
            txt.ForeColor = Color.Gray;
            txt.BorderStyle = BorderStyle.FixedSingle;

            txt.Region = Region.FromHrgn(
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
            // NOMBRE
            txtNombreServicio.Text = "Ingrese el nombre";
            txtNombreServicio.ForeColor = Color.Gray;

            txtNombreServicio.Enter += (s, e) =>
            {
                if (txtNombreServicio.Text == "Ingrese el nombre")
                {
                    txtNombreServicio.Text = "";
                    txtNombreServicio.ForeColor = Color.Black;
                }
            };

            txtNombreServicio.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtNombreServicio.Text))
                {
                    txtNombreServicio.Text = "Ingrese el nombre";
                    txtNombreServicio.ForeColor = Color.Gray;
                }
            };

            // PRECIO
            txtPrecio.Text = "Ingrese el precio";
            txtPrecio.ForeColor = Color.Gray;

            txtPrecio.Enter += (s, e) =>
            {
                if (txtPrecio.Text == "Ingrese el precio")
                {
                    txtPrecio.Text = "";
                    txtPrecio.ForeColor = Color.Black;
                }
            };

            txtPrecio.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtPrecio.Text))
                {
                    txtPrecio.Text = "Ingrese el precio";
                    txtPrecio.ForeColor = Color.Gray;
                }
            };

            // DURACION
            txtDescripcion.Text = "Ingrese la duración";
            txtDescripcion.ForeColor = Color.Gray;

            txtDescripcion.Enter += (s, e) =>
            {
                if (txtDescripcion.Text == "Ingrese la duración")
                {
                    txtDescripcion.Text = "";
                    txtDescripcion.ForeColor = Color.Black;
                }
            };

            txtDescripcion.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
                {
                    txtDescripcion.Text = "Ingrese la duración";
                    txtDescripcion.ForeColor = Color.Gray;
                }
            };
        }

        // =========================
        // VALIDAR CAMPOS
        // =========================
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombreServicio.Text)
                || txtNombreServicio.Text == "Ingrese el nombre")
            {
                MessageBox.Show("Debes ingresar el nombre del servicio");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPrecio.Text)
                || txtPrecio.Text == "Ingrese el precio")
            {
                MessageBox.Show("Debes ingresar el precio");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text)
                || txtDescripcion.Text == "Ingrese la duración")
            {
                MessageBox.Show("Debes ingresar la duración");
                return false;
            }

            if (cmbCategoria.SelectedIndex == -1)
            {
                MessageBox.Show("Debes seleccionar una categoría");
                return false;
            }

            return true;
        }

        // =========================
        // CATEGORIAS
        // =========================
        private void CargarCategorias()
        {
            cmbCategoria.Items.Clear();

            cmbCategoria.Items.Add("Masajes");
            cmbCategoria.Items.Add("Faciales");
            cmbCategoria.Items.Add("Corporales");
            cmbCategoria.Items.Add("Uñas");
            cmbCategoria.Items.Add("Cabello");

            cmbCategoria.SelectedIndex = 0;
        }

        // =========================
        // CARGAR DATOS
        // =========================
        private void CargarDatos(int id)
        {
            DataTable dt = bll.Listar();

            DataRow[] fila = dt.Select("id_servicio = " + id);

            if (fila.Length == 0)
            {
                MessageBox.Show("Servicio no encontrado");
                return;
            }

            txtNombreServicio.Text = fila[0]["nombre_servicio"].ToString();
            txtNombreServicio.ForeColor = Color.Black;

            txtPrecio.Text = fila[0]["precio"].ToString();
            txtPrecio.ForeColor = Color.Black;

            txtDescripcion.Text = fila[0]["duracion_minutos"].ToString();
            txtDescripcion.ForeColor = Color.Black;
        }

        // =========================
        // GUARDAR
        // =========================
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            if (!decimal.TryParse(txtPrecio.Text.Trim(), out decimal precio))
            {
                MessageBox.Show("Precio inválido");
                return;
            }

            string soloNumeros = new string(
                txtDescripcion.Text.Where(char.IsDigit).ToArray());

            if (!int.TryParse(soloNumeros, out int duracion))
            {
                MessageBox.Show("Duración inválida");
                return;
            }

            Servicios s = new Servicios
            {
                id_servicio = IdServicio,
                nombre_servicio = txtNombreServicio.Text.Trim(),
                precio = precio,
                duracion_minutos = duracion
            };

            bll.Guardar(s);

            MessageBox.Show("Guardado correctamente");

            this.Close();
        }

        // =========================
        // SOLO NUMEROS
        // =========================
        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // =========================
        // CANCELAR
        // =========================
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}