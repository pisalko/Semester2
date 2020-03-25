#include <limits.h>
#include <stddef.h>
#include "bit_stuff.h"

unsigned int count_ones(unsigned int value)
{
    unsigned int count = 0;



	//value   - 0001 0100
	//              &
	//mask    - 0000 0001
	//result  - 0000 0000  -> counter++ (1)
	// value>>1

	while(value != 0)
	{
		
		value>>1;
	}



    return count;
}

void make_bitmask(unsigned int width, unsigned int shift, unsigned int *mask)
{
    
}

void apply_bitmask(unsigned int value, unsigned int mask, unsigned int* masked_value)
{
    
}

void flip_bit(unsigned int value, unsigned int bit_index, unsigned int *updated_value)
{
  
}

void extract_nibbles_from_byte(uint8_t value, uint8_t *high_nibble, uint8_t* low_nibble)
{
  
}

void combine_nibbles_to_byte(uint8_t high_nibble, uint8_t low_nibble, uint8_t* value)
{
  
}
