namespace e_commerce_domain.entities.User
{
    /// <summary>
    /// Administrador de la plataforma
    /// </summary>
    public class Admin : UserBase
    {
        public Admin(string username, string email, string password) : base(username, email, password)
        {
        }
    }
}
