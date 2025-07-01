using System;
using System.Drawing;
using System.Net.Http;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace SegurosSelers.Formularios
{
    public partial class FormularioImagenPopUp : Form
    {
        // ¡Declaramos pictureBoxImagen y labelCargando aquí porque NO están en Designer.cs!
        private PictureBox pictureBoxImagen;
        private Label labelCargando;

        // botonVolver NO lo declaramos aquí, porque ya está en Designer.cs
        // y es accesible a través de InitializeComponent().

        public FormularioImagenPopUp()
        {
            // SI llamamos a InitializeComponent() porque el botonVolver está definido allí.
            InitializeComponent();

            // --- CÓDIGO PARA CREAR pictureBoxImagen y labelCargando MANUALMENTE ---
            // Esto es necesario porque el error CS1061 indica que no existen.

            // 1. Crear y añadir el PictureBox
            pictureBoxImagen = new PictureBox
            {
                Dock = DockStyle.Fill, // Hace que el PictureBox llene todo el formulario
                SizeMode = PictureBoxSizeMode.Zoom, // Escala la imagen para que quepa sin distorsión
                BackColor = Color.LightGray // Un color de fondo mientras la imagen carga
            };
            this.Controls.Add(pictureBoxImagen); // Agrega el PictureBox al formulario

            // 2. Crear y añadir el Label de "Cargando..."
            labelCargando = new Label
            {
                Text = "Cargando imagen...",
                AutoSize = true, // El tamaño del label se ajusta automáticamente al texto
                Font = new Font("Arial", 12, FontStyle.Italic),
                // La ubicación (Location) la calcularemos en el evento Load para centrarla
            };
            this.Controls.Add(labelCargando); // Agrega el Label al formulario
            // --- FIN CÓDIGO MANUAL ---

            // Configuración general del formulario
            this.Text = "Detalle de Imagen";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new Size(600, 500);
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new Size(400, 300);

            // Asegurar que el label y el botón estén al frente desde el inicio
            // Usamos 'this.' para acceder a los controles.
            this.labelCargando.BringToFront();
            this.botonVolver.BringToFront(); // 'botonVolver' ya existe por InitializeComponent()

            // Suscribimos el evento Click del botón (asegúrate de que no esté duplicado en Designer.cs)
            this.botonVolver.Click += botonVolver_Click;

            // Suscribimos el evento Load del formulario para posicionar los controles
            // una vez que el formulario ha establecido su tamaño final.
            this.Load += FormularioImagenPopUp_Load;
        }

        // Este evento se dispara cuando el formulario ha terminado de cargarse y su tamaño es definitivo.
        private void FormularioImagenPopUp_Load(object sender, EventArgs e)
        {
            // Calcular la posición del botón en la esquina inferior derecha
            int margin = 15; // Margen para separar el botón de los bordes del formulario
            this.botonVolver.Location = new Point(
                this.ClientSize.Width - this.botonVolver.Width - margin,  // Posición X (desde la derecha)
                this.ClientSize.Height - this.botonVolver.Height - margin // Posición Y (desde abajo)
            );

            // Calcular la posición del label de cargando para que esté centrado en el formulario
            this.labelCargando.Location = new Point(
                (this.ClientSize.Width - this.labelCargando.Width) / 2,  // Posición X (centrado horizontalmente)
                (this.ClientSize.Height - this.labelCargando.Height) / 2 // Posición Y (centrado verticalmente)
            );
        }

        public async void CargarImagenDesdeUrl(string imageUrl)
        {
            if (string.IsNullOrEmpty(imageUrl))
            {
                this.pictureBoxImagen.Image = null;
                this.labelCargando.Text = "No se proporcionó URL de imagen.";
                this.labelCargando.Visible = true;
                return;
            }

            this.labelCargando.Text = "Cargando imagen...";
            this.labelCargando.Visible = true;
            this.pictureBoxImagen.Image = null;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    byte[] imageBytes = await client.GetByteArrayAsync(imageUrl);

                    using (var ms = new System.IO.MemoryStream(imageBytes))
                    {
                        this.pictureBoxImagen.Image = Image.FromStream(ms);
                    }
                }
                this.labelCargando.Visible = false;
            }
            catch (HttpRequestException httpEx)
            {
                this.labelCargando.Text = $"Error de red: {httpEx.Message}. Asegúrese de que la URL es accesible.";
                this.labelCargando.Visible = true;
                MessageBox.Show($"Error de red al cargar la imagen: {httpEx.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                this.labelCargando.Text = $"Error al cargar la imagen: {ex.Message}";
                this.labelCargando.Visible = true;
                MessageBox.Show($"Error al cargar la imagen: {ex.Message}", "Error de Imagen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}