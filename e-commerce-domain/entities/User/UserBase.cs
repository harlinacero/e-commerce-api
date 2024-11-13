using System.Text.RegularExpressions;

namespace e_commerce_domain.entities.User
{
    /// <summary>
    /// Usuario base
    /// </summary>
    public abstract class UserBase : EntityBase
    {
        /// <summary>
        /// Nombre de usuario
        /// </summary>
        protected string userName;
        /// <summary>
        /// Correo electrónico
        /// </summary>
        protected string email;
        /// <summary>
        /// Contraseña
        /// </summary>
        protected string password;

        protected UserBase(string username, string email, string password)
        {
            this.userName = username;
            this.email = email;
            this.password = password;
        }

        public string GetUserName()
        {
            return userName;
        }
        public void SetUserName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("El username no puede ser null o vacio");
            }
            userName = value;
        }


        public string GetEmail()
        {
            return email;
        }

        public void SetEmail(string value)
        {
            // Verifica que el valor del email no se nul o vacio
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("El email no puede ser null o vacio");
            }

            // Verifica la validez del email
            string sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (!Regex.IsMatch(value, sFormato))
            {
                throw new InvalidDataException($"El email introducido no es válido");
            }

            if (Regex.Replace(value, sFormato, string.Empty).Length != 0)
            {
                throw new InvalidDataException($"El email introducido no es válido");
            }

            email = value;
        }


        public string GetPassword()
        {
            return password;
        }

        public void SetPassword(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("El password no puede ser null o vacio");
            }
            password = value;
        }
    }
}
