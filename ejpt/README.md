# Recon

## Passive enumeration
We get a website and the first thing we do is find the ip address or vice versa.
If you get an ip and want the dns to redirect the ip to website modify the ```/etc/hosts``` file.

Finding the ip with website address can be done by
```host```

And if you get multiple ips you can safely assume that you are dealing with some kind of proxy.

Whenever we go the website the main things to find is any names or email address as it can lead to potential usernames or hidden domains.

While looking for info on website the most important thing to look for important files. This could potentially give some file name which were not intended to be public. Some of the webpages are:
```
robots.txt
sitemap.xml
```

Now to some plugins like ```Wappalyzer``` addon which essenitally tells us which tech stack is the website made from.

Command line utitilies:
```whatweb``` Tells the basic info about the whole website and web server
```whois```
```dnsrecon -d (hostname)```: Dns enumeration

[DNS dumpester](dnddumpster.com) is an amazing website for passive dns enuemration.


WAFwoof is a tool which can tell if the website is protected by a firewall or not.
```wafw00f -l``` tells the list of the firewall it can detect.

