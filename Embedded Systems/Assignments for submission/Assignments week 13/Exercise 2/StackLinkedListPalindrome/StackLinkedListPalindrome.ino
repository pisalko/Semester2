#include "stack.h"
struct Node* head;
bool stackExist = false, messageReceived = false;

struct Node
{
  struct Node* linkPointer;
  char data;
};

void setup() {
  Serial.begin(9600);
}

void loop() {
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
    String reversedMessage = dataInStack();
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
}

void stack_destroy(void)
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

int stack_push(char elem)
{
  if (!stackExist)
  {
    Serial.println("Please call stack_create() first. Stack is nonexistent.");
    return -1;
  }
  struct Node* transitionNode = new Node();
  if (sizeof(transitionNode) != sizeof(struct Node*))
  {
    Serial.println("Not enough memory, will create a Stack overflow");
    return -1;
  }
  transitionNode->data = elem;
  transitionNode->linkPointer = head;
  head = transitionNode;
  return 0;
}

int stack_pop(char *elem)
{
  if (!stackExist)
  {
    Serial.println("Please call stack_create() first. Stack is nonexistent.");
    return -1;
  }
  struct Node* transitionNode = new Node();

  if (head == NULL)
  {
    Serial.println("No elements in Stack.");
    return -1;
  }
  else
  {
    transitionNode = head;
    *elem = transitionNode->data;
    head = head->linkPointer;
    transitionNode->linkPointer = NULL;
    free(transitionNode);
    return 0;
  }
}

int stack_top(char *elem)
{
  if (!stackExist)
  {
    Serial.println("Please call stack_create() first. Stack is nonexistent.");
    return -1;
  }
  if (!head == NULL)
  {
    *elem = head->data;
    return 0;
  }
  else
  {
    Serial.println("Stack is empty");
    return -1;
  }
}

String dataInStack()
{
  String messageReversed = "";
  struct Node* transitionNode;
  if (head != NULL)
  {
    transitionNode = head;
    while (transitionNode != NULL)
    {
      messageReversed += transitionNode->data;
      transitionNode = transitionNode->linkPointer;
    }
    messageReversed.trim();
  }
  return messageReversed;
}
