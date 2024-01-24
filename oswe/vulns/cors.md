## cors

It instructs the browser which resource to access from other websites
These headers start with ```Access Control``` for example, 

Basically adds flexibility to the same origin policy.

```
HTTP/1.1 200 OK
Cache-Control: no-cache
Access-Control-Allow-Origin: https://a.com
Access-Control-Allow-Credentials: true
Access-Control-Expose-Headers:
cache-control, content-language, expires, last-modified, content-range, content-length, accept-ranges
Cache-Control: no-cache
Content-Туре: application/json
Vary: Accept-Encoding
Connection: close
Content-Length: 15
{"status": "ok"}

```

- Access-Control-Allow-Origin : describes which origin can access the response, if the header is set to **wildcard** then the it can access resources from any origin
- Access-Control-Allow-Credentials : indicates if request can contain credentials,if this is set to true any request sent will include the cookies and by default this header is set to false.
- Access-Control-Expose-Headers : allowing certain headers.


If origin header is said to wildcard then credentials cannot be false for security reasons


