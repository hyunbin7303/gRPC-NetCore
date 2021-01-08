using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace grpcService.Infrastructure
{

    internal interface ISystemClock
    {
        DateTime UtcNow { get; }
    }
}
