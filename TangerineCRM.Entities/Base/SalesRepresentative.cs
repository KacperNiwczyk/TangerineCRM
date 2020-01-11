using TangerineCRM.Core.Entities;

namespace TangerineCRM.Entities.Base
{
    public class SalesRepresentative : IEntity
    {
        public int SalesRepresentativeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
