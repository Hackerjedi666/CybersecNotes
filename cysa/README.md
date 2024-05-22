# Cysa Training

# Threat Classfication
Two types of threats

* *Known Threats* : These include malwares or documented exploits
* *Unknown Threats* : These include zero days, obfuscated malware codes, Behaviour Based Detection, Recycled Threats.

# Threat Actors

Basically talking about cybercriminals

# Malware

* *Commodity Malwares* : Widely up for sales on dark web and easily accesable.
* *Zero Days* : Vulnerability where it is exploited before the vendor patches it.
* *Command and Control node* : Single point of contact for all the comprimised machines.

# Threat research

* *Reputation Data* : Blacklisting of the known threats.
* *Indicators of comprimise* : Residual or clue that an attack might have been happening.
* *Indicators of Attack* : Evidence for intrusiton attempt
* *Behavior threat intel* : Behaviour pattern used in historical cyber attacks and adversary actions
* *Port Hopping* : Apt's C2 framework might be hoppign between different ports to communicate 
* *Fast flux dns* : Rapidly changing ip address of a domain. This is typically used to bypass blacklisting of ip address.


# Indicator Management

* *MISP* (Malware Information Sharing Platform) is an open-source threat information platform that facilitates the collection, storage and distribution of threat intelligence and Indicators of Compromise (IOCs) related to malware, cyber attacks, financial fraud or any intelligence within a community of trusted members. 

* *Structured Threat Information expression* : A standard temrinology for IOCs and ways of indicating relationships between them that is included as part of OASIS cti framework. Its communcation is done in json format.

# Edr configuration

EDR requires tuning to reduce false positives.
You should submit your findings with the community as much as you can.
You can create yara rules for matching the patterns of a malware and open source it.

# Block listing and allow listing
Process of blocking know applications,traffic,ports etc.
Allowlisting is just the opposite of it.
The execution control is determinig what additional software is installed on the software beyond its baseline.



# Log analysis

## Firewall logs
Firewall limits the traffic based on access control list
There is 4 different types of logs in the firewall

* Connections that are permitted or denied
* Port and protocol usage
* Bandwidth usage
* Audit log of the network of port address translition
