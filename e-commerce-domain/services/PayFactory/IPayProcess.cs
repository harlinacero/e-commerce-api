namespace e_commerce_domain.services.PayFactory
{
    public interface IPayProcess
    {
        void BeginPayProcess();
        bool IsPayProcessAvailable();
        void ConfirmPay();
    }
}