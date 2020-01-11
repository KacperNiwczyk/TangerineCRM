using TangerineCRM.Core.Entities;

namespace TangerineCRM.Entities.Base
{
    public class Store : IEntity
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Postcode { get; set; }

        public string Telephone { get; set; }
        public virtual int ContractorID { get; set; }
        public virtual Contractor Contractor { get; set; }
    }
}
