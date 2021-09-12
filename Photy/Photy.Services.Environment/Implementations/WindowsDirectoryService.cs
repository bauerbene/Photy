using System.Collections.Generic;
using System.IO;
using Photy.Services.Environment.Interfaces;

namespace Photy.Services.Environment.Implementations
{
    public class WindowsDirectoryService : IDirectoryService
    {
        private readonly IDirectoryService _directoryService;

        public WindowsDirectoryService(IDirectoryService directoryService)
        {
            _directoryService = directoryService;
        }

        public void CreateDirectory(string directory)
        {
            _directoryService.CreateDirectory(directory);
        }

        public IEnumerable<string> EnumerateFilesRecursively(string directory)
        {
            return _directoryService.EnumerateFilesRecursively(PreprocessPath(directory));
        }

        public IEnumerable<string> EnumerateDirectoriesRecursively(string directory)
        {
            return _directoryService.EnumerateDirectoriesRecursively(PreprocessPath(directory));
        }

        public IEnumerable<string> EnumerateFileSystemEntriesRecursively(string directory)
        {
            return _directoryService.EnumerateFileSystemEntriesRecursively(PreprocessPath(directory));
        }

        public DirectoryInfo GetDirectory(string directory)
        {
            return _directoryService.GetDirectory(PreprocessPath(directory));
        }

        public string[] GetDirectories(string directory)
        {
            return _directoryService.GetDirectories(PreprocessPath(directory));
        }

        public bool CheckIfExists(string directory)
        {
            return _directoryService.CheckIfExists(PreprocessPath(directory));
        }

        public string GetCurrentDirectory()
        {
            return _directoryService.GetCurrentDirectory();
        }

        public void Move(string srcDirectory, string destDirectory)
        {
            _directoryService.Move(srcDirectory, destDirectory);
        }

        public void Copy(string srcDirectory, string destDirectory, bool recursive)
        {
            // TODO PreprocessPath necessary ? 
            _directoryService.Copy(srcDirectory, destDirectory, recursive);
        }

        public void Delete(string path, bool recursive)
        {
            _directoryService.Delete(path, recursive);
        }

        private static string PreprocessPath(string directory)
        {
            return directory.EndsWith("\\") ? directory : directory + "\\";
        }
    }
}