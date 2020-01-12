using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangerineCRM.Core.Helpers.Enums
{
    public enum UserType
    {
        [Description("Administrator")]
        ADMIN,
        [Description("Zwykły")]
        NORMAL
    }
}
