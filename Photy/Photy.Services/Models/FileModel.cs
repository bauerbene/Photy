using System;
using Photy.Services.Models.Enums;

namespace Photy.Services.Models
{
    public class FileModel
    {
        public string Name { get; set; }
        
        public string FullPath { get; set; }
        
        public DateTime CreatedDateTime { get; set; }
        
        public DateTime LastModifiedDateTime { get; set; }
        
        public DateTime LastAccessDateTime { get; set; }
        
        public long SizeBytes { get; set; }
        
        public FileType Type { get; set; }
    }
}