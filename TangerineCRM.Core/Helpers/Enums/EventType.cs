using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangerineCRM.Core.Helpers.Enums
{
    public enum EventType
    {

        [Description("Email")]
        EMAIL,
        [Description("Rozmowa telefoniczna")]
        CALL,
        [Description("Wizyta")]
        VISIT,
        [Description("Wideo konferencja")]
        VIDEOCONFERENCE
    }
}
