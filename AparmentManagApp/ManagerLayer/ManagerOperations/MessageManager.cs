using ApartmentManager.Entities;
using ApartmentManager.ManagerLayer.ManagerServices;
using ApartmentManager.Access.Services;

namespace ApartmentManager.ManagerLayer.ManagerOperations
{
    public class MessageManager : IMessageService
    {
        IMessageSer MessageSer;

        public MessageManager(IMessageSer messageSer)
        {
            MessageSer = messageSer;
        }

        public Message GetByID(int id)
        {
            return MessageSer.GetByID(id);
        }

        public List<Message> GetList()
        {
            return MessageSer.GetListAll();
        }

        public List<Message> GetListMessageInInbox(string ReceiverMail)
        {
            return MessageSer.GetListAll().Where(x => x.ReceiverMail ==ReceiverMail ).ToList();
        }

        public List<Message> GetListMessageInSendbox(string SenderMail)
        {
            return MessageSer.GetListAll().Where(x => x.SenderMail == SenderMail).ToList();
        }

        public void TAdd(Message t)
        {
            MessageSer.Insert(t);
        }

        public void TDelete(Message t)
        {
            MessageSer.Delete(t);
        }

        public void TUpdate(Message t)
        {
            MessageSer.Update(t);
        }
    }
}
