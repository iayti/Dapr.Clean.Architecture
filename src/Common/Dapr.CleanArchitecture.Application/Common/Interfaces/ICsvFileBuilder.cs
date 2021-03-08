using System.Collections.Generic;
using Dapr.CleanArchitecture.Application.Dto;

namespace Dapr.CleanArchitecture.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildDistrictsFile(IEnumerable<DistrictDto> districts);
    }
}
