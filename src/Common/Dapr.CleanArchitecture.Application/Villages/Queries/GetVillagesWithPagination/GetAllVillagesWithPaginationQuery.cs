using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapr.CleanArchitecture.Application.Common.Mapping;
using Dapr.CleanArchitecture.Application.Common.Interfaces;
using Dapr.CleanArchitecture.Application.Common.Models;
using Dapr.CleanArchitecture.Application.Dto;
using Mapster;
using MapsterMapper;

namespace Dapr.CleanArchitecture.Application.Villages.Queries.GetVillagesWithPagination
{
    public class GetAllVillagesWithPaginationQuery : IRequestWrapper<PaginatedList<VillageDto>>
    {
        public int DistrictId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetAllVillagesWithPaginationQueryHandler : IRequestHandlerWrapper<GetAllVillagesWithPaginationQuery, PaginatedList<VillageDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllVillagesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<PaginatedList<VillageDto>>> Handle(GetAllVillagesWithPaginationQuery request, CancellationToken cancellationToken)
        {
            PaginatedList<VillageDto> list = await _context.Villages
                .Where(x => x.DistrictId == request.DistrictId)
                .OrderBy(o => o.Name)
                .ProjectToType<VillageDto>(_mapper.Config)
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            return list.Items.Any() ? ServiceResult.Success(list) : ServiceResult.Failed<PaginatedList<VillageDto>>(ServiceError.NotFount);
        }
    }
}
