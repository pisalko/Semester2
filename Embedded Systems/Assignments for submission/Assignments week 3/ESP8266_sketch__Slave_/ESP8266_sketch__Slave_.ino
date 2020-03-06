#include <SoftwareSerial.h>

#define RX_PIN D7
#define TX_PIN D8
#define LEDR D3
#define LEDG D2

SoftwareSerial s(RX_PIN, TX_PIN);
bool beginGreenLight = false;

void setup() {
  s.begin(9600);
  pinMode(LEDR, OUTPUT);
  pinMode(LEDG, OUTPUT);
}

void loop() {
  if (s.available())
  {
    char c = s.read();
    if (c == '<')
    {
      char buff[2];
      for (int i = 0; i < 2; i++)
      {
        buff[i] = s.read();
      }
      if (buff[0] == 'G' && buff[1] == 'O')
      {
        beginGreenLight = true;
      }
    }
    else if (c == '>');
  }

  if (beginGreenLight)
  {
    digitalWrite(LEDR, LOW);
    digitalWrite(LEDG, HIGH);
    delay(4980);
    s.print("<GO>");
    delay(15);
    digitalWrite(LEDG, LOW);
    digitalWrite(LEDR, HIGH);
    beginGreenLight = false;
  }
}
//ESP8266
