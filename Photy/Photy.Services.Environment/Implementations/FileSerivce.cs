using System.IO;
using System.Threading.Tasks;
using Photy.Services.Environment.Interfaces;

namespace Photy.Services.Environment.Implementations
{
    public class FileService : IFileService
    {
        public FileInfo GetFile(string file)
        {
            return new FileInfo(file);
        }

        public string[] GetFiles(string directory)
        {
            return Directory.GetFiles(directory);
        }

        public bool CheckIfExists(string filePath)
        {
            return File.Exists(filePath);
        }

        public void Move(string srcFilePath, string destFilePath)
        {
            // TODO as task ? 
            // Task.Run(() => File.Move(srcFilePath, destFilePath));
            File.Move(srcFilePath, destFilePath);
        }

        public void Delete(string filePath)
        {
            File.Delete(filePath);
        }

        public async Task WriteTextAsync(string filePath, string text)
        {
            await File.WriteAllTextAsync(filePath, text);
        }
        
        public async Task WriteBytesAsync(string filePath, byte[] bytes)
        {
            await File.WriteAllBytesAsync(filePath, bytes);
        }

        public void Create(string filePath)
        {
            // TODO DisposeAsync() ?
            File.Create(filePath).Dispose();
        }

        public Stream OpenRead(string filePath)
        {
            return File.OpenRead(filePath);
        }

        public Stream OpenWrite(string filePath)
        {
            return File.OpenWrite(filePath);
        }
    }
}