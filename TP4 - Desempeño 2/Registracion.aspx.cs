using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP4___Desempeño_2
{
    public partial class Registracion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            ErrorLabel.Text = "";

            // Validación
            if (string.IsNullOrWhiteSpace(TextBox1.Text) ||
                string.IsNullOrWhiteSpace(TextBox2.Text) ||
                string.IsNullOrWhiteSpace(TextBox3.Text) ||
                string.IsNullOrWhiteSpace(TextBox4.Text) ||
                string.IsNullOrWhiteSpace(TextBox5.Text))
            {
               
                ErrorLabel.Text = "Todos los campos son requeridos";
                return;
            }

            // Validación: Edad mayor a 15 años
            if (!int.TryParse(TextBox3.Text, out int edad) || edad <= 15)
            {
                
                ErrorLabel.Text = "La edad debe ser mayor a 15 años";
                return;
            }

            // Validación: Contraseña escrita y repetida son iguales
            if (TextBox4.Text != TextBox5.Text)
            {
                
                ErrorLabel.Text = "Las contraseñas no coinciden";
                return;
            }

            // Validación: Mail tiene formato de Email
            if (!IsValidEmail(TextBox1.Text))
            {
                ErrorLabel.Text = "El formato del correo electrónico no es válido";
                return;
            }

            

            // Crear Cookie con la contraseña
            HttpCookie passwordCookie = new HttpCookie("PasswordCookie");
            passwordCookie.Value = TextBox4.Text; 
            passwordCookie.Expires = DateTime.Now.AddMonths(1); 
            Response.Cookies.Add(passwordCookie);

            // Crear Session con el nombre de usuario
            Session["Username"] = TextBox2.Text; 

            // Mensaje de exito en la Label
            ErrorLabel.Text = "Registro exitoso";

        }

        // Función para validar el formato de Email
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}