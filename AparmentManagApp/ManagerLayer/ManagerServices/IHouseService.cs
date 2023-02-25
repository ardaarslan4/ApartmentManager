using ApartmentManager.Entities;

namespace ApartmentManager.ManagerLayer.ManagerServices
{
    public interface IHouseService : IOverAllService<House>
    {
        List<House> GetListLoggedHouse(int id);
    }
}
