#include <Wire.h>

void setup() {
  Wire.begin();
  Serial.begin(9600);
}

void loop() {
  char c;
  if (Serial.available())
  {
    c = Serial.read();
    if(c == '\n')
    return;
    Wire.beginTransmission(42);
    Wire.write(c);
    Wire.endTransmission();
    Wire.requestFrom(42, 1);
    delay(30);
    while (Wire.available())
    {
      Serial.print((char)Wire.read());
    }
    delay(1000);
  }
}
