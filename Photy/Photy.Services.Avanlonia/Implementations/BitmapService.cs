using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using ImageMagick;
using Photy.Services.Avanlonia.Interfaces;

namespace Photy.Services.Avanlonia.Implementations
{
    public class BitmapService : IBitmapService
    {
        public Bitmap GetBitmapByPath(string path)
        {
            using var image = new MagickImage(path);
            image.Resize(200, 200);
            MemoryStream tempStream = new();
            image.Write(tempStream);
            tempStream.Position = 0;
            return new Bitmap(tempStream);
        }

        public async Task<Bitmap> GetBitmapByPathAsync(string path)
        {
            return await Task.Run(() =>
            {
                using var image = new MagickImage(path);
                image.Resize(200, 200);
                MemoryStream tempSream = new();
                image.Write(tempSream);
                tempSream.Position = 0;
                return new Bitmap(tempSream);
            });
        }

        public async Task<Bitmap> GetBitmapByPathAsyncTest(string path)
        {
            return await Task.Run(() => GetBitmapByPath(path));
        }

        public IEnumerable<Bitmap> GetBitmapsByPaths(IEnumerable<string> paths)
        {
            List<Bitmap> bitmaps = new();
            foreach (var path in paths)
            {
                bitmaps.Add(GetBitmapByPath(path));
            }

            return bitmaps;
        }
    }
}