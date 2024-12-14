namespace e_commerce_domain.customExceptions
{
    public class FailedPaymentException : Exception
    {
        public FailedPaymentException() { }
        public FailedPaymentException(string message) : base(message) { }
        public FailedPaymentException(string message, Exception inner) : base(message, inner) { }
    }
}