namespace SalesApp.Application.Interfaces
{
    public interface IMessageBus
    {
        void Send<T>(T message);
    }
}
