#ifndef __STACK_H__
#define __STACK_H__

/*
   Creates new stack. Returns 0 on success
*/
int stack_create(void);

/*
   Destroys the stack.
*/
void stack_destroy(void);

/*
   Pushes a new element on the stack
   returns 0 on success
   returns -1 on error
*/
int stack_push(char elem);

/*
   Pops an element from the stack
   returns 0 on success
   returns -1 on error or empty
*/
int stack_pop(char *elem);

/*
   Shows the top an element of the stack
   returns 0 on success
   returns -1 on error or empty
*/
int stack_top(char *elem);

/*
   Returns everything in the stack as a String
*/
String dataInStack();

#endif
