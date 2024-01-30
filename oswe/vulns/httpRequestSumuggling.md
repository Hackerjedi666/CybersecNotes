# HTTP REQUEST SMUGGLING

## Components of Modern Web Applications



Modern web applications are no longer straightforward, monolithic structures. They are composed of different components that work with each other. Below are some of the components that a modern web application usually consists of:

* Front-end server: This is usually the reverse proxy or load balancer that forwards the requests to the back-end.
* Back-end server: This server-side component processes user requests, interacts with databases, and serves data to the front-end. It's often developed using languages like PHP, Python, and Javascript and frameworks like Laravel, Django, or Node.js.
* Databases: Persistent storage systems where application data is stored. Examples of this are databases like MySQL, PostgreSQL, and NoSQL.
* APIs (Application Programming Interfaces): Interfaces allow the front and back-end to communicate and integrate with other services.
* Microservices: Instead of a single monolithic back-end, many modern applications use microservices, which are small, independent services that communicate over a network, often using HTTP/REST or gRPC.


## Understanding http request

* Request Line: The first line of the request POST /admin/login HTTP/1.1 is the request line. It consists of at least three items. First is the method, which in this case is "POST". The method is a one-word command that tells the server what to do with the resource. Second is the path component of the URL for the request. The path identifies the resource on the server, which in this case is "/admin/login". Lastly, the HTTP version number shows the HTTP specification to which the client has tried to make the message comply. Note that HTTP/2 and HTTP/1.1 have different structures.
* Request Headers: This section contains metadata about the request, such as the type of content being sent, the desired response format, and authentication tokens. It's like the envelope of a letter, providing information about the sender, receiver, and the nature of the content inside.
* Message Body: This is the actual content of the request. The body might be empty for a GET request, but for a POST request, it could contain form data, JSON payloads, or file uploads.

## Content-Length Header

The Content-Length header indicates the request or response body size in bytes. It informs the receiving server how much data to expect, ensuring the entire content is received.

## Transfer-Encoding Header

The Transfer-Encoding header specifies how the message body is formatted or encoded.




## Introduction to CL.TE request smuggling
To exploit the CL.TE technique, an attacker crafts a request that includes both headers, ensuring that the front-end and back-end servers interpret the request boundaries differently. For example, an attacker sends a request like:
```
POST /search HTTP/1.1
Host: example.com
Content-Length: 80
Transfer-Encoding: chunked

0

POST /update HTTP/1.1
Host: example.com
Content-Length: 13
Content-Type: application/x-www-form-urlencoded

isadmin=true
```

Here, the front-end server sees the Content-Length of 80 bytes and believes the request ends after  isadmin=true. However, the back-end server sees the Transfer-Encoding: chunked and interprets the 0 as the end of a chunk, making the second request the start of a new chunk. This can lead to the back-end server treating the POST /update HTTP/1.1 as a separate, new request, potentially giving the attacker unauthorized access.


## Introduction to TE.CL Technique

TE.CL stands for Transfer-Encoding/Content-LengthTo exploit the TE.CL technique, an attacker crafts a specially designed request that includes both the Transfer-Encoding and Content-Length headers, aiming to create ambiguity in how the front-end and back-end servers interpret the request.

```
POST / HTTP/1.1
Host: example.com
Content-Length: 4
Transfer-Encoding: chunked	

4c
POST /update HTTP/1.1
Host: example.com
Content-Type: application/x-www-form-urlencoded
Content-Length: 15

isadmin=true
0
```
In the above payload, the front-end server sees the Transfer-Encoding: chunked header and processes the request as chunked. The 4c (hexadecimal for 76) indicates that the next 76 bytes are part of the current request's body. The front-end server considers everything up to the 0 (indicating the end of the chunked message) as part of the body of the first request.

The back-end server, however, uses the Content-Length header, which is set to 4. It processes only the first 4 bytes of the request, not including the entire smuggled request POST /update. The remaining part of the request, starting from POST /update, is then interpreted by the back-end server as a separate, new request.

The smuggled request is processed by the back-end server as if it were a legitimate, separate request. This request includes the isadmin=true parameter, which could potentially elevate the attacker's privileges or alter data on the server, depending on the application's functionality.








