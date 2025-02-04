using SalesApp.Application.Interfaces;
using System.Text.Json;

namespace SalesApp.Infrastructure.Messaging
{
    public class MessageBus: IMessageBus
    {
        public void Send<T>(T message)
        {
            Console.WriteLine();
            Console.WriteLine("=====> Sent message type: " + typeof(T).Name);
            Console.WriteLine("=====> Content: " + JsonSerializer.Serialize(message));
        }
    }
}
