using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SimpleRotator.Tools
{
    public interface FileIO
    {
        string ReadAllText(string directory, string filePath);
        IList<string> GetFiles(string directory);
        IList<string> GetDirs(string directory);
        string GetFolderName(string directory);
    }

    public class DiskIO : FileIO
    {
        public string ReadAllText(string directory, string filePath)
        {
            return File.ReadAllText(Path.Combine(directory,filePath));
        }

        public IList<string> GetFiles(string dirPath)
        {
            return Directory.GetFiles(dirPath).ToList();
        }

        public IList<string> GetDirs(string dirPath)
        {
            return Directory.GetDirectories(dirPath).ToList();
        }

        public string GetFolderName(string directory)
        {
            return new DirectoryInfo(directory).Name;
        }
    }
}