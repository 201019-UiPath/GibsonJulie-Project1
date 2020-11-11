using System.Collections.Generic;
using SoilMatesDB.Models;
using SoilMatesResources.Models;

namespace SoilMatesResources
{
    public interface IManagerMapper
    {
        Manager ParseManager(ManagerResource manager);
        ManagerResource ParseManager(Manager manager);
        List<ManagerResource> ParseManager(List<Manager> manager);
    }
}
