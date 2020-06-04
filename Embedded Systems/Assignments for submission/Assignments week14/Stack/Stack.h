/*
 * Library for a Stack written by Valentin Vasilev
 This way you can truly have multiple stacks for different purposes.
 */

#ifndef Stack_h
#define Stack_h

#include "Arduino.h"

class Stack
{
  public:
    Stack(String givenName);
    int stack_create(void);
    void stack_destroy(void);
    int stack_push(double *elem);
    int stack_pop(double *elem);
    int stack_top(double *elem);
    int stack_display(bool display);

  private:
  struct Node
    {
      struct Node* linkPointer;
      double data;
    };
    struct Node* head;
    bool stackExist;
    String name;
};
#endif
