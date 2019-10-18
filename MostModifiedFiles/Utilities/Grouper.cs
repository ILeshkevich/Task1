using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MostModifiedFiles.Utilities
{
    public class Grouper
    {
        public Dictionary<string, int> GroupList(IEnumerable<string> files)
        {
            return files.GroupBy(f => f).Select(f => new {Key = f.Key, Count = f.Count()})
                .ToDictionary(o => o.Key, o => o.Count);
        }
    }
}
