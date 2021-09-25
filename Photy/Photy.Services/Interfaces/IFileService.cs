using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Photy.Services.Models;

namespace Photy.Services.Interfaces
{
    public interface IFileService
    {
        IReadOnlyList<FileModel> GetFiles(string directory);

        IReadOnlyList<FileModel> GetFiles(IEnumerable<string> files);

        FileModel GetFile(string file);

        bool CheckIfExists(string file);

        Task<bool> CopyAsync(
            string source,
            string destination,
            CancellationToken cancellationToken,
            bool overwrite = false
        );

        bool Rename(string filePath, string newName);

        bool Remove(string file);

        Task WriteTextAsync(string filePath, string text);

        Task WriteBytesAsync(string filePath, byte[] bytes);

        void CreateFile(string filePath);

        Stream OpenRead(string filePath);

        Stream OpenWrite(string filePath);
    }
}