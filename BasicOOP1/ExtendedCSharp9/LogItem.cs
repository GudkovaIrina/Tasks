using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExtendedCSharp9
{
    public class LogItem
    {
        const string BackUp = @"D:\BackUp";

        public LogItem()
        {

        }

        public LogItem(FileSystemEventArgs e)
        {
            this.time = DateTime.Now;
            this.fullPath = e.FullPath;
            this.changeType = e.ChangeType;

            if ((e.ChangeType == WatcherChangeTypes.Changed) || (e.ChangeType == WatcherChangeTypes.Created))
            {
                this.pathBackUp = Path.Combine(BackUp,
                                              TimeOfChangeToString(time),
                                              e.Name.Substring(e.Name.LastIndexOf(@"\") + 1));
            }
            
            if (e is RenamedEventArgs)
            {
                this.oldFullPath = ((RenamedEventArgs)e).OldFullPath;
            }
        }
        [XmlElementAttribute("Time")]
        public DateTime time;
        [XmlElementAttribute("FullPath")]
        public string fullPath;
        [XmlElementAttribute("ChangeType")]
        public WatcherChangeTypes changeType;
        [XmlElementAttribute("PathBackUp")]
        public string pathBackUp;
        [XmlElementAttribute("OldFullPath")]
        public string oldFullPath;

        private string TimeOfChangeToString(DateTime time)
        {
            return String.Format("{0}-{1}-{2} {3}-{4}-{5}",
                   time.Day.ToString(),
                   time.Month.ToString(),
                   time.Year.ToString(),
                   time.Hour.ToString(),
                   time.Minute.ToString(),
                   time.Second.ToString());
        }
    }
}
