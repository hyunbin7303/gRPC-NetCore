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



