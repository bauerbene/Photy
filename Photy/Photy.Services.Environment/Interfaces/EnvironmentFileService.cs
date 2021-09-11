using System.IO;
using System.Threading.Tasks;
using Photy.Services.Environment.Implementations;

namespace Photy.Services.Environment.Interfaces
{
    public class EnvironmentFileService : IEnvironmentFileService
    {
        public FileInfo GetFile(string file)
        {
            throw new System.NotImplementedException();
        }

        public string[] GetFiles(string directory)
        {
            throw new System.NotImplementedException();
        }

        public bool CheckIfExists(string filePath)
        {
            throw new System.NotImplementedException();
        }

        public void Move(string srcFilePath, string destFilePath)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(string filePath)
        {
            throw new System.NotImplementedException();
        }

        public Task WriteTextAsync(string filePath, string text)
        {
            throw new System.NotImplementedException();
        }

        public Task WriteBytesAsync(string filePath, byte[] bytes)
        {
            throw new System.NotImplementedException();
        }

        public void Create(string filePath)
        {
            throw new System.NotImplementedException();
        }

        public Stream OpenRead(string filePath)
        {
            throw new System.NotImplementedException();
        }

        public Stream OpenWrite(string filePath)
        {
            throw new System.NotImplementedException();
        }
    }
}