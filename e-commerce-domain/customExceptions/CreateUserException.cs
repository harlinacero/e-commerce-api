namespace e_commerce_domain.customExceptions
{
    public class CreateUserException : Exception
    {
        public CreateUserException() { }
        public CreateUserException(string message) : base(message) { }
        public CreateUserException(string message, Exception inner) : base(message, inner) { }
    }
}