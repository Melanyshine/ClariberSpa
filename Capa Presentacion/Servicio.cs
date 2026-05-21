using CapaNegocio;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Capa_Presentacion
{
    public partial class Servicio : Form
    {
        ServiciosBLL objBLL = new ServiciosBLL();
        DataTable tablaOriginal = new DataTable();

        int paginaActual = 1;
        int filasPorPagina = 8;
        int totalPaginas = 1;

        public Servicio()
        {
            InitializeComponent();
        }

        private void Servicio_Load(object sender, EventArgs e)
        {
            dgvServicio.CellContentClick += dgvServicio_CellContentClick;

            btnNuevoServicio.Click += btnNuevoServicio_Click;
            btnAnterior.Click += btnAnterior_Click;
            btnSiguiente.Click += btnSiguiente_Click;

            txtBuscar.TextChanged += txtBuscar_TextChanged;

            CargarDatos();
        }

        private void btnNuevoServicio_Click(object sender, EventArgs e)
        {
            FrmServicio frm = new FrmServicio();
            frm.ShowDialog();
            CargarDatos();
        }

        private void CargarDatos()
        {
            tablaOriginal = objBLL.Listar();

            totalPaginas = (int)Math.Ceiling(tablaOriginal.Rows.Count / (double)filasPorPagina);
            if (totalPaginas == 0) totalPaginas = 1;

            paginaActual = 1;
            MostrarPagina();
        }

        private void MostrarPagina()
        {
            DataTable dt = tablaOriginal.Clone();

            int inicio = (paginaActual - 1) * filasPorPagina;
            int fin = Math.Min(inicio + filasPorPagina, tablaOriginal.Rows.Count);

            for (int i = inicio; i < fin; i++)
                dt.ImportRow(tablaOriginal.Rows[i]);

            dgvServicio.DataSource = dt;

            if (!dgvServicio.Columns.Contains("Eliminar"))
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.Name = "Eliminar";
                btn.Text = "Eliminar";
                btn.UseColumnTextForButtonValue = true;
                dgvServicio.Columns.Add(btn);
            }
        }

        private void dgvServicio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvServicio.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                int id = Convert.ToInt32(dgvServicio.Rows[e.RowIndex].Cells["id_servicio"].Value);

                objBLL.Eliminar(id);
                CargarDatos();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            DataView dv = tablaOriginal.DefaultView;
            dv.RowFilter = $"nombre_servicio LIKE '%{txtBuscar.Text.Replace("'", "''")}%'";
            dgvServicio.DataSource = dv.ToTable();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual--;
                MostrarPagina();
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (paginaActual < totalPaginas)
            {
                paginaActual++;
                MostrarPagina();
            }
        }
    }
}