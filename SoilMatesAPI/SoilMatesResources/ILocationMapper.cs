using SoilMatesDB.Models;
using SoilMatesResources.Models;
using System.Collections.Generic;

namespace SoilMatesResources
{
    public interface ILocationMapper
    {
        Location ParseLocation(LocationResource location);
        LocationResource ParseLocation(Location location);
        List<LocationResource> ParseLocation(List<Location> location);
        List<Location> ParseLocation(List<LocationResource> location);
    }
}
