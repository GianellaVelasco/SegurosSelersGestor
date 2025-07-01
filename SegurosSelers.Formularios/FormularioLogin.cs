using System;
using System.Windows.Forms;
using SegurosSelers.Servicios;
using System.Text.RegularExpressions;
using SegurosSelers.Entidades;

namespace SegurosSelers.Formularios
{
    public partial class FormularioLogin : Form
    {
        private GestorService _gestorService;
        private bool _mostrarClave = false; // Variable para controlar la visibilidad de la contraseña

        public FormularioLogin()
        {
            InitializeComponent();
            _gestorService = new GestorService();
            textBoxClave.UseSystemPasswordChar = true; // Establece el modo de contraseña por defecto

            // Llama a un método para configurar el estado inicial del "ojo"
            // y la visibilidad de la clave al iniciar el formulario.
            ConfigurarEstadoInicialClave();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Validar los datos ingresados
            if (!ValidarDatos())
            {
                return;
            }

            // 2. Obtener el gestor por correo electrónico
            Gestor gestor = _gestorService.ObtenerGestorPorCorreo(textBoxEmail.Text);

            // 3. Verificar si el gestor existe y la contraseña es correcta
            if (gestor != null && gestor.Clave == textBoxClave.Text) // ¡Ojo! La clave se guarda en texto plano, deberías encriptarla.
            {
                this.Hide();

                FormularioHome formularioHome = new FormularioHome(gestor);

                formularioHome.Show();

                //this.Close(); // Opcional, si quieres cerrar el login completamente.
            }
            else
            {
                MessageBox.Show("Email o contraseña incorrectos.\r\nPor favor, revisá e intentá de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarCampos();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Crea una instancia del formulario de registro
            FormularioRegistro formularioRegistro = new FormularioRegistro();

            formularioRegistro.ShowDialog();
        }

        private void FormularioLogin_Load(object sender, EventArgs e)
        {
            // Este método puede quedar vacío si ConfigurarEstadoInicialClave() ya se llama en el constructor.
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text) || string.IsNullOrWhiteSpace(textBoxClave.Text))
            {
                MessageBox.Show("Campos incompletos. Revisá e intentá de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarCampos();
                return false;
            }

            if (!EsCorreoValido(textBoxEmail.Text))
            {
                MessageBox.Show("El formato del correo electrónico no es válido.\nPor favor, ingresá una dirección válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarCampos();
                return false;
            }

            // Las validaciones de contraseña aquí están comentadas, pero es buena práctica tenerlas activas.
            if (!EsContraseñaValida(textBoxClave.Text))
            {
                 MessageBox.Show("La contraseña ingresada no es válida.\nDebe tener al menos 8 caracteres, incluir una mayúscula, una minúscula y un número.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 LimpiarCampos();
                 return false;
             }

            return true;
        }

        private bool EsCorreoValido(string correo)
        {
            try
            {
                var mailAddress = new System.Net.Mail.MailAddress(correo);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool EsContraseñaValida(string contraseña)
        {
            // Al menos una mayúscula, una minúscula, un número y mínimo 8 caracteres
            var regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$");
            return regex.IsMatch(contraseña);
        }

        private void LimpiarCampos()
        {
            textBoxEmail.Text = "";
            textBoxClave.Text = "";
        }

        // Este método toggleVerClave_Click parece ser una versión anterior o duplicada.
        // Si 'ojito' es el control que usas, puedes eliminar este método para evitar confusión.
        private void toggleVerClave_Click(object sender, EventArgs e)
        {
            _mostrarClave = !_mostrarClave;
            if (_mostrarClave)
            {
                textBoxClave.UseSystemPasswordChar = false;
            }
            else
            {
                textBoxClave.UseSystemPasswordChar = true;
            }
            // Falta actualizar la imagen aquí si este método fuera el usado.
        }


        private void ojito_Click(object sender, EventArgs e)
        {
            // La lógica de _mostrarClave se invierte primero, luego se usa para determinar el nuevo estado
            _mostrarClave = !_mostrarClave;
            AplicarEstadoVisibilidadClave();
        }

        /// <summary>
        /// Configura el estado inicial del TextBoxClave y la imagen del control 'ojito'
        /// al cargar el formulario. Por defecto, la clave estará oculta.
        /// </summary>
        private void ConfigurarEstadoInicialClave()
        {
            _mostrarClave = false; // Asegura que la clave esté oculta al inicio
            textBoxClave.UseSystemPasswordChar = true; // Oculta los caracteres de la contraseña

            // CAMBIO CLAVE: Usa .Image en lugar de .BackgroundImage
            if (ojito != null)
            {
                ojito.Image = Properties.Resources.cerrado; // Asigna a la propiedad Image
            }
        }

        /// <summary>
        /// Aplica los cambios de visibilidad al TextBoxClave y actualiza la imagen/texto del control 'ojito'.
        /// </summary>
        private void AplicarEstadoVisibilidadClave()
        {
            if (_mostrarClave)
            {
                textBoxClave.UseSystemPasswordChar = false;
                if (ojito != null)
                {
                    // Usa .Image
                    ojito.Image = Properties.Resources.abierto;
                }
            }
            else
            {
                textBoxClave.UseSystemPasswordChar = true;
                if (ojito != null)
                {
                    // Usa .Image
                    ojito.Image = Properties.Resources.cerrado;
                }
            }
            // Opcional: Para asegurar que el cambio se muestre inmediatamente, puedes forzar un redibujado.
            // ojito.Refresh();
        }
    }
}