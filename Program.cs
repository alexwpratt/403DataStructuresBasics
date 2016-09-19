/*
 * Alex Wilcken Pratt
 * IS403
 * Section 2 Group 12
 * 
 * Data Structures Basics Assignment

Your task is to create a program that will help you familiarize yourself with various data structures available in the C# language.

You are the owner of a very successful hamburger restaurant. Your faithful customers line up every day and eat dozens of burgers. You are writing a program to track exactly how many hamburgers each customer eats.

Requirements

Create a new C# Console Application. In the Main function, add a new variable of type Queue that contains items of type string.

Create a variable for a Queue with items of type string
This variable will represent your line of customers waiting outside.
Create a variable for a Dictionary with keys of type string and values of type int.
This variable will hold information about each customer
Put 100 customers into the queue
You can use the randomName function below to generate random people for your line
Add a random number of burgers to the total for each customer. Make sure there is a key in the dictionary for each customer before you try incrementing their total!
Print out each customer and their total burgers eaten.
Sample Output

Your output will look something like this:

Greg Anderson                 131
John Miller                   137
Emily Bell                    148
Ann Rose                      149
Carol Roche                   233
Arthur McKinney               111
Joann Fisher                  72
Dan Morain                    65
Resources

Here is some code that will help you with this project. Paste it into your Program class above your Main function.

public static Random random = new Random();

public static string randomName() {
    string[] names = new string[8]{"Dan Morain", "Emily Bell", "Carol Roche", "Ann Rose", "John Miller", "Greg Anderson", "Arthur McKinney", "Joann Fisher"};
    int randomIndex = Convert.ToInt32(random.NextDouble() * 7);
    return names[randomIndex];
}

public static int randomNumberInRange() {
    return Convert.ToInt32(random.NextDouble() * 20);
}
Guide

First, add the randomName and randomNumberInRange functions above to your program. Then, create a new queue of strings and a dictionary with string keys and int values.

You need to add 100 customers to your queue using the Enqueue method. Remember you can use randomName to generate a random customer name.

Next, we need to iterate over the customers in the queue. This can be done in a number of different ways:

Use the Dequeue method to remove customers from the queue one by one
Use a foreach loop to iterate over the items in the collections
Use an enumerator like so:
IEnumerator MyQueueEnumerator = qMyQueue.GetEnumerator();

while (MyQueueEnumerator.MoveNext())
{
  ...
}
Note: IEnumerator is used to get the values of lists, where the length is not necessarily known ahead of time (even though it could be).
As you iterate through your customers, you should keep track of how many burgers they are ordering. If a customer's name does not yet exist as a key in the dictionary you created, you will need to create a new entry with a starting value of 0. Then, add a random number to their value each time they appear in the list (you can use the provided randomNumberInRange function).

If you are using the provided randomName function, you will encounter the same customer multiple times. Make sure your code increments the number of burgers ordered each time (hint: use +=).

Once you have iterated over all the customers in the queue, you need to print their name and the total number of burgers consumed. Do this by iterating over your dictionary. Again, there are many ways to accomplish this; you can choose to do it any way as long as your output resembles the sample output above.
 * 
 * 
 * 
 * EXTRA: see github repo at https://github.com/awpratt/403DataStructuresBasics
 * */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresBasics
{
    class Program
    {
        public static Random random = new Random();

        public static string randomName()
        {
            string[] names = new string[8] { "Dan Morain", "Emily Bell", "Carol Roche", "Ann Rose", "John Miller", "Greg Anderson", "Arthur McKinney", "Joann Fisher" };
            int randomIndex = Convert.ToInt32(random.NextDouble() * 7);
            return names[randomIndex];
        }

        public static int randomNumberInRange()
        {
            return Convert.ToInt32(random.NextDouble() * 20);
        }



        static void Main(string[] args)
        {
            //variables:
            Queue<string> qsLineWaiters = new Queue<string>();
            Dictionary<string, int> dsiCustomers = new Dictionary<string,int>();
            int iNumCustomers = 0;
            bool bRepeat = true;


            //EXTRA:
            //ask the user how many orders they want:
            while (bRepeat)
            {
                bRepeat = false;
                try 
                {
                    Console.Write("How many customer orders would you like to have generated? ");
                    iNumCustomers = Convert.ToInt32(Console.ReadLine());
                }
                catch 
                {
                    Console.WriteLine("Please enter a valid integer");
                    Console.WriteLine();
                    Console.WriteLine();
                    bRepeat = true;
                }
            }
            


            //fill the queue with random names
            for ( int i = 0; i < iNumCustomers; i++)
            {
                qsLineWaiters.Enqueue(randomName());
            }


            //iterate through the queue and get the names to fill the dictionary
            foreach (string name in qsLineWaiters)
            {
                //if name not found, make a new entry. If found, add the amount to the existing total
                if (dsiCustomers.ContainsKey(name))
                {
                    dsiCustomers[name] += randomNumberInRange();
                }
                else
                {
                    dsiCustomers.Add(name, randomNumberInRange());
                }
            }


            //print the data from the dicitonary out:
            Console.WriteLine();
            Console.WriteLine();
            foreach (KeyValuePair<string, int> customer in dsiCustomers)
            {
                Console.WriteLine(Convert.ToString(customer.Key).PadRight(25, ' ') + " " + Convert.ToString(customer.Value).PadRight(25, ' '));
            }


            //EXTRA
            //sort the data by who ate the most burgers:
            var lSortedCustomers = dsiCustomers.ToList();
            lSortedCustomers.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));

            //EXTRA
            //print the sorted data from the list out:
            Console.WriteLine();
            Console.WriteLine();
            foreach (var customer in lSortedCustomers)
            {
                Console.WriteLine(Convert.ToString(customer.Key).PadRight(25, ' ') + " " + Convert.ToString(customer.Value).PadRight(25, ' '));
            }



            Console.Read();
        }
    }
}
