# System Security

## Cpu architecture

Each cpu has its own instruction set format (ISA).

Cpu instruction are written in hex format and because of that it is very difficult to read. As a result machine code is translated to assembly language.


There are different types of assembly language (the only difference is syntax).

X86 is mainly used in intel and amd processors. 

ARM assembly is used arm processors.

Registers are small, high speed storage locations within the cpu used to store data temporariliy.



## Registers

The architecture of cpu specifies the width or height of registers (32bit or 64bit).

So obviously each cpu has fixed set of registers.

*General purpose Registers*

Wherever you see the the register name starting with E (EAX, EBX etc) it means it a 32 bit register and R is 64 bit registers.

EAX, EBS, ECX, EDX  is used for general arthemetic operaitons.
ESP and EBP is used for managing the stack pointer and base pointer resepctively.
ESI and EDI is used for string manipulaiton.

*Instruction pointer (EIP)*

It tell the CPU where the next instruction is.	 


## Process Memory

* Code Segment: Contains the executable code of the program.
* Data Segment: Stores initialized data, such as global variables and static variables.
* BSS Segment: Contains uninitialized data, initialized to zero during program execution.
* Heap Segment: Dynamically allocated memory for program data structures le.g., heap memory allocated using functions like malloc() and free()	.
* Stack Segment: Stores function call frames, local variables, and function parameters. The stack grows and shrinks dynamically as functions are called and return.


## Understanding the stack










