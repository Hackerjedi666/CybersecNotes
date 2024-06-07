# Physical SEcurity

One of the security principles is Defence-in-Depth. Hence, we should always think in terms of layers of security. One of the first layers is physical security.
Let's say you make it such that no one can access your system from any type of password attacks or something. But if a threat actor gets physical access to your system then using a non-sophisticated attack like resetting the password from grub bootloader is very common.
That's why we have to ensure physical security practices are implemented on every device in an organization.
We can consider adding a GRUB password depending on the Linux system we want to protect. Many tools help achieve that. One tool is ```grub2-mkpasswd-pbkdf2```, which prompts you to input your password twice and generates a hash for you. The resulting hash should be added to the appropriate configuration file depending on the Linux distribution (examples: Fedora and Ubuntu). This configuration would prevent unauthorised users from resetting your root password. It will require the user to supply a password to access advanced boot configurations via GRUB, including logging in with root access.



# File permissions

The first set of permissions is the user set which owns the file system.
The second set is of permissoins is the group which owns the file
The third set of permissions is of everyone in the entire world.


# File system and parititioning and encryption

Let's say the threat actor have your physical access to the device by any means, we have to make sure that it is of no use to them. This can be done with the help of encryption cuz and encrypted device is as good as a damaged drive.
Most of the linux distribution ship with parititinoing ecryption called LUKS(linux unified key setup) that is what I am gonna be telling you about.


When a partition is encrypted with LUKS it has following headers:
- LUKS phdr: It stands for LUKS Partition Header. LUKS phdr stores information about the UUID (Universally Unique Identifier), the used cipher, the cipher mode, the key length, and the checksum of the master key.

- KM: KM stands for Key Material, where we have KM1, KM2, …, KM8. Each key material section is associated with a key slot, which can be indicated as active in the LUKS phdr. When the key slot is active, the associated key material section contains a copy of the master key encrypted with a user's password. In other words, we might have the master key encrypted with the first user's password and saved in KM1, encrypted with the second user's password and saved in KM2, and so on.

- Bulk Data: This refers to the data encrypted by the master key. The master key is saved and encrypted by the user's password in a key material section.


# Linux Forensics

## Some important files you should check

`/etc/os-release`



## WORKING

LUKS reuses existing block encryption implementations. The pseudocode to encrypt data uses the following syntax:
```enc_data = encrypt(cipher_name, cipher_mode, key, original, original_length)```

The user-supplied password is used to derive the encryption key; the key is derived using password-based key derive function 2 (PBKDF2).
```key = PBKDF2(password, salt, iteration_count, derived_key_length)```


## Steps
1) Install Cryptsetup
2) confirm the parition using ```lsblk```
3) setup partition for luks encryption using ```cryptsetup -y -v luksFormat /dev/sdb1```
4) Create a mapping to access the partition: ```cryptsetup luksOpen /dev/sdb1 EDCdrive```
5) overwrite existing data with zero: ```dd if=/dev/zero of=/dev/mapper/EDCdrive```
6) format the partition ```mkfs.ext4 /dev/mapper/EDCdrive -L "Strategos USB"``` 
7) mount it and start using it like a normal partition.


## Firewall

A firewall decides which packets can enter a system and which packets can leave a system. For more information about firewalls, we recommend you check the Firewalls room. Without a firewall, a client can communicate with any server without restrictions; moreover, a client can function as a server and listen for incoming connections from other clients. In other words, if an attacker manages to exploit a vulnerability on a system without a firewall in place, the attacker could use the exploit to listen on a chosen port number on the victim’s machine and connect to it without any restrictions.

The firewall has two main functions:

- What can enter? Allow or deny packets from entering a system.
- What can leave? Allow or deny packets from leaving a system.

### Ip tables
We can use IPTABLES for the firewall setup and for filtering traffic it has the following chains:

* Input: This chain applies to the packets incoming to the firewall.
* Output: This chain applies to the packets outgoing from the firewall.
* Forward This chain applies to the packets routed through the system.

See the docs for the use, they are much more detailed.

### NetFilter

The Linux kernel embeds the netfilter firewall. Netfilter uses four distinct tables, which store rules regulating three kinds of operations on packets:
* *filter* - concerns filtering rules (accepting, refusing, or ignoring a packet);
* *nat (Network Address Translation)* - concerns translation of source or destination addresses and ports of packets;
* *mangle* - concerns other changes to the IP packets (including the ToS—Type of Service—field and options);
* *raw* - allows other manual modifications on packets before they reach the connection tracking system.



### UFW
UFW stands for uncomplicated firewall. Let’s see how it stands for its promise of being uncomplicated. We will allow SSH traffic. This firewall rule can be achieved through one of the following commands:
```bash
ufw allow 22/tcp
```

### Securing User accounts

The root account carries with it tremendous power and hence risk. You are at risk of rendering your system unbootable with a simple mistake. Using a non-root account for everyday work is recommended to avoid sabotaging your system. However, root privileges are still needed for system maintenance, installing/removing software packages, and updating/configuring the system.

To avoid logging in as root, the better approach would be to have an account -created for administrative purposes- added to the sudoers, i.e. group who can use the sudo command. sudo stands for Super User Do and it should precede any command that requires root privileges.

We can create new users with the help of ```usermod -aG sudo username```
















