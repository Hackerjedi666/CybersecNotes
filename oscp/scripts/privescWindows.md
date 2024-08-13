
# Basic PS commands to Start

```
Get-Help * #List everything loaded
Get-Help process #List everything containing "process"
Get-Help Get-Item -Full #Get full helpabout a topic
Get-Help Get-Item -Examples #List examples
Import-Module <modulepath>
Get-Command -Module <modulename>
```

# PortScanning

```
1..1024 | ForEach-Object { Test-NetConnection -ComputerName "172.16.85.1" -Port $_ } | Where-Object { $_.TcpTestSucceeded } | Select-Object Port
```

# Get User

```
Get-LocalUser | ft Name,Enabled,Description,LastLogon
Get-ChildItem C:\Users -Force | select Name
```

# Groups

```
Get-LocalGroup | ft Name #All groups
Get-LocalGroupMember Administrators | ft Name, PrincipalSource #Members of Administrators
```

# Stored Credentials

## Windows Files

```
C:\unattend.xml
C:\Windows\Panther\Unattend.xml
C:\Windows\Panther\Unattend\Unattend.xml
C:\Windows\system32\sysprep.inf
C:\Windows\system32\sysprep\sysprep.xml
```

If the system is running an IIS web server the web.config file should be checked as it might contain the administrator password in plaintext. The location of this file is usually in the following directories:

```
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\Config\web.config
C:\inetpub\wwwroot\web.config
```

Local administrators passwords can also retrieved via the Group Policy Preferences. The Groups.xml file which contains the password is cached locally or it can be obtained from the domain controller as every domain user has read access to this file.

```
C:\ProgramData\Microsoft\Group Policy\History\????\Machine\Preferences\Groups\Groups.xml
\\????\SYSVOL\\Policies\????\MACHINE\Preferences\Groups\Groups.xml
```

## Commands

Instead of manually browsing all the files in the system it is also possible to run the following command in order to discover files that contain the word password:

```bash
findstr /si password *.txt
findstr /si password *.xml
findstr /si password *.ini
```

```bash
Get-UnattendedInstallFile
Get-Webconfig
Get-ApplicationHost
Get-SiteListPassword
Get-CachedGPPPassword
Get-RegistryAutoLogon
```


## Metasploit

search type:post platform:windows name:gather
run post/multi/recon/local_exploit_suggester













