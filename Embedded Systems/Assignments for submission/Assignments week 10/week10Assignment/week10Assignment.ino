volatile bool btnClick, key1State, key1Click, key2State, key2Click;
volatile bool halfByte[4];
volatile unsigned long long pciTime, lastTimer = 0;
bool builtinLedState = false;

void setup()
{
  pinMode(LED_BUILTIN, OUTPUT);
  for (int i = 0; i < 4; i++) halfByte[i] = random(0, 1);                 //creating my number
  cli();                                                                  // disable interrupts *explained why in previous assignment*
  DDRB |= _BV(DDB2) | _BV(DDB3) | _BV(DDB0) |  _BV(DDB1);                 //pinMode(D10D11, OUTPUT);
  PORTB &= ~_BV(PORTB2) & ~_BV(PORTB3) & ~_BV(PORTB0) & ~_BV(PORTB1);     //setting output to low
  DDRD &= ~_BV(DDD5) & ~_BV(DDD6);                                        //pinMode(D5D6, INPUT);
  PORTD |= _BV(PORTD5) | _BV(PORTD6);                                     //pullup resistors activated
  PCICR |= _BV(PCIE2);                                                    //enabling pin change interupts
  PCMSK2 |= _BV(PCINT21) | _BV(PCINT22);                                  //enabling pci for pins 5 & 6 on PORTD

  TCCR1A = 0;
  TCNT1  = 0;                                                             // initialize counter value to 0
  OCR1A = 62499;                                                          // timer interrupts every 250ms
  TCCR1B = _BV(WGM12) | _BV(CS11) | _BV(CS10);                            //Set CS11, CS10 for a prescaler of 64, Set CTC mode
  TCCR1B &= ~_BV(CS12);                                                   // Unset CS12
  TIMSK1 |= _BV(OCIE1A);                                                  // enable timer compare interrupt (what we use)
  sei();                                                                  // allow interrupts
}

void loop() {
  if (millis() < pciTime + 100) return;                                   //debouncing
  else pciTime = millis();

  if (btnClick) btnClick = false;
  else return;
    cli();
  if (key1State == 0 && key2State == 1 && key1Click)                      //increase speed of LEDs button 5
  {
    if (OCR1A > 10000)
      OCR1A -= 10000;
    else if (OCR1A > 5000)
      OCR1A -= 5000;
    else if (OCR1A > 3000)
      OCR1A -= 3000;
    else if (OCR1A > 1000)
      OCR1A -= 1000;
    else if (OCR1A > 500)
      OCR1A -= 500;
    else if (OCR1A > 100)
      OCR1A -= 100;
      sei();
    return;
  }

  if (key2State == 0 && key1State == 1 && key2Click)                        //deacrese speed of LEDs button 6
  {
    if (OCR1A < 55535)
      OCR1A += 10000;
    else if (OCR1A < 60535)
      OCR1A += 5000;
    else if (OCR1A < 62535)
      OCR1A += 3000;
    else if (OCR1A < 64535)
      OCR1A += 1000;
    else if (OCR1A < 65000)
      OCR1A += 500;
    else if (OCR1A < 65300)
      OCR1A += 100;
      sei();
    return;
  }
  sei();
}

ISR(TIMER1_COMPA_vect) {
  if(millis() >= lastTimer + 900)    //bonus code                            not 1000 because of execution time and other timer operations, I did testing
  {
    builtinLedState = !builtinLedState;
    digitalWrite(LED_BUILTIN, builtinLedState);
    lastTimer = millis();
  }
  
  for (int i = 0; i < 4; i++)
  {
    halfByte[i] = random(0, 2);                                             //shuffling my number for a "new halfByte, 4 bits"
    if (halfByte[i] == 1)
      PORTB |= _BV(i);
    else
      PORTB &= ~_BV(i);
  }
}

ISR(PCINT2_vect)                                                            //called on PCI occurance for PORTB(Block 0) pins | I used this code from my previous assignment
{
  pciTime = millis();                                                       //debouncing
  btnClick = true;
  key1State = (PIND & _BV(PIND5)) >> 5; analogRead(5);                                     // returns 0 if pressed
  key2State = (PIND & _BV(PIND6)) >> 6;                                     // returns 0 if pressed
  if (!key1State == 0)key1Click = true;                                     //making sure its on a falling edge
  if (!key2State == 0)key2Click = true;
}
