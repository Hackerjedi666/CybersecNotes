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

















