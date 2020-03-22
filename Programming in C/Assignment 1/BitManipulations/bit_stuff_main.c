#include <stdio.h>

#include "bit_stuff.h"

int main()
{
	unsigned int maskk = 0;
	make_bitmask(6, 1, &maskk);
	printf("%d%c", maskk, '\n');
    return 0;
}
//Checks and Tests are not implemented since I used Vladimir Vladinov's TEST main
