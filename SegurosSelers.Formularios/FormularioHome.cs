using SegurosSelers.Entidades;
using SegurosSelers.Formularios.Controles;
using SegurosSelers.Servicios;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SegurosSelers.Formularios
{
    public partial class FormularioHome : Form
    {
        // Declaración de las instancias de los UserControls (para mantenerlos en memoria)
        private UserControlUsuarios _userControlUsuarios;
        private UserControlPolizas _userControlPolizas;
        private UserControlSiniestros _userControlSiniestros;
        private UserControlContratados _userControlContratados;

        // Información del gestor logueado y servicio
        private Gestor _gestorLogueado;
        private GestorService _gestorService;

        // NOTA: Ya no necesitamos declarar _pbInicioContenido y _lblMensajeInicioContenido aquí
        // porque los crearemos dinámicamente cada vez que se muestre la vista inicial.

        public FormularioHome()
        {
            InitializeComponent();
            _gestorService = new GestorService();
        }

        public FormularioHome(Gestor gestor) : this()
        {
            _gestorLogueado = gestor;
            MostrarInformacionGestor(); // Muestra el nombre del gestor en lblNombreGestor.
            ConfigurarVistaInicial();   // <-- ¡Llama a este método para mostrar la vista inicial al cargar el Home!
        }

        /// <summary>
        /// Muestra el nombre y apellido del gestor logueado en el Label correspondiente.
        /// </summary>
        private void MostrarInformacionGestor()
        {
            if (_gestorLogueado != null)
            {
                lblNombreGestor.Text = $"{_gestorLogueado.Nombre} {_gestorLogueado.Apellido}";
            }
            else
            {
                lblNombreGestor.Text = "Invitado"; // En caso de que no haya gestor (debería haberlo si pasas por login)
            }
        }

        // Método para salir de la sesión y volver al login
        private void labelSalir_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario Home
            FormularioLogin formularioLogin = new FormularioLogin();
            formularioLogin.Show(); // Muestra el formulario de Login de nuevo
        }

        private void FormularioHome_Load(object sender, EventArgs e)
        {
            // Este método se ejecuta cuando el formulario se carga.
            // Si ya llamas a ConfigurarVistaInicial() en el constructor (como lo hacemos ahora),
            // este método puede quedar vacío a menos que tengas otra lógica específica de carga aquí.
        }

        /// <summary>
        /// Configura la vista inicial del panel principal (panelInformacion)
        /// mostrando un Label en la parte superior y un PictureBox en el resto del espacio.
        /// </summary>
        private void ConfigurarVistaInicial()
        {
            // 1. Limpiar el panel principal de cualquier contenido anterior (UserControls, etc.)
            panelInformacion.Controls.Clear();

            // 2. Crear y configurar el Label superior (tu "label1")
            Label lblBienvenidaContenido = new Label();
            lblBienvenidaContenido.Name = "lblBienvenidaContenido";
            lblBienvenidaContenido.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))); // Ajusta la fuente
            lblBienvenidaContenido.TextAlign = ContentAlignment.MiddleCenter; // Centra el texto
            lblBienvenidaContenido.Dock = DockStyle.Top; // Se ancla a la parte superior del panel
            lblBienvenidaContenido.Height = 120; // Define una altura fija para el Label
            lblBienvenidaContenido.Padding = new Padding(0, 20, 0, 0); // Pequeño padding superior

            // Define el texto de bienvenida (personalizado si hay gestor logueado)
            lblBienvenidaContenido.Text = "¡Bienvenido a Seguros Selers!";
            if (_gestorLogueado != null)
            {
                lblBienvenidaContenido.Text = $"Sistema de administración de Usuarios, Pólizas, Siniestros y Vehículos";
            }
            lblBienvenidaContenido.Visible = true; // Asegura que el Label sea visible

            // 3. Crear y configurar el PictureBox principal (tu "pictureBox7")
            PictureBox pbLogoPrincipalContenido = new PictureBox();
            pbLogoPrincipalContenido.Name = "pbLogoPrincipalContenido";
            pbLogoPrincipalContenido.SizeMode = PictureBoxSizeMode.Zoom; // Ajusta la imagen manteniendo la proporción
            // Asigna la imagen de bienvenida desde los recursos (¡asegúrate de que exista!)
            pbLogoPrincipalContenido.Image = Properties.Resources.ChatGPT_Image_3_jun_2025__10_08_11_p_m_; // <-- ¡IMPORTANTE: Cambia 'logo_bienvenida' al nombre de tu recurso!
            pbLogoPrincipalContenido.Dock = DockStyle.Fill; // Ocupa el resto del espacio disponible en el panel
            pbLogoPrincipalContenido.Visible = true; // Asegura que el PictureBox sea visible

            // 4. Agregar los controles al panel principal (panelInformacion)
            // El orden de adición es importante para DockStyle: Top primero, luego Fill.
            panelInformacion.Controls.Add(pbLogoPrincipalContenido); // Añade el PictureBox que llenará
            panelInformacion.Controls.Add(lblBienvenidaContenido);   // Añade el Label que se anclará arriba

            // Asegura que los controles estén al frente
            lblBienvenidaContenido.BringToFront();
            pbLogoPrincipalContenido.BringToFront();
        }

        // --- Evento Click para el PictureBox de "Inicio" en el Menú ---
        // Asocia este método al evento Click de tu PictureBox llamado 'pbInicioMenu' en el diseñador.
        private void pbInicioMenu_Click(object sender, EventArgs e)
        {
            ConfigurarVistaInicial(); // Llama al método para restaurar la vista inicial
        }

        // --- Evento Click para el Label de "Inicio" en el Menú (si tienes uno) ---
        // Asocia este método al evento Click de tu Label llamado 'lblInicioMenu' en el diseñador.
        private void lblInicioMenu_Click(object sender, EventArgs e)
        {
            ConfigurarVistaInicial(); // Llama al método para restaurar la vista inicial
        }


        // --- Métodos Click para la carga de UserControls ---

        private void labelSiniestro_Click(object sender, EventArgs e)
        {
            panelInformacion.Controls.Clear(); // Limpia el panel antes de cargar el nuevo UC

            if (_userControlSiniestros == null)
            {
                _userControlSiniestros = new UserControlSiniestros();
                _userControlSiniestros.Dock = DockStyle.Fill; // El UC llenará todo el panel
            }

            if (!panelInformacion.Controls.Contains(_userControlSiniestros))
            {
                panelInformacion.Controls.Add(_userControlSiniestros);
            }

            // Opcional: Si tu UserControlSiniestros tiene un método para recargar sus datos.
            // _userControlSiniestros.CargarSiniestros();
            _userControlSiniestros.BringToFront(); // Asegura que el UC esté visible al frente
        }

        // Agrega aquí los métodos para los otros UserControls siguiendo el mismo patrón
        // Ejemplo para UserControlUsuarios:
        private void labelUsuarios_Click(object sender, EventArgs e) // Asumo que tienes un Label o Panel para "Usuarios"
        {
            panelInformacion.Controls.Clear();

            if (_userControlUsuarios == null)
            {
                _userControlUsuarios = new UserControlUsuarios();
                _userControlUsuarios.Dock = DockStyle.Fill;
            }

            if (!panelInformacion.Controls.Contains(_userControlUsuarios))
            {
                panelInformacion.Controls.Add(_userControlUsuarios);
            }
            // _userControlUsuarios.CargarDatos(); // Si tiene un método para cargar datos
            _userControlUsuarios.BringToFront();
        }

        // --- Eventos MouseEnter/MouseLeave para los paneles del menú (para efectos visuales) ---
        // Estos métodos asumen que panel1, panel2, panel3, panel4 son tus elementos de menú o los contenedores de ellos.
        private void panel4_MouseEnter(object sender, EventArgs e)
        {
            panel4.BackColor = Color.FromArgb(168, 204, 255);
        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(168, 204, 255);
        }

        private void panel3_MouseEnter(object sender, EventArgs e)
        {
            panel3.BackColor = Color.FromArgb(168, 204, 255);
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(206, 227, 255);
        }

        private void panel1_MouseEnter_1(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(168, 204, 255);
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(206, 227, 255);
        }

        private void panel4_MouseLeave(object sender, EventArgs e)
        {
            panel4.BackColor = Color.FromArgb(206, 227, 255);
        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            panel3.BackColor = Color.FromArgb(206, 227, 255);
        }

       
    }
}