using SoilMatesDB.Models;
using System.Collections.Generic;

namespace SoilMatesLib
{
    public interface IManagerService
    {
        void AddManager(Manager newManager);
        Manager GetManagerByLogin(string password, string email);
        void SaveChanges();
        void SignUpManager(string name, string email, string password);
        List<Manager> GetAllManagers();
        Manager GetManagerByEmail(string email);
    }
}