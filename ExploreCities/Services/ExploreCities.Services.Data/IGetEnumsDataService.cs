namespace ExploreCities.Services.Data
{
    using System;
    using System.Collections.Generic;

    public interface IGetEnumsDataService
    {
        IEnumerable<Type> GetEnumsFromNameSpace();

        IEnumerable<string> GetEnumvValues(Type enumType);

        string ReturnCorrectName(string name);
    }
}
