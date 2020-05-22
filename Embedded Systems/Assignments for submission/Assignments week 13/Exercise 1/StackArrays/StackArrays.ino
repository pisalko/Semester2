#include "stack.h"
#define stackSize 100

double stackBuffer[stackSize];
int stackTop = 0;
bool stackExist = false;

void setup() {
  Serial.begin(9600);
}

void loop() {
  // put your main code here, to run repeatedly:
}

int stack_create(void)
{
  stackExist = true;
  return 0;
}

void stack_destroy(void)
{
  stackExist = false;
}

int stack_push(const double *elem)
{
  if(!stackExist)
  {
    Serial.println("Stack not created");
    return -1;
  }
  
  if (stackTop < stackSize)
  {
    stackBuffer[stackTop++] = *elem;
    return 0;
  }
  else
  {
    Serial.println("Not enough memory on the stack for a new element.");
    return -1;
  }
}

int stack_pop(double *elem)
{
  if(!stackExist)
  {
    Serial.println("Stack not created");
    return -1;
  }
  
  if (stackTop >= 1 && stackTop <= 99)
  {
    Serial.println(stackBuffer[stackTop-1]);
    *elem = stackBuffer[stackTop-1];
    stackBuffer[stackTop--] = NULL;
    return 0;
  }
  else if (stackTop == 0 && stackBuffer[stackTop] != NULL)
  {
    Serial.println(stackBuffer[stackTop]);
    *elem = stackBuffer[stackTop];
    stackBuffer[stackTop] = NULL;
    return 0;
  }
  else
  {
    Serial.println("Error on stack, no elements to pop");
    return -1;
  }
}

int stack_top(double *elem)
{
  if(!stackExist)
  {
    Serial.println("Stack not created");
    return -1;
  }
  
  if(stackBuffer[stackTop-1] != NULL)
  {
  Serial.println(stackBuffer[stackTop-1]);
  return 0;
  }
  else
  {
    Serial.println("No elements in stack");
    return -1;
  }
}
