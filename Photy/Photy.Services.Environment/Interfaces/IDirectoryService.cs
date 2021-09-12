using System.Collections.Generic;
using System.IO;

namespace Photy.Services.Environment.Interfaces
{
    public interface IEnvironmentDirectoryService
    {
        void CreateDirectory(string directory);
        
        IEnumerable<string> EnumerateFilesRecursively(string directory);

        IEnumerable<string> EnumerateDirectoriesRecursively(string directory);

        IEnumerable<string> EnumerateFileSystemEntriesRecursively(string directory);

        DirectoryInfo GetDirectory(string directory);

        string[] GetDirectories(string directory);

        bool CheckIfExists(string directory);

        string GetCurrentDirectory();

        void Move(string srcDirectory, string destDirectory);

        void Copy(string srcDirectory, string destDirectory, bool recursive);

        void Delete(string path, bool recursive);
    }
}