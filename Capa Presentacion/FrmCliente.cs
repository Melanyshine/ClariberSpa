using CapaNegocio;
using CapaEntidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Capa_Presentacion
{
    public partial class FrmCliente : Form
    {
        public int IdCliente { get; set; } = 0;

        ClientesBLL bll = new ClientesBLL();

        public FrmCliente()
        {
            InitializeComponent();
            this.Load += FrmCliente_Load;
        }

        // ✔️ ESTE ES EL CONSTRUCTOR QUE TE FALTABA (ARREGLA TU ERROR)
        public FrmCliente(int id)
        {
            InitializeComponent();
            this.IdCliente = id;
            this.Load += FrmCliente_Load;
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            if (IdCliente != 0)
            {
                CargarDatosCliente(IdCliente);
            }
        }

        // =========================
        // CARGAR DATOS PARA EDITAR
        // =========================
        private void CargarDatosCliente(int id)
        {
            DataTable dt = bll.Listar();

            DataRow[] fila = dt.Select("id_cliente = " + id);

            if (fila.Length == 0)
            {
                MessageBox.Show("Cliente no encontrado");
                return;
            }

            txtNombre.Text = fila[0]["nombre"].ToString();
            txtApellido.Text = fila[0]["apellido"].ToString();
            txtCorreo.Text = fila[0]["correo"].ToString();
            txtTelefono.Text = fila[0]["telefono"].ToString();
        }

        // =========================
        // GUARDAR / ACTUALIZAR
        // =========================
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("Completa todos los campos obligatorios");
                return;
            }

            CapaEntidades.Clientes c = new CapaEntidades.Clientes
            {
                id_cliente = IdCliente,
                nombre = txtNombre.Text,
                apellido = txtApellido.Text,
                correo = txtCorreo.Text,
                telefono = txtTelefono.Text,
                fecha_registro = DateTime.Now
            };

            bll.Guardar(c);

            MessageBox.Show(
                IdCliente == 0 ? "Cliente creado correctamente" : "Cliente actualizado correctamente"
            );

            this.Close();
        }

        // =========================
        // CANCELAR
        // =========================
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

    }
}