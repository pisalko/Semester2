#include <stdio.h>
#include <stdlib.h>

void  main()
{
	int* vale = malloc(sizeof(int)*10);
	for(int j = 0, i = 0; j < 10; j++, i+=2)
		{
			*(vale+j) = i;
			printf("%d ", i);
		}
	printf("\n");

	for(int i = 9, j = vale[9]; i>=0; i--, j-=2)
		{
			vale[i] = j;
			printf("%d ", j);
		}
	printf("\n");
}
