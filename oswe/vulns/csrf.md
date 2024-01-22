## Csrf vulnerabilities
Getting the user to some actions which they doesn't wanna do like change their email or password lol.

Some ways to prevent this 

- **csrf tokens**; Everytime a form is filled its request is sent with this token and chages with every request but can be bypassed if not implmented properly

- **same site restriction**; It just tell the browser which cookies to send or should there be restricition on it or not.
Types of restriction on it:

1) Strict: No cookies can be send.
2) None: No restriction
3) Lax: Some cookies can be send

Default implementation of samesite attribute varies with the browser you are using.

- **Referrer based validation**;  The HTTP Referer header (which is inadvertently misspelled in the HTTP specification) is an optional request header that contains the URL of the web page that linked to the resource that is being requested. It is generally added automatically by browsers when a user triggers an HTTP request, including by clicking a link or submitting a form. Various methods exist that allow the linking page to withhold or modify the value of the ```Referer``` header. This is often done for privacy reasons. 