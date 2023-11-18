These notes are gonna be about source review, Basically whiteBox Testing

Just some important pointer and notes which might help me in future.

The CirclekFramework:

1) Application Review
2) Take Notes about everything eg. tech stacks, Behaviour profile etc.
3) Map the applicaiton
4) Brainstorm the risks of the application
5) Build list of review items in the notest itself
6) Perform all the reviews one by one



Behavior Profile
• What does it do? (business purpose)
• Who does it do this for? (internal / external customer base)
• What kind of information will it hold?
• What are the different types of roles?
• What aspects concern your client/customer/staff the most?


# Authorization Review

1) Analyze source for role enforcement, appropriate user boundaries, privileges required for access, and business-logic flaws.
2) Roles and associated enforcement routines must be identified during information gathering
3) Pay attention to any endpoints that include sensitive data or functionality
4) Vertical authorization weaknesses - escalated privileges
5) Authenticated and unauthenticated access
6) Horizontal authorization weaknesses - access another user's data


Auditing Review
• Validate that appropriate logging and exception handling are handled within application source
• One path in the trace of sensitive data from source to sink
• Logging functions and error messages are considered a data sink
• Logging should happen in any endpoint that performs a state-changing operation or has security implications
•This data is used for immediate analysis and future forensics needs.Check that sensitive data is appropriately handled    (no credit card numbers, etc) and the correct details are logged.
• Administrators must trust that logs may not be manipulated by unauthorized parties



# Sources
All the the inputs which are not secure or where all the malicious data can come from.

# Sinks
All the places where that payloads or data can do damage.
There are lot of sites which can give us a list of dangerours sinks which can be exploited.


# An Approach to Analysis
Regardless of which approach we use, our end goals are the same: we want to identify vulnerabilities or logic errors in the application, determine how to call the vulnerable code, and bypass restrictions.

In OSWE we are gonna mostly cover HTTP routing patterns of the web applicatoin.
File system routing of different languages maps all the files in local file system of the server, for example, the APACHE web server stores all the web application files in ```/var/www/html```

If the server cannot find the file it responds with the 404.


JAva applications uses SERVELET mappings to handle all the http requests 
for example,
```
<!-- SubscriptionHandler-->
Advanced Web Attacks and Exploitation
<servlet
id="SubscriptionHandler"
<servlet-name>SubscriptionHandler</servlet-name>
>
<servlet-
class>org.opencrx.kernel.workflow.servlet.SubscriptionHandlerServlet</servlet-class>
</servlet>
...
<servlet-mapping>
<servlet-name>SubscriptionHandler</servlet-name>
<url-pattern>/SubscriptionHandler/*</url-
pattern> </servlet-mapping>
```Some programming languages maps the http routing directly in the source code.




