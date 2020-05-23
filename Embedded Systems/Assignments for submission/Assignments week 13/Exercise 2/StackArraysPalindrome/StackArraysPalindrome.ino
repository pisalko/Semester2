#include "stack.h"
#define stackSize 100

char stackBuffer[stackSize];
int stackTop = 0;
bool stackExist = false, messageReceived = false;


void setup() {
  Serial.begin(9600);
}

void loop()
{
  while (Serial.available())
  {
    stack_create();
    char c = Serial.read();
    if (c != '\n' || c != '\r')
      stack_push(c);
    delay(5);
    messageReceived = true;
  }

  if (messageReceived)
  {
    String reversedMessage = "";
    char c;
    int stackTopUnmodified = stackTop;
    for (int i = 0; i < stackTopUnmodified; i++)
    {
      stack_pop(&c);
      reversedMessage += c;
    }
    reversedMessage.trim();
    stack_destroy();
    String message = "";
    for (int i = reversedMessage.length() - 1; i >= 0; i--)
    {
      message += reversedMessage[i];
    }
    Serial.println("Received message - " + message);
    Serial.println("Message in reverse - " + reversedMessage);
    if (message == reversedMessage)
    {
      Serial.println("This is a palindrome!");
    }
    else
    {
      Serial.println("Sorry, but this is not a palindrome :(");
    }
    messageReceived = false;
  }
}

int stack_create(void)
{
  stackExist = true;
  return 0;
}

void stack_destroy(void)
{
  stackExist = false;
  for (int i = 0; i < stackSize; i++)
    stackBuffer[i] = '\0';
  stackTop = 0;
}

int stack_push(char elem)
{
  if (!stackExist)
  {
    Serial.println("Stack not created");
    return -1;
  }

  if (stackTop < stackSize)
  {
    stackBuffer[stackTop++] = elem;
    return 0;
  }
  else
  {
    Serial.println("Not enough memory on the stack for a new element.");
    return -1;
  }
}

int stack_pop(char *elem)
{
  if (!stackExist)
  {
    Serial.println("Stack not created");
    return -1;
  }

  if (stackTop >= 1 && stackTop <= 99)
  {
    *elem = stackBuffer[stackTop - 1];
    stackBuffer[--stackTop] = '\0';
    return 0;
  }
  else if (stackTop == 0 && stackBuffer[stackTop] != '\0')
  {
    *elem = stackBuffer[stackTop];
    stackBuffer[stackTop] = '\0';
    return 0;
  }
  else
  {
    Serial.println("Error on stack, no elements to pop");
    return -1;
  }
}

int stack_top(char *elem)
{
  if (!stackExist)
  {
    Serial.println("Stack not created");
    return -1;
  }

  if (stackBuffer[stackTop - 1] != '\0')
  {
    *elem = stackBuffer[stackTop - 1];
    Serial.println(stackBuffer[stackTop - 1]);
    return 0;
  }
  else
  {
    Serial.println("No elements in stack");
    return -1;
  }
}
