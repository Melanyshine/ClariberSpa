using CapaNegocio;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Capa_Presentacion
{
    public partial class Clientes : Form
    {
        ClientesBLL objBLL = new ClientesBLL();

        DataTable tablaOriginal = new DataTable();

        int paginaActual = 1;
        int filasPorPagina = 5;
        int totalPaginas = 0;

        public Clientes()
        {
            InitializeComponent();

            dgvClientes.CellContentClick += dgvClientes_CellContentClick;
            btnAnterior.Click += btnAnterior_Click;
            btnSiguiente.Click += btnSiguiente_Click;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            cbFiltro.SelectedIndexChanged += cbFiltro_SelectedIndexChanged;
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.White;

            panelMenu.BackColor = Color.FromArgb(214, 177, 185);
            panelMenu.Width = 220;

            panelContenido.BackColor = Color.White;

            // COMBOBOX FILTRO
            cbFiltro.Items.Clear();
            cbFiltro.Items.Add("Todos");
            cbFiltro.Items.Add("Nombre");
            cbFiltro.Items.Add("Apellido");
            cbFiltro.Items.Add("Correo");
            cbFiltro.SelectedIndex = 0;

            // BOTONES
            btnNuevoCliente.BackColor = Color.FromArgb(190, 120, 140);
            btnNuevoCliente.ForeColor = Color.White;
            btnNuevoCliente.FlatStyle = FlatStyle.Flat;
            btnNuevoCliente.FlatAppearance.BorderSize = 0;

            btnAnterior.BackColor = Color.FromArgb(190, 120, 140);
            btnAnterior.ForeColor = Color.White;

            btnSiguiente.BackColor = Color.FromArgb(190, 120, 140);
            btnSiguiente.ForeColor = Color.White;

            // DATAGRIDVIEW
            dgvClientes.BackgroundColor = Color.White;
            dgvClientes.BorderStyle = BorderStyle.None;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.RowHeadersVisible = false;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.ReadOnly = true;
            dgvClientes.EnableHeadersVisualStyles = false;

            dgvClientes.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(235, 210, 220);

            dgvClientes.ColumnHeadersHeight = 35;
            dgvClientes.RowTemplate.Height = 35;

            CargarClientes();
        }

        // CARGAR CLIENTES
        private void CargarClientes()
        {
            tablaOriginal = objBLL.Listar();

            totalPaginas = tablaOriginal.Rows.Count == 0
                ? 1
                : Convert.ToInt32(Math.Ceiling((double)tablaOriginal.Rows.Count / filasPorPagina));

            paginaActual = 1;

            MostrarPagina();
        }

        // PAGINACIÓN
        private void MostrarPagina()
        {
            DataTable tablaPagina = tablaOriginal.Clone();

            int inicio = (paginaActual - 1) * filasPorPagina;
            int fin = inicio + filasPorPagina;

            for (int i = inicio; i < fin; i++)
            {
                if (i >= tablaOriginal.Rows.Count)
                    break;

                tablaPagina.ImportRow(tablaOriginal.Rows[i]);
            }

            dgvClientes.DataSource = tablaPagina;

            ConfigurarGrid();
            MostrarColumnas(); // 🔥 importante
        }

        // GRID
        private void ConfigurarGrid()
        {
            if (dgvClientes.Columns.Count == 0)
                return;

            if (dgvClientes.Columns["id_cliente"] != null)
                dgvClientes.Columns["id_cliente"].HeaderText = "ID";

            if (dgvClientes.Columns["nombre"] != null)
                dgvClientes.Columns["nombre"].HeaderText = "Nombre";

            if (dgvClientes.Columns["apellido"] != null)
                dgvClientes.Columns["apellido"].HeaderText = "Apellido";

            if (dgvClientes.Columns["correo"] != null)
                dgvClientes.Columns["correo"].HeaderText = "Correo";

            if (dgvClientes.Columns["telefono"] != null)
                dgvClientes.Columns["telefono"].HeaderText = "Teléfono";

            if (dgvClientes.Columns["fecha_registro"] != null)
                dgvClientes.Columns["fecha_registro"].HeaderText = "Fecha";

            if (!dgvClientes.Columns.Contains("Editar"))
            {
                DataGridViewButtonColumn editar = new DataGridViewButtonColumn();
                editar.Name = "Editar";
                editar.HeaderText = "Editar";
                editar.Text = "Editar";
                editar.UseColumnTextForButtonValue = true;
                dgvClientes.Columns.Add(editar);
            }

            if (!dgvClientes.Columns.Contains("Eliminar"))
            {
                DataGridViewButtonColumn eliminar = new DataGridViewButtonColumn();
                eliminar.Name = "Eliminar";
                eliminar.HeaderText = "Eliminar";
                eliminar.Text = "Eliminar";
                eliminar.UseColumnTextForButtonValue = true;
                dgvClientes.Columns.Add(eliminar);
            }
        }

        // CLICK GRID
        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string columna = dgvClientes.Columns[e.ColumnIndex].Name;

            int id = Convert.ToInt32(
                dgvClientes.Rows[e.RowIndex].Cells["id_cliente"].Value);

            if (columna == "Editar")
            {
                FrmCliente frm = new FrmCliente();
                frm.IdCliente = id;
                frm.ShowDialog();
                CargarClientes();
            }

            if (columna == "Eliminar")
            {
                DialogResult r = MessageBox.Show(
                    "¿Deseas eliminar este cliente?",
                    "Eliminar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    objBLL.Eliminar(id);
                    CargarClientes();
                }
            }
        }

        // BUSCAR
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        // COMBOBOX
        private void cbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
            MostrarColumnas();
        }

        // FILTRO
        private void AplicarFiltro()
        {
            if (tablaOriginal == null) return;

            string filtroTexto = txtBuscar.Text.Trim();
            string campoSeleccionado = cbFiltro.SelectedItem.ToString();

            string columna = "";

            switch (campoSeleccionado)
            {
                case "Nombre":
                    columna = "nombre";
                    break;
                case "Apellido":
                    columna = "apellido";
                    break;
                case "Correo":
                    columna = "correo";
                    break;
            }

            DataView dv = tablaOriginal.DefaultView;

            if (campoSeleccionado == "Todos" || string.IsNullOrEmpty(filtroTexto))
            {
                dv.RowFilter = "";
            }
            else
            {
                dv.RowFilter = $"{columna} LIKE '%{filtroTexto}%'";
            }

            dgvClientes.DataSource = dv.ToTable();
            ConfigurarGrid();
            MostrarColumnas(); // 🔥 importante
        }

        // MOSTRAR COLUMNAS
        private void MostrarColumnas()
        {
            if (dgvClientes.Columns.Count == 0) return;

            string opcion = cbFiltro.SelectedItem.ToString();

            foreach (DataGridViewColumn col in dgvClientes.Columns)
            {
                if (col.Name != "Editar" && col.Name != "Eliminar")
                    col.Visible = false;
            }

            if (opcion == "Todos")
            {
                foreach (DataGridViewColumn col in dgvClientes.Columns)
                {
                    col.Visible = true;
                }
            }
            else if (opcion == "Nombre")
            {
                dgvClientes.Columns["nombre"].Visible = true;
            }
            else if (opcion == "Apellido")
            {
                dgvClientes.Columns["apellido"].Visible = true;
            }
            else if (opcion == "Correo")
            {
                dgvClientes.Columns["correo"].Visible = true;
            }
        }

        // PAGINACIÓN
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (paginaActual < totalPaginas)
            {
                paginaActual++;
                MostrarPagina();
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual--;
                MostrarPagina();
            }
        }

        // NUEVO CLIENTE
        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            FrmCliente frm = new FrmCliente();
            frm.ShowDialog();
            CargarClientes();
        }
    }
}