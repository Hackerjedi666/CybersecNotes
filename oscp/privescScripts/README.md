# privellege escilation

## Enumaration

```hostname```
```uname -a```
```cat /proc/version```
```cat /etc/passwd```
```env```
```history```


To get a nice wordlist which will help you in bruteforcing for other user accounts you can cut /etc/passwd file to reduce the noise 

```cat /etc/passwd | cut -d ":" -f 1```



# Automated tools

## linpeas
```curl -L https://github.com/carlospolop/PEASS-ng/releases/latest/download/linpeas.sh | sh```
```wget https://github.com/carlospolop/PEASS-ng/releases/latest/download/linpeas.sh```

## linenum
https://github.com/rebootuser/LinEnum/blob/master/LinEnum.sh


# Tactics

## kernel exploits 
Privilege escalation ideally leads to root privileges. This can sometimes be achieved simply by exploiting an existing vulnerability, or in some cases by accessing another user account that has more privileges, information, or access.


The Kernel exploit methodology is simple;

* Identify the kernel version
* Search and find an exploit code for the kernel version of the target system
* Run the exploit


Most of the cves can be found in [linux exploit cves]( https://www.linuxkernelcves.com/cves )


## Privilege Escalation: Sudo services
Any user can check its current situation related to root privileges using the ```sudo -l``` command.
[GFTOBINS](https://gtfobins.github.io/) is a valuable source that provides information on how any program, on which you may have sudo rights, can be used.

## SUID and GUID files
The first step in Linux privilege escalation exploitation is to check for files with the SUID/GUID bit set. This means that the file or files can be run with the permissions of the file(s) owner/group.
Finding suid binaries

```bash
find / -perm -u=s -type f 2>/dev/null
```

find - Initiates the "find" command

/ - Searches the whole file system

-perm - searches for files with specific permissions

-u=s - Any of the permission bits mode are set for the file. Symbolic modes are accepted in this form

-type f - Only search for files

2>/dev/null - Suppresses errors


## Exploiting a writable /etc/passwd

Understanding /etc/passwd

The /etc/passwd file stores essential information, which  is required during login. In other words, it stores user account information. The /etc/passwd is a plain text file. It contains a list of the system’s accounts, giving for each account some useful information like user ID, group ID, home directory, shell, and more.

It's simple really, if we have a writable /etc/passwd file, we can write a new line entry according to the above formula and create a new user! We add the password hash of our choice, and set the UID, GID and shell to root. Allowing us to log in as our own root user!








