#include <Wire.h>

byte address, a, b, c, d = 0;
short requesNm = 0;

void setup() {
  Wire.begin(42);
  Wire.onReceive(receiveEvent);
  Wire.onRequest(requestEvent);
  Serial.begin(9600);
}

void loop() {}

void receiveEvent() {
  requestNm++;
  while (0 < Wire.available())
  {
    if (requestNm == 1)
    {
      address = Wire.read();
    }
    if (requestNm == 2)
    {
      //switch s zavisi koi e adresa assign value to it
      requestNm = 0;
    }
  }
}

void requestEvent() {
  switch (address)
  {

  }
}
