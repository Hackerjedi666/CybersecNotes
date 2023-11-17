# Buisiness logic vulenrablities


These type of vulnerability are also called logic flaws in which developer fail to think of all the test cases in which a user can control the functionality of sending data.
These vulnerability are mostly found accidently, most of the time a hacker is not even looking for them and there is a wide variety of bugs in this category which can be quite dangerous or not harmful at all.


# Examples

As i said there is a wide variety of these vulnerabilities but these are the most common

 Examples of logic flaws include:

Excessive trust in client-side controls 
Failing to handle unconventional input 
Making flawed assumptions about user behavior 
Domain-specific flaws 
Providing an encryption oracle 


# Excessive Trust

The fundamental flawed assumption of a developer is that the user is gonna be interacting with the web applicaiton with web interface. Me as a hacker can use Proxy like burpsuite and easily rendering the client side validation useless.


# Handline uncoventional inputs

One aim of the application logic is to restrict user input to values that adhere to the business rules.
By observing the application's response, you should try and answer the following questions:

-    Are there any limits that are imposed on the data?
-    What happens when you reach those limits?
-    Is any transformation or normalization being performed on your input?


example:
lets say you are ordering something try changing the parameters to different thiings and see how the web application react to it, you'll be surprised how many negetive quantity or price bugs you'll be able to find in web applicatoins.











