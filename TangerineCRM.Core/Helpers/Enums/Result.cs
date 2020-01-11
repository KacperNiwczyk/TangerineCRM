using System.ComponentModel;

namespace TangerineCRM.Core.Helpers.Enums
{
    public enum Result
    {
        [Description("Pozytywny")]
        SUCCESS,
        [Description("Negatywny")]
        FAIL,
        [Description("Nieokreślony")]
        INDEFINITE
    }
}
