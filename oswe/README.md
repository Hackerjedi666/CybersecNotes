# important links for oswe prep

[oswe important links](https://stacktrac3.co/oswe-review-awae-course/)
[node js rce and reverse shell](https://ibreak.software/2016/08/nodejs-rce-and-a-simple-reverse-shell/)
[Dotenet nuke deserialization](https://pentest-tools.com/blog/exploit-dotnetnuke-cookie-deserialization)
[json attacks](https://www.blackhat.com/docs/us-17/thursday/us-17-Munoz-Friday-The-13th-JSON-Attacks-wp.pdf)
[safe eval module](https://www.wispwisp.com/index.php/2019/08/16/cve-2017-16088-poc/)
[git hub repo oswe prep](https://github.com/kajalNair/OSWE-Prep?tab=readme-ov-file)
[oswe programming languages challenges](https://github.com/wetw0rk/AWAE-PREP)


# my notes

```grep -rnw ""	``` is an important tool for manual source code review and can find a text from the whole code base


## Remote Debugging

We can use vscode remote feature through whih we debug any code from whatever system we want.
While debugging the application developers can use
```DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints```

Debuggable attribute will control how the jit compiler will treat your code


if we change the above assembly to

```
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default |
DebuggableAttribute.DebuggingModes.DisableOptimizations |
DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints
| DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
```

Different scripts like these are written in scripts file, you can check them out.

## Python skills

Interacting with the web application through basic scripting skills such that we can make exploit and proof of concepts of each web application that is hacked.

We can use python inbuilt "requests" library for interacting with the web application plus there is a inbuilt proxie setup in request library which can be accessed by just making a dictionary such as follows:

```proxies = {"http" : "http://127.0.0.1:8080", "https" : "http://127.0.0.1:8080"}```

## Same origin policy

Prevents a website or an origin to access resources from the different orgin. Without it the web will be much more dangerous place.
The purpose of it is to not prevent sending the resources but to prevent javscript from reading the response.

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
- Access-Control-Expose-Headers : allowing certain headers


# Server side attacks

The term server side refers to the logic, proccess and infrastructure that resides on the server and not on the client.

Server side attacks target the backend components of a web application, including webservers, apis and databases.

### Server side attacks

* Trust Assumptions 

It can arise due to implicit trust between the server and its resources or components.

For eg:

1) Trust in user input leading to insecure deserialization.
2) Trust in internal network request leading to SSRF.

* Server Resources

It can arise due to exploitation of the resources and capabilities of the servers such as file system, memory or the CPU.

For eg: File upload vulnerability.







## Dotnetnuke

This machine is gonna teach you about deserialization.
