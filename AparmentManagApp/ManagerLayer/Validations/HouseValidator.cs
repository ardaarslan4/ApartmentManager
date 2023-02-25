using ApartmentManager.Entities;

namespace ApartmentManager.ManagerLayer.Validations
{
    public class HouseValidator : AbstractValidator<House>
    {
        public HouseValidator()
        {
            RuleFor(x => x.Floor).NotEmpty().WithMessage("Floor info cannot be empty");
            RuleFor(x => x.HouseType).NotEmpty().WithMessage("HouseType info cannot be empty");
            RuleFor(x => x.HouseNo).GreaterThan(0);
            RuleFor(x => x.Block).GreaterThan(0);
        }
    }
}
