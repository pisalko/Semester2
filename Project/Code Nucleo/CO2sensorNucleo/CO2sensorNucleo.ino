#include <SoftSerial.h>

SoftSerial ss(D12, D13, 3); // A5, A4 original, rerouted to D12 and D13

int CO2ppmValue()
{
  ss.write(0x11);
  ss.write(0x01);
  ss.write(0x01);
  ss.write(0xED);
  delay(50);
  int ppmValue = 0;
  if(ss.available())
  {
    ss.read();
    ss.read();
    ss.read();
    ppmValue = (int)ss.read()*256+(int)ss.read();
    ss.read();
    ss.read();
    ss.read();
  }
  return ppmValue;
}

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  ss.begin(9600);
}

void loop() {
  Serial.println(CO2ppmValue());
  delay(2000);
}
