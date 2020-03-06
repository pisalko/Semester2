const int KEY1 = 7;
const int LEDDAY = 8;
const int LEDNIGHT = 11;

bool key1State = HIGH;                
bool key1OldState = HIGH;
bool key1Click = HIGH;

unsigned long long debounceTimer = 0;

short modeLed = 0;

void setup() {
  // put your setup code here, to run once:
  pinMode(KEY1, INPUT_PULLUP);
  pinMode(LEDDAY, OUTPUT);
  pinMode(LEDNIGHT, OUTPUT);

}

void loop() {
if (millis() - debounceTimer < 50)          //Debounce method
  {
    return;
  }
  else
  {
    debounceTimer = millis();
  }

  key1State = digitalRead(KEY1);                

 if ( key1State != key1OldState )      //If there is a change in the key1's state (pressed?), store a boolean that has a value of "true" (because a change occured)
  {
    key1OldState = key1State;           //Assign the new state of the Key1 to the old State of the Key1, so we can use it later (in the next check, when the program reruns)
    key1Click = true;                   //We register if there was a click or not (change)
  }
  else
  {
    key1Click = false;                  //In case there was no change
  }

//---------------------------------------------------------------------
  if(key1Click && !key1State)
  {
    modeLed++;
    if(modeLed == 2)
    modeLed = 0;
  }

  switch(modeLed)
  {
    case 0:
      digitalWrite(LEDDAY, HIGH);
      digitalWrite(LEDNIGHT, LOW);
    break;

    case 1:
      digitalWrite(LEDDAY, LOW);
      digitalWrite(LEDNIGHT, HIGH);
    break;
  }

}
