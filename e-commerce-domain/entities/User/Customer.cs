namespace e_commerce_domain.entities.User
{
    /// <summary>
    /// Usuario de tipo cliene
    /// </summary>
    public class Customer : UserBase
    {
        /// <summary>
        /// Primer Nombre
        /// </summary>
        private string firstName;
        /// <summary>
        /// Apellido
        /// </summary>
        private string lastName;
        /// <summary>
        /// Dirección
        /// </summary>
        private string address;


        /// <summary>
        /// Teléfono
        /// </summary>
        private string phone;

        public Customer(string username, string email, string password, string firstname, string lastname, string address)
            : base(username, email, password)
        {
            this.firstName = firstname;
            this.lastName = lastname;
            this.address = address;
        }

        public string GetFirstName()
        {
            return firstName;
        }
        public void SetFirstName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("El Primer nombre del usuario no puede ser null o vacio");
            }

            firstName = value;
        }


        public string GetLastName()
        {
            return lastName;
        }

        public void SetLastName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("El apellido del usuario no puede ser null o vacio");
            }

            lastName = value;
        }

        public string GetAddress()
        {
            return address;
        }

        public void SetAddress(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("La dirección del usuario no puede ser null o vacio");
            }

            address = value;
        }

        public string GetPhone()
        {
            return phone;
        }
        public void SetPhone(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("El teléfono del usuario no puede ser null o vacio");
            }
            phone = value;
        }
    }
}
