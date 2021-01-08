//Source from : https://thecloudblog.net/post/integration-tests-for-grpc-services-in-asp.net-core/


using System;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Core.Testing;
using NUnit.Framework;
using grpc.Domain;
using grpcService;
using Microsoft.AspNetCore.Mvc.Testing;
using Grpc.Net.Client;
using System.Net.Http;

namespace grpcService.Test
{
    public sealed class TestServerFixture : IDisposable
    {
        private readonly WebApplicationFactory<Startup> _factory;
        public GrpcChannel GrpcChannel { get; }
        public TestServerFixture()
        {
            _factory = new WebApplicationFactory<Startup>();
            var client = _factory.CreateDefaultClient(new ResponseVersionHandler());
            GrpcChannel = GrpcChannel.ForAddress(client.BaseAddress, new GrpcChannelOptions
            {
                HttpClient = client
            });
        }
        public void Dispose()
        {
            _factory.Dispose();
        }

        private class ResponseVersionHandler : DelegatingHandler
        {
            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                CancellationToken cancellationToken)
            {
                var response = await base.SendAsync(request, cancellationToken);
                response.Version = request.Version;
                return response;
            }
        }
    }



}