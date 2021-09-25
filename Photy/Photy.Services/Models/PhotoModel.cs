using System;

namespace Photy.Services.Models
{
    public class PhotoModel
    {
        public ExifData ExifData { get; set; }
        
        public IptcData IptcData { get; set; }
    }
}