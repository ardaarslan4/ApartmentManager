using ApartmentManager.Entities;
using ApartmentManager.ManagerLayer.ManagerServices;
using ApartmentManager.Access.Services;

namespace ApartmentManager.ManagerLayer.ManagerOperations
{
    public class HouseManager:IHouseService
    {
        IHouseSer HouseSer;

        public HouseManager(IHouseSer houseSer)
        {
            HouseSer = houseSer;
        }

        public House GetByID(int id)
        {
            return HouseSer.GetByID(id);
        }

        public List<House> GetList()
        {
            return HouseSer.GetListAll();
        }

        public List<House> GetListLoggedHouse(int id)
        {
            return HouseSer.GetListLoggedHouse(id);
        }

        public void TAdd(House t)
        {
            HouseSer.Insert(t);
        }

        public void TDelete(House t)
        {
            HouseSer.Delete(t);
        }

        public void TUpdate(House t)
        {
            HouseSer.Update(t);
        }
    }
}
