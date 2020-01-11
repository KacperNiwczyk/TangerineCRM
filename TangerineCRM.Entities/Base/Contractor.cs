using TangerineCRM.Core.Entities;

namespace TangerineCRM.Entities.Base
{
    public class Contractor : IEntity
    {
        public int ContractorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public decimal IndividualPricePercentage { get; set; }
        public bool IsContracted { get; set; }
    }
}
