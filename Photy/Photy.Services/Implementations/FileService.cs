using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Photy.Services.Environment.Interfaces;
using Photy.Services.Interfaces;
using Photy.Services.Models;
using Photy.Services.Models.Enums;

namespace Photy.Services.Implementations
{
    public class FileService : IFileService
    {
        private readonly IPathService _pathService;
        private readonly IEnvironmentFileService _environmentFileService;
        private readonly ILogger<FileService> _logger;

        public FileService(
            IPathService pathService,
            IEnvironmentFileService environmentFileService,
            ILogger<FileService> logger)
        {
            _pathService = pathService;
            _environmentFileService = environmentFileService;
            _logger = logger;
        }

        public IReadOnlyList<FileModel> GetFiles(string directory)
        {
            return _environmentFileService
                .GetFiles(directory)
                .Select(CreateFileModelFromFileString)
                .Where(fileModel => fileModel != null)
                .ToArray();
        }

        public IReadOnlyList<FileModel> GetFiles(IEnumerable<string> files)
        {
            return files
                .Select(CreateFileModelFromFileString)
                .Where(fileModel => fileModel != null)
                .ToArray();
        }

        public FileModel GetFile(string file)
        {
            return CreateFileModelFromFileString(file);
        }

        public bool CheckIfExists(string file)
        {
            return _environmentFileService.CheckIfExists(file);
        }

        public async Task<bool> CopyAsync(string source, string destination, CancellationToken cancellationToken, bool overwrite = false)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (CheckIfExists(destination) && !overwrite)
            {
                return false;
            }
            
            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                await using var readStream = _environmentFileService.OpenRead(source);
                await using var writeStream = _environmentFileService.OpenWrite(destination);
                await readStream.CopyToAsync(writeStream, cancellationToken);
            }
            catch (TaskCanceledException)
            {
                _logger.LogInformation(
                    $"Cancelled file copy from {source} to {destination}. Overwrite: {overwrite}"
                );
                throw;
            }
            catch (Exception e)
            {
                _logger.LogError(
                    $"Failed to copy file from {source} to {destination}. Overwrite: {overwrite}. Error: {e}"
                );
                return false;
            }

            return true;
        }

        public bool Remove(string file)
        {
            try
            {
                _environmentFileService.Delete(file);
            }
            catch (Exception e)
            {
                _logger.LogError(
                    $"Failed to remove file {file} with error {e}"
                );
                return false;
            }

            return true;
        }

        public bool Rename(string filePath, string newName)
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

        public void CreateFile(string filePath)
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

        private FileModel CreateFileModelFromFileString(string file)
        {
            try
            {
                var fileInfo = _environmentFileService.GetFile(file);
                var fileModel = new FileModel
                {
                    Name = fileInfo.Name,
                    FullPath = fileInfo.FullName,
                    LastModifiedDateTime = fileInfo.LastWriteTime,
                    LastAccessDateTime = fileInfo.LastAccessTime,
                    CreatedDateTime = fileInfo.CreationTime,
                    SizeBytes = fileInfo.Length,
                    Type = GetFileType(fileInfo)
                };
                return fileModel;
            }
            catch
            {
                return null;
            }
        }

        private static FileType GetFileType(FileInfo fileInfo)
        {
            // TODO do this
            return fileInfo.Extension switch
            {
                "jpg" => FileType.Jpg,
                "png" => FileType.Png,
                _ => FileType.Jpg
            };
        }
    }
}