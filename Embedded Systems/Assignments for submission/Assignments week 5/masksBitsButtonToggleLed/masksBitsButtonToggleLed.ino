#define pin7mask 0b01111111
#define ledManipulationMask 0b11111011

bool btnState, btnOldState, btnClick = false;
unsigned long long debounceTimer = 0;
uint8_t modeNow = 1;

void setup() {
  DDRB = DDRB | (1 << 2);                       //pinMode(10, OUTPUT);
  DDRD = DDRD & pin7mask;                       //pinMode(7, INPUT);        setting the pin to input
  PORTD = PORTD | (1 << 7);                     //pinMode(7, INPUT_PULLUP); enabling the inside pullup resistor since we are using it for a button
  debounceTimer = millis();
}

void loop() {
  //------------------------------------------------------
  if (millis() - debounceTimer < 50)            //Debounce method, executes code every 50 milliseconds
  {                                             //Average "bouncing period" is between 5-20 milliseconds,
    return;                                     //but for the sake of sureness, I make it run every 50.
  }
  else
  {
    debounceTimer = millis();
  }
  //------------------------------------------------------
  btnState = (PIND & ~pin7mask) >> 7;           //btn = digitalRead(7); Returns 0 if button is pressed and 1 if button is not pressed
  //------------------------------------------------------
  if (btnState != btnOldState)                  //StateChange Machine btn
  {
    btnOldState = btnState;
    btnClick = true;
  }//
  else
  { 
    btnClick = false;
  }
  //------------------------------------------------------
  if (btnClick && !btnState)                    //Executing code once when btn is pressed
  {
    modeNow = modeNow << 1;                     //shifting between the 2 modes using bitwise operations
    PORTB = PORTB | (1 << 2);                   //pinMode(10, HIGH); LED ON
    if (modeNow == 4)
    {
      modeNow = modeNow >> 2;                   //shifting between the 2 modes using bitwise operations
      PORTB = PORTB & ledManipulationMask;      //pinMode(10, LOW); LED OFF
    }
  }
}
