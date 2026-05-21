using CapaEntidades;
using CapaNegocio;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Capa_Presentacion
{
    public partial class FrmServicio : Form
    {
        public int IdServicio { get; set; } = 0;

        ServiciosBLL bll = new ServiciosBLL();

        public FrmServicio()
        {
            InitializeComponent();

            CargarCategorias();

            // 🔥 BLOQUEO: SOLO NÚMEROS EN DURACIÓN
            txtDescripcion.KeyPress += txtDescripcion_KeyPress;
        }

        private void FrmServicio_Load(object sender, EventArgs e)
        {
            if (IdServicio != 0)
            {
                CargarDatos(IdServicio);
            }
        }

        // =========================
        // CATEGORÍAS
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
        // CARGAR DATOS (EDITAR)
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
            txtPrecio.Text = fila[0]["precio"].ToString();
            txtDescripcion.Text = fila[0]["duracion_minutos"].ToString();
        }

        // =========================
        // GUARDAR
        // =========================
        private void btnGuardar_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Valor real: [" + txtDescripcion.Text + "]");
            if (string.IsNullOrWhiteSpace(txtNombreServicio.Text))
            {
                MessageBox.Show("Nombre requerido");
                return;
            }

            if (!decimal.TryParse(txtPrecio.Text.Trim(), out decimal precio))
            {
                MessageBox.Show("Precio inválido");
                return;
            }

            // 🔥 AQUÍ VA LA DURACIÓN
            string textoDuracion = txtDescripcion.Text.Trim();

            if (string.IsNullOrWhiteSpace(textoDuracion))
            {
                MessageBox.Show("Ingresa la duración");
                return;
            }

            string soloNumeros = new string(textoDuracion.Where(char.IsDigit).ToArray());

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
        // BLOQUEO SOLO NÚMEROS
        // =========================
        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
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