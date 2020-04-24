#include <SoftSerial.h>
#include <Wire.h>
#define sAddress 0x44 //SHT sensor address
#define sAddressVOC 0x5a //IAQ Core VOC sensor address

SoftSerial ss(D12, D13, 3); // A5, A4 original, rerouted to D12 and D13

void ValuesVOC(uint16_t *co2Prediction, uint16_t *etvoc, int *statuss)
{
  Wire.requestFrom(sAddressVOC, 9);
  delay(50);
  if (Wire.available())
  {
    byte byteBuffer[9];

    for ( int i = 0; i < 9; i++ )
    {
      byteBuffer[i] = Wire.read();
      delay(10);
    }
    *co2Prediction = (int)(byteBuffer[0] << 8) | (byteBuffer[1] << 0);;
    *etvoc = (byteBuffer[7] << 8) | (byteBuffer[8] << 0);
    *statuss = (int)byteBuffer[2];
  }
}

void setupTempHumSensor() //SHT sensor
{
  Wire.begin();
  delay(100);
  Wire.beginTransmission(sAddress);
  Wire.write(0x23); // mps, measurements per second - 4
  Wire.write(0x22); // repeatability                - Medium
  Wire.endTransmission();
  delay(1000);
}

double getHum() // from SHT sensor    //depricated, could be used to single TEMP/HUM measurements
{
  Wire.requestFrom(sAddress, 6);
  delay(50);
  if (Wire.available())
  {
    for (int i = 0; i < 3; i++)
    {
      Wire.read();
    }
    byte aHum = Wire.read();
    byte bHum = Wire.read();
    uint16_t rawValueHum = aHum;
    rawValueHum = rawValueHum << 8;
    rawValueHum = rawValueHum | bHum;
    Wire.read();
    return (100 * rawValueHum / (pow(2, 16) - 1));

  }
  else
  {
    return 0;
  }
}

double getTemp() //SHT sensor         //depricated, could be used to single TEMP/HUM measurements
{
  Wire.requestFrom(sAddress, 6);
  delay(50);
  if (Wire.available())
  {
    byte aTemp = Wire.read();
    byte bTemp = Wire.read();
    uint16_t rawValueTemp = aTemp;
    rawValueTemp = rawValueTemp << 8;
    rawValueTemp = rawValueTemp | bTemp;
    for (int i = 0; i < 4; i++)
    {
      Wire.read();
    }
    return (-45 + 175 * rawValueTemp / (pow(2, 16) - 1));
  }
  else
    return 0;
}

void getTempHum(double *hum, double *temp) //SHT sensor 
{
  Wire.requestFrom(sAddress, 6);
  delay(50);
  if (Wire.available())
  {
    byte aTemp = Wire.read();
    byte bTemp = Wire.read();
    uint16_t rawValueTemp = aTemp;
    rawValueTemp = rawValueTemp << 8;
    rawValueTemp = rawValueTemp | bTemp;
    Wire.read();
    byte aHum = Wire.read();
    byte bHum = Wire.read();
    uint16_t rawValueHum = aHum;
    rawValueHum = rawValueHum << 8;
    rawValueHum = rawValueHum | bHum;
    Wire.read();
    
    *hum = (100 * rawValueHum / (pow(2, 16) - 1));
    *temp = (-45 + 175 * rawValueTemp / (pow(2, 16) - 1));
  }
  else
  getTempHum(hum, temp);
}

int CO2ppmValue()
{
  ss.write(0x11);
  ss.write(0x01);
  ss.write(0x01);
  ss.write(0xED);
  delay(50);
  int ppmValue = 0;
  if (ss.available())
  {
    ss.read();
    ss.read();
    ss.read();
    ppmValue = (int)ss.read() * 256 + (int)ss.read();
    ss.read();
    ss.read();
    ss.read();
  }
  return ppmValue;
}

void setup() {
  Serial.begin(9600);
  ss.begin(9600);
  Wire.begin();
  setupTempHumSensor();
}

void loop() {
  //*CO2ppmValue() - ppm CO2 in room                /int/                       ///CO2 sensor///
  //**getHum() - relative humidity in room in %    /double/                     ///SHT sensor///
  //**getTemp() - temperature in Celsius in room   /double/                     ///SHT sensor///
  //***ValuesVOC(&co2Prediction/uint16_t/, &etvoc/uint16_t/, &statuss/int/);    ///IAQ Core sensor///
  //***CO2Prediction values, estimated volatile organic compounds value, status ///IAQ Core Sensor///

  Serial.println(F("First, the CO2 Sensor is to be tested: "));
  Serial.println((String)CO2ppmValue() + " parts per million /ppm/ CO2 in the air.");
  for (int i = 0; i < 3; i++)
  {
    Serial.println(F("*"));
  }
  delay(100);
  //-------------------------------------------------------------------------------
  Serial.println(F("Second, the SHT30 sensor is to be tested: "));
  double humidity, temperature;
  getTempHum(&humidity, &temperature);
  Serial.println((String)humidity + "% is the relative humidity in the room.");
  Serial.println((String)temperature + "°C is the temperature in the room.");
  for (int i = 0; i < 3; i++)
  {
    Serial.println(F("*"));
  }
  delay(100);
//-------------------------------------------------------------------------------
  Serial.println(F("And last, the IAQ Core /VOC/ sensor is to be tested: "));
  uint16_t predictionCO2, etvocValue;
  int statuss;
  ValuesVOC(&predictionCO2, &etvocValue, &statuss);
  Serial.println((String)predictionCO2 + " is the CO2 ppm predicted to be in the room.");
  Serial.println((String)etvocValue + " is the Volatile Organic Compounds value in the room.");
  Serial.println((String)statuss + " is the status of the Sensor.");
  for (int i = 0; i < 3; i++)
  {
    Serial.println(F("*"));
  }
  delay(10000);
}
