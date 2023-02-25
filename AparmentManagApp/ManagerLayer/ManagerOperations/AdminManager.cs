using ApartmentManager.Entities;
using ApartmentManager.ManagerLayer.ManagerServices;
using ApartmentManager.Access.Services;

namespace ApartmentManager.ManagerLayer.ManagerOperations
{
    public class AdminManager:IAdminManagerService
    {
        IAdminSer AdminSer;

        public AdminManager(IAdminSer adminSer)
        {
            AdminSer = adminSer;
        }

        public Admin GetByID(int id)
        {
            return AdminSer.GetByID(id);
        }

        public List<Admin> GetList()
        {
            return AdminSer.GetListAll();
        }

        public Admin getListLoggedAdmin(string mail)
        {
            return AdminSer.GetListAll().Where(x => x.Email == mail).SingleOrDefault();
        }

        public void TAdd(Admin t)
        {
            AdminSer.Insert(t);
        }

        public void TDelete(Admin t)
        {
            AdminSer.Delete(t);
        }

        public void TUpdate(Admin t)
        {
            AdminSer.Update(t);
        }
    }
}
