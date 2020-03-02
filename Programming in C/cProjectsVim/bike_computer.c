#include <stdio.h>
#include <stdint.h>
#include <stdlib.h>
#include <stdbool.h>
#include <Windows.h>

#define MIN_SPEED 20
#define MAX_SPEED 60
#define MIN_POWER 150
#define MAX_POWER 200
#define MIN_HEART_RATE 60
#define MAX_HEART_RATE 140
#define MIN_CADENCE 50
#define MAX_CADENCE 100

#define MAX_NUMBER_MEASUREMENTS 32

typedef enum
{
	BIKE_SPEED,
	BIKE_HEART_RATE,
	//make data type complete
} BIKE_DATA_TYPE_ENUM;

typedef struct
{
	uint16_t speed;
	uint16_t heart_rate;
	//make data complete
} bike_data;

bike_data bike_measurements[MAX_NUMBER_MEASUREMENTS] = {
	{
		0,
	},
};

uint16_t number_of_measurements_present = 0;

uint16_t get_random_value(uint16_t min_range, uint16_t max_range)
{
	//implement the function to generate random value within min_range and max_range using rand()
}

uint16_t bike_measure_speed_in_kmh()
{
	return get_random_value(MIN_SPEED, MAX_SPEED);
}

uint16_t bike_measure_heart_rate_in_bpm()
{
	return get_random_value(MIN_HEART_RATE, MAX_HEART_RATE);
}

uint16_t get_maximum_number_of_measurements()
{
	return MAX_NUMBER_MEASUREMENTS;
}

uint16_t get_number_of_measurements_present()
{
	return number_of_measurements_present;
}

void add_measurement(bike_data value)
{
	//implement
}

bike_data get_measurement(uint16_t index)
{
	return bike_measurements[index];
}

uint16_t get_value_for_data_type(bike_data measurement, BIKE_DATA_TYPE_ENUM data_type)
{
	uint16_t value = 0;

	if (data_type == BIKE_SPEED)
	{
		value = measurement.speed;
	}
	if (data_type == BIKE_HEART_RATE)
	{
		value = measurement.heart_rate;
	}
	//implement the rest of the data type
	return value;
}

uint16_t calculate_min_value(BIKE_DATA_TYPE_ENUM data_type)
{
	//implement this function
}

uint16_t calculate_max_value(BIKE_DATA_TYPE_ENUM data_type)
{
	uint16_t number_of_measurements = get_number_of_measurements_present();

	uint16_t max_value = 0;

	for (uint16_t index_position = 0; index_position < number_of_measurements; index_position++)
	{
		bike_data measurement = get_measurement(index_position);
		uint16_t value = get_value_for_data_type(measurement, data_type);
		if (value > max_value)
		{
			max_value = value;
		}
	}

	return max_value;
}

uint16_t calculate_average_value(BIKE_DATA_TYPE_ENUM data_type)
{
     //implement this function  
}

int main()
{
	bike_data measurement;
	uint16_t min = 0, max = 0, average = 0;
	BIKE_DATA_TYPE_ENUM data_type;

	while (true)
	{
		measurement.speed = bike_measure_speed_in_kmh();
		measurement.heart_rate = bike_measure_heart_rate_in_bpm();

		add_measurement(measurement);

		data_type = BIKE_SPEED;
		min = calculate_min_value(data_type);
		max = calculate_max_value(data_type);
		average = calculate_average_value(data_type);
		printf("SPEED:\t\t%d, average = %d, min = %d, max = %d [km/h]\n", measurement.speed, average, min, max);
		
		data_type = BIKE_HEART_RATE;
		min = calculate_min_value(data_type);
		max = calculate_max_value(data_type);
		average = calculate_average_value(data_type);
		printf("HEART-RATE:\t%d, average = %d, min = %d, max = %d [hrm]\n", measurement.heart_rate, average, min, max);

                // implement the rest of the data type

		Sleep(1000);
	}

	return (0);
}