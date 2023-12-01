# Client Server Architecture

Its simple as that client request the server like for example a web server google.com and server responds with the desired ouput.
client can be a web browser or desktop application that a person interacts with to make requests to computer servers.


# Benefits of cloud computing

Consider why a company might choose to take a particular cloud computing approach when addressing business needs.

Trade upfront expense for variable expense
Stop spending money to run and maintain data centers
Stop guessing capacity
Benefit from massive economies of scale
Increase speed and agility
Go global in minutes


# Amazon ec2
Servers you use to gain access to virtual servers in cloud AWS is are call ec2 (Amazon elastic compute cloud).It comes under Compute as a service model.


# Multitenancy
Sharing underlying hardware between virutal machienes and it is managed by aws iteself.

# Vertical Scaling 
You can make the instances bigger and smaller according to your needs if you need to

# Types of ec2 instances:
1) General purpose: balanced amount of resources.
2) Compute optimzed: For high computation power for gaming servers or large language model calculations
3) Storage opmitmized
4) Memory optmized: memory intensive tasks 
5) Accelerated computing: floating point number calculations, graphics processign, Data pattern matching etc


# Amazon Ec2 pricing
1) On-Demand pricing
2) Savings plan
3) Reserved instances
4) Spot instances
5) Dedicated hosts

# Elastic load balancing

* WE solved the scaling problem but we now have a traffic problem. Many traffic is coming and to make sure the routing of traffic is accurate we use elastic load balancing.

* Elastic Load Balancing is the AWS service that automatically distributes incoming application traffic across multiple resources, such as Amazon EC2 instances. 

* It make sures to redistribute all the traffic evenly in all the instances.

* Although Elastic Load Balancing and Amazon EC2 Auto Scaling are separate services, they work together to help ensure that applications running in Amazon EC2 can provide high performance and availability. 


# Messegin and Queing

Monolothic architecture: Application with tightly coupled components in which if one service or component fail the whole applicatoin will fail comes under this architecture.

**To help maintain application availability when a single component fails, you can design your application through a microservices approach.**

# Amazon sqs service 
Allow you to send, store and recieve messeges between software components at any volume. Data contained within the messege are call payloads.


# Serverless Computing architecture
The term “serverless” means that your code runs on servers, but you do not need to provision or manage these servers. With serverless computing, you can focus more on innovating new products and features instead of maintaining servers.

* AWS Lambda(opens in a new tab) is a service that lets you run code without needing to provision or manage servers. 

# Containers 
Containers basically provide you a standard way in which you can package you whole applicatoin into a single object or in this case a container.

* Amazon Elastic Container Service (Amazon ECS)(opens in a new tab) is a highly scalable, high-performance container management system that enables you to run and scale containerized applications on AWS. 
* Amazon Elastic Kubernetes Service (Amazon EKS)(opens in a new tab) is a fully managed service that you can use to run Kubernetes on AWS. 

# AWS farget 

A serverless platoform where both ecs or eks can be managed for you (All the containers you make), unlike ec2 where you have to manually interact with the containers.


# Amazon VPC
Its essentially your own private network in the cloud.
You place every resource into subnets. Subnets are basically chucks of ip addresses in your vpc that allows you to group resource together.

Now since we don't want anyone to reach the private resources of the vpc we make sure to not attach the internet gateway to a vpc.We use a private gateway or virutal private gateway. This gateway allows you to create a vpn connection between your vpc and your onpremise data center.

Now since there is still a lot of traffic flowing by your vpn we need to make sure to make a dedicated private tunnel from datacenter to your gateway and that is done by **AWS Direct connect**. It creates a physical line that connects your network and vpc.

# Network Hardening in your vpc

The only need for creating private and public subnets is for accessing your gateway.
Public subnets have access to your gateway and private subnets do not.

Packets are messeges of the internet and every packet that goes through the boundary of a subnet is checked through a **Network Access Control List**. This check is to see if the packet have the permission to leave or enter the subnet based on who it is sent from and who it is trying to communicate with.


A Network ACL only evaluates if a packet enters subnet or not, it doesn't evaluate if reaches the particular instance or not because sometimes we have multiple instances in subnet. So we need instance level security for this too. To solve this **Security groups**
come in. Every instance come by default with a security group whcih does not allow any traffic into the instance. All ports and ip addresses are blocked. We can modify the security group so that particular type of traffic is allowed in the instance.

The main difference between **Network ACL** and **Security groups** is that the security group is stateful which means it has some form of memory which traffic is flowing whereas NACL is stateless and checks each and every packet that is coming.

# Global Networking

**Route 53** It is the aws domain name service.(DNS)
**Aws cloudfront**: Helps setting up the CDN.

**CDN(content delivery network)**: It is a network to deliver edge content to users based on their geographic locations.



# STORAGE IN AWS

## Amazon elastic block store:

Block level storage is a place to store file.
When you make an Ec2 instance it, by default it gives you instance store volumes which is attached to underlying physical host like hypervisor etc. If you terminate the instance all the data will be deleted.

With EBS you can create seperate storage volumes that are not directly tied to the instance and thus even if the instance is terminated your data will be safe.
While running your instance just take EBS snapshots from time to time and you will never loose that backup data.


## Amazon simple storage Servie (S3)
Its just as the name says, its a simple storage service provided by aws, having a lot of features.
In s3 data is stored in buckets instead of ojects.

**Amazon s3 standard**: Very high durability.
**Static website hosting**
**S3 standard infrequent access(s3 standard IA)**: Data is access less frequently but requires rapid access when needed.
**S3 glacier instant retrieval**: works well with data that requires immidiate access.
**S3 glacier flexible retrieval**: Able to retrieve objects within a few minutes to hours and has lower cost.
**S3 glacier deep archive**: Able to retrieve objects within 12 hours


## Elastic file system (EFS)
Shared file system for enterprise like networks. Multiple instances will be able to access this file system at the same time.

In amazon EBS you need to be in same Availiblity zones for accesing the storage and it does not automatically scale to give you more storage.
But in EFS its a regional resource (Stores the data in multiple regions at the same time) and automatically scales the storage as needed.


## Amazon relational database
AWS supports multiple database supports.
If you on premise datacenter and you need to move to cloud you can do something called LIFT and SHIFT.You can migrate your database to ec2 instances.

**Amazon RDS**: This service supports all the major database engienes with added benifits like automated patching, backups, redundancy management etc.

**Amazon aurora**: this is the amazong offical database which works on posgres and mysql. Its the most cost effective databse and replicates your data upto 15 times so you can scale performance with continous backups to s3.

**Amazon dynamo DB**: Its a serverless database, meaning you don't have to manage underlying instances or infrasture powering it. You don't need to worry about scaling too. Plus it has a millisecond response time.

**Amazon redshift**: 





## Security
If you wanna go into detail about cloud security you can check out the notes i am gonna make in **cloudsecurity** folder























