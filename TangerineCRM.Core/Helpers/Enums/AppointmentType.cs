using System.ComponentModel;

namespace TangerineCRM.Core.Helpers.Enums
{
    public enum AppointmentType
    {
        [Description("Sprzedaż")]
        SALE,
        [Description("Zakup")]
        BUY,
        [Description("Informacyjne")]
        INFO
    }


}
