using System;
using System.Windows.Forms;
using SegurosSelers.Entidades;
using SegurosSelers.Servicios;
using System.Text.RegularExpressions; // Para la validación del correo electrónico

namespace SegurosSelers.Formularios
{
    public partial class FormularioRegistro : Form
    {
        private GestorService _gestorService;
        // No longer need _mostrarClave as a global variable

        public FormularioRegistro()
        {
            InitializeComponent();
            _gestorService = new GestorService();
            textBoxClave.UseSystemPasswordChar = true; // Establece el modo de contraseña por defecto
            textBoxConfirmar.UseSystemPasswordChar = true; // También para el campo de confirmación
        }

        private void button1_Click(object sender, EventArgs e) // Cambio de nombre del evento
        {
            // 1. Validar los datos ingresados
            if (!ValidarDatos())
            {
                return; // Detiene el proceso si la validación falla
            }

            // 2. Crear un objeto Gestor con los datos del formulario
            Gestor nuevoGestor = new Gestor
            {
                Nombre = FormatearNombre(textBoxNombre.Text),
                Apellido = FormatearNombre(textBoxApellido.Text),
                Correo = textBoxEmail.Text, // Cambio de nombre del TextBox
                Clave = textBoxClave.Text, // ¡Encriptar antes de guardar!
            };

            // 3. Llamar al método del servicio para guardar el gestor
            try
            {
                _gestorService.GuardarGestor(nuevoGestor);
                MessageBox.Show("Registro Exitoso. \nYa podés empezar a usar tu cuenta.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
                FormularioLogin formularioLogin = new FormularioLogin();
                formularioLogin.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar gestor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Aquí podrías loguear el error
            }
        }

        private void botonVolver_Click(object sender, EventArgs e) // Cambio de nombre del evento
        {
            FormularioLogin formularioLogin = new FormularioLogin();
            this.Hide();
            formularioLogin.Show();
            this.Close();
        }

        private void FormularioRegistro_Load(object sender, EventArgs e)
        {
        }

        private void LimpiarFormulario()
        {
            textBoxNombre.Text = "";
            textBoxApellido.Text = "";
            textBoxEmail.Text = ""; // Cambio de nombre del TextBox
            textBoxClave.Text = "";
            textBoxConfirmar.Text = ""; // Limpiamos el campo confirmar también
        }

        private bool ValidarDatos()
        {
            // Validar campos vacíos
            if (string.IsNullOrWhiteSpace(textBoxNombre.Text) ||
                string.IsNullOrWhiteSpace(textBoxApellido.Text) ||
                string.IsNullOrWhiteSpace(textBoxEmail.Text) ||
                string.IsNullOrWhiteSpace(textBoxClave.Text) ||
                string.IsNullOrWhiteSpace(textBoxConfirmar.Text)) // también la confirmación
            {
                MessageBox.Show("Campos incompletos. Revisá e intentá de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarCampos();
                return false;
            }

            // Validar nombre y apellido
            if (!EsNombreApellidoValido(textBoxNombre.Text) || !EsNombreApellidoValido(textBoxApellido.Text))
            {
                MessageBox.Show("Nombre o apellido no válido.\nPor favor, ingresá texto válido.\nNo se permiten números ni caracteres especiales.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarCampos();
                return false;
            }

            // Validar correo electrónico
            if (!EsCorreoValido(textBoxEmail.Text))
            {
                MessageBox.Show("El formato del correo electrónico no es válido.\nPor favor, ingresá una dirección válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarCampos();
                return false;
            }

            // Validar que ambas contraseñas coincidan
            if (textBoxClave.Text != textBoxConfirmar.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.\nPor favor, verificá que ambas sean iguales.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarCampos();
                return false;
            }
            if (!EsContraseñaValida(textBoxClave.Text))
            {
                MessageBox.Show("La contraseña ingresada no es válida.\nDebe tener al menos 8 caracteres, incluir una mayúscula, una minúscula y un número.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarCampos();
                return false;
            }

            return true;
        }


        private bool EsContraseñaValida(string contraseña)
        {
            // Al menos una mayúscula, una minúscula, un número y mínimo 8 caracteres
            var regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$");
            return regex.IsMatch(contraseña);
        }
        private void LimpiarCampos()
        {
            textBoxNombre.Text = "";
            textBoxApellido.Text = "";
            textBoxEmail.Text = "";
            textBoxClave.Text = "";
            textBoxConfirmar.Text = "";
        }

        private bool EsNombreApellidoValido(string texto)
        {
            // Acepta letras (mayúsculas y minúsculas) y espacios, incluyendo tildes
            var regex = new Regex(@"^[A-Za-zÁÉÍÓÚáéíóúÑñ\s]+$");
            return regex.IsMatch(texto);
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

        private string FormatearNombre(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
                return nombre;

            return nombre.Substring(0, 1).ToUpper() + nombre.Substring(1).ToLower();
        }

        // --- MODIFIED CODE FOR SINGLE OJITO_CLICK ---
        private void ojito_Click(object sender, EventArgs e)
        {
            // Determine which PictureBox sent the event
            PictureBox clickedOjito = sender as PictureBox;

            if (clickedOjito == ojito1)
            {
                textBoxClave.UseSystemPasswordChar = !textBoxClave.UseSystemPasswordChar;
                if (textBoxClave.UseSystemPasswordChar)
                {
                    ojito1.Image = Properties.Resources.cerrado;
                }
                else
                {
                    ojito1.Image = Properties.Resources.abierto;
                }
            }
            else if (clickedOjito == ojito2) // Assuming you have a PictureBox named ojito2
            {
                textBoxConfirmar.UseSystemPasswordChar = !textBoxConfirmar.UseSystemPasswordChar;
                if (textBoxConfirmar.UseSystemPasswordChar)
                {
                    ojito2.Image = Properties.Resources.cerrado;
                }
                else
                {
                    ojito2.Image = Properties.Resources.abierto;
                }
            }
        }
        // --- END MODIFIED CODE ---

        private void botonLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormularioLogin formularioLogin = new FormularioLogin();

            formularioLogin.Show();

        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormularioLogin formularioLogin = new FormularioLogin();
            formularioLogin.Show();

        }
    }
}
