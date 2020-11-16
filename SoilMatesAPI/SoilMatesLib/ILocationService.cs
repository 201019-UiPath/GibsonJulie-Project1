using SoilMatesDB.Models;
using System.Collections.Generic;

namespace SoilMatesLib
{
    /// <summary>
    /// ILocation services inventory to serve location services
    /// </summary>
    public interface ILocationService
    {
        void AddLocation(Location location);
        void AddNewLocation(string name, string address);
        List<Location> GetAllLocations();
        Location GetLocationById(int id);
        Location GetLocationByName(string name);
        void RemoveLocation(Location location);
        void SaveChanges();
    }
}