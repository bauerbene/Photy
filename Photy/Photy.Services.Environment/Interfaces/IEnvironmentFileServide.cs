using System.IO;
using System.Threading.Tasks;

namespace Photy.Services.Environment.Interfaces
{
    public interface IEnvironmentFileService
    {
        /// <summary>
        ///     Get the <see cref="FileInfo"/> of the file at the specified location.
        /// </summary>
        /// 
        /// <param name="file">
        ///     The absolute path of the requested file.
        /// </param>
        /// 
        /// <returns>The <see cref="FileInfo"/> of the file at the specified location.</returns>
        FileInfo GetFile(string file);

        /// <summary>
        ///     Get all files, which are contained in the specified directory.
        /// </summary>
        /// 
        /// <param name="directory">
        ///     The absolute path of the directory, which contains the files.
        /// </param>
        ///
        /// <returns>
        ///     The absolute paths of all files, contained in the specified directory.
        /// </returns>
        string[] GetFiles(string directory);

        /// <summary>
        ///     Check if a file at a given location exists.
        /// </summary>
        /// 
        /// <param name="filePath">
        ///     The absolute path of the requested file.
        /// </param>
        /// <returns>
        ///     True, if the file at the specified location exists, false otherwise.
        /// </returns>
        bool CheckIfExists(string filePath);

        /// <summary>
        ///     Move a file from a location to another.
        /// </summary>
        /// 
        /// <param name="srcFilePath">
        ///     The absolute path of the source location.
        /// </param>
        /// <param name="destFilePath">
        ///     The absolute path of the destination location.
        /// </param>
        void Move(string srcFilePath, string destFilePath);

        /// <summary>
        ///     Delete a file at the specified location.
        /// </summary>
        /// 
        /// <param name="filePath">
        ///     The absolute path of the file, which should be deleted.
        /// </param>
        void Delete(string filePath);

        /// <summary>
        ///     Asynchronously creates a new file, writes the specified string to the file, and then closes the file.
        ///     If the target file already exists, it is overwritten.
        /// </summary>
        /// 
        /// <param name="filePath">
        ///     The absolute path of the file, to write to.
        /// </param>
        /// <param name="text">
        ///     The content, which should be written to the file.
        /// </param>
        Task WriteTextAsync(string filePath, string text);

        /// <summary>
        ///     Asynchronously creates a new file, writes the specified byte array to the file, and then closes the
        ///     file. If the target file already exists, it is overwritten.
        /// </summary>
        /// 
        /// <param name="filePath">
        ///     The absolute path of the file, to write to.
        /// </param>
        /// <param name="bytes">
        ///     The content, which should be written to the file.
        /// </param>
        Task WriteBytesAsync(string filePath, byte[] bytes);

        /// <summary>
        ///     Create a new file at the specific location.
        /// </summary>
        /// 
        /// <param name="filePath">
        ///     The absolute path of the file, which should be created.
        /// </param>
        void Create(string filePath);

        /// <summary>
        ///     Opens an existing file for reading.
        /// </summary>
        /// 
        /// <param name="filePath">
        ///     The absolute path of the file to be opened for reading.
        /// </param>
        /// 
        /// <returns>
        ///     A read-only <see cref="FileStream"/> on the specified path.
        /// </returns>
        Stream OpenRead(string filePath);

        /// <summary>
        ///     Opens an existing file or creates a new file for writing.
        /// </summary>
        /// 
        /// <param name="filePath">
        ///     The absolute path of the file to be opened for writing
        /// </param>
        /// 
        /// <returns>
        ///     An unshared <see cref="FileStream"/> object on the specified path with write access.
        /// </returns>
        Stream OpenWrite(string filePath);
    }
}