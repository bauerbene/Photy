using System.Collections.Generic;
using ImageMagick;
using Photy.Services.Models;
using static System.String;

namespace Photy.Services.Interfaces
{
    public interface IIptcService
    {
        void SetIptcData(MagickImage image, IptcData iptcData, string path);
        
        IptcData GetIptcData(MagickImage image);
    }
}