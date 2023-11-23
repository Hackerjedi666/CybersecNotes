# OSWE prep


# Python skills
Interacting with the web application through basic scripting skills such that we can make exploit and proof of concepts of each web application that is hacked.


We can use python inbuilt "requests" library for interacting with the web application plus there is a inbuilt proxie setup in request library which can be accessed by just making a dictionary such as follows:



```proxies = {"http" : "http://127.0.0.1:8080", "https" : "http://127.0.0.1:8080"}```



# Source code recovery

Recovering source code from web applications written in compiled language is must have skill in oswe.

* Managed .net code recovery

WE can decompile the .net code very easily with the help on free and opensource online tools like Dnsspy.

# Remote Debugging
We can use vscode remote feature through whih we debug any code from whatever system we want.
While debugging the application developers can use
```DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints```

Debuggable attribute will control how the jit compiler will treat your code

if we change the above assembly to 

```
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default |
DebuggableAttribute.DebuggingModes.DisableOptimizations |
DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints
| DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
```








