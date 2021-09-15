using System.Collections.Generic;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;

namespace Photy.Services.Avanlonia.Interfaces
{
    public interface IBitmapService
    {
        Bitmap GetBitmapByPath(string path);

        Task<Bitmap> GetBitmapByPathAsync(string path);

        IEnumerable<Bitmap> GetBitmapsByPaths(IEnumerable<string> paths);
    }
}