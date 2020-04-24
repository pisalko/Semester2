volatile unsigned long long timestamp = 0, icuTime = 0;
volatile bool key1State, key1Click, key2State, key2Click, icuClick, ledBlink;


void setup() {
  Serial.begin(9600);
  cli();                          //disabling global interupts*
  DDRB &= ~_BV(2) | ~_BV(3);      //pinMode(D10D11, INPUT);
  PORTB |= _BV(2) | _BV(3);       //enabling the pullup resistor
  DDRD |= _BV(5) | _BV(6);        //pinMode(D5D6, OUTPUT);
  PCICR |= _BV(0);                //enabling pin change interupts
  PCMSK0 |= _BV(2) | _BV(3);      //enabling pci for pins 10,11
  sei();                          //enabling back up global interupts
}
/*
    Disabling global interupts is vital when you are setting up
   other interupts. Why ? Because if an interupt occurs before you
   are done setting up the interupts you want, it might not function
   as intended and might even break.
*/
void loop()
{
  if (ledBlink) //blinking the LEDs
  {
    short blinkDur = random(600, 1200);
    if (millis() - timestamp < blinkDur && millis() - timestamp > 500)
    {
      PORTD |= _BV(5);
      PORTD |= _BV(6);
    }
    else if (millis() - timestamp < 1500 && millis() - timestamp > blinkDur)
    {
      PORTD &= ~_BV(5);
      PORTD &= ~_BV(6);
      timestamp = millis();
    }
  }

  if (millis() < icuTime + 100) return; //debouncing
  else icuTime = millis();

  if (icuClick) icuClick = false;
  else return;

  ledBlink = false;
  if (key1State == 0 && key2State == 1 && key1Click)
  {
    PORTD ^= _BV(5);
    key1Click = false;
    return;
  }

  if (key2State == 0 && key1State == 1 && key2Click)
  {
    PORTD ^= _BV(6);
    Serial.println(F("Hello World!"));
    key2Click = false;
    return;
  }

  if (key2State == 0 && key1State == 0)
  {
    ledBlink = true;
    timestamp = millis();
  }

}

ISR(PCINT0_vect) //called on PCI occurance for PORTB(Block 0) pins
{
  icuTime = millis(); //debouncing
  icuClick = true;
  key1State = (PINB & _BV(2)) >> 2; // returns 0 if pressed
  key2State = (PINB & _BV(3)) >> 3; // returns 0 if pressed
  if (!key1State == 0)key1Click = true;  //making sure its on a fallign edge
  if (!key2State == 0)key2Click = true;
}
