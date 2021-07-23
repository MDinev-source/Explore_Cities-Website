namespace ExploreCities.Services.Data
{
    using System.Collections.Generic;

    public interface ICitiesService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
