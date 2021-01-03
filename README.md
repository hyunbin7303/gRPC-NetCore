# gRPC-NetCore


## GRPC remote procedure calls and HTTP APIs comparison.

### HTTP APIs
* Content first (URL, Http Method, JSON)
* Content is for humans
* Emphasises HTTP       
==> Performance developer productivity


### GRPC
* Contract first (Proto file)
* contract is for humans
* Hides remoting complexity          
==> Widest audience ease of getting started.



### Description
* gRPC services need a service contract usually defined using the Protocol Buffer Language in proto files.


### GRPC Performance.
Http/2 multiplexing
* Send multiple requests and responses in parallel over a single TCP Connection.
* Avoid Head-of-line blocking
* Reduce latency and improve network utlization.



http2 works under the hood.
* Single TCP connection carries multiple bidrectional streams.
* Each stream has a unique ID and caries multiple bidrectional messages.
* Each message(request/response) is broken down into multiple binary frames.
* Frame is the smallest unit carries different types of data such as Headers, settings, priority, data.
* Frames from different streams are interleaved and then reassembled on the other side.





### Things to remember.
* A gPRC client should use the same connection-level seecurity as the called service. So please use client cerficate authentication over TLS. 




### Reference
* https://docs.microsoft.com/en-us/aspnet/core/grpc/client?view=aspnetcore-5.0
* https://auth0.com/blog/implementing-microservices-grpc-dotnet-core-3/
* https://medium.com/aspnetrun/using-grpc-in-microservices-for-building-a-high-performance-interservice-communication-with-net-5-11f3e5fa0e9d
