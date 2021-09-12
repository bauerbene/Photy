using System.IO;
using System.Threading.Tasks;
using Photy.Services.Environment.Interfaces;

namespace Photy.Services.Environment.Implementations
{
    public class WindowsFileService : IFileService
    {
        private readonly IFileService _fileService;

        public WindowsFileService(IFileService fileService)
        {
            _fileService = fileService;
        }

        public FileInfo GetFile(string file)
        {
            return _fileService.GetFile(file);
        }

        public string[] GetFiles(string directory)
        {
            return _fileService.GetFiles(PreprocessPath(directory));
        }

        public bool CheckIfExists(string filePath)
        {
            return _fileService.CheckIfExists(filePath);
        }

        public void Move(string srcFilePath, string destFilePath)
        {
            _fileService.Move(srcFilePath, destFilePath);
        }

        public void Delete(string filePath)
        {
            _fileService.Delete(filePath);
        }

        public async Task WriteTextAsync(string filePath, string text)
        {
            await _fileService.WriteTextAsync(filePath, text);
        }

        public async Task WriteBytesAsync(string filePath, byte[] bytes)
        {
            await _fileService.WriteBytesAsync(filePath, bytes);
        }

        public void Create(string filePath)
        {
            _fileService.Create(filePath);
        }

        public Stream OpenRead(string filePath)
        {
            return _fileService.OpenRead(filePath);
        }

        public Stream OpenWrite(string filePath)
        {
            return _fileService.OpenWrite(filePath);
        }

        private static string PreprocessPath(string path)
        {
            return path.EndsWith("\\") ? path : path + "\\";
        }
    }
}