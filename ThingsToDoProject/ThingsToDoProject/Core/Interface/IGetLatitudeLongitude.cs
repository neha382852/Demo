using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThingsToDoProject.Model;

namespace ThingsToDoProject.Core.Interface
{
    interface IGetLatitudeLongitude
    {
        Location Get(string CityName);
    }
}
