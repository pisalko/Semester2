#include <Wire.h>

int i;
byte a,b,c,d;

void setup() {
  Wire.begin(42);                
  Wire.onReceive(receiveEvent); 
  Wire.onRequest(requestEvent);
  Serial.begin(9600);           
}

void loop() {}

void receiveEvent() {
  int howMany = 0;
  while (0 < Wire.available()) { 
    i = Wire.read(); 
    Serial.print((char)i);       
    howMany++;
  }
  Serial.print("\nThe i2c bus received ");
  Serial.print(howMany);
  Serial.println(" bytes.");
}

void requestEvent() {
  if(i > 100)
  Wire.write('2');
  else
  Wire.write('4');
}
