#include <SoftwareSerial.h>

#define RX_PIN 7
#define TX_PIN 8
#define LEDR 13
#define LEDG 12
#define BTN 4

SoftwareSerial s(RX_PIN, TX_PIN);
bool beginGreenLight = true;
bool startBool = false;

void setup() {
  Serial.begin(9600);
  s.begin(9600);
  pinMode(LEDR, OUTPUT);
  pinMode(LEDG, OUTPUT);
  pinMode(BTN, INPUT_PULLUP);
}

void loop() {
  bool btn = digitalRead(BTN);
  if(!btn) startBool = true;
  
  if (startBool == true)
  {
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
      Serial.println("here");
      digitalWrite(LEDR, LOW);
      digitalWrite(LEDG, HIGH);
      delay(2540);
      s.print("<GO>");
      delay(15);
      digitalWrite(LEDG, LOW);
      digitalWrite(LEDR, HIGH);
      beginGreenLight = false;
      delay(2540);
    }
  }
}
//ARDUINO

//protocol:
// Start message - <
//command - GO
// end of message - >
