using ApartmentManager.Access.Repository;
using ApartmentManager.Access.Services;
using ApartmentManager.Entities;

namespace ApartmentManager.Access.Framework
{
    public class UserFWLayer : Repository<User>, IUserSer
    {
    }
}
