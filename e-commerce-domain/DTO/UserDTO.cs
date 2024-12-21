using e_commerce_domain.enums;

namespace e_commerce_domain.DTO
{
    public class UserDTO
    {
        public UserType UserType { get; set; }
        public Guid Id { get; set; }
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
        /// <summary>
        /// Puntuación o calificación
        /// </summary>
        public int Score { get; set; }
    }

}
