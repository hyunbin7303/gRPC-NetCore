using System;
using System.Collections.Generic;
using System.Text;

namespace grpc.Domain
{
    [Flags]
    public enum LoginStatus
    {
        Logout,
        Login,
        Pending,
        Banned,
        Other
    }
}
