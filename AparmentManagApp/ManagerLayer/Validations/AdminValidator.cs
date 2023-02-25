using ApartmentManager.Entities;
using FluentValidation;

namespace ApartmentManager.ManagerLayer.Validations
{
    public class AdminValidator : AbstractValidator<Admin>
    {
        public AdminValidator()
        {
            RuleFor(x => x.AdminId).GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty().MinimumLength(4);
            RuleFor(x => x.Surname).NotEmpty().MinimumLength(4);
            RuleFor(x => x.Email).NotEmpty().MinimumLength(8);
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
        }
    }
}
