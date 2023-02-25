using ApartmentManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManager.ManagerLayer.ManagerServices
{
    public interface IAdminManagerService : IOverAllService<Admin>
    {
        Admin getListLoggedAdmin(string mail);
    }
}
