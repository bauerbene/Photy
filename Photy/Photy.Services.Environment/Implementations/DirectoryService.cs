using System.Collections.Generic;
using System.IO;
using Photy.Services.Environment.Interfaces;

namespace Photy.Services.Environment.Implementations
{
    public class DirectoryService : IDirectoryService
    {
        public void CreateDirectory(string directory)
        {
            Directory.CreateDirectory(directory);
        }

        public IEnumerable<string> EnumerateFilesRecursively(string directory)
        {
            return Directory.EnumerateFiles(directory, "*.*", SearchOption.AllDirectories);
        }

        public IEnumerable<string> EnumerateDirectoriesRecursively(string directory)
        {
            return Directory.EnumerateDirectories(directory, "*.*", SearchOption.AllDirectories);
        }

        public IEnumerable<string> EnumerateFileSystemEntriesRecursively(string directory)
        {
            return Directory.EnumerateFileSystemEntries(directory, "*.*", SearchOption.AllDirectories);
        }

        public DirectoryInfo GetDirectory(string directory)
        {
            return new DirectoryInfo(directory);
        }

        public string[] GetDirectories(string directory)
        {
            return Directory.GetDirectories(directory);
        }

        public bool CheckIfExists(string directory)
        {
            return Directory.Exists(directory);
        }

        public string GetCurrentDirectory()
        {
            return Directory.GetCurrentDirectory();
        }

        public void Move(string srcDirectory, string destDirectory)
        {
            Directory.Move(srcDirectory, destDirectory);
        }

        public void Copy(string srcDirectory, string destDirectory, bool recursive = true)
        {
            var srcDirectoryInfo = new DirectoryInfo(srcDirectory);

            if (!srcDirectoryInfo.Exists)
            {
                // TODO Throw exception?
                return;
            }
            
            // Create new destination directory if it doesn't exist
            Directory.CreateDirectory(destDirectory);
            
            // Get the files in the directory and copy them to the new location.
            var srcFiles = srcDirectoryInfo.GetFiles();
            foreach (var srcFile in srcFiles)
            {
                var tempPath = Path.Combine(destDirectory, srcFile.Name);
                srcFile.CopyTo(tempPath, false);
            }
            
            // Copy subdirectories
            var subDirectories = srcDirectoryInfo.GetDirectories();
            if (recursive)
            {
                foreach (var subDirectory in subDirectories)
                {
                    var tempPath = Path.Combine(destDirectory, subDirectory.Name);
                    Copy(subDirectory.FullName, tempPath);
                }
            }
        }

        public void Delete(string path, bool recursive)
        {
            Directory.Delete(path, recursive);
        }
    }
}