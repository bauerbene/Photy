using System;
using ImageMagick;
using Microsoft.Extensions.Logging;
using Photy.Services.Interfaces;
using Photy.Services.Models;

namespace Photy.Services.Implementations
{
    public class PhotoMetadataService : IPhotoMetadataService
    {
        private readonly IExifService _exifService;
        private readonly IIptcService _iptcService;
        private readonly ILogger<PhotoMetadataService> _logger;

        public PhotoMetadataService(
            IExifService exifService, 
            IIptcService iptcService,
            ILogger<PhotoMetadataService> logger)
        {
            _exifService = exifService;
            _iptcService = iptcService;
            _logger = logger;
        }

        public PhotoModel ReadMetadata(string path)
        {
            using var image = new MagickImage(path);
            var exifData = _exifService.GetExifData(image);
            var iptcData = _iptcService.GetIptcData(image);

            return new PhotoModel
            {
                ExifData = exifData,
                IptcData = iptcData
            };
        }

        public void WriteMetadata(PhotoModel photoModel, string path)
        {
            try
            {
                using var image = new MagickImage(path);
                _iptcService.SetIptcData(image, photoModel.IptcData, path);
                // TODO write async
                image.Write(path);
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to write Metadata. Exception {e.Message}");
            }
        }
    }
}