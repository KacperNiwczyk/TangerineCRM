using TangerineCRM.Core.Entities;

namespace TangerineCRM.Entities.Base
{
    public class Store : IEntity
    {
        public int StoreId { get; set; }

        public virtual Address Address { get; set; }

        public virtual Contractor Contractor { get; set; }
    }
}
