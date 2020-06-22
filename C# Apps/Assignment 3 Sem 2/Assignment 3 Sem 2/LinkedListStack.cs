using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_3_Sem_2
{
    public class LinkedListStack
    {
        private Node head;
        /// <summary>
        /// This is our so-called "node". This is how linked lists operate and are connected to each other.
        /// </summary>
        private class Node
        {
            public string clientMessage;
            public Node lastNode;
        }
        
        public LinkedListStack()
        {
            head = null; //allocating memory
        }

        /// <summary>
        /// Pushes new data on top of the stack
        /// </summary>
        public void push(string message)
        {
            Node transitionNode = new Node();
            if (transitionNode == null)
            {
                Console.WriteLine("Memory is full");
                return;
            }

            transitionNode.clientMessage = message;
            transitionNode.lastNode = head;
            head = transitionNode;
        }

        /// <summary>
        /// Removes the top elem of the stack and returns it
        /// </summary>
        public string pop()
        {
            if (head == null)
            {
                Console.WriteLine("Stack is empty");
                return "empty";
            }
            head = head.lastNode;
            return head.clientMessage;

        }

        /// <summary>
        /// Returns the top element of the stack without "reading" (deleting) it
        /// </summary>
        public string peek()
        {
            if (!(head == null))
            {
                return head.clientMessage;
            }
            else
            {
                Console.WriteLine("Stack is empty");
                return "Stack is empty";
            }
        }

        /// <summary>
        /// Returns the data in the Linked List as an ObjectCollection, suitable for ListBox use
        /// </summary>
        public ListBox.ObjectCollection AsListBoxCollection()
        {
            ListBox lb = new ListBox();
            if (!(head == null))
            {
                Node transitionNode = head;
                while (transitionNode != null)
                {
                    lb.Items.Add(transitionNode.clientMessage);
                    transitionNode = transitionNode.lastNode;
                }
            }
            return lb.Items;
        }

        /// <summary>
        /// Checks if the stack contains <data>
        /// </summary>
        public bool Contains(string data)
        {
            if (!(head == null))
            {
                Node transitionNode = head;
                while (transitionNode != null)
                {
                    if (transitionNode.clientMessage == data)
                        return true;
                    transitionNode = transitionNode.lastNode;
                }
            }
            return false;
        }
    }
}
