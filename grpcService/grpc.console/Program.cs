using grpc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;

namespace grpc.console
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<EShoppingContext>()
                .UseSqlite("Filename=../../MyLocalShoppingmall.db")
                .Options;


        }
    }
}
