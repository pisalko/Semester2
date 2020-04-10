#include <Wire.h>

byte address;

void setup() {
  Wire.begin();
  Serial.begin(9600);
}

void loop() {
  String c = "";
  while (Serial.available())
  {
    c = Serial.readString();
    c.trim();
    if ( c.startsWith("w"))
    {
      short index = 0;
      c = c.substring(1);
      for (int i = 0; i < c.length(); i++)
      {
        if (c[i] == '=')
        {
          index = i;
          break;
        }
      }
      address = (byte)c.substring(0, index).toInt();
      if ((int)address == 21 || (int)address == 22)
      {
        byte assignedValue = (byte)c.substring(index + 1, c.length()).toInt();
        Wire.beginTransmission(42);
        Wire.write(address);
        Wire.endTransmission();
        Wire.beginTransmission(42);
        Wire.write(assignedValue);
        Wire.endTransmission();
      }
      else
      {
        Wire.beginTransmission(42);
        Wire.write(address);
        Wire.endTransmission();
        Wire.requestFrom(42, 1);
        while (Wire.available())
        {
          Serial.print((int)Wire.read());
        }
        Serial.println();
      }
    }
    else if ( c.startsWith("r"))
    {
      c = c.substring(1);
      address = (byte)c.toInt();
      Wire.beginTransmission(42);
      Wire.write(address);
      Wire.endTransmission();
      Wire.requestFrom(42, 1);
      while (Wire.available())
      {
        Serial.print((int)Wire.read());
      }
      Serial.println();
    }
  }
}
