using ApartmentManager.Entities;
using ApartmentManager.ManagerLayer.ManagerServices;
using ApartmentManager.Access.Services;

namespace ApartmentManager.ManagerLayer.ManagerOperations
{
    public class UserManager : IUserService
    {
        IUserSer UserSer;

        public UserManager(IUserSer userSer)
        {
            UserSer = userSer;
        }

        public User GetByID(int id)
        {
            return UserSer.GetByID(id);
        }

        public List<User> GetList()
        {
            return UserSer.GetListAll();
        }

        public User getListLoggedUser(string p)
        {
            return UserSer.GetListAll().FirstOrDefault(x => x.Email == p);
        }

        public void TAdd(User t)
        {
            UserSer.Insert(t);
        }

        public void TDelete(User t)
        {
            UserSer.Delete(t);
        }

        public void TUpdate(User t)
        {
            UserSer.Update(t);
        }
    }
}
