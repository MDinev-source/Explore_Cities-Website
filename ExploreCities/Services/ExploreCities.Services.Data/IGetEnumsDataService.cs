using System;
using System.Collections.Generic;
using System.Text;

namespace ExploreCities.Services.Data
{
    public interface IGetEnumsDataService
    {
        IEnumerable<Type> GetEnumsFromNameSpace();

        IEnumerable<string> GetEnumvValues(Type enumType);
    }
}
