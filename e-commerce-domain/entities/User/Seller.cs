namespace e_commerce_domain.entities.User
{
    /// <summary>
    /// Vendedor
    /// </summary>
    public class  Seller : UserBase
    {
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
