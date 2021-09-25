using System;
using ImageMagick;
using Microsoft.Extensions.Logging;
using Photy.Services.Interfaces;
using Photy.Services.Models;
using static System.String;

namespace Photy.Services.Implementations
{
    public class IptcService : IIptcService
    {
        private readonly ILogger<IptcService> _logger;
        private const string Separator = ";";
        
        public IptcService(ILogger<IptcService> logger)
        {
            _logger = logger;
        }

        public void SetIptcData(MagickImage image, IptcData iptcData, string path)
        {
            try
            {
                var iptcProfile = image.GetIptcProfile() ?? new IptcProfile();
                iptcProfile.SetValue(IptcTag.CustomField1, Join(Separator, iptcData.Persons));
                image.SetProfile(iptcProfile);
                // TODO async
                //image.Write(path);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error writing Iptc data. Exception: {e.Message}");
            }
        }

        public IptcData GetIptcData(MagickImage image)
        {
            try
            {
                var iptcProfile = image.GetIptcProfile();
                var personsAsString = iptcProfile?.GetValue(IptcTag.CustomField1)?.ToString();
                var persons = personsAsString?.Split(Separator);
                return new IptcData
                {
                    Persons = persons
                };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error reading iptc data. Exception: {e.Message}");
                return new IptcData();
            }
            
        }
    }
}