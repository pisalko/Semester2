#include <Wire.h>
#define sAddress 0x5a

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  Wire.begin();
  Wire.beginTransmission(sAddress);
  Wire.write(0xB5);
  Wire.endTransmission();
  delay(1000);
}

void loop() {
  // put your main code here, to run repeatedly:
  Wire.requestFrom(sAddress, 9);
  byte byteBuffer[9];
  int counter = 0;
  while (Wire.available())
  {
    byteBuffer[counter] = Wire.read();
    Serial.println((char)byteBuffer[counter]);
    counter++;
  }
  Serial.println();
  delay(1000);
}
