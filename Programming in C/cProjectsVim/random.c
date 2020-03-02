#include <stdio.h>

int random;
int min_range = 0;
int max_range = 60;


int main()
{


	random = min_range + rand() % (max_range+1 - min_range);
	printf("%d\n", random); 

return 0;
}
