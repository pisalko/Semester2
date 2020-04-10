#include <Wire.h>

byte address, a, b, c, d = 0;
short requestNm = 0;

void setup() {
  Wire.begin(42);
  Wire.onReceive(receiveEvent);
  Wire.onRequest(requestEvent);
  Serial.begin(9600);
}

void loop() {}

void receiveEvent() {
  requestNm++;
  if (0 < Wire.available())
  {
    if (requestNm == 1)
    {
      address = Wire.read();
    }
    if (requestNm == 2)
    {
      switch ((int)address)
      {
        case 21:
          a = Wire.read();
          break;

        case 22:
          b = Wire.read();
          break;
      }
      requestNm = 0;
    }
  }
}

void requestEvent() {
  switch ((int)address)
  {
    case 21:
      Wire.write(a);
      Serial.println(a);
      break;
    case 22:
      Wire.write(b);
      Serial.println(b);
      break;
    case 23: //min of a,b
      Wire.write(min(a, b));
      Serial.println(min(a, b));
      break;
    case 24: //max of a,b
      Wire.write(max(a, b));
      Serial.println(max(a, b));
      break;
  }
  requestNm = 0;
}
