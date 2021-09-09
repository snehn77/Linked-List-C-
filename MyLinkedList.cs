using System;


namespace MyLinkedList
{

    public class MyLinkedList<T>
    {
        private class Node
        {
            public T value;
            public Node next;
        }

        private Node Head;

        public MyLinkedList()
        {
            Head = null;
        }

        public int Size()
        {
            int count = 0;
            Node first = Head;

            while (first != null)
            {
                count++;
                first = first.next;
            }
            return count;
        }

        public void Insert(T value)
        {
            Node newNode = new Node();
            newNode.value = value;
            Console.ForegroundColor = ConsoleColor.Green;
            if (Head == null)
            {
                Head = newNode;
                Console.WriteLine("\nInserted Successfully!");
            }
            else
            {
                Node first = Head;
                while (first.next != null)
                {
                    first = first.next;
                }
                first.next = newNode;
                Console.WriteLine("\nInserted Successfully!");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void InsertAt(uint position, T value)
        {
            Node newNode = new Node();
            newNode.value = value;

            if (position == 1)
            {
                newNode.next = Head;
                Head = newNode;
            }
            else if (position > Size() || position == 0)
            {
                Console.WriteLine("\nPosition Not in the list");
                return;
            }
            else
            {
                Node first = Head;

                for (int i = 1; i < position - 1; i++)
                {
                    first = first.next;
                }
                newNode.next = first.next;
                first.next = newNode;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nInserted Successfully!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Print()
        {
            var headOfList = Head;
            try
            {
                while (headOfList.next != null)
                {
                    Console.Write(headOfList.value + " -> ");
                    headOfList = headOfList.next;
                }
                Console.Write(headOfList.value + "\n");
            }
            catch (NullReferenceException)
            {
                Console.Write("Linked List is empty");
            }
        }

        public void Delete(T value)
        {
            Node previous = null;
            Node first = Head;
            try
            {
                if (Head == null)
                {
                    Console.WriteLine("\nList is empty");
                    return;
                }

                if (first != null && first.value.Equals(value))
                {
                    Head = first.next;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nDeleted Successfully!");
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }

                while (first != null && !(first.value.Equals(value)))
                {
                    previous = first;
                    first = first.next;
                }
                previous.next = first.next;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nDeleted Successfully!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("\nElement not in the list");
            }

        }

        public void DeleteAt(uint position)
        {
            int size = Size();
            Node first = Head;
            Node temp = null;

            // If the given position is not in the linked List
            if (position > size || position == 0)
            {
                Console.WriteLine("\nPosition is not in the Linked List");
                return;
            }
            // Delete at head if position = 1
            else if (position == 1)
            {
                Head = first.next;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nDeleted Successfully!");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            for (int i = 1; i < position - 1; i++)
            {
                first = first.next;
            }
            temp = first.next.next;
            first.next.next = null;
            first.next = temp;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nDeleted Successfully!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Center()
        {
            Node first = Head;
            int size = Size();
            int middle;
            // Check if list is empty or not
            if (first == null)
            {
                Console.WriteLine("\nList is Empty");
            }
            else
            {
                // If list has odd number of elements
                if (size % 2 != 0)
                {
                    middle = size / 2;
                    for (int i = 0; i < middle; i++)
                    {
                        first = first.next;
                    }
                    Console.WriteLine("\nValue at center: " + first.value);
                }
                // Else with list of even number of elements
                else
                {
                    Console.WriteLine("\nList size is Even. Hence no center in the list");
                }
            }
        }

        public void Reverse()
        {
            Node previous = null;
            Node current = Head;
            Node temp = null;
            // Checking if list is empty or not
            if (current == null)
            {
                Console.WriteLine("\nList is Empty");
                return;
            }
            // Reversing the list
            while (current != null)
            {
                temp = current.next;
                current.next = previous;
                previous = current;
                current = temp;
            }

            Head = previous;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nReversed Successful");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Iterator(MyLinkedList<T> myList)
        {
            if (Head == null)
            {
                Console.Write("\nLinked List is empty");
                return;
            }
            MyLinkedList<T>.Enumerator enumerator = GetEnumerator();
            enumerator.Reset();
            Console.WriteLine("\nList using Iterator: ");
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }
        public Enumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        public class Enumerator
        {
            private Node current;
            private MyLinkedList<T> myList;

            public Enumerator(MyLinkedList<T> list)
            {
                myList = list;
                Reset();
            }

            public void Reset()
            {
                current = null;
            }

            public T Current
            {
                get
                {
                    return current.value;
                }
            }

            public bool MoveNext()
            {
                if (current == null)
                {
                    current = myList.Head;
                }
                else
                {
                    current = current.next;
                }
                return (current != null);
            }

        }

    }
}
