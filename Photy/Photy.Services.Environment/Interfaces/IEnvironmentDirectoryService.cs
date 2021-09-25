using System.Collections.Generic;
using System.IO;

namespace Photy.Services.Environment.Interfaces
{
    public interface IEnvironmentDirectoryService
    {
        /// <summary>
        ///     Create a new Directory if it not already exists at the specified location.
        /// </summary>
        ///
        /// <param name="directory">
        ///     The full path of the new directory.
        /// </param>
        void CreateDirectory(string directory);
        
        /// <summary>
        ///     Get full path of all Files, which are contained in the given directory and all subdirectories.
        /// </summary>
        /// 
        /// <param name="directory">
        ///     Full path of the starting point directory.
        /// </param>
        ///
        /// <returns>
        ///     Full path of all files in the specified directory.
        /// </returns>
        IEnumerable<string> EnumerateAllFilesRecursively(string directory);

        /// <summary>
        ///     Get full path of all Files of specified type, which are contained in the given directory and all
        ///     subdirectories.
        /// </summary>
        ///
        /// <param name="directory">
        ///     Full path of the starting point directory
        /// </param>
        /// <param name="types">
        ///     The file types which should be returned (e.g. "png", "jpg").
        /// </param>
        ///
        /// <returns>Full path of all files in the specified directory.</returns>
        IEnumerable<string> EnumerateFilesRecursivelyByTypes(string directory, IEnumerable<string> types);

        /// <summary>
        ///     Get full path of all directories, which are contained in the given directory and all subdirectories.
        /// </summary>
        /// 
        /// <param name="directory">
        ///     Full path of the starting point directory.
        /// </param>
        /// 
        /// <returns>
        ///     Full path of all directories in the specified directory.
        /// </returns>
        IEnumerable<string> EnumerateDirectoriesRecursively(string directory);

        /// <summary>
        ///     Get full path of all FileSystemEntries (e.g. files and folders), which are contained in the given directory
        ///     and all subdirectories.
        /// </summary>
        /// 
        /// <param name="directory">
        ///     Absolute path of the starting point directory.
        /// </param>
        /// 
        /// <returns>
        ///     Absolute path of all FileSystemEntries in the specified directory.
        /// </returns>
        IEnumerable<string> EnumerateFileSystemEntriesRecursively(string directory);

        /// <summary>
        /// Returns the <see cref="DirectoryInfo"/> for a given directory.
        /// </summary>
        ///
        /// <param name="directory">
        ///     Absolute path of the directory, which is requested.
        /// </param>
        ///
        /// <returns>
        ///     The <see cref="DirectoryInfo"/> of the requested directory.
        /// </returns>
        DirectoryInfo GetDirectory(string directory);

        /// <summary>
        /// Returns the names of subdirectories (including their paths) in the specified directory.
        /// </summary>
        /// 
        /// <param name="directory">
        ///     The absolute path to the directory to search.
        /// </param>
        /// 
        /// <returns>
        ///     An array of the full names (including paths) of subdirectories in the specified path, or an empty array
        ///     if no directories are found.
        /// </returns>
        string[] GetDirectories(string directory);

        /// <summary>
        ///     Returns, if a directory exists or not.
        /// </summary>
        /// 
        /// <param name="directory">
        ///     The absolute path of the requested directory.
        /// </param>
        /// 
        /// <returns>
        ///     True, if the directory at the specified location exists, false otherwise.
        /// </returns>
        bool CheckIfExists(string directory);

        /// <summary>
        ///     Returns the current working directory.
        /// </summary>
        /// 
        /// <returns>
        ///     The current working directory.
        /// </returns>
        string GetCurrentDirectory();

        /// <summary>
        ///     Move a directory and all its content to a new location.
        /// </summary>
        /// 
        /// <param name="srcDirectory">
        ///     The absolute path of the directory to move.
        /// </param>
        /// 
        /// <param name="destDirectory">
        ///     The absolute path of the new directory.
        /// </param>
        void Move(string srcDirectory, string destDirectory);

        /// <summary>
        ///     Copy a to a new location. If the new directory does not exist, it is created
        /// </summary>
        /// 
        /// <param name="srcDirectory">
        ///     The absolute path of the directory to copy.
        /// </param>
        /// <param name="destDirectory">
        ///     The absolute path of the new directory (it is created if it does not exist).
        /// </param>
        /// <param name="recursive">
        ///     If true, all subdirectories of the specified directory are copied as well, with all their content.
        /// </param>
        void Copy(string srcDirectory, string destDirectory, bool recursive);

        /// <summary>
        ///     Delete a Directory at a specified location.
        /// </summary>
        /// 
        /// <param name="path">
        ///     The absolute path of the directory, which should be deleted.
        /// </param>
        /// <param name="recursive">
        ///     If true, all subdirectories are deleted as well.
        /// </param>
        void Delete(string path, bool recursive);
    }
}