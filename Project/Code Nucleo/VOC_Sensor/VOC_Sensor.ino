#include <Wire.h>
#define sAddressVOC 0x5a

void setup() {
  Serial.begin(9600);
  Wire.begin();
  delay(1000);
}


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
    *co2Prediction = (int)(byteBuffer[0]<<8) | (byteBuffer[1]<<0);;
    *etvoc = (byteBuffer[7]<<8) | (byteBuffer[8]<<0);
    *statuss = (int)byteBuffer[2];
  } 
}


void loop() {
  uint16_t v,vv;
  int s;
  ValuesVOC(&v,&vv,&s);
  Serial.println(v);
  Serial.println(vv);
  Serial.println(s);
  delay(1000);
}
