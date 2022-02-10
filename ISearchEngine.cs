using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySearch
{
   public interface ISearchEngine
    {
        List<string> Search(string query);
    }
}
