using System.Globalization;
using Dapr.CleanArchitecture.Application.Dto;
using CsvHelper.Configuration;

namespace Dapr.CleanArchitecture.Infrastructure.Files.Maps
{
    public sealed class DistrictMap : ClassMap<DistrictDto>
    {
        public DistrictMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.Villages).ConvertUsing(_ => "");
        }
    }
}
