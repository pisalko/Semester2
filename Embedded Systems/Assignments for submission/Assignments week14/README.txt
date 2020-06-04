the "Stack" folder is the library I created to ease the use of the Stack in this assignment.
This way I can create 1 or more Stack instances for the different purposes I need. 
Please put in libraries folder in your Arduino folder.

In this assignments I have 2 stacks:
One storing the inputs from the user, and one storing the all-time results.

Usage of the calculator:

   Commands include:
   <any float number>   - adds the number to the Input stack
   +, -, *, /,          - takes the last 2 numbers and does the corresponding action, else prints the error
   r                    - takes the last number and swaps it with its square root
   p                    - takes the last number and swaps it with it in the power of -1 (1/x)
   new                  - Clears the Input stack and adds the result to the Results stack, else prints the error(new equation)
   ce                   - Ignores everything and clears the Input stack (clear everything)
   cres                 - Prints data in Results stack (check results)
   cinp                 - Prints data in Inputs stack (check inputs)
   mav                  - Puts calc in simple moving average mode, will expect 6 doubles after "mav" command, else prints 0 as answer