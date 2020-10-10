using MarchePOS.Services.Interfaces;

namespace MarchePOS.Services
{
    public class MessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Hello from the Message Service";
        }
    }
}
