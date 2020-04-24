unsigned long long debounceTimer = 0;
bool lock = true;

void setup() {
  Serial.begin(9600);
  DDRB &= ~_BV(2) | ~_BV(3);  //pinMode(D10D11, INPUT);
  PORTB |= _BV(2) | _BV(3);   //enabling the pullup resistor
  DDRD |= _BV(5) | _BV(6);    //pinMode(D5D6, OUTPUT);
  debounceTimer = millis();
}

void LedBlink(bool *btnOneState, bool *btnTwoState)
{
  while (*btnTwoState == 0 && *btnOneState == 0)
  {
    *btnOneState = (PINB & _BV(2)) >> 2;
    *btnTwoState = (PINB & _BV(3)) >> 3;
    PORTD |= _BV(5) | _BV(6);
    delay(random(50,1000));           //LEDs blinking every 500 millisec
    PORTD &= ~_BV(5) & ~_BV(6);       //with an alternating pattern
    delay(500);
  }
  PORTD &= ~_BV(5) & ~_BV(6);         //making sure they are off, not needed
}

void loop() {
  if (millis() - debounceTimer < 50)  //Debounce method, executes code every 50 milliseconds
  {                                   //Average "bouncing period" is between 5-20 milliseconds,
    return;                           //but for the sake of sureness, I make it run every 50.
  }                                   //An alternative is to check the button state 20 millisec
  else                                //after the initial state check.
  {
    debounceTimer = millis();
  }
  bool btnOneState = (PINB & _BV(2)) >> 2; // returns 0 if pressed /pullup resistor/
  bool btnTwoState = (PINB & _BV(3)) >> 3; // returns 0 if pressed /pullup resistor/

  if (btnOneState == 0 && btnTwoState != 0)
  {
    PORTD |= _BV(5);
    return;
  }
  else
  {
    PORTD &= ~_BV(5);
  }

  if (btnTwoState == 0 && btnOneState != 0)
  {
    PORTD |= _BV(6);
    if (lock)
    {
      Serial.print(F("Hello World!"));
      lock = false;
    }
    return;
  }
  else
  {
    PORTD &= ~_BV(6);
    lock = true;
  }
  LedBlink(&btnOneState, &btnTwoState);
} 
