using System.IO;
using System.Threading.Tasks;

namespace Photy.Services.Environment.Interfaces
{
    public interface IFileService
    {
        FileInfo GetFile(string file);

        string[] GetFiles(string directory);

        bool CheckIfExists(string filePath);

        void Move(string srcFilePath, string destFilePath);

        void Delete(string filePath);

        Task WriteTextAsync(string filePath, string text);

        Task WriteBytesAsync(string filePath, byte[] bytes);

        void Create(string filePath);

        Stream OpenRead(string filePath);

        Stream OpenWrite(string filePath);
    }
}