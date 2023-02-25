using ApartmentManager.Entities;

namespace ApartmentManager.ManagerLayer.ManagerServices
{
    public interface IMessageService : IOverAllService<Message>
    {
        List<Message> GetListMessageInInbox(string ReceiverMail);
        List<Message> GetListMessageInSendbox(string SenderMail);
    }
}
