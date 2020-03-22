#include <limits.h>
#include <stddef.h>
#include "bit_stuff.h"

unsigned int count_ones(unsigned int value)
{
	unsigned int count = 0;
	while(value != 0)
	{
		if(value & 1)
			{
				count++;
			}
		value = value>>1;
	}
    return count;
}

void make_bitmask(unsigned int width, unsigned int shift, unsigned int *mask)
{

// int 		0000 0000
//     			|
// mask 	0000 0001
// result 	0000 0001
//>
// result<<1
// result 	0000 0010
//     			|
// mask   	0000 0001

    *mask = 0;
	for (int i = 0; i < width; i++)
		{
			*mask = *mask | 1;
			if(!(i == width - 1))
				*mask = *mask<<1;
		}
	*mask = *mask << shift;
}

void apply_bitmask(unsigned int value, unsigned int mask, unsigned int *masked_value)
{
    *masked_value = value & mask;
}

void flip_bit(unsigned int value, unsigned int bit_index, unsigned int *updated_value)
{
	*updated_value = value ^ (1<<bit_index);
}

void extract_nibbles_from_byte(uint8_t value, uint8_t *high_nibble, uint8_t *low_nibble)
{
  	*high_nibble = value>>4; 
	*low_nibble = value & 15;
}

void combine_nibbles_to_byte(uint8_t high_nibble, uint8_t low_nibble, uint8_t *value)
{
  	high_nibble = high_nibble<<4;
	*value = high_nibble | low_nibble;
}
