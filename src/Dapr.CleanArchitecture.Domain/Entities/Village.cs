using Dapr.CleanArchitecture.Domain.Common;

namespace Dapr.CleanArchitecture.Domain.Entities
{
    public class Village : AuditableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DistrictId { get; set; }
        public District District { get; set; }

    }
}
