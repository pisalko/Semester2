#include <SoftwareSerial.h>

SoftwareSerial ss(A5, A4);
void setup() {
  // put your setup code here, to run once:
Serial.begin(9600);
ss.begin(9600);
pinMode(D10, OUTPUT);
pinMode(9, OUTPUT);

}

void loop() {
  // put your main code here, to run repeatedly:
digitalWrite(D10, LOW);
digitalWrite(9, HIGH);

}
