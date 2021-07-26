namespace ExploreCities.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using ExploreCities.Data.Models.Enums;

    public class GetEnumsDataService : IGetEnumsDataService
    {
        private const string NameSpace = "ExploreCities.Data.Models.Enums";

        public IEnumerable<Type> GetEnumsFromNameSpace()
        {
            Assembly assembly = typeof(AirPollutionRating).Assembly;

            List<Type> enumsFromNameSpace = assembly.GetTypes()
                          .Where(t => t.Namespace == NameSpace)
                          .Where(x => x.Name.Contains("Rating")
                          || x.Name.Contains("Existence"))
                          .OrderBy(x => x.Name)
                          .ToList();

            return enumsFromNameSpace;
        }

        public IEnumerable<string> GetEnumvValues(Type enumType)
        {
            List<string> enumValues = Enum.GetNames(enumType).ToList();

            return enumValues;
        }
    }
}
