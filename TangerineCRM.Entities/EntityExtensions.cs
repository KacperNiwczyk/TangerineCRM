using TangerineCRM.Entities.Base;

namespace TangerineCRM.Entities
{
    public static class EntityExtensions
    {
        public static string GetFullContractorName(this Contractor contractor)
        {
            return string.Concat('[', contractor.ContractorId, ']', " ", contractor.FirstName, " ", contractor.LastName);
        }


        public static string GetRepresentativeFullName(this SalesRepresentative representative)
        {
            return string.Concat('[', representative.SalesRepresentativeId, ']', " ", representative.FirstName, " ", representative.LastName);
        }
    }
}
