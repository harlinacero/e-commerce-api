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
        public string FirstName { get; set; }
        /// <summary>
        /// Apellido
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Dirección
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Teléfono
        /// </summary>
        public string Phone { get; set; }
    }
}
