#include "stack.h"
struct Node* head;
bool stackExist = false;

void setup() {
  Serial.begin(9600);
  double a = 11, b = 22, c = 44, d = 12.51;
  stack_create();
  stack_push(&a);
  stack_push(&b);
  stack_push(&c);
  stack_push(&d);
  double f;
  stack_destroy();
  stack_pop(&f);
  stack_create();
  stack_pop(&f);
}

void loop() {

}

struct Node
{
  struct Node* linkPointer;
  double data;
};

int stack_create(void)
{
  stackExist = true;
}

void stack_destroy(void)
{
  stackExist = false;
}

int stack_push(const double *elem)
{
  if(!stackExist)
  {
    Serial.println("Please call stack_create() first. Stack is nonexistent.");
    return -1;
  }
  struct Node* transitionNode = new Node();
  if (!sizeof(transitionNode) == sizeof(struct Node*))
  {
    Serial.println("Not eonugh memory, will create a Stack overflow");
    return -1;
  }
  transitionNode->data = *elem;
  transitionNode->linkPointer = head;
  head = transitionNode;
  Serial.print("Element added: ");
  Serial.println(transitionNode->data);
  return 0;
}

int stack_pop(double *elem)
{
  if(!stackExist)
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
    Serial.print("Element popped: ");
    Serial.println(transitionNode->data);
    head = head->linkPointer;
    transitionNode->linkPointer = NULL;
    free(transitionNode);
    return 0;
  }
}

int stack_top(double *elem)
{
  if(!stackExist)
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
