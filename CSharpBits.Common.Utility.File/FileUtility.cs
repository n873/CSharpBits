using System;
using System.Collections.Generic;
using System.IO;

namespace CSharpBits.Common.Utility.File
{
    public static class FileUtility
    {
        public static void EnsureDirectoryExists(string filePath)
        {
            try
            {
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
            }
            catch (Exception) { throw; }
        }

        public static void CreateTextFile(string directoryPath, string fileName, string text)
        {
            try
            {
                System.IO.File.WriteAllText(directoryPath + $"\\{fileName}.txt", text);
            }
            catch (Exception) { throw; }
        }

        public static bool CheckIfFileExists(string fileName, string downloadDirectory)
        {
            try
            {
                return System.IO.File.Exists($"{downloadDirectory}\\{fileName}");
            }
            catch (Exception) { throw; }
        }

        public static IEnumerable<string> GetFileNames(string fileName, string filePath)
        {
            try
            {
                var files = Directory.GetFiles(filePath, $"{fileName}*.*");
                var fileNames = new List<string>();
                fileNames.AddRange(files);
                return fileNames;
            }

            catch (Exception ex) { throw ex; }
        }
    }
}
