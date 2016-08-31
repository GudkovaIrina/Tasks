using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedCSharp9
{
    class WatchingByFolder
    {
        const string LogFile = @"D:\Log.xml";
        const string BackUp = @"D:\BackUp";
        string folderName;
        private FileSystemWatcher watcher;
        private List<LogItem> logItems;
        public WatchingByFolder(string folderName)
        {
            this.folderName = folderName;
            watcher = new FileSystemWatcher(folderName, "*.txt");
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
           | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.IncludeSubdirectories = true;
            logItems = new List<LogItem>();

            Directory.CreateDirectory(BackUp);
            CopyStartState(folderName);

            watcher.Changed += new FileSystemEventHandler(AddedToLogAndBackUp);
            watcher.Created += new FileSystemEventHandler(AddedToLogAndBackUp);
            watcher.Deleted += new FileSystemEventHandler(AddedToLogAndBackUp);
            watcher.Renamed += new RenamedEventHandler(AddedToLogAndBackUp); ;
        }

        private void AddedToLogAndBackUp(object sender, FileSystemEventArgs e)
        {
            LogItem logItem = new LogItem(e);
            logItems.Add(logItem);
            if ((e.ChangeType == WatcherChangeTypes.Changed) || (e.ChangeType == WatcherChangeTypes.Created))
            {
                BackUped(logItem);
            }
        }

        private void BackUped(LogItem logItem)
        {
            Directory.CreateDirectory(logItem.pathBackUp.Remove(logItem.pathBackUp.LastIndexOf(@"\") + 1));
            //если возникают два одновременных изменения
            if ((logItem.changeType == WatcherChangeTypes.Changed) && (File.Exists(logItem.pathBackUp))) 
            {
                File.Delete(logItem.pathBackUp);
            }
            File.Copy(logItem.fullPath, logItem.pathBackUp);
        }

        private void CopyStartState(string folder)
        {
            foreach (var file in Directory.EnumerateFiles(folder))
            {
                FileSystemEventArgs e = new FileSystemEventArgs(WatcherChangeTypes.Created, folder, file.Substring(file.LastIndexOf(@"\") + 1));
                AddedToLogAndBackUp(this, e);
            }
   
            foreach (var subfolder in Directory.EnumerateDirectories(folder))
            {
                CopyStartState(subfolder);
            }
        }
        
        public void StartWatching()
        {
            watcher.EnableRaisingEvents = true;
        }

        public void PauseWatching()
        {
            this.watcher.EnableRaisingEvents = false;
        }

        public void StopWatching()
        {
            this.watcher.EnableRaisingEvents = false;
            Serializer.SerializeTo(LogFile, new LogItems(logItems));
        }

        public bool IfRunWatching()
        {
            return this.watcher.EnableRaisingEvents;
        }
    }
}
