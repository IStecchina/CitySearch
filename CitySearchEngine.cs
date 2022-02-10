using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySearch
{
    public class CitySearchEngine : ISearchEngine
    {
        public static readonly string cityString = "Paris, Budapest, Skopje, Rotterdam, Valencia, Vancouver, Amsterdam, Vienna, Sydney, New York City, London, Bangkok, Hong Kong, Dubai, Rome, Istanbul";
        private readonly List<string> cityList;

        public CitySearchEngine()
        {
            var tempList = cityString.Split(",");
            cityList = new List<string>(tempList.Select(c => c.Trim()));
        }

        public List<string> Search(string query)
        {
            var result = new List<string>();
            //Wildcard query
            if (query.Equals("*"))
            {
                result.AddRange(cityList);
                return result;
            }
            //Empty result on non-wildcard short query
            if (query.Length < 2) return result;
            //Normal search
            var matches = cityList.Where(city => city.ToLower().Contains(query.ToLower()));
            result.AddRange(matches);
            return result;

        }
    }
}
