#include <SoftwareSerial.h>

#define RX_PIN 3
#define TX_PIN 4
#define LEDR 12
#define LEDG 11
#define KEY1 A0 //I am using a capacitive touch sensor (8 of them) as a keypad for controls and inputs
#define KEY2 A1
#define KEY3 A2
#define KEY4 A3
#define KEY5 A4
#define KEY6 A5
#define KEY7 A6
#define KEY8 A7

SoftwareSerial ss(RX_PIN, TX_PIN);

unsigned long long debounceTimer, timeNow = 0;
bool key1State, key1OldState, key2State, key2OldState, key3State, key3OldState,
     key4State, key4OldState, key5State, key5OldState, key6State, key6OldState = true;
bool key1Click, key2Click, key3Click, key4Click, key5Click, key6Click, clickInLoop = false;
int modeNow = 6;
int counterOKChecks = 0;


bool checkForClicks()
{
  key1State = digitalRead(KEY1); //reading key Values to check for changes
  key2State = digitalRead(KEY2);
  key3State = digitalRead(KEY3);
  key4State = digitalRead(KEY4);
  key5State = digitalRead(KEY5);
  key6State = digitalRead(KEY6);

  key1Click = keyXClick(&key1State, &key1OldState);
  key2Click = keyXClick(&key2State, &key2OldState);
  key3Click = keyXClick(&key3State, &key3OldState);
  key4Click = keyXClick(&key4State, &key4OldState);
  key5Click = keyXClick(&key5State, &key5OldState);
  key6Click = keyXClick(&key6State, &key6OldState);
  
  return key1Click || key2Click || key3Click || key4Click || key5Click || key6Click;
}

void turnOffLEDs()
{
  digitalWrite(LEDG, LOW);
  digitalWrite(LEDR, LOW);
}

void changeMode()
{
  turnOffLEDs();
  if (key1Click && !key1State) //Executing code once when pressed & released Key1
  {
    //key 1 = MASTER START with GREEN, hold GREEN 2 seconds continue RED & cycle
    //SLAVE START with RED, hold RED 2 seconds continue GREEN & cycle
    Serial.println("key1 pressed");
    modeNow = 1;
    Serial.println("<mode=1>");
    ssPrintWithCheck("<mode=1>");
  }
  //-------------------------------------------------------------------------------
  else if (key2Click && !key2State) //Executing code once when pressed & released Key2
  {
    //key 2 = MASTER & SLAVE switch to RED until other mode
    Serial.println("key2 pressed");
    modeNow = 2;
    Serial.println("<mode=2>");
    ssPrintWithCheck("<mode=2>");
  }
  //-------------------------------------------------------------------------------
  else if (key3Click && !key3State) //Executing code once when pressed & released Key3
  {
    //key 3 = MASTER & SLAVE switch to GREEN until other mode.
    Serial.println("key3 pressed");
    modeNow = 3;
    Serial.println("<mode=3>");
    ssPrintWithCheck("<mode=3>");
  }
  //-------------------------------------------------------------------------------
  else if (key4Click && !key4State) //Executing code once when pressed & released Key4
  {
    //key 4 = MASTER START with GREEN, hold GREEN 5 seconds continue RED & cycle
    //SLAVE START with RED, hold RED 5 seconds continue GREEN & cycle
    Serial.println("key4 pressed");
    modeNow = 4;
    Serial.println("<mode=4>");
    ssPrintWithCheck("<mode=4>");
  }
  //-------------------------------------------------------------------------------
  else if (key5Click && !key5State) //Executing code once when pressed & released Key5
  {
    //key 5 = MASTER START with GREEN, hold GREEN 10 seconds continue RED & cycle
    //SLAVE START with RED, hold RED 10 seconds continue GREEN & cycle
    Serial.println("key5 pressed");
    modeNow = 5;
    Serial.println("<mode=5>");
    ssPrintWithCheck("<mode=5>");
  }
  //-------------------------------------------------------------------------------
  else if (key6Click && !key6State) //Executing code once when pressed & released Key6
  {
    //key 6 = BOTH MASTER & SLAVE turn off ALL lights.
    Serial.println("key6 pressed");
    modeNow = 6;
    Serial.println("<mode=6>");
    ssPrintWithCheck("<mode=6>");
  }

}

void delayWithCheck(int interval)
{
  timeNow = millis();
  while (millis() < timeNow + interval)
  {
    if (checkForClicks())
    {
      changeMode();
      turnOffLEDs();
      return;
    }
  }
}

bool keyXClick(bool *keyState, bool *keyOldState) //Improvised Universal StateChange Machine
{
  if (*keyState != *keyOldState)
  {
    *keyOldState = *keyState;
    return true;
  }
  else
  {
    return false;
  }
}

bool waitForOKDIY()
{
  delay(30); //Allowing the microproccessors some time to understand the data and work with it
  while (ss.available())
  {
    if (ss.read() == '<')
    {
      if (ss.read() == 'O')
        if (ss.read() == 'K')
          if (ss.read() == '>') return true;
    }
    else
    {
      return false;
    }
  }
  return false;
}

void ssFlush()
{
  while (ss.read() >= 0);
}

void ssPrintWithCheck(String printData)
{
  ss.print(printData);
  delay(20);  
  if (waitForOKDIY())
  {
    Serial.println("OK Received!");
    counterOKChecks = 0;
  }
  else
  {
    if (counterOKChecks == 5)
    {
      Serial.println("OK NOT Received 5 times in a row!");
      counterOKChecks = 0;
    }
    else
    {
      Serial.println("OK NOT Received! Sending data again !");
      counterOKChecks++;     
      ssPrintWithCheck(printData);      
    }
  }
}

void setup() {
  Serial.begin(9600); //debugging
  ss.begin(9600);
  pinMode(LEDR, OUTPUT);
  pinMode(LEDG, OUTPUT);
  pinMode(KEY1, INPUT_PULLUP);
  pinMode(KEY2, INPUT_PULLUP);
  pinMode(KEY3, INPUT_PULLUP);
  pinMode(KEY4, INPUT_PULLUP);
  pinMode(KEY5, INPUT_PULLUP);
  pinMode(KEY6, INPUT_PULLUP);
  pinMode(KEY7, INPUT_PULLUP);
  pinMode(KEY8, INPUT_PULLUP);
  debounceTimer = millis();
}

void loop() {
  //Debounce method is not needed since -
  //1. This is not a mechanical switch/button and therefore there is a lot less "bouncing".
  //2. I checked the sensor's datasheet and apparently there is some on-board debouncing done on the module itself. (I tested it too)
  if (checkForClicks());
  //-------------------------------------------------------------------------------
  changeMode();
  //-------------------------------------------------------------------------------
  switch (modeNow)
  {
    case 1:
      //key 1 = MASTER START with GREEN, hold GREEN 2 seconds continue RED & cycle
      //SLAVE START with RED, hold RED 2 seconds continue GREEN & cycle
      digitalWrite(LEDG, HIGH);
      digitalWrite(LEDR, LOW);
      delayWithCheck(2000);
      digitalWrite(LEDR, HIGH);
      digitalWrite(LEDG, LOW);
      delayWithCheck(2000);
      break;

    case 2:
      //key 2 = MASTER & SLAVE switch to RED until other mode
      digitalWrite(LEDR, HIGH);
      digitalWrite(LEDG, LOW);
      //delayWithCheck(15);

      break;

    case 3:
      //key 3 = MASTER & SLAVE switch to GREEN until other mode.
      digitalWrite(LEDG, HIGH);
      digitalWrite(LEDR, LOW);
      //delayWithCheck(10);
      break;

    case 4:
      //key 4 = MASTER START with GREEN, hold GREEN 5 seconds continue RED & cycle
      //SLAVE START with RED, hold RED 5 seconds continue GREEN & cycle
      digitalWrite(LEDG, HIGH);
      digitalWrite(LEDR, LOW);
      delayWithCheck(5000);
      digitalWrite(LEDR, HIGH);
      digitalWrite(LEDG, LOW);
      delayWithCheck(5000);

      break;

    case 5:
      //key 5 = MASTER START with GREEN, hold GREEN 10 seconds continue RED & cycle
      //SLAVE START with RED, hold RED 10 seconds continue GREEN & cycle
      digitalWrite(LEDG, HIGH);
      digitalWrite(LEDR, LOW);
      delayWithCheck(10000);
      digitalWrite(LEDR, HIGH);
      digitalWrite(LEDG, LOW);
      delayWithCheck(10000);
      break;

    case 6:
      //key 6 = BOTH MASTER & SLAVE turn off ALL lights.
      turnOffLEDs();
      //delayWithCheck(10);
      break;
  }
  turnOffLEDs();
}



//ARDUINO NANO

//protocol:
// Start message - <
//payload
//{
//  commands - mode, OK (when command is ok message looks like "<OK>")
//  separator - =
//  parameter - an Integer 1-6
//}
// end of message - >
