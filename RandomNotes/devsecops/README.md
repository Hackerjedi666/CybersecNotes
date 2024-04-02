# Container vuln 101



* misconfigured containers : Sometimes containers have permissions that they shouldn't have or they are running in the privellege mode which will be harmful as the permission will be abused by the attackers.

* Vulnerable Images	: If the image itself is vulnerable.

* Network Connectivity	: A container that is not correctly networked can be exposed to the internet. For example, a database container for a web application should only be accessible to the web application container - not the internet.





## privilleged containers


These capabilities determine what permissions a Docker container has to the operating system. Docker containers can run in two modes:

- User (Normal) mode
- Privileged mode


