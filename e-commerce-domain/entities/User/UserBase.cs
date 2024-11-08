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
        public string UserName { get; set; }
        /// <summary>
        /// Correo electrónico
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Contraseña
        /// </summary>
        public string Password { get; set; }
    
    }
}
