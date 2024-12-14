namespace e_commerce_domain.services.Contracts
{
    public interface IPayProcess
    {
        void BeginPayProcess();
        bool IsPayProcessAvailable();
        void ConfirmPay();
    }
}