using System;
using System.Collections.Generic;
using System.Text;

namespace grpc.Domain
{
    [Flags]
    public enum OrderStatus
    {
        New,
        Hold,
        Shipped,
        Delivered,
        Pending,
        Confirmed,
        Close,
        Other,
    }
}
