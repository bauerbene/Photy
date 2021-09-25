using System.IO;
using System.Threading.Tasks;
using Photy.Services.Environment.Interfaces;

namespace Photy.Services.Environment.Implementations
{
    public class EnvironmentWindowsFileService : IEnvironmentFileService
    {
        private readonly IEnvironmentFileService _environmentFileService;

        public EnvironmentWindowsFileService(IEnvironmentFileService environmentFileService)
        {
            _environmentFileService = environmentFileService;
        }

        public FileInfo GetFile(string file)
        {
            return _environmentFileService.GetFile(file);
        }

        public string[] GetFiles(string directory)
        {
            return _environmentFileService.GetFiles(PreprocessPath(directory));
        }

        public bool CheckIfExists(string filePath)
        {
            return _environmentFileService.CheckIfExists(filePath);
        }

        public void Move(string srcFilePath, string destFilePath)
        {
            _environmentFileService.Move(srcFilePath, destFilePath);
        }

        public void Delete(string filePath)
        {
            _environmentFileService.Delete(filePath);
        }

        public async Task WriteTextAsync(string filePath, string text)
        {
            await _environmentFileService.WriteTextAsync(filePath, text);
        }

        public async Task WriteBytesAsync(string filePath, byte[] bytes)
        {
            await _environmentFileService.WriteBytesAsync(filePath, bytes);
        }

        public void Create(string filePath)
        {
            _environmentFileService.Create(filePath);
        }

        public Stream OpenRead(string filePath)
        {
            return _environmentFileService.OpenRead(filePath);
        }

        public Stream OpenWrite(string filePath)
        {
            return _environmentFileService.OpenWrite(filePath);
        }

        private static string PreprocessPath(string path)
        {
            return path.EndsWith("\\") ? path : path + "\\";
        }
    }
}