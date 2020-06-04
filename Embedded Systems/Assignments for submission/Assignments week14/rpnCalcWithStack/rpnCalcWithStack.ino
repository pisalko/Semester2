/*
   Commands include:
   <any float number>,
   +, -, *, /,
   r(square root),
   p(1/x),
   new(new equation),
   ce(clear everything),
   cres(check results),
   cinp(check inputs),
   mav(moving average)
*/


#include <Stack.h>
#define queueLength 6

Stack stackInput("Input");
Stack stackResults("Results");

void setup()
{
  Serial.begin(9600);
}

void loop()
{
  while (Serial.available())
  {
    String s = Serial.readString();
    s.trim();


    if (s == "+")
    {
      double second;
      int status = stackInput.stack_top(&second);
      if(CheckTopPop(status)) return;
      status = stackInput.stack_pop(&second);
      if(CheckTopPop(status)) return;
      double first;
      status = stackInput.stack_pop(&first);
      if(CheckTopPop(status)) return;
      double res = first + second;
      status = stackInput.stack_push(&res);
      if(CheckPush(status)) return;
      int counter = stackInput.stack_display(true);
    }


    else if (s == "-")
    {
      double second;
      int status = stackInput.stack_top(&second);
      if(CheckTopPop(status)) return;
      status = stackInput.stack_pop(&second);
      if(CheckTopPop(status)) return;
      double first;
      status = stackInput.stack_pop(&first);
      if(CheckTopPop(status)) return;
      double res = first - second;
      status = stackInput.stack_push(&res);
      if(CheckPush(status)) return;
      int counter = stackInput.stack_display(true);
    }


    else if (s == "*")
    {
      double second;
      int status = stackInput.stack_top(&second);
      if(CheckTopPop(status)) return;
      status = stackInput.stack_pop(&second);
      if(CheckTopPop(status)) return;
      double first;
      status = stackInput.stack_pop(&first);
      if(CheckTopPop(status)) return;
      double res = first * second;
      status = stackInput.stack_push(&res);
      if(CheckPush(status)) return;
      int counter = stackInput.stack_display(true);
    }


    else if (s == "/")
    {
      double second;
      int status = stackInput.stack_top(&second);
      if(CheckTopPop(status)) return;
      status = stackInput.stack_pop(&second);
      if(CheckTopPop(status)) return;
      double first;
      status = stackInput.stack_pop(&first);
      if (CheckTopPop(status)) return;
      double res = first / second;
      status = stackInput.stack_push(&res);
      if (CheckPush(status)) return;
      int counter = stackInput.stack_display(true);
    }


    else if (s == "r") //square .root
    {
      double top;
      int status = stackInput.stack_top(&top);
      if (CheckTopPop(status)) return;
      status = stackInput.stack_pop(&top);
      if (CheckTopPop(status)) return;
      double res = sqrt(top);
      status = stackInput.stack_push(&res);
      if (CheckPush(status)) return;
      int counter = stackInput.stack_display(true);
    }


    else if (s == "p") //power (of -1)
    {
      double top;
      int status = stackInput.stack_top(&top);
      if (CheckTopPop(status)) return;
      status = stackInput.stack_pop(&top);
      if (CheckTopPop(status)) return;
      double res = pow(top, -1);
      status = stackInput.stack_push(&res);
      if (CheckPush(status)) return;
      int counter = stackInput.stack_display(true);
    }


    else if (s.startsWith("0") ||
             s.startsWith("1") ||
             s.startsWith("2") ||
             s.startsWith("3") ||
             s.startsWith("4") ||
             s.startsWith("5") ||
             s.startsWith("6") ||
             s.startsWith("7") ||
             s.startsWith("8") ||
             s.startsWith("9"))
    {

      double d = s.toFloat();
      int status = stackInput.stack_push(&d);
      if (CheckPush(status)) return;
      int counter = stackInput.stack_display(true);
    }


    else if (s == "new")   //Command for new equation
    {
      int counter = stackInput.stack_display(false);
      if (counter == 0 || counter == 1)
      {
        Serial.println(F("Resetting the stack and expecting next equation!"));
        double res;
        stackInput.stack_pop(&res);
        stackResults.stack_push(&res);
        stackInput.stack_destroy();
        stackInput.stack_create();
      }
      else if (counter > 1)
      {
        Serial.println(F("There is more than 1 number in stack, please finish the equation."));
        stackInput.stack_display(true);
      }
    }


    else if (s == "ce")   //Command for Clear Everything
    {
      Serial.println(F("Resetting the stack and expecting next equation!"));
      stackInput.stack_destroy();
      stackInput.stack_create();
    }


    else if (s == "cres")   //Command to display all sttored results
    {
      Serial.println(F("These are the stored results: "));
      stackResults.stack_display(true);
    }


    else if (s == "cinp")   //Command to display all inputs so far
    {
      Serial.println(F("These are the stored inputs: "));
      stackInput.stack_display(true);
    }


    else if (s == "mav")   //Command to put calc in Moving Average mode
    {
      Serial.println(F("Please enter exactly 6 doubles in the format d d d d d d "));
      while(Serial.available() < 1)
      {
        delay(50);
        if(Serial.available())
        {
          double doublesQueue[queueLength];
          String ss = Serial.readString();
          for(int i = 0; i < queueLength; i++)
          {
            doublesQueue[i] = ss.toDouble();
            ss = ss.substring(ss.indexOf(' ') + 1);
          }
          Serial.print(F("The simple moving average of these numbers is: "));
          double result = 0;
          for(int i = 0; i < queueLength; i++)
          {
            result += doublesQueue[i];
          }
          result /= queueLength;
          Serial.println(result);
          break;
        }
      }
    }


    else
    {
      Serial.println(F("Invalid input!"));
      return;
    }
  }
}

bool CheckTopPop(int s)
{
  if (s == -1)
  {
    Serial.println(F("Stack is empty. Please add elements first."));
    return true;
  }
  else if (s == -2)
  {
    Serial.println(F("Please call stack_create() first. Stack is nonexistent."));
    return true;
  }
  return false;
}

bool CheckPush(int s)
{
  if (s == -1)
  {
    Serial.println(F("Please call stack_create() first. Stack is nonexistent."));
    return true;
  }
  else if (s == -2)
  {
    Serial.println(F("Not enough memory, will create a stack overflow"));
    return true;
  }
  return false;
}
