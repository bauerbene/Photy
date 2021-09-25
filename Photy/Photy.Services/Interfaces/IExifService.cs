using ImageMagick;
using Photy.Services.Models;

namespace Photy.Services.Interfaces
{
    public interface IExifService
    {
        ExifData GetExifData(MagickImage image);
    }
}