/*
 Hoi Ching Tong
 Curt Gilbert
 Connor Williams 

 IS 403
 Section 2 
 Group 13

 This program prints a main menu that allows the user to choose what data structure they want to work with first. 
 Then, it displays a menu which allows the user to add an item, add a huge list of items, display, delete, clear, search, or return to the main menu.
 Each of the options have error handling to ensure that the program doesn't fall apart if the user does something we don't like. 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures2
{
    class Storage
    {
        protected string[] options = {  "\n1. Add one item to ",                        //This creates an Array which is the template for our submenu of all our data types. 
                                        "2. Add Huge List of Items to ", "" +
                                        "3. Display ",
                                        "4. Delete from ",
                                        "5. Clear ", "" +
                                        "6. Search ",
                                        "7. Return to Main Menu" +"\n"};

        protected const int hugeList = 2000;        //This ensures that our huge list of items is always constant at the number 2000
        protected System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();     //This creates our stopwatch that we will use for all of our search options in all 3 data structures
        public Storage() { }        //Creates a blank constructor

        public int getInput()  //Gets input and converts to int
        {
            //This is where I declared my variables 
            string userInput;
            int input = 0;  //This helps ensure that the user input is valid. 

            //This statement is to handle any user errors to help our program keep on going.
            try
            {
                userInput = Console.ReadLine();
                input = Convert.ToInt32(userInput);
            }
            catch
            {
                input = 0;
            }

            return input;
        }

    }

    //This is the class we created for the Stack Data Structure, and makes it a child class for the parent class Storage
    class MyStack : Storage
    {
        public MyStack() { }        //This is a blank constructor for Stack

        protected Stack<string> theStack = new Stack<string>();     //This creates my stack
        protected Stack<string> holdStack = new Stack<string>();

        //This method allows the user to add one item to the stack
        public void addOneItem()
        {
            Console.Write("\nEnter a value: ");
            theStack.Push(Console.ReadLine());
        }

        //This method allows the user to add a list of 2000 to the stack
        public void addHugeList()
        {
            clear();    //This clears any data that is currently in the stack
            for (int i = 1; i <= hugeList; i++)
            {
                theStack.Push("New Entry " + Convert.ToString(i));
            }
        }

        //This displays all the data in the stack.
        public void display()
        {
            Console.WriteLine();    //This creates some blank space 
            if (theStack.Count() == 0)      //This ensures to tell the user that the stack is empty when they try to display
            {
                Console.WriteLine("\nThe Stack is currently empty");
            }
            else
            {
                foreach (string entry in theStack)      //This iterates through the Stack to print the data
                {
                    Console.WriteLine(entry);
                }
            }
        }

        //This deletes the top element of the stack.
        public void delete()
        {
            string answer;
            List<String> myHoldList = new List<String>();       //This creates a hold List for my Stack

            if (theStack.Count == 0)    //This tells the user that it can't delete data because there isn't any in the data structure
            {
                Console.WriteLine("\nThere is no data in the stack to delete");
            }
            else
            {
                Console.WriteLine("\nWhat element would you like to delete from the stack?");
                answer = Console.ReadLine();

                foreach (String var in theStack) //This adds all the values from the Stack to my List
                {
                    myHoldList.Add(var);
                }

                theStack.Clear(); //This clears the stack so we can use it later on

                int iHasValue = myHoldList.FindIndex(a => a == answer); //You are looking for a specific value in the List and returns a value
                
                if (iHasValue < -1) //If it doesn't exist in the Stack, it can't be deleted
                {
                    Console.WriteLine("\nThis does not exist in the Stack, and can't be deleted");
                }
                else
                {
                    myHoldList.RemoveAt(iHasValue);     //The user input is found, and deleted in the list
                }

                myHoldList.Reverse();
                foreach(String var in myHoldList)       //This is where I update the stack. 
                {
                    theStack.Push(var);
                }
            }
        }

        //This clears the stack of any data
        public void clear()
        {
            theStack.Clear();
        }

        //This allows the user to search the stack.
        public void search()
        {
            if (theStack.Count == 0)
            {
                Console.WriteLine("\nThere is no data in the stack to search");
            }
            else
            {
                Console.Write("\nWhat item you like to search for? ");
                string answer = Console.ReadLine();

                sw.Start();         //This is how I start my stopwatch to calculate the time it takes to search.

                if (theStack.Contains(answer))      //This if statement ensures that whatever the user is looking for is in the stack. 
                {
                    Console.WriteLine("\nThe item has been found. It took " + sw.Elapsed + " to find.");
                }
                else
                {
                    Console.WriteLine("\nThe item was not found. It took " + sw.Elapsed + " to search the stack.");       //This informs the user that whatever they were searching for does not exist in the stack
                }
                sw.Stop();      //This stops the stopwatch
                sw.Reset();     //This resets the watch so it can be used in other data structures and to have the correct time stamp
            }
        }

        //This is where the Stack sub menu is put into practice. 
        public void initialize()
        {
            int choice = 0;

            do
            {
                //This adds the word Stack to the end of my sub menu.
                for (int i = 0; i < (options.Length - 1); i++)
                {
                    Console.WriteLine(options[i] + "Stack");
                }

                Console.WriteLine(options[options.Length - 1]);

                choice = getInput(); //This calls my earlier method to get input from the user

                //This is the switch statement that calls the various methods according to the submenu options
                switch (choice)
                {
                    case 1: addOneItem(); break;
                    case 2: addHugeList(); break;
                    case 3: display(); break;
                    case 4: delete(); break;
                    case 5: clear(); break;
                    case 6: search(); break;
                }

            } while (choice != 7); //This breaks out of the loop and brings you back to the main menu

            clear();        //This clears the data in the Stack.

        }

    }

    //This creates a class called MyQueue which is a child of the parent class Storage
    class MyQueue : Storage
    {
        public MyQueue() { }        //Creates a blank constructor

        protected Queue<string> myQueue = new Queue<string>();      //Creates a new Queue to add and hold data
        protected Queue<string> myholdQueue = new Queue<string>();

        //This allows the user to add one item to the Queue
        public void addOneItem()
        {
            Console.Write("\nEnter a value: ");
            myQueue.Enqueue(Console.ReadLine());
        }

        //This allows the user to add 2000 items to the Queue
        public void addHugeList()
        {
            clear();
            for (int i = 1; i <= hugeList; i++)     //The for loop that handles adding data to the Queue
            {
                myQueue.Enqueue("New Entry " + (i));
            }
        }

        //This method displays all the data in the Queue
        public void display()
        {
            
            //This ensures that if the user wants to see data that is in the Queue, but it is empty, that they know it is empty. 
            if (myQueue.Count == 0)
            {
                Console.WriteLine("\nERROR: Cannot Display Since the Queue is Empty");
            }
            else
            {
                Console.WriteLine();        //This adds some blank space

                //This foreach statement allows you to iterate through the entire queue and print out the data
                foreach (string istring in myQueue)
                {
                    Console.WriteLine(istring);
                }
            }
        }

        //This method deletes a single entry in the queue
        public void delete()
        {
            String sUserAnswer;
            Console.Write("\nEnter what you want to delete: ");
            sUserAnswer = Console.ReadLine();

            if (myQueue.Count == 0)     //This ensures that the user knows it can't delete something from an empty queue
            {
                Console.WriteLine();
                Console.WriteLine("\nERROR: Cannot Delete Since the Queue is Empty");
            }

            else
            {
                while (myQueue.Count > 0)       //This iterates through the queue to find the value the user put in to delete
                {
                    if (myQueue.Peek() == sUserAnswer)
                    {
                        myQueue.Dequeue();
                    }
                    else
                    {
                        myholdQueue.Enqueue(myQueue.Dequeue());     //This puts the data that is dequeued somewhere else so the data isn't lost
                    }
                }
            }

            for (int iCount = myholdQueue.Count; myholdQueue.Count > 0; iCount--)       //This adds the numbers back to the original queue
            {
                myQueue.Enqueue(myholdQueue.Dequeue());
            }
        }

        //This method clears the queue
        public void clear()
        {
            myQueue.Clear();
        }

        //This method searches through the queue to find what the user is looking for
        public void search()
        {

            Console.Write("\nEnter what you want to search for: ");

            if (myQueue.Count == 0)     //This ensures that the user knows it can't search for something in an empty queue
            {
                Console.WriteLine();
                Console.WriteLine("\nERROR: Cannot Search Since the Queue is Empty");
            }

            else
            {
                sw.Start();     //This starts the stopwatch

                if (myQueue.Contains(Console.ReadLine())) //This searches through the queue to find the value the user is looking for
                {
                    Console.WriteLine();        //This adds blank space

                    Console.WriteLine("\nItem was found and took " + sw.Elapsed + " to search the data structure");    //This prints the data, and the time it took to search

                }
                else
                {
                    Console.WriteLine();        //This adds blank space

                    Console.WriteLine("\nItem was not found and took " + sw.Elapsed + " to search the data structure");
                }

            }
            sw.Stop();      //This stops the stopwatch
            sw.Reset();     //This resets the stopwatch so it can be used in different data structures
        }

        //This is where the submenu of Queue is actually initialized
        public void initialize()
        {
            int choice = 0;

            do
            {
                //This loop prints out the submenu with the work queue at the end of it. 
                for (int i = 0; i < (options.Length - 1); i++)
                {
                    Console.WriteLine(options[i] + "Queue");
                }
                Console.WriteLine(options[options.Length - 1]);

                choice = getInput();        //This calls the method so that it collects user input

                //This switch statement calls different methods that aligns with the menu options
                switch (choice)
                {
                    case 1: addOneItem(); break;
                    case 2: addHugeList(); break;
                    case 3: display(); break;
                    case 4: delete(); break;
                    case 5: clear(); break;
                    case 6: search(); break;
                }

            } while (choice != 7);      //If the user chooses 7, then it will jump out to the main menu

            clear();        //This clears the queue


        }


    }

    //This is my class that inherits from the parent class Storage
    class MyDictionary : Storage
    {
        public MyDictionary() { }       //This creates a blank constructor

        protected Dictionary<string, int> myDictionary = new Dictionary<string, int>();     //This creates a Dictionary

        //This method adds one item to the dictionary
        public void addOneItem()
        {

            Console.Write("\nEnter a Key: ");
            String sKeyValue = Console.ReadLine();

            if (myDictionary.ContainsKey(sKeyValue))    //This tells the user that they can't add a value that already exists
            {
                Console.WriteLine("\nWhat you entered already exists in dictionary.");

            }

            else
            {
                Console.Write("\nEnter a Value: ");
                int sAddValue = Convert.ToInt32(Console.ReadLine());
                myDictionary.Add(sKeyValue, sAddValue);

            }

        }

        //This is the method that adds the huge list
        public void addHugeList()
        {
            clear();
            for (int i = 1; i <= hugeList; i++)
            {
                String tKey = "New Entry";
                String tKeyNum = Convert.ToString(i);
                myDictionary.Add(tKey + " " + tKeyNum, i);

            }
        }

        //This method displays all the data in the dictionary
        public void display()
        {
            if (myDictionary.Count == 0)        //This lets the user know that the dictionary is empty and can't display any data
            {
                Console.WriteLine("\nDictionary is Empty");
            }

            else
            {
                Console.WriteLine();    //This adds some blank space
                foreach (var pair in myDictionary)  //This loop iterates through the dictionary to print
                {
                    Console.Write("Key: " + pair.Key);
                    Console.WriteLine("\tValue: " + pair.Value);
                }
            }
        }

        //This method deletes one item from the Dictionary
        public void delete()
        {
            if (myDictionary.Count == 0)
            {
                Console.WriteLine("\nThere is no data in the dictionary to delete");
            }
            else
            {
                String sDelete;
                Console.Write("\nWhat key do you want to delete from the dictionary? ");
                sDelete = Console.ReadLine();


                if (!myDictionary.ContainsKey(sDelete))      //This tells the user it can't delete something that doesn't exist in the dictionary
                {
                    Console.WriteLine("\nKey " + sDelete + " is not found.");
                }
                myDictionary.Remove(sDelete);
            }
        }

        //This clears out the data in a dictionary
        public void clear()
        {
            myDictionary.Clear();
        }

        //This does a search through the dictionary for whatever the user is looking for
        public void search()
        {
            String sLookKey;

            if (myDictionary.Count == 0)    //This checks if the dictionary is empty, and tells the user it can't search if it's empty
            {
                Console.WriteLine("\nDictionary is Empty");
            }
            else
            {


                Console.Write("\nWhat are you searching for? ");
                sLookKey = Console.ReadLine();
                sw.Start();

                if (!myDictionary.ContainsKey(sLookKey))    //If whatever was searched wasn't in the dictionary, the program tells the user
                {


                    Console.WriteLine("\nItem was not found and took " + sw.Elapsed + " to search the data structure");     //This tells the user that whatever was searchd wasn't found, and time elapsed

                }
                else
                {

                    Console.WriteLine("\nThe item has been found. It took " + sw.Elapsed + " to search the data structure.");   //This tells the user that whatever has been searched has been found, and the time elapsed
                }

                sw.Stop();      //This stops the stopwatch
                sw.Reset();     //This resets the stopwatch so it can be used across data structures
            }
        }

        //This is where the submenu is actually used for Dictionary
        public void initialize()
        {
            int choice = 0;

            do
            {
                for (int i = 0; i < (options.Length - 1); i++)  //This prints out the submenu
                {
                    Console.WriteLine(options[i] + "Dictionary");
                }
                Console.WriteLine(options[options.Length - 1]);

                choice = getInput();    //This calls the method to get what the user inputted

                //This switch statement calls the method for each menu item
                switch (choice)
                {
                    case 1: addOneItem(); break;
                    case 2: addHugeList(); break;
                    case 3: display(); break;
                    case 4: delete(); break;
                    case 5: clear(); break;
                    case 6: search(); break;
                }

            } while (choice != 7);  //This closes out of the loop to the main menu

            clear();    //This clears the stack


        }



    }

    class Program
    {

        static void Main(string[] args)
        {
            string[] menuOptions = { "\n1. Stack",          //This creates the main menu for the program
                                     "2. Queue",
                                     "3. Dictionary",
                                     "4. Exit\n" };

            MyQueue theQueue = new MyQueue();
            MyStack theStack = new MyStack();
            MyDictionary theDictionary = new MyDictionary();
            string userInput;
            int input = 0;

            do
            {
                foreach (string option in menuOptions)  //This prints out the main menu
                {
                    Console.WriteLine(option);
                }

                //This is a try catch for the user input, and converts it to an int.
                try
                {
                    userInput = Console.ReadLine();
                    input = Convert.ToInt32(userInput);
                }
                catch
                {
                    input = 0;
                }

                if (input <= 0 || input > 4)    //This tells the user that they have inputted an invalid number
                {
                    Console.WriteLine("\nYou must enter a valid option integer.");
                }

                switch (input)
                {
                    case 1: theStack.initialize(); break;  //This tells the program exactly where to go for each data structure
                    case 2: theQueue.initialize(); break;
                    case 3: theDictionary.initialize(); break;
                }

            } while (input != 4); //This exits out of the program

            Console.Read();
        }
    }


}



