using CapaNegocio;
using CapaEntidades;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Capa_Presentacion
{
    public partial class FrmCliente : Form
    {
        public int IdCliente { get; set; } = 0;
        ClientesBLL bll = new ClientesBLL();

        // 🎨 Mismos colores del Historial
        private readonly Color colorRosado = Color.RosyBrown;
        private readonly Color fondo = Color.FromArgb(250, 248, 246);

        public FrmCliente()
        {
            InitializeComponent();
            this.Load += FrmCliente_Load;
        }

        public FrmCliente(int id)
        {
            InitializeComponent();
            this.IdCliente = id;
            this.Load += FrmCliente_Load;
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            AplicarDiseno(); // Aplicamos el estilo del Historial
            if (IdCliente != 0)
            {
                CargarDatosCliente(IdCliente);
            }
        }

        // 🎨 MÉTODO DE DISEÑO UNIFICADO
        private void AplicarDiseno()
        {
            this.BackColor = fondo;
            
            // Estilo de los Labels
            foreach (Control c in this.Controls)
            {
                if (c is Label)
                {
                    c.ForeColor = Color.FromArgb(90, 70, 70);
                    c.Font = new Font("Segoe UI", 10F);
                }
            }

            // Estilo de los TextBox
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    TextBox txt = (TextBox)c;
                    txt.BorderStyle = BorderStyle.FixedSingle;
                    txt.Font = new Font("Segoe UI", 11F);
                }
            }

            // Estilo Botón Guardar
            btnGuardar.BackColor = colorRosado;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnGuardar.Cursor = Cursors.Hand;

            // Estilo Botón Cancelar
            btnCancelar.BackColor = Color.FromArgb(235, 230, 228);
            btnCancelar.ForeColor = colorRosado;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.FlatAppearance.BorderColor = colorRosado;
            btnCancelar.Font = new Font("Segoe UI Semibold", 11F);
            btnCancelar.Cursor = Cursors.Hand;
        }

        private void CargarDatosCliente(int id)
        {
            DataTable dt = bll.Listar();
            DataRow[] fila = dt.Select("id_cliente = " + id);

            if (fila.Length > 0)
            {
                txtNombre.Text = fila[0]["nombre"].ToString();
                txtApellido.Text = fila[0]["apellido"].ToString();
                txtCorreo.Text = fila[0]["correo"].ToString();
                txtTelefono.Text = fila[0]["telefono"].ToString();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Completa los campos obligatorios", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            MessageBox.Show(IdCliente == 0 ? "Cliente creado correctamente" : "Cliente actualizado");
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e) => this.Close();
    }
}