using CapaNegocio;

using System;

using System.Data;

using System.Drawing;

using System.Drawing.Drawing2D;

using System.Windows.Forms;

namespace Capa_Presentacion

{

    public partial class FrmClientes : Form

    {

        ClientesBLL objBLL = new ClientesBLL();

        DataTable tablaOriginal = new DataTable();



        int paginaActual = 1;

        int filasPorPagina = 5;

        int totalPaginas = 0;

        bool limpiando = false;



        // --- PALETA DE COLORES CLARIBER ---

        private readonly Color COLOR_FONDO_EXTERIOR = Color.FromArgb(249, 245, 242);  // Crema muy claro

        private readonly Color COLOR_PANEL_MENU = Color.FromArgb(114, 88, 87);       // Marrón/Moca oscuro

        private readonly Color COLOR_TEXTO_MENU = Color.FromArgb(218, 194, 180);     // Oro viejo/Beige suave

        private readonly Color COLOR_MENU_ACTIVO = Color.FromArgb(193, 163, 145);    // Beige seleccionado

        private readonly Color COLOR_BOTON_NUEVO = Color.FromArgb(143, 94, 104);     // Rosa viejo/Vino suave

        private readonly Color COLOR_CABECERA_GRID = Color.FromArgb(245, 238, 234);   // Crema suave cabecera

        private readonly Color COLOR_TEXTO_COMUN = Color.FromArgb(70, 50, 48);       // Marrón oscuro para fuentes



        // Colores de los botones de acción del Grid

        private readonly Color COLOR_BTN_EDITAR = Color.FromArgb(253, 248, 245);     // Fondo editar

        private readonly Color COLOR_BORDER_EDITAR = Color.FromArgb(230, 215, 205);  // Borde editar

        private readonly Color COLOR_BTN_ELIMINAR = Color.FromArgb(254, 242, 242);   // Fondo eliminar (tonalidad rojiza/rosa)

        private readonly Color COLOR_BORDER_ELIMINAR = Color.FromArgb(243, 214, 214);// Borde eliminar



        public FrmClientes()

        {

            InitializeComponent();



            dgvClientes.CellContentClick += dgvClientes_CellContentClick;

            dgvClientes.CellPainting += dgvClientes_CellPainting; // 🔥 Evento para estilizar los botones del Grid

            btnAnterior.Click += btnAnterior_Click;

            btnSiguiente.Click += btnSiguiente_Click;

            txtBuscar.TextChanged += txtBuscar_TextChanged;

            cbFiltro.SelectedIndexChanged += cbFiltro_SelectedIndexChanged;

            btnNuevoCliente.Click += btnNuevoCliente_Click;

        }



        private void Clientes_Load(object sender, EventArgs e)
        {
            // =========================================
            // FORMULARIO
            // =========================================

            this.BackColor =
                COLOR_FONDO_EXTERIOR;

            this.WindowState =
                FormWindowState.Maximized;

            // =========================================
            // PANEL CONTENIDO
            // =========================================

            panelContenido.BackColor =
                Color.White;

            // =========================================
            // TITULO
            // =========================================

            label1.ForeColor =
                COLOR_TEXTO_COMUN;

            label1.Font =
                new Font(
                    "Georgia",
                    22F,
                    FontStyle.Regular);

            // =========================================
            // BOTON NUEVO CLIENTE
            // =========================================

            btnNuevoCliente.BackColor =
                COLOR_BOTON_NUEVO;

            btnNuevoCliente.ForeColor =
                Color.White;

            btnNuevoCliente.FlatStyle =
                FlatStyle.Flat;

            btnNuevoCliente.FlatAppearance.BorderSize =
                0;

            btnNuevoCliente.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Regular);

            btnNuevoCliente.Height =
                42;

            // =========================================
            // COMBOBOX FILTRO
            // =========================================

            cbFiltro.BackColor =
                Color.White;

            cbFiltro.ForeColor =
                COLOR_TEXTO_COMUN;

            cbFiltro.FlatStyle =
                FlatStyle.Flat;

            cbFiltro.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Regular);

            cbFiltro.Items.Clear();

            cbFiltro.Items.Add(
                "Todos los clientes");

            cbFiltro.Items.Add(
                "Nombre");

            cbFiltro.Items.Add(
                "Apellido");

            cbFiltro.Items.Add(
                "Correo");

            cbFiltro.SelectedIndex =
                0;

            // =========================================
            // TEXTBOX BUSCAR
            // =========================================

            txtBuscar.BackColor =
                Color.White;

            txtBuscar.ForeColor =
                COLOR_TEXTO_COMUN;

            txtBuscar.BorderStyle =
                BorderStyle.FixedSingle;

            txtBuscar.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Regular);

            // =========================================
            // BOTONES PAGINACION
            // =========================================

            ConfigurarBotonPaginacion(
                btnAnterior,
                "<");

            ConfigurarBotonPaginacion(
                btnSiguiente,
                ">");

            // =========================================
            // DATAGRIDVIEW
            // =========================================

            dgvClientes.BackgroundColor =
                Color.White;

            dgvClientes.BorderStyle =
                BorderStyle.None;

            dgvClientes.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvClientes.GridColor =
                Color.FromArgb(
                    245,
                    240,
                    238);

            dgvClientes.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvClientes.RowHeadersVisible =
                false;

            dgvClientes.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvClientes.AllowUserToAddRows =
                false;

            dgvClientes.ReadOnly =
                true;

            dgvClientes.EnableHeadersVisualStyles =
                false;

            dgvClientes.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            // =========================================
            // CABECERAS
            // =========================================

            dgvClientes.ColumnHeadersDefaultCellStyle.BackColor =
                COLOR_CABECERA_GRID;

            dgvClientes.ColumnHeadersDefaultCellStyle.ForeColor =
                COLOR_TEXTO_COMUN;

            dgvClientes.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            dgvClientes.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                COLOR_CABECERA_GRID;

            dgvClientes.ColumnHeadersHeight =
                45;

            // =========================================
            // FILAS
            // =========================================

            dgvClientes.DefaultCellStyle.BackColor =
                Color.White;

            dgvClientes.DefaultCellStyle.ForeColor =
                COLOR_TEXTO_COMUN;

            dgvClientes.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9.5F,
                    FontStyle.Regular);

            dgvClientes.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(
                    250,
                    245,
                    242);

            dgvClientes.DefaultCellStyle.SelectionForeColor =
                COLOR_TEXTO_COMUN;

            dgvClientes.RowTemplate.Height =
                45;

            // =========================================
            // CARGAR DATOS
            // =========================================

            CargarClientes();
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



        private void CargarClientes()

        {

            tablaOriginal = objBLL.Listar();



            totalPaginas = tablaOriginal.Rows.Count == 0

                ? 1

                : Convert.ToInt32(Math.Ceiling((double)tablaOriginal.Rows.Count / filasPorPagina));



            paginaActual = 1;

            MostrarPagina();

        }



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

            MostrarColumnas();

        }



        private void ConfigurarGrid()

        {

            if (dgvClientes.Columns.Count == 0)

                return;



            if (dgvClientes.Columns["id_cliente"] != null) dgvClientes.Columns["id_cliente"].HeaderText = "ID";

            if (dgvClientes.Columns["nombre"] != null) dgvClientes.Columns["nombre"].HeaderText = "Nombre";

            if (dgvClientes.Columns["apellido"] != null) dgvClientes.Columns["apellido"].HeaderText = "Apellido";

            if (dgvClientes.Columns["correo"] != null) dgvClientes.Columns["correo"].HeaderText = "Correo";

            if (dgvClientes.Columns["telefono"] != null) dgvClientes.Columns["telefono"].HeaderText = "Teléfono";

            if (dgvClientes.Columns["fecha_registro"] != null) dgvClientes.Columns["fecha_registro"].HeaderText = "Fecha Registro";



            if (!dgvClientes.Columns.Contains("Editar"))

            {

                DataGridViewButtonColumn editar = new DataGridViewButtonColumn();

                editar.Name = "Editar";

                editar.HeaderText = "Acciones"; // Alineado bajo la misma columna conceptual

                editar.Text = "Editar";

                editar.UseColumnTextForButtonValue = true;

                dgvClientes.Columns.Add(editar);

            }



            if (!dgvClientes.Columns.Contains("Eliminar"))

            {

                DataGridViewButtonColumn eliminar = new DataGridViewButtonColumn();

                eliminar.Name = "Eliminar";

                eliminar.HeaderText = "";

                eliminar.Text = "Eliminar";

                eliminar.UseColumnTextForButtonValue = true;

                dgvClientes.Columns.Add(eliminar);

            }

        }



        // 🔥 DIBUJADO PERSONALIZADO DE BOTONES (Remueve el aspecto plano/gris antiguo)

        private void dgvClientes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)

        {

            if (e.RowIndex < 0) return;



            // Verificar si corresponde a la columna Editar o Eliminar

            if (e.ColumnIndex >= 0 && (dgvClientes.Columns[e.ColumnIndex].Name == "Editar" || dgvClientes.Columns[e.ColumnIndex].Name == "Eliminar"))

            {

                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground & ~DataGridViewPaintParts.Background);



                bool esEditar = dgvClientes.Columns[e.ColumnIndex].Name == "Editar";



                // Definir paleta de color según el botón

                Color fondoBtn = esEditar ? COLOR_BTN_EDITAR : COLOR_BTN_ELIMINAR;

                Color bordeBtn = esEditar ? COLOR_BORDER_EDITAR : COLOR_BORDER_ELIMINAR;

                Color textoBtn = esEditar ? COLOR_TEXTO_COMUN : Color.FromArgb(180, 80, 80);



                // Margen interno del botón dentro de la celda

                Rectangle rectBoton = new Rectangle(e.CellBounds.X + 8, e.CellBounds.Y + 6, e.CellBounds.Width - 16, e.CellBounds.Height - 12);



                using (GraphicsPath path = GetRoundedRect(rectBoton, 6)) // 6px de radio redondeado

                using (SolidBrush brushFondo = new SolidBrush(fondoBtn))

                using (Pen penBorde = new Pen(bordeBtn, 1))

                {

                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;



                    // Dibujar Fondo

                    e.Graphics.FillPath(brushFondo, path);

                    // Dibujar Borde

                    e.Graphics.DrawPath(penBorde, path);



                    // Escribir Texto Texto

                    TextRenderer.DrawText(e.Graphics, esEditar ? "✏️ Editar" : "🗑️ Eliminar",

                        new Font("Segoe UI", 9F, FontStyle.Regular), rectBoton, textoBtn,

                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                }



                e.Handled = true;

            }

        }



        // Generador de caminos redondeados para gráficos planos modernos

        private GraphicsPath GetRoundedRect(Rectangle bounds, int radius)

        {

            int diameter = radius * 2;

            Size size = new Size(diameter, diameter);

            Rectangle arc = new Rectangle(bounds.Location, size);

            GraphicsPath path = new GraphicsPath();



            if (radius == 0) { path.AddRectangle(bounds); return path; }



            path.AddArc(arc, 180, 90);

            arc.X = bounds.Right - diameter;

            path.AddArc(arc, 270, 90);

            arc.Y = bounds.Bottom - diameter;

            path.AddArc(arc, 0, 90);

            arc.X = bounds.Left;

            path.AddArc(arc, 90, 90);

            path.CloseFigure();

            return path;

        }



        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)

        {

            if (e.RowIndex < 0) return;



            string columna = dgvClientes.Columns[e.ColumnIndex].Name;

            int id = Convert.ToInt32(dgvClientes.Rows[e.RowIndex].Cells["id_cliente"].Value);



            if (columna == "Editar")

            {

                FrmCliente frm = new FrmCliente();

                frm.IdCliente = id;

                frm.ShowDialog();

                CargarClientes();

            }



            if (columna == "Eliminar")

            {

                DialogResult r = MessageBox.Show("¿Deseas eliminar este cliente?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.Yes)

                {

                    objBLL.Eliminar(id);

                    CargarClientes();

                }

            }

        }



        private void txtBuscar_TextChanged(object sender, EventArgs e)

        {

            if (limpiando) return;

            AplicarFiltro();

        }



        private void cbFiltro_SelectedIndexChanged(object sender, EventArgs e)

        {

            limpiando = true;

            txtBuscar.Clear();

            limpiando = false;



            AplicarFiltro();

            MostrarColumnas();

        }



        private void AplicarFiltro()

        {

            if (tablaOriginal == null) return;



            string filtroTexto = txtBuscar.Text.Trim();

            string campoSeleccionado = cbFiltro.SelectedItem.ToString();

            string columna = "";



            switch (campoSeleccionado)

            {

                case "Nombre": columna = "nombre"; break;

                case "Apellido": columna = "apellido"; break;

                case "Correo": columna = "correo"; break;

            }



            DataView dv = tablaOriginal.DefaultView;



            if (campoSeleccionado == "Todos los clientes" || string.IsNullOrEmpty(filtroTexto))

            {

                dv.RowFilter = "";

            }

            else

            {

                dv.RowFilter = $"{columna} LIKE '%{filtroTexto}%'";

            }



            dgvClientes.DataSource = dv.ToTable();

            ConfigurarGrid();

            MostrarColumnas();

        }



        private void MostrarColumnas()

        {

            if (dgvClientes.Columns.Count == 0) return;



            string opcion = cbFiltro.SelectedItem.ToString();



            foreach (DataGridViewColumn col in dgvClientes.Columns)

            {

                if (col.Name != "Editar" && col.Name != "Eliminar")

                    col.Visible = false;

            }



            if (opcion == "Todos los clientes")

            {

                foreach (DataGridViewColumn col in dgvClientes.Columns)

                {

                    col.Visible = true;

                }

            }

            else if (opcion == "Nombre") { dgvClientes.Columns["nombre"].Visible = true; }

            else if (opcion == "Apellido") { dgvClientes.Columns["apellido"].Visible = true; }

            else if (opcion == "Correo") { dgvClientes.Columns["correo"].Visible = true; }

        }



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



        private void btnNuevoCliente_Click(object sender, EventArgs e)

        {

            FrmCliente frm = new FrmCliente();

            frm.ShowDialog();

            CargarClientes();

        }

    }

}