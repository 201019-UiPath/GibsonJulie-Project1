using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoilMatesWeb.Models
{
    public class UserLocation
    {
        User user { get; set; }
        Location location { get; set; }
    }
}
