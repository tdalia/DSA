using System;

namespace DataStru {
    // Implementation of Stack using an array
    class MyStack {
        int[] elements;
        int max;
        int top;

        public MyStack(int size) {
            elements = new int[size];
            top = -1;
            max = size;
        }

        public void Push(int i) {
            if (top == max-1) {
                Console.WriteLine("Stack Overflow ");
                return;
            }
            elements[++top] = i;
            Console.WriteLine("{0} pushed to stack ", elements[top]);
        }

        public int Peek() {
            if (top == -1) {
                Console.WriteLine("Stack is empty.");
                return -1;
            }
            Console.WriteLine("{0} peeked from stack ", elements[top]);
            return elements[top];
        }
        
        public int Pop() {
            if (top == -1) {
                Console.WriteLine("Stack is empty.");
                return -1;
            }

            Console.WriteLine("{0} popped from stack ", elements[top]);
            return elements[top--];
        }

        public bool isEmpty() {
            if (top == -1)
                return true;
            return false;
        }

        public void printStack()
        {
            if (top == -1) {
                Console.WriteLine("Stack is Empty");
                return;
            }
            else {
                for (int i = 0; i <= top; i++) {
                    Console.WriteLine("{0} pushed into stack", elements[i]);
                }
            }
        }

    }
}