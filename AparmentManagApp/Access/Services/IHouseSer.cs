
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManager.Entities;

namespace ApartmentManager.Access.Services
{
    public interface IHouseSer:IAllOverSer<House>
    {
        List<House> GetListLoggedHouse(int id);
    }
}
