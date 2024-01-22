## cors

It instructs the browser which resource to access from other websites
These headers start with ```Access Control``` for example, 

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
