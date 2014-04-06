using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRotatorTests.TestTools
{
    public class DiskIO
    {
        public static string GetTempFolder()
        {
            var tmpDir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tmpDir);
            return tmpDir;
        }

        public static string WriteTextFileToTempFolder(string fileName, string fileContents)
        {
            var tmpDir = GetTempFolder();
            
            var tmpFile = Path.Combine(tmpDir, fileName);

            File.WriteAllText(tmpFile, fileContents);

            return tmpFile;
        }
    }
}