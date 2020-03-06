#include <Arduino.h>
#include <Wire.h>
#include <SoftwareSerial.h>

const int RX = 7;
const int TX = 8;

SoftwareSerial s(7,8);

void setup()
{
  s.begin(9600);
  Serial.begin(9600);
}

void loop()
{
  if (Serial.available() > 0)
  {
    char letter = '\n';
    letter = Serial.read();
    Serial.print(letter);
    s.print(letter);
  }
}