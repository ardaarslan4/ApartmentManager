using ApartmentManager.Entities;

namespace ApartmentManager.ManagerLayer.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Surname).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
            RuleFor(x => x.PhoneNumber).NotEmpty().MinimumLength(10);
            RuleFor(x => x.TCNo).NotEmpty().MinimumLength(11);
        }
    }
}
