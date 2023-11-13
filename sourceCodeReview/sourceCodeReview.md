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


There are lot of sites which can give us a list of dangerours sinks which can be exploited






