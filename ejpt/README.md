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
- ```whatweb``` Tells the basic info about the whole website and web server
- ```whois```
- ```dnsrecon -d (hostname)```: Dns enumeration

[DNS dumpester](https://dnsdumpster.com/) is an amazing website for passive dns enuemration.


WAFwoof is a tool which can tell if the website is protected by a firewall or not.
- ```wafw00f -l``` tells the list of the firewall it can detect.

- ```theHarvester``` tool lets you enumerate the email,hosts and subdomains of the webstie
- ```sublist3r``` helps you with subdomain enumeraiton

- ```nikto -h (url)``` enumerates the basic things about website might be useful but not all the time.

## Active Enumeration

### Dns zone transfers
```dnsenum```: This tool help with dns zone transfer files enumeration.

### Nmap
My go to command for nmap scan is

* ```nmap -A -v -F -T5 -Pn (ip)```
* ```nmap -A -v -F -T5 -Pn (ip) -oX nmapscans.xml```

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

It stands for server messege block. It is a Windows implementation for file share. Common port number is **445**.


## FTP

File transfer protocol 
Check for anonymous login

Then try Bruteforcing the ftp 
```bash
hydra -L username_wordlist.txt -P password_wordlist.txt ip ftp
```


## SSH

Getting the RSA key

```bash
nmap (ip) -p 22 --script ssh-hostkey --scirpt-args ssh_hostkey=full
```

## Http
Windows main server for hosting websites in IIS and linux is apache or ngnix.

```bash
dirb (url)
```
```bash
browsh --start-up (url)
```
```bash
nmap -p 80 (ip) --script http-enum,http-headers
```
* metapsloit module => /auxilliary/scanner/http/http_version
* metapsloit module => /auxilliary/scanner/http/brute_dirs


----------------------------

# Host Based Attacks/System Based Attacks

Primiraly focused on targeting an operating system like windows or linux

## Windows Vulnerabilites

* Version out of date.
* Cross platform vulenerablities
* Information Disclosure
* Buffer Overflows
* RCE
* DOS

Windows have several services and protocols that can be run on hosts. 

Common Services:

* IIS (web server)
* WebDav (web server)
* SMB (tcp 445 (file sharing))
* RDP (tcp 3389)
* WinRM (tcp 5986)
 

## Exploiting Windows Vulns

* IIS Web Dav
Internet Information services. Just a web server developed by windows on ASP.NET.It lets you upload or download files on the webserver.
Supported extension by iis are

.asp
.aspx
.php
.config

With the help of ```davtest``` tool you can perfrom a series of check about which type of files you can upload and which files will be executed.
```cadver``` is a tool for WebDAV clients, which supports a command-line style interface. It supports operations such as uploading files, editing, moving, etc.

eg lab:
bob:password_123321
flag: 0cc175b9c0f1b6a831c399e269772661
flagWithMetasploit: d3aff16a801b4b7d36b4da1094bee345


### Exploiting SMB

Network file sharing protocol with default port 445

SMB AUTHENTICATION

* User Authentication -> Username and password
* Share Authentication -> Password

```PsExec``` is a lightweight telnet replacement developed by microsoft.
It can be used for authentication by SMB.

Typical attack would be brute forcing username and password and then using psexec for the authentication.

eg lab:
flag: e0da81a9cd42b261bc9b90d15f780433


### Exploiting RDP

Default Port : 3389
default Attack type : Brute force

Brute Forcing using hydra if RDP is configured on port 3333:: 
```hydra -L /usr/share/metasploit-framework/data/wordlists/common_users.txt -P /usr/share/metasploit-framework/data/wordlists/unix_passwords.txt rdp://10.5.21.28 -s 3333```

eg lab:
flag: port-number-3333


### exploiting WinRm

Windows Remote Management protocol.
Default ports: 5985 or 5986
Tools to exploit it: ```crackmapexec``` for bruteforcing and ```evil-winrm```

Scirpt : ```crackmapexec winrm 10.5.24.33 -u administrator -p /usr/share/metasploit-framework/data/wordlists/unix_passwords.txt```

After bruteforcing use -x flag to execute the command or use ```evin-winrm``` to get the shell.

eg lab: 
flag : 


## Windows Privillege Escilation

- Metasploit module for enumeration of privillege escialtion is **multi/recon/local_exploit_suggester**
- [windows enumeration](https://github.com/AonCyberLabs/Windows-Exploit-Suggester)

### Windows kernal Exploits

Kernel is computer program that acts as a translation between hardware and software. Windows NT is the kernel that comes prepackaged with the windows. There are two main modes:
 
* **User Mode**: limited access to the resources
* **kernel Mode**: Unrestricited access to the resources, So if we get any vuln in kernel we are always gonna have the root access.

### Bypassing UAC

**UAC**(User account Control)
Feature that prevents unauthorized changes from users. It allows a program to be executed by a administrative privilleges, consequently prompting user for confirmation.

In Order to bypass UAC you need to have access to local administrative group.
Tool for bypassing it: [UACme](https://github.com/hfiref0x/UACME)

eg lab:
used ```Akagi64 23``` to bypass UAC with my backdoor generated by msfvenom

Admin NTLM Hash: ```4d6583ed4cef81c2f2ac3c88fc5f3da6```



### Access Token Impersonation

They are core element of authentication process on Windows and are created by LSASS.
Its generated by winlogon.exe process everytime the user authenticates and it consist of the identity and privilleges of that particular user.
There are two types of access tokens:

* Impersonate Access Token
* Delegete level token


**Windows privilleges**:
You can check the privs with the help of metasploit command ```getprivs```.

- SetAssignPrimaryToken: Allows user to impersonate the token 
- SeCreateToken: Create a token with administrative privilleges
- SeImpersonatePrivillege
With the help of Metasploit you 
can just load the ```load incognito``` and see the tokens available by the meterpreter command
```list_tokens -u```

And when u find one you can just say ```impersonate_token (Token u found)```.

eg lab:
flag : `x28c832a39730b7d46d6c38f1ea18e12`


### Windows file system Vulnerabilities

Alternate Data Stream(ADS) is essentially and NTFS file attribute.
Any file that is created in NTFS has two attributes:
- Resource Stream: Metadata of the file
- Data Stream: Actual Content of the file.


ADS can be used to hide malicious code and evade antivirus detection.


## Windows Credentials Dumping

### Windows passwords hashes
There are two different types of hashes
* LM
* NTLM

LM is not used nowdays anymore

**SAM(Security Account Manager)**: It consists the list of all the user accounts and passwords.

Most of the time while configuring the unattended software config files are left on the computer by sysadmins and since they contain the admin password a hacker won't need to exploit any service, he/she can easily rdp or psexec it.

That file can be found on:
```C:\Windows\Panther\Unattend.xml```

You can also use meterpreter modules like kiwi to dump the hashes and many other things and can be used by 
```load kiwi```

eg lab:
flag 097ab83639dce0ab3429cb0349493f60

eg lab(Mimikatz lab):
admin: e3c61a68f1b89ee6c8ba9507378dc88d
student: bd4ca1fbe028f3c5066467a7f6a73b0b
syskey: 377af0de68bdc918d22c57a263d38326


## Linux

### Exploiting FTP
Default attack:  Bruteforce with hydra
Script: 
```bash
hydra -L /usr/share/metasploit-framework/data/wordlists/common_user.txt -P usr/share/metasploit-framework/data/wordlists/unix_passwords.txt $ip -t 4 ftp
```

### Exploiting SSH
Default attack:  Bruteforce with hydra
Script: 
```bash
hydra -L /usr/share/metasploit-framework/data/wordlists/common_user.txt -P usr/share/metasploit-framework/data/wordlists/common_passwords.txt $ip -t 4 ssh
```

eg lab:
flag: eb09cc6f1cd72756da145892892fbf5a

### Exploiting SMb
Default attack:  Bruteforce with hydra
Script: 
```bash
hydra -L /usr/share/metasploit-framework/data/wordlists/common_user.txt -P usr/share/metasploit-framework/data/wordlists/common_passwords.txt $ip smb
```

Other utitiliy for exploiting smb is
```enum4linux```

Go to command for this is
```bash
enum4linux -a -u $(username) -p $(password) $(ip)
```

eg lab:
flag : 2727069bc058053bd561ce372721c92e



## Linux Privillege escialtion

### linux kernel exploits

Kernel Exploits just like windows allows attacker to run arbitrary code in kernel itself and thus giving us the admin access.

Methodology:
- Identify the version of kernel
- Find the exploit of that kernel if available

Tool:[Linux exploit suggester](https://github.com/The-Z-Labs/linux-exploit-suggester.git)


### Cronjob

Running a script or file which was configured on cronjob at ```/etc/crontab``` is the vulnerability if that particular script or that file have imporper configuration.

eg lab:
flag 697914df7a07bb9b718c8ed258150164




------------------


# Metasploit Framework pentesting

Difference Between exploit and a payload is that exploit is how we send the payload to the target system and with the help of payload we get a reverse sehll or something.
Auxillary module are additional functionalities which cannot be paired with payloads.

Payload Types:

- Non Staged paylaod : When payload is send to the target along with the exploit
- Staged payload

## Autorouting(Pivoting)

You can set autorouting or pivoting with the help of the following meterpreter command:

```bash
autoroute -s (anotherIpSubnet)
```

## Workspaces

You can create a new workspace for you to work in. It is advised to always create a new workspace for the new red team operation.

```bash
workspace -a
```

You see number of ip addresses with the help of ```hosts``` command.
We can use ```import_db filename``` to import the nmap details which had an output in output.xml







































