using ApartmentManager.Entities;

namespace ApartmentManager.ManagerLayer.ManagerServices
{
    public interface IUserService : IOverAllService<User>
    {
        User getListLoggedUser(string mail);
    }
}
