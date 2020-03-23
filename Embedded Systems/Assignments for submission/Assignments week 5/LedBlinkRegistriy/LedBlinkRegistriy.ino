void setup() {
  DDRB = DDRB | (1 << 2); //pinMode(10, OUTPUT);
  }

  //LED on for 2000 millisec
  //LED off for 3000 millisec
  void loop() {
  PORTB = PORTB | (1 << 2); //digitalWrite(10, HIGH); turn on led on pin 10
  delay(2000);
  PORTB = PORTB ^ (1 << 2);//digitalWrite(10, LOW); turn off led on pin 10
  delay(3000);
  }
