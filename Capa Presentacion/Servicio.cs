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
        int filasPorPagina = 6;
        int totalPaginas = 1;

        // --- PALETA DE COLORES CLARIBER ---
        private readonly Color COLOR_FONDO_EXTERIOR = Color.FromArgb(249, 245, 242);  // Crema muy claro
        private readonly Color COLOR_BOTON_NUEVO = Color.FromArgb(143, 94, 104);     // Rosa viejo / Vino suave
        private readonly Color COLOR_CABECERA_GRID = Color.FromArgb(245, 238, 234);   // Crema suave cabecera
        private readonly Color COLOR_TEXTO_COMUN = Color.FromArgb(70, 50, 48);       // Marrón oscuro para fuentes

        // Colores de los botones de acción del Grid
        private readonly Color COLOR_BTN_EDITAR = Color.FromArgb(253, 248, 245);     // Fondo editar
        private readonly Color COLOR_BORDER_EDITAR = Color.FromArgb(230, 215, 205);  // Borde editar
        private readonly Color COLOR_BTN_ELIMINAR = Color.FromArgb(254, 242, 242);   // Fondo eliminar
        private readonly Color COLOR_BORDER_ELIMINAR = Color.FromArgb(243, 214, 214);// Borde eliminar

        public Servicio()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void Servicio_Load(object sender, EventArgs e)
        {
            dgvServicio.CellContentClick += dgvServicio_CellContentClick;
            dgvServicio.CellPainting += dgvServicio_CellPainting; // 🔥 Dibujado plano y recto de botones

            btnNuevoServicio.Click += btnNuevoServicio_Click;
            btnAnterior.Click += btnAnterior_Click;
            btnSiguiente.Click += btnSiguiente_Click;
            txtBuscar.TextChanged += txtBuscar_TextChanged;

            DiseñarFormulario();
            ConfigurarPlaceholder();
            CargarDatos();
        }

        // =========================================
        // DISEÑO UNIFICADO CLARIBER (BORDES RECTOS)
        // =========================================
        private void DiseñarFormulario()
        {
            this.BackColor = COLOR_FONDO_EXTERIOR;

            // Panel contenedor blanco principal (Bordes rectos limpios)
            panelServiciosRegistrados.BackColor = Color.White;
            panelServiciosRegistrados.Region = null; // ❌ Removida la región redonda

            // Título de la sección
            lblTitulo.Font = new Font("Georgia", 22, FontStyle.Regular);
            lblTitulo.ForeColor = COLOR_TEXTO_COMUN;

            // Botón "Nuevo Servicio"
            btnNuevoServicio.BackColor = COLOR_BOTON_NUEVO;
            btnNuevoServicio.ForeColor = Color.White;
            btnNuevoServicio.FlatStyle = FlatStyle.Flat;
            btnNuevoServicio.FlatAppearance.BorderSize = 0;
            btnNuevoServicio.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            btnNuevoServicio.Height = 42;

            // Botones de paginación e indicador visual inferior
            ConfigurarBotonPaginacion(btnAnterior, "<");
            ConfigurarBotonPaginacion(btnSiguiente, ">");

            lblPagina.BackColor = COLOR_BOTON_NUEVO;
            lblPagina.ForeColor = Color.White;
            lblPagina.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPagina.TextAlign = ContentAlignment.MiddleCenter;

            // TextBox de búsqueda estilizado
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            txtBuscar.Font = new Font("Segoe UI", 10);
            txtBuscar.BackColor = Color.White;
            txtBuscar.ForeColor = COLOR_TEXTO_COMUN;

            // --- DISEÑO INTERNO DEL DATAGRIDVIEW ---
            dgvServicio.BorderStyle = BorderStyle.None;
            dgvServicio.BackgroundColor = Color.White;
            dgvServicio.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvServicio.GridColor = Color.FromArgb(245, 240, 238); // Separadores suaves
            dgvServicio.EnableHeadersVisualStyles = false;
            dgvServicio.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Cabeceras del Grid
            dgvServicio.ColumnHeadersDefaultCellStyle.BackColor = COLOR_CABECERA_GRID;
            dgvServicio.ColumnHeadersDefaultCellStyle.ForeColor = COLOR_TEXTO_COMUN;
            dgvServicio.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvServicio.ColumnHeadersDefaultCellStyle.SelectionBackColor = COLOR_CABECERA_GRID;
            dgvServicio.ColumnHeadersHeight = 45;

            // Filas del Grid
            dgvServicio.DefaultCellStyle.BackColor = Color.White;
            dgvServicio.DefaultCellStyle.ForeColor = COLOR_TEXTO_COMUN;
            dgvServicio.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            dgvServicio.DefaultCellStyle.SelectionBackColor = Color.FromArgb(250, 245, 242); // Selección tenue
            dgvServicio.DefaultCellStyle.SelectionForeColor = COLOR_TEXTO_COMUN;
            dgvServicio.RowTemplate.Height = 45;

            dgvServicio.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvServicio.AllowUserToAddRows = false;
            dgvServicio.RowHeadersVisible = false;
        }

        private void ConfigurarBotonPaginacion(Button btn, string texto)
        {
            btn.Text = texto;
            btn.BackColor = Color.White;
            btn.ForeColor = COLOR_TEXTO_COMUN;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = Color.FromArgb(230, 220, 215);
            btn.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
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
                    txtBuscar.ForeColor = COLOR_TEXTO_COMUN;
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
            {
                dt.ImportRow(tablaOriginal.Rows[i]);
            }

            dgvServicio.DataSource = dt;

            // Inserción de columnas de botones si no existen
            if (!dgvServicio.Columns.Contains("Editar"))
            {
                DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
                btnEditar.Name = "Editar";
                btnEditar.HeaderText = "Acciones";
                btnEditar.Text = "Editar";
                btnEditar.UseColumnTextForButtonValue = true;
                dgvServicio.Columns.Add(btnEditar);
            }

            if (!dgvServicio.Columns.Contains("Eliminar"))
            {
                DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                btnEliminar.Name = "Eliminar";
                btnEliminar.HeaderText = "";
                btnEliminar.Text = "Eliminar";
                btnEliminar.UseColumnTextForButtonValue = true;
                dgvServicio.Columns.Add(btnEliminar);
            }

            // Mapeo e internacionalización de Cabeceras
            if (dgvServicio.Columns["id_servicio"] != null) dgvServicio.Columns["id_servicio"].HeaderText = "ID";
            if (dgvServicio.Columns["nombre_servicio"] != null) dgvServicio.Columns["nombre_servicio"].HeaderText = "Servicio";
            if (dgvServicio.Columns["categoria"] != null) dgvServicio.Columns["categoria"].HeaderText = "Categoría";
            if (dgvServicio.Columns["nombre_categoria"] != null) dgvServicio.Columns["nombre_categoria"].HeaderText = "Categoría";
            if (dgvServicio.Columns["duracion_minutos"] != null) dgvServicio.Columns["duracion_minutos"].HeaderText = "Duración";
            if (dgvServicio.Columns["precio"] != null) dgvServicio.Columns["precio"].HeaderText = "Precio";

            lblPagina.Text = paginaActual.ToString();

            lblResultados.Text = $"Mostrando {dt.Rows.Count} de {tablaOriginal.Rows.Count} resultados";
        }

        // ===================================================================
        // 🔥 RENDERIZADO RECTO Y PLANO DE LOS BOTONES ACCIONES DEL GRID
        // ===================================================================
        private void dgvServicio_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex >= 0 && (dgvServicio.Columns[e.ColumnIndex].Name == "Editar" || dgvServicio.Columns[e.ColumnIndex].Name == "Eliminar"))
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground & ~DataGridViewPaintParts.Background);

                bool esEditar = dgvServicio.Columns[e.ColumnIndex].Name == "Editar";

                Color fondoBtn = esEditar ? COLOR_BTN_EDITAR : COLOR_BTN_ELIMINAR;
                Color bordeBtn = esEditar ? COLOR_BORDER_EDITAR : COLOR_BORDER_ELIMINAR;
                Color textoBtn = esEditar ? COLOR_TEXTO_COMUN : Color.FromArgb(185, 85, 85);

                // Rectángulo exacto con bordes rectos de esquina a esquina
                Rectangle rectBoton = new Rectangle(e.CellBounds.X + 6, e.CellBounds.Y + 6, e.CellBounds.Width - 12, e.CellBounds.Height - 12);

                using (SolidBrush brushFondo = new SolidBrush(fondoBtn))
                using (Pen penBorde = new Pen(bordeBtn, 1))
                {
                    // Dibujado completamente plano (Sin curvas)
                    e.Graphics.FillRectangle(brushFondo, rectBoton);
                    e.Graphics.DrawRectangle(penBorde, rectBoton);

                    TextRenderer.DrawText(e.Graphics, esEditar ? "✏️ Editar" : "🗑️ Eliminar",
                        new Font("Segoe UI", 9F, FontStyle.Regular), rectBoton, textoBtn,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }

                e.Handled = true;
            }
        }

        private void dgvServicio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvServicio.Columns[e.ColumnIndex].Name == "Editar")
            {
                FrmServicio frm = new FrmServicio();
                frm.IdServicio = Convert.ToInt32(dgvServicio.Rows[e.RowIndex].Cells["id_servicio"].Value);
                frm.ShowDialog();
                CargarDatos();
            }

            if (dgvServicio.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                DialogResult r = MessageBox.Show("¿Deseas eliminar este servicio?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgvServicio.Rows[e.RowIndex].Cells["id_servicio"].Value);
                    objBLL.Eliminar(id);
                    CargarDatos();
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "Buscar servicio...") return;

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