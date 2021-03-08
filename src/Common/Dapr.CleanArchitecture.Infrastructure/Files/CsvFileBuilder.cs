using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Dapr.CleanArchitecture.Application.Common.Interfaces;
using Dapr.CleanArchitecture.Application.Dto;
using CsvHelper;
using Dapr.CleanArchitecture.Infrastructure.Files.Maps;

namespace Dapr.CleanArchitecture.Infrastructure.Files
{
    public class CsvFileBuilder : ICsvFileBuilder
    {
        public byte[] BuildDistrictsFile(IEnumerable<DistrictDto> cities)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream, Encoding.UTF8))
            {
                using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

                csvWriter.Configuration.RegisterClassMap<DistrictMap>();
                csvWriter.WriteRecords(cities);
            }

            return memoryStream.ToArray();
        }
    }
}
