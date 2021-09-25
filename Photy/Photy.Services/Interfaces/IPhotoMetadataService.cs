using Photy.Services.Models;

namespace Photy.Services.Interfaces
{
    public interface IPhotoMetadataService
    {
        PhotoModel ReadMetadata(string path);
    }
}