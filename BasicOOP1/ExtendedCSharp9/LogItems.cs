using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExtendedCSharp9
{
    [XmlRootAttribute("Log")]
    public class LogItems
    {
        [XmlArrayAttribute("LogItems")]
        public LogItem[] logItems;

        public LogItems()
        {

        }

        public LogItems(List<LogItem> logItems)
        {
            this.logItems = logItems.ToArray();
        }
    }
}
