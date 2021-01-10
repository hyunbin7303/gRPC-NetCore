using Grpc.Core;
using grpcService;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grpcClient.Tests
{
    class Test
    {
        [TestFixture]
        public class ClientBaseTests
        {
            [Test]
            public void ClientBaseClass_ExplicitSetting_UsesClientBase()
            {
                // Assert
                Assert.True(typeof(Greeter.GreeterClient).IsSubclassOf(typeof(ClientBase)));
            }
        }
    }
}
