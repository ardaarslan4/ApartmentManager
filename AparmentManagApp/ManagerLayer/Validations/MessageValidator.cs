using ApartmentManager.Entities;

namespace ApartmentManager.ManagerLayer.Validations
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().MinimumLength(8);
            RuleFor(x => x.SenderMail).NotEmpty().MinimumLength(8);
            RuleFor(x => x.MessageContent).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Subject).NotEmpty().MinimumLength(4);
        }
    }
}
