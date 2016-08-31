using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedCSharp9
{
    class BackChanges
    {
        const string LogFile = @"D:\Log.xml";
        const string BackUp = @"D:\BackUp";
        LogItem[] logItems;
        string folderName;

        public BackChanges(string folderName)
        {
            this.folderName = folderName;
            LogItems logItems = new LogItems();
            Serializer.DeserializeTo(LogFile, ref logItems);
            this.logItems = logItems.logItems;
        }
        
        public void BackAtTime(DateTime time)
        {
            int i = logItems.Length-1;
            while ((logItems[i].time > time) && (i > -1))
            {
                switch (logItems[i].changeType)
                {
                    case WatcherChangeTypes.Created: ReCreate(logItems[i].fullPath);
                        break;
                    case WatcherChangeTypes.Deleted: ReDelete(logItems[i].fullPath, i);
                        break;
                    case WatcherChangeTypes.Renamed: ReRename(logItems[i].fullPath, logItems[i].oldFullPath);
                        break;
                    case WatcherChangeTypes.Changed: ReChange(logItems[i].fullPath, i);
                        break;
                }
                i--;
            }
        }

        private void ReCreate(string fileFullName)
        {
            File.Delete(fileFullName);
        }

        private void ReDelete(string fileFullName, int i)
        {
            File.Copy(SearchPreviousVersion(i), fileFullName);
        }

        private void ReRename(string newFileFullName, string oldFileFullName)
        {
            File.Move(newFileFullName, oldFileFullName);
        }

        private void ReChange(string fileFullName, int i) 
        {
            if (File.Exists(fileFullName))
            {
                File.Delete(fileFullName);
            }
            File.Copy(SearchPreviousVersion(i), fileFullName);
        }

        private string SearchPreviousVersion(int i)
        {
            var fullPath = logItems[i].fullPath;
            for (int j = i - 1; j >= 0; j--)
            {
                if (logItems[j].fullPath == fullPath)
                {
                    if (logItems[j].changeType == WatcherChangeTypes.Renamed)
                    {
                        fullPath = logItems[j].oldFullPath;
                    }
                    else if (logItems[j].changeType == WatcherChangeTypes.Changed || 
                            logItems[j].changeType == WatcherChangeTypes.Created)
                    {
                        return logItems[j].pathBackUp;
                    }
                }
            }

            throw new FileNotFoundException(string.Format("BackUp versia of file {0} not founded!", fullPath));
        }
    }
}
