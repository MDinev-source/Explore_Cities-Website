namespace ExploreCities.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

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

        public string ReturnCorrectName(string name)
        {
            var sb = new StringBuilder();

            int count = name.Count(c => char.IsUpper(c));

            if (count > 1)
            {
                foreach (var ch in name)
                {
                    if (name.IndexOf(ch) == 0)
                    {
                        sb.Append(ch.ToString());
                    }
                    else if (char.IsUpper(ch))
                    {
                        sb.Append(" " + ch.ToString());
                    }
                    else
                    {
                        sb.Append(ch.ToString());
                    }
                }

                return sb.ToString().TrimEnd();
            }

            return name;
        }
    }
}
