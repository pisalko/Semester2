#include <SoftwareSerial.h>

#define RX_PIN 12
#define TX_PIN 13
#define LEDR 7
#define LEDG 8

const int sizeBuff = 8; //Change only this if buffer needs to be larger
char modeNow = '6';

SoftwareSerial ss(RX_PIN, TX_PIN);
unsigned long long timeNow = 0;

void turnOffLEDs()
{
  digitalWrite(LEDG, LOW);
  digitalWrite(LEDR, LOW);
}

void ssFlush()
{
  while (ss.read() >= 0);
}

/*void returnOk (String bufff)
{
  char f = bufff[sizeBuff];
  Serial.println(f);
  if (f == '>')
  {
    ss.print("<OK>");
    Serial.println("data sent to ss - <OK>");
  }
}

String readIntoBuffer()
{
  int buffPlace = 0;
  char buff[sizeBuff];
  while (ss.available())
  {
    buff[buffPlace] = ss.read();
    buffPlace++;
  }
  String vale = buff;
  returnOk(buff);
  return vale;
}

char readSS()
{
  String ssReadAsString = readIntoBuffer();
  //Serial.println(ssReadAsString[sizeBuff - 1]);
  return ssReadAsString[sizeBuff - 2];
}*/

char readSS()
{
  //delay(10);
  char buffi[sizeBuff];
  int counteri = 0;
  while (ss.available())
  {
    //delay(10);
    if (counteri >= sizeBuff)
    {
      Serial.println("Message length too large for buffer ? Unexpected message!");
      break;
    }
    else
    {
      char c = ss.read();
      buffi[counteri] = c;
      Serial.print(buffi[counteri]);
      if (buffi[counteri] == '>')
      {
        ss.print("<OK>");
        Serial.println("data sent to ss - <OK>");
        //Serial.println(buffi);
        //buffi[counteri] = '=';
        
        if (buffi[counteri - 1] ==  '1' || buffi[counteri - 1] ==  '2' || buffi[counteri - 1] ==  '3' || buffi[counteri - 1] ==  '4' || buffi[counteri - 1] ==  '5' || buffi[counteri - 1] ==  '6')
        {
          //Serial.println(buffi[counteri - 1]);
          return buffi[counteri - 1];
        }
        else
          break;
      }
    }
    counteri++;
  }
  return '0';
}

bool checkForMode()
{
  if (ss.available())
    return true;
  else
    return false;
}

void delayWithCheck(int interval)
{
  timeNow = millis();
  while (millis() < timeNow + interval)
  {
    if (checkForMode())
    {
      //turnOffLEDs();
      char c = readSS();
      if (!(c == '0'))
        modeNow = c;
      break;
    }
  }
}

void setup() {
  ss.begin(9600);
  Serial.begin(9600); //debugging
  pinMode(LEDR, OUTPUT);
  pinMode(LEDG, OUTPUT);
}

void loop() {
turnOffLEDs();
  char c = readSS();
  if (!(c == '0'))
    modeNow = c;

    Serial.println(modeNow);

  switch (modeNow)
  {
    case '1':
      //key 1 = MASTER START with GREEN, hold GREEN 2 seconds continue RED & cycle
      //SLAVE START with RED, hold RED 2 seconds continue GREEN & cycle
      digitalWrite(LEDG, LOW);
      digitalWrite(LEDR, HIGH);
      delayWithCheck(2000);
      digitalWrite(LEDR, LOW);
      digitalWrite(LEDG, HIGH);
      delayWithCheck(2000);
      break;

    case '2':
      //key 2 = MASTER & SLAVE switch to RED until other mode
      digitalWrite(LEDR, HIGH);
      digitalWrite(LEDG, LOW);
      break;

    case '3':
      //key 3 = MASTER & SLAVE switch to GREEN until other mode.
      digitalWrite(LEDG, HIGH);
      digitalWrite(LEDR, LOW);
      break;

    case '4':
      //key 4 = MASTER START with GREEN, hold GREEN 5 seconds continue RED & cycle
      //SLAVE START with RED, hold RED 5 seconds continue GREEN & cycle
      digitalWrite(LEDG, LOW);
      digitalWrite(LEDR, HIGH);
      delayWithCheck(5000);
      digitalWrite(LEDR, LOW);
      digitalWrite(LEDG, HIGH);
      delayWithCheck(5000);

      break;

    case '5':
      //key 5 = MASTER START with GREEN, hold GREEN 10 seconds continue RED & cycle
      //SLAVE START with RED, hold RED 10 seconds continue GREEN & cycle
      digitalWrite(LEDG, LOW);
      digitalWrite(LEDR, HIGH);
      delayWithCheck(10000);
      digitalWrite(LEDR, LOW);
      digitalWrite(LEDG, HIGH);
      delayWithCheck(10000);
      break;

    case '6':
      //key 6 = BOTH MASTER & SLAVE turn off ALL lights.
      turnOffLEDs();
      break;
  }
}
//ARDUINO UNO

//protocol:
// Start message - <
//payload
//{
//  commands - mode, OK (when command is ok message looks like "<OK>")
//  separator - =
//  parameter - an Integer 1-6
//}
// end of message - >
