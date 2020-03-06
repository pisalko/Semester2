#include <Arduino.h>

#define LEDred       2
#define LEDgreen     4
#define numberLength 20  //How long the 2 numbers can be - 20 in this case. Please change only this number if bigger numbers are needed.

int charsRead = 0;
char firstNumber[numberLength];
int firstNumberCount = 0;
int firstNumberAsInt = 0;
char secondNumber[numberLength];
int secondNumberCount = 0;
int secondNumberAsInt = 0;
bool first = true;
bool second = false;
char operand = 'n';
int result = 0;
double dresult = 0;


void setup() {
  Serial.begin(9600);
  pinMode(LEDred, OUTPUT);
  pinMode(LEDgreen, OUTPUT);
  Serial.println("Input expressions in format: '<integer1><operator><integer2>='");
}

void Reset()
{
  first = true;
  second = false;
  firstNumber[numberLength];
  secondNumber[numberLength];
  firstNumberCount = 0;
  secondNumberCount = 0;
  firstNumberAsInt = 0;
  secondNumberAsInt = 0;
  charsRead = 0;
  result = 0;
  dresult = 0;
}

int Powdiy(int base, int power)
{
  int newNum = 1;
  for (int i = 0; i < power; i++)
    newNum *= base;
  return newNum;
}

void loop() {
  while (Serial.available() > 0)
  {
    char c = Serial.read();
    if (c != '\n')
    {
      digitalWrite(LEDgreen, LOW);
      digitalWrite(LEDred, LOW);
      if (c == '0' || c == '1' || c == '2' || c == '3' || c == '4' || c == '5' || c == '6' || c == '7' || c == '8' || c == '9')
      {
        if (first)
        {
          firstNumber[charsRead] = c;
          charsRead++;
          firstNumberCount = charsRead;
        }
        else if (second)
        {
          secondNumber[charsRead] = c;
          charsRead++;
          secondNumberCount = charsRead;
        }
      }
      else if (c == '+' || c == '-' || c == '*' || c == '/')
      {
        switch (c)
        {
            if (firstNumberCount > 0)
            {
            case '+':
              first = false;
              second = true;
              charsRead = 0;
              operand = '+';
              break;

            case '-':
              first = false;
              second = true;
              charsRead = 0;
              operand = '-';
              break;

            case '*':
              first = false;
              second = true;
              charsRead = 0;
              operand = '*';
              break;

            case '/':
              first = false;
              second = true;
              charsRead = 0;
              operand = '/';
              break;
            }
            else
            {
              Serial.println("Please enter a normal integer");
              Reset();
            }
        }

      }
      if (c == '=')
      {
        switch (operand)
        {

          case '+':
            for (int i = 0; i < firstNumberCount; i++)
            {
              int integ = (((int)(firstNumber[i])) - '0');
              if (integ == 0)
              {
                //We skip an iteration
              }
              else
              {
                integ *= Powdiy(10, (firstNumberCount - i) - 1);
                firstNumberAsInt += integ;
              }
            }
            for (int i = 0; i < secondNumberCount; i++)
            {
              int integ = (((int)(secondNumber[i])) - '0');
              if (integ == 0)
              {
                //We skip an iteration
              }
              else
              {
                integ *= Powdiy(10, (secondNumberCount - i) - 1);
                secondNumberAsInt += integ;
              }
              result = firstNumberAsInt + secondNumberAsInt;
            }
            break;


          case '-':
            for (int i = 0; i < firstNumberCount; i++)
            {
              int integ = (((int)(firstNumber[i])) - '0');
              if (integ == 0)
              {
                //We skip an iteration
              }
              else
              {
                integ *= Powdiy(10, (firstNumberCount - i) - 1);
                firstNumberAsInt += integ;
              }
            }
            for (int i = 0; i < secondNumberCount; i++)
            {
              int integ = (((int)(secondNumber[i])) - '0');
              if (integ == 0)
              {
                //We skip an iteration
              }
              else
              {
                integ *= Powdiy(10, (secondNumberCount - i) - 1);
                secondNumberAsInt += integ;
              }
              result = firstNumberAsInt - secondNumberAsInt;
            }
            break;


          case '*':
            for (int i = 0; i < firstNumberCount; i++)
            {
              int integ = (((int)(firstNumber[i])) - '0');
              if (integ == 0)
              {
                //We skip an iteration
              }
              else
              {
                integ *= Powdiy(10, (firstNumberCount - i) - 1);
                firstNumberAsInt += integ;
              }
            }
            for (int i = 0; i < secondNumberCount; i++)
            {
              int integ = (((int)(secondNumber[i])) - '0');
              if (integ == 0)
              {
                //We skip an iteration
              }
              else
              {
                integ *= Powdiy(10, (secondNumberCount - i) - 1);
                secondNumberAsInt += integ;
              }
              result = firstNumberAsInt * secondNumberAsInt;
            }
            break;


          case '/':
            for (int i = 0; i < firstNumberCount; i++)
            {
              int integ = (((int)(firstNumber[i])) - '0');
              if (integ == 0)
              {
                //We skip an iteration
              }
              else
              {
                integ *= Powdiy(10, (firstNumberCount - i) - 1);
                firstNumberAsInt += integ;
              }
            }
            for (int i = 0; i < secondNumberCount; i++)
            {
              int integ = (((int)(secondNumber[i])) - '0');
              if (integ == 0)
              {
                //We skip an iteration
              }
              else
              {
                integ *= Powdiy(10, (secondNumberCount - i) - 1);
                secondNumberAsInt += integ;
              }              
              dresult = (double)firstNumberAsInt / (double)secondNumberAsInt;
            }
            break;
        }
        if(operand == '/')
        {Serial.print("Result is: "); Serial.println(dresult);}
        else
        {Serial.print("Result is: "); Serial.println(result);}
        if (result > 0 || dresult > 0)
        {
          digitalWrite(LEDgreen, HIGH);
          Serial.println("Green LED lit up!");

        }
        else if (result < 0 || dresult < 0)
        {
          digitalWrite(LEDred, HIGH);
          Serial.println("RED LED lit up!");
        }
        else
        {
          digitalWrite(LEDgreen, LOW);
          digitalWrite(LEDred, LOW);
        }
        //We reset variables for the next loop.
        Reset();
      }
    }
  }
}
