#include <Wire.h>

bool command = false;

void setup() {
  Wire.begin();
  Serial.begin(9600);
}

void loop() {
  String c = "";
  byte address;
  while (Serial.available())
  {
    char v = Serial.read();
    if (v == '\n')
      return;
    c += v;
    uint8_t transitionInt = c.toInt();
    address = (byte)transitionInt;
    command = true;

  }
  if (command)
  {
    Wire.beginTransmission(42);
    Wire.write(address);
    switch (c.toInt())
    {
      case 21:
        Wire.write(address); //value sent after address (2nd byte) for write
        Wire.endTransmission();
        Wire.requestFrom(42, 1);
        delay(30);
        while (Wire.available())
        {
          Serial.print((char)Wire.read());
        }
        break;
        
      case 22:
        Wire.write(address); //value sent after address (2nd byte) for write
        Wire.endTransmission();
        Wire.requestFrom(42, 1);
        delay(30);
        while (Wire.available())
        {
          Serial.print((char)Wire.read());
        }
        break;
        
      case 23:
        Wire.endTransmission();
        Wire.requestFrom(42, 1);
        delay(30);
        while (Wire.available())
        {
          Serial.print((char)Wire.read());
        }
        break;
        
      case 24:
        Wire.endTransmission();
        Wire.requestFrom(42, 1);
        delay(30);
        while (Wire.available())
        {
          Serial.print((char)Wire.read());
        }
        break;
    }
    command = false;
    delay(1000);
  }
}
