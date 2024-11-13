namespace e_commerce_domain.entities.User
{
    /// <summary>
    /// Vendedor
    /// </summary>
    public class Seller : UserBase
    {
        /// <summary>
        /// Teléfono
        /// </summary>
        private string phone;
        /// <summary>
        /// Puntuación o calificación
        /// </summary>
        private int score;

        public Seller(string username, string email, string password, string phone) 
            : base(username, email, password)
        {
            this.phone = phone;
        }

        public string GetPhone()
        {
            return phone;
        }
        public void SetPhone(string value)
        {
            phone = value;
        }


        public int GetScore()
        {
            return score;
        }

        public void SetScore(int value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("El escore del vendedor no puede ser menor a 0");
            }

            if (value >= 5)
            {
                throw new ArgumentOutOfRangeException("El escore del vendedor no puede ser mayor a 5");
            }

            score = value;
        }
    }
}
