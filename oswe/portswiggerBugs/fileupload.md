# File upload vuln

These are one of the most dangerous bugs if found as it can lead to direct remote code execution but there are many measures which can be taken place for these.


Obviously there are two types of filtering 

* client side: Happens before even the file is uploaded.
* server side: Happens after the file is uploaded in the server


# Client side filtering

This is the most weakest filtering out of all. It can be bypassed by the following ways:

1) Turing off the javascript in the browser
2) Using a proxy
3) Sending the file directly to the upload point using command line tools like **curl**.

Syntax for the third point would look something like this

```curl -X POST -F "submit:<value>" -F "<file-parameter>:@<path-to-file>" <site>```



Using a proxy to break client side filtering has its own challenges but very easy, we just have to see the file type filtering mainly and change the content and metadata of the file accordingly in burpsuite

To bypass the the magic number server side filtering you can use signatures of the files adding on top of your payloads you can find a lot of signatures in the following link

[Signatures for magic number bypass](https://en.wikipedia.org/wiki/List_of_file_signatures)
