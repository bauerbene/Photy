using System;
using ImageMagick;
using Microsoft.Extensions.Logging;
using Photy.Services.Interfaces;
using Photy.Services.Models;

namespace Photy.Services.Implementations
{
    public class ExifService : IExifService
    {
        private readonly ILogger<ExifService> _logger;
        private const string DateTimePattern = "yyyy:MM:dd HH:mm:ss";
        
        public ExifService(ILogger<ExifService> logger)
        {
            _logger = logger;
        }

        public ExifData GetExifData(MagickImage image)
        {
            try
            {
                var exifProfile = image.GetExifProfile();
                var dateOfRecordingAsString = exifProfile?.GetValue(ExifTag.DateTime)?.ToString();
                if (dateOfRecordingAsString == null)
                {
                    throw new Exception("TODO");
                }

                var dateOfRecording =
                    DateTime.ParseExact(dateOfRecordingAsString, DateTimePattern, null);

                return new ExifData
                {
                    DateOfRecording = dateOfRecording
                };
            }
            catch (Exception e)
            {
                _logger.LogError($"Could not load exif data. Exception: {e.Message}");
                return new ExifData();
            }

            /*var newIptcProfile = new IptcProfile();
            newIptcProfile.SetValue(IptcTag.CustomField1, "test");
            image.SetProfile(newIptcProfile);
            image.Write(path);
            var iptcProfile = image.GetIptcProfile();
            var bla = iptcProfile.GetValue(IptcTag.CustomField1);
*/
        }
    }
}