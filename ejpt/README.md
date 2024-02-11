# Recon through publically available informaition 

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
- ```whatweb``` Tells the basic info about the whole website and web server
- ```whois```
- ```dnsrecon -d (hostname)```: Dns enumeration

[DNS dumpester](https://dnsdumpster.com/) is an amazing website for passive dns enuemration.


WAFwoof is a tool which can tell if the website is protected by a firewall or not.
- ```wafw00f -l``` tells the list of the firewall it can detect.

- ```theHarvester``` tool lets you enumerate the email,hosts and subdomains of the webstie
- ```sublist3r``` helps you with subdomain enumeraiton


## Active Enumeration

### Dns zone transfers
```dnsenum```: This tool help with dns zone transfer files enumeration.

### Nmap
My go to command for nmap scan is

```nmap -A -v -F -T5 -Pn (ip)```

Will be covering nmap in detail.


### Network Mapping

Identifying all the devices on the network so that they may be able to pivot through it.
Identifying all the open ports and services.
Creating a map of the entire organization we are having a pentest on.


### Host discovery

* Ping Sweep: ICMP Echo request => ```fping -ag (ip) 2>/dev/null```
* Nmap Scans:
	- ```nmap -sn (ip) --send-ip```
	- ```nmap -sn -iL targets.txt``` 


### Port Scanning

- ```nmap -Pn (ip)``` : Port scanning with skipping the host discovery usually used to bypass the firewalls
- ```nmap -F (ip)```: perform a fast scan on the ip
- ```nmap -Pn -p- -T5 (ip)```: Scan all the ports.(Will take a long time).
- ```nmap -Pn -sT (ip)```: Tcp scan
- ```nmap -Pn -sU (ip)```: Udp scan 
- ```nmap -sV (ip)```: Service Version detection.
- ```nmap -O --osscan-guess (ip)```: OS scan (you need to be root for this)
- ```nmap -sS (ip)```: Stealth scan

### Firewall Detection and IDS Evansion

- ```nmap -sA -p(ports) (ip)``` Checks if that pariticular port is behind a firewall or not.
- ```nmap -f (ip)``` : Send packets in small fragments and then they are reassembled.
- ```nmap -(whatevery scan flags you want) -D (decoy ips you wanna spoof) (target ip)```



# Enumeration In Detail of each service

## SMB

It stands for server messege block.



