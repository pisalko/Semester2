#include "Stack.h"
#include "Arduino.h"

Stack::Stack(String givenName)
{
  stackExist = true;
  name = givenName;
}

int Stack::stack_create(void)
{
  stackExist = true;
}

void Stack::stack_destroy(void)
{
  struct Node* transitionNode = new Node();
  while (1)
  {
    if (head == NULL)
    {
      break;
    }
    else
    {
      transitionNode = head;
      head = head->linkPointer;
      transitionNode->linkPointer = NULL;
    }
  }
  free(transitionNode);
  stackExist = false;
}

int Stack::stack_push(double *elem)
{
  if(!stackExist)
  {
    //Serial.println(name + " said: " + "Please call stack_create() first. Stack is nonexistent.");
    return -1;
  }
  struct Node* transitionNode = new Node();
  if (!sizeof(transitionNode) == sizeof(struct Node*))
  {
    //Serial.println(name + " said: " + "Not enough memory, will create a Stack overflow");
    return -2;
  }
  transitionNode->data = *elem;
  transitionNode->linkPointer = head;
  head = transitionNode;
  //Serial.print(name + " said: " + "Element added: ");
  //Serial.println(transitionNode->data);
  return 0;
}

int Stack::stack_pop(double *elem)
{
  if(!stackExist)
  {
    //Serial.println(name + " said: " + "Please call stack_create() first. Stack is nonexistent.");
    return -2;
  }
  struct Node* transitionNode = new Node();

  if (head == NULL)
  {
    //Serial.println(name + " said: " + "No elements in Stack.");
    return -1;
  }
  else
  {
    transitionNode = head;
    *elem = transitionNode->data;
    //Serial.print(name + " said: " + "Element popped: ");
    //Serial.println(transitionNode->data);
    head = head->linkPointer;
    transitionNode->linkPointer = NULL;
    free(transitionNode);
    return 0;
  }
}

int Stack::stack_top(double *elem)
{
  if(!stackExist)
  {
    //Serial.println(name + " said: " + "Please call stack_create() first. Stack is nonexistent.");
    return -2;
  }
  if (!head == NULL)
  {
    *elem = head->data;
    return 0;
  }
  else
  {
    //Serial.println(name + " said: " + "Stack is empty");
    return -1;
  }
}

int Stack::stack_display(bool display)
{
    struct Node* transitionNode;
    int counter = 0;
    // check for stack underflow 
    if (!(head == NULL)) {
        //Serial.println("*\n*\n*\nCommands include: <any float number>, +, -, *, /,\n r(square root), p(1/x), new(new equation), \nnewf(new equation Force), cres(check results):\n");
        Serial.println("**************************************************");
        transitionNode = head;
        while (transitionNode != NULL) 
        {
            counter++;
            if (display)
                Serial.print(name + ": Element ");
            Serial.print(counter);
            Serial.print(": ");
            Serial.println(transitionNode->data);
            transitionNode = transitionNode->linkPointer;
        }
    }
    else
    {
        Serial.println(name + " stack is empty.");
    }
    Serial.println("**************************************************");

    return counter;
}
