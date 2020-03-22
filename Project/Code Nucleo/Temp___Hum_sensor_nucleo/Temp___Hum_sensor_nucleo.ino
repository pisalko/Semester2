#include <Wire.h>
#define sAddress 0x44

void setupTempHumSensor()
{
  Wire.begin();
  delay(100);
  Wire.beginTransmission(sAddress);
  Wire.write(0x23); // mps, measurements per second - 4
  Wire.write(0x22); // repeatability                - Medium
  Wire.endTransmission();
  delay(1000);
}

double getHum()
{
  Wire.requestFrom(sAddress, 6);
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

double getTemp()
{
  Wire.requestFrom(sAddress, 6);
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




void setup() {
  Serial.begin(9600);
  setupTempHumSensor();
  Serial.println("Setup finished!");
}

void loop() {
    Serial.println(String(getHum()));
    delay(500);
    Serial.println(String(getTemp()));
    delay(500);
}
