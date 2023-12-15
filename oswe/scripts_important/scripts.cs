//If you see this you can modify it to the below script

DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePointsjava.net

//Script to modify the assembly to disable optimizations
Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations |
DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)


