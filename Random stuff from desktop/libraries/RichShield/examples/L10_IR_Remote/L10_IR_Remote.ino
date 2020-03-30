#include "Display.h"
#include "IRremote.h"

IRreceive IR;

void setup() {
  // put your setup code here, to run once:
  IR.enableIRIn();
}

void loop() {
  // put your main code here, to run repeatedly:
  if(IR.decode())
  {
    if (IR.isReleased())
    {
      Display.show(IR.keycode);
    }
  }
}
