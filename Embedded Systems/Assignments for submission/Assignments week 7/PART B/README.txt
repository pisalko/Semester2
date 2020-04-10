How to use:

The program uses in-line commands. The syntax is as follows:

protocol:		command 	- 	register 	- 	separator 	- 	value

viable characters:	r/w		-	21/22/23/24	- 	 =/blank	-	0-255/blank

explanation:		read/write 	-	num of reg	-    always '='/blank	-	unsigned byte value


Examples:
w21=123 -> writes register 21 with value of 123
w22=255 -> writes register 22 with value of 255
r21     -> returns value at register 21
r24     -> returns value at register 24

Special behaviour:
Since only registers 21 and 22 are writable, if you execute a command like "w24=123", the Arduino will assume you want to 
only READ register 24, and will return value at register 24. Same goes for 23. Negative values cannot be assigned due to
the use of unsigned bytes.