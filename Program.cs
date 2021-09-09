using System;
namespace MyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList<int> myList = new MyLinkedList<int>();

            int flag = 0, value;
            uint position;
        redo:
            Console.Clear();
            ShowOptions();
            int choice = Choice();
            while (flag == 0)
            {
                switch (choice)
                {
                    case 1:
                        value = GetValue();
                        myList.Insert(value);
                        PressToContinue();
                        goto redo;

                    case 2:
                        position = GetPosition();
                        value = GetValue();
                        myList.InsertAt(position,value);
                        PressToContinue();
                        goto redo;

                    case 3:
                        value = GetValue();
                        myList.Delete(value);
                        PressToContinue();
                        goto redo;

                    case 4:
                        position = GetPosition();
                        myList.DeleteAt(position);
                        PressToContinue();
                        goto redo;

                    case 5:
                        myList.Center();
                        PressToContinue();
                        goto redo;

                    case 6:
                        myList.Reverse();
                        PressToContinue();
                        goto redo;

                    case 7:
                        Console.WriteLine("\nSize of List: " + myList.Size());
                        PressToContinue();
                        goto redo;

                    case 8:
                        myList.Iterator(myList);
                        PressToContinue(); 
                        goto redo;

                    case 9:
                        Console.Write("\nList: ");
                        myList.Print();
                        PressToContinue();
                        goto redo;

                    case 0:
                        flag = 1;
                        break;

                    default:
                        goto redo;
                }
            }

        }

        public static void ShowOptions()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press 0 ---> Exit");
            Console.WriteLine("Press 1 ---> Insert");
            Console.WriteLine("Press 2 ---> Insert At Position");
            Console.WriteLine("Press 3 ---> Delete");
            Console.WriteLine("Press 4 ---> Delete At Position");
            Console.WriteLine("Press 5 ---> Center");
            Console.WriteLine("Press 6 ---> Reverse");
            Console.WriteLine("Press 7 ---> Size");
            Console.WriteLine("Press 8 ---> Iterator");
            Console.WriteLine("Press 9 ---> Print");
        }

        public static int GetValue()
        {
            redo:
            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nEnter Number To Insert/Delete: ");
                int value = int.Parse(Console.ReadLine());
                return value;
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid Type. Please enter a integer");
                Console.ForegroundColor = ConsoleColor.White;
                goto redo;
            }
        }

        public static uint GetPosition()
        {
            Console.WriteLine("\nNote - Position Starts from index 1 i.e. To Insert/Delete at Head of Linked List press 1");
            redo:
            try
            {
                Console.Write("\nEnter index : ");
                uint position = uint.Parse(Console.ReadLine());
                return position;
            }

            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid Type. Please enter the type integer");
                Console.ForegroundColor = ConsoleColor.White;
                goto redo;
            }
            catch (OverflowException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError: Position cannot be negative");
                Console.ForegroundColor = ConsoleColor.White;
                goto redo;
            }
        }

        public static int Choice()
        {
            redo:
            Console.Write("\nEnter Choice of Operation: ");
            int choice;
            try
            {
                choice = int.Parse(Console.ReadLine());
                while (choice < 0 || choice > 9)
                {
                    Console.Write("\nPlease enter valid choice: ");
                    choice = int.Parse(Console.ReadLine());
                }
                return choice;
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError: Invalid Type! Please enter a integer from the given choices");
                Console.ForegroundColor = ConsoleColor.White; 
                goto redo;
            }
        }

        public static void PressToContinue()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\nPress Any Key to continue: ");
            Console.ReadKey();
        }
    }

    
}
