using CapaNegocio;
using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Capa_Presentacion
{
    public partial class Servicio : Form
    {
        ServiciosBLL objBLL = new ServiciosBLL();

        DataTable tablaOriginal = new DataTable();

        int paginaActual = 1;
        int filasPorPagina = 6;
        int totalPaginas = 1;

        // =========================================
        // BORDES REDONDOS
        // =========================================
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

        public Servicio()
        {
            InitializeComponent();

            // FORMULARIO GRANDE
            this.WindowState = FormWindowState.Maximized;
        }

        private void Servicio_Load(object sender, EventArgs e)
        {
            dgvServicio.CellContentClick += dgvServicio_CellContentClick;

            btnNuevoServicio.Click += btnNuevoServicio_Click;

            btnAnterior.Click += btnAnterior_Click;

            btnSiguiente.Click += btnSiguiente_Click;

            txtBuscar.TextChanged += txtBuscar_TextChanged;

            DiseñarFormulario();

            ConfigurarPlaceholder();

            CargarDatos();
        }

        // =========================================
        // DISEÑO
        // =========================================
        private void DiseñarFormulario()
        {
            Color fondo = Color.FromArgb(248, 245, 242);

            this.BackColor = fondo;

            // =====================================
            // PANEL REDONDO
            // =====================================
            panelServiciosRegistrados.BackColor = Color.White;

            panelServiciosRegistrados.Region =
                Region.FromHrgn(
                    CreateRoundRectRgn(
                        0,
                        0,
                        panelServiciosRegistrados.Width,
                        panelServiciosRegistrados.Height,
                        40,
                        40));

            // =====================================
            // TITULO
            // =====================================
            lblTitulo.Font =
                new Font("Georgia", 24, FontStyle.Bold);

            lblTitulo.ForeColor =
                Color.FromArgb(60, 30, 30);

            // =====================================
            // BOTON NUEVO
            // =====================================
            btnNuevoServicio.BackColor =
                Color.FromArgb(153, 94, 107);

            btnNuevoServicio.ForeColor =
                Color.White;

            btnNuevoServicio.FlatStyle =
                FlatStyle.Flat;

            btnNuevoServicio.FlatAppearance.BorderSize = 0;

            btnNuevoServicio.Font =
                new Font("Segoe UI", 11, FontStyle.Bold);

            btnNuevoServicio.Height = 45;

            // =====================================
            // BOTON ANTERIOR
            // =====================================
            btnAnterior.BackColor =
                Color.FromArgb(245, 240, 236);

            btnAnterior.ForeColor =
                Color.Gray;

            btnAnterior.FlatStyle =
                FlatStyle.Flat;

            btnAnterior.FlatAppearance.BorderSize = 0;

            btnAnterior.Height = 40;

            // =====================================
            // BOTON SIGUIENTE
            // =====================================
            btnSiguiente.BackColor =
                Color.FromArgb(245, 240, 236);

            btnSiguiente.ForeColor =
                Color.Gray;

            btnSiguiente.FlatStyle =
                FlatStyle.Flat;

            btnSiguiente.FlatAppearance.BorderSize = 0;

            btnSiguiente.Height = 40;

            // =====================================
            // LABEL PAGINA
            // =====================================
            lblPagina.BackColor =
                Color.FromArgb(153, 94, 107);

            lblPagina.ForeColor =
                Color.White;

            lblPagina.Font =
                new Font("Segoe UI", 11, FontStyle.Bold);

            lblPagina.TextAlign =
                ContentAlignment.MiddleCenter;

            // =====================================
            // TEXTBOX BUSCAR
            // =====================================
            txtBuscar.BorderStyle =
                BorderStyle.FixedSingle;

            txtBuscar.Font =
                new Font("Segoe UI", 11);

            txtBuscar.BackColor =
                Color.White;

            txtBuscar.Height = 35;

            // =====================================
            // DATAGRID
            // =====================================
            dgvServicio.BorderStyle =
                BorderStyle.None;

            dgvServicio.BackgroundColor =
                Color.White;

            dgvServicio.EnableHeadersVisualStyles = false;

            dgvServicio.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            dgvServicio.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(248, 245, 242);

            dgvServicio.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.FromArgb(100, 80, 80);

            dgvServicio.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 11, FontStyle.Bold);

            dgvServicio.DefaultCellStyle.Font =
                new Font("Segoe UI", 11);

            dgvServicio.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(240, 230, 225);

            dgvServicio.DefaultCellStyle.SelectionForeColor =
                Color.Black;

            dgvServicio.RowTemplate.Height = 70;

            dgvServicio.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvServicio.AllowUserToAddRows = false;

            dgvServicio.RowHeadersVisible = false;

            dgvServicio.GridColor =
                Color.FromArgb(240, 240, 240);
        }

        // =========================================
        // PLACEHOLDER BUSCAR
        // =========================================
        private void ConfigurarPlaceholder()
        {
            txtBuscar.Text = "Buscar servicio...";
            txtBuscar.ForeColor = Color.Gray;

            txtBuscar.Enter += (s, e) =>
            {
                if (txtBuscar.Text == "Buscar servicio...")
                {
                    txtBuscar.Text = "";
                    txtBuscar.ForeColor = Color.Black;
                }
            };

            txtBuscar.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtBuscar.Text))
                {
                    txtBuscar.Text = "Buscar servicio...";
                    txtBuscar.ForeColor = Color.Gray;
                }
            };
        }

        // =========================================
        // NUEVO SERVICIO
        // =========================================
        private void btnNuevoServicio_Click(object sender, EventArgs e)
        {
            FrmServicio frm = new FrmServicio();

            frm.ShowDialog();

            CargarDatos();
        }

        // =========================================
        // CARGAR DATOS
        // =========================================
        private void CargarDatos()
        {
            tablaOriginal = objBLL.Listar();

            totalPaginas =
                (int)Math.Ceiling(
                    tablaOriginal.Rows.Count /
                    (double)filasPorPagina);

            if (totalPaginas == 0)
                totalPaginas = 1;

            paginaActual = 1;

            MostrarPagina();
        }

        // =========================================
        // MOSTRAR PAGINA
        // =========================================
        private void MostrarPagina()
        {
            DataTable dt = tablaOriginal.Clone();

            int inicio =
                (paginaActual - 1) * filasPorPagina;

            int fin =
                Math.Min(
                    inicio + filasPorPagina,
                    tablaOriginal.Rows.Count);

            for (int i = inicio; i < fin; i++)
            {
                dt.ImportRow(tablaOriginal.Rows[i]);
            }

            dgvServicio.DataSource = dt;

            // =====================================
            // BOTON EDITAR
            // =====================================
            if (!dgvServicio.Columns.Contains("Editar"))
            {
                DataGridViewButtonColumn btnEditar =
                    new DataGridViewButtonColumn();

                btnEditar.Name = "Editar";

                btnEditar.Text = "✏";

                btnEditar.UseColumnTextForButtonValue = true;

                dgvServicio.Columns.Add(btnEditar);
            }

            // =====================================
            // BOTON ELIMINAR
            // =====================================
            if (!dgvServicio.Columns.Contains("Eliminar"))
            {
                DataGridViewButtonColumn btnEliminar =
                    new DataGridViewButtonColumn();

                btnEliminar.Name = "Eliminar";

                btnEliminar.Text = "🗑";

                btnEliminar.UseColumnTextForButtonValue = true;

                dgvServicio.Columns.Add(btnEliminar);
            }

            // =====================================
            // CAMBIAR NOMBRES COLUMNAS
            // =====================================
            if (dgvServicio.Columns["id_servicio"] != null)
            {
                dgvServicio.Columns["id_servicio"].HeaderText = "ID";
            }

            if (dgvServicio.Columns["nombre_servicio"] != null)
            {
                dgvServicio.Columns["nombre_servicio"].HeaderText = "Servicio";
            }

            // COLUMNA CATEGORIA
            if (dgvServicio.Columns["categoria"] != null)
            {
                dgvServicio.Columns["categoria"].HeaderText = "Categoría";
            }

            // SI TU COLUMNA SE LLAMA nombre_categoria
            if (dgvServicio.Columns["nombre_categoria"] != null)
            {
                dgvServicio.Columns["nombre_categoria"].HeaderText = "Categoría";
            }

            if (dgvServicio.Columns["duracion_minutos"] != null)
            {
                dgvServicio.Columns["duracion_minutos"].HeaderText = "Duración";
            }

            if (dgvServicio.Columns["precio"] != null)
            {
                dgvServicio.Columns["precio"].HeaderText = "Precio";
            }

            lblPagina.Text = paginaActual.ToString();

            lblResultados.Text =
                "Mostrando " +
                dt.Rows.Count +
                " de " +
                tablaOriginal.Rows.Count +
                " resultados";
        }

        // =========================================
        // CLICK DATAGRID
        // =========================================
        private void dgvServicio_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            // EDITAR
            if (dgvServicio.Columns[e.ColumnIndex].Name == "Editar")
            {
                FrmServicio frm = new FrmServicio();

                frm.IdServicio = Convert.ToInt32(
                    dgvServicio.Rows[e.RowIndex]
                    .Cells["id_servicio"].Value);

                frm.ShowDialog();

                CargarDatos();
            }

            // ELIMINAR
            if (dgvServicio.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                DialogResult r = MessageBox.Show(
                    "¿Deseas eliminar este servicio?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(
                        dgvServicio.Rows[e.RowIndex]
                        .Cells["id_servicio"].Value);

                    objBLL.Eliminar(id);

                    CargarDatos();
                }
            }
        }

        // =========================================
        // BUSCAR
        // =========================================
        private void txtBuscar_TextChanged(
            object sender,
            EventArgs e)
        {
            if (txtBuscar.Text == "Buscar servicio...")
                return;

            DataView dv = tablaOriginal.DefaultView;

            dv.RowFilter =
                $"nombre_servicio LIKE '%{txtBuscar.Text.Replace("'", "''")}%'";

            dgvServicio.DataSource = dv.ToTable();
        }

        // =========================================
        // PAGINA ANTERIOR
        // =========================================
        private void btnAnterior_Click(
            object sender,
            EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual--;

                MostrarPagina();
            }
        }

        // =========================================
        // PAGINA SIGUIENTE
        // =========================================
        private void btnSiguiente_Click(
            object sender,
            EventArgs e)
        {
            if (paginaActual < totalPaginas)
            {
                paginaActual++;

                MostrarPagina();
            }
        }
    }
}