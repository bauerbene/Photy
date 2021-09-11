using System.Collections.Generic;
using System.IO;
using Photy.Services.Environment.Interfaces;

namespace Photy.Services.Environment.Implementations
{
    public class EnvironmentDirectoryServiceWindowsDecorator : IEnvironmentDirectoryService
    {
        private readonly IEnvironmentDirectoryService _environmentDirectoryService;

        public EnvironmentDirectoryServiceWindowsDecorator(IEnvironmentDirectoryService environmentDirectoryService)
        {
            _environmentDirectoryService = environmentDirectoryService;
        }

        public void CreateDirectory(string directory)
        {
            _environmentDirectoryService.CreateDirectory(directory);
        }

        public IEnumerable<string> EnumerateFilesRecursively(string directory)
        {
            return _environmentDirectoryService.EnumerateFilesRecursively(PreprocessPath(directory));
        }

        public IEnumerable<string> EnumerateDirectoriesRecursively(string directory)
        {
            return _environmentDirectoryService.EnumerateDirectoriesRecursively(PreprocessPath(directory));
        }

        public IEnumerable<string> EnumerateFileSystemEntriesRecursively(string directory)
        {
            return _environmentDirectoryService.EnumerateFileSystemEntriesRecursively(PreprocessPath(directory));
        }

        public DirectoryInfo GetDirectory(string directory)
        {
            return _environmentDirectoryService.GetDirectory(PreprocessPath(directory));
        }

        public string[] GetDirectories(string directory)
        {
            return _environmentDirectoryService.GetDirectories(PreprocessPath(directory));
        }

        public bool CheckIfExists(string directory)
        {
            return _environmentDirectoryService.CheckIfExists(PreprocessPath(directory));
        }

        public string GetCurrentDirectory()
        {
            return _environmentDirectoryService.GetCurrentDirectory();
        }

        public void Move(string srcDirectory, string destDirectory)
        {
            _environmentDirectoryService.Move(srcDirectory, destDirectory);
        }

        public void Copy(string srcDirectory, string destDirectory, bool recursive)
        {
            // TODO PreprocessPath necessary ? 
            _environmentDirectoryService.Copy(srcDirectory, destDirectory, recursive);
        }

        public void Delete(string path, bool recursive)
        {
            _environmentDirectoryService.Delete(path, recursive);
        }

        private static string PreprocessPath(string directory)
        {
            return directory.EndsWith("\\") ? directory : directory + "\\";
        }
    }
}