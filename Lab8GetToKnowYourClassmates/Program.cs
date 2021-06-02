using System;
using System.Collections.Generic;

namespace Lab8GetToKnowYourClassmates
{
    class Program
    {
        static void Main(string[] args)
        {
            //3 big sections of this program
            //1) storing our names, favorite foods, hometown
            //2) Asking which user you'd like to learn about
            //3) Learn about someone's either hometown or favorite food

                                                    //0,        1,      2
            List<string> names = new List<string>() { "Tommy", "Mark", "James", "Andrew", "Maggie", "Jerome", "Trent", "Troy", "Kevin", "Josh", "Sean", "Kate"};
            //given our list of names, how do we tie hometowns/favoritefoods to a particular person?
            List<string> foods = new List<string>() { "Chicken Curry", "Cilantro", "Sushi", "Sushi", "Movie theater popcorn", "Italian Cuisine", "Tacos", "Broccoli", "Asian Cuisine", "Nalesniki", "Meat", "Pizza"};
            List<string> hometown = new List<string>() { "Raleigh NC", "Grand Rapids", "Toledo", "Grayslake", "Montrose", "Milwaukee WI", "Rochester", "Indian River", "Detroit", "Northville", "Eaton Rapids", "Zeeland"};
            List<string> operatingSystem = new List<string>() { "Windows", "Linux", "Windows", "Windows", "Windows", "Windows", "Linux", "Windows", "OSX", "Windows", "Windows", "OSX"};

            /*PrintWholeList(names);
            PrintWholeList(foods);
            PrintWholeList(hometown);
            PrintWholeList(os);*/

            while (true)
            {
                // Console readline can only give us a string
                //so to use it as an index we MUST convert it to an int

                int index = -1;


                //search by name
                string firstPrompt = GetUserInput("Welcome to our C# class. Would you like to search by student name or number?");
                if (firstPrompt == "name")
                {
                    Console.WriteLine("Please enter a name: ");
                    string enteredName = Console.ReadLine();
                    index = names.FindIndex(x => x.Contains(enteredName));

                    /*for (int i = 0; i < names.Count; i++)
                    {
                        if (names[i] == enteredName)
                        {
                            index = i;
                            break;
                        }
                    }*/

                    if (index == -1)
                    {
                        Console.WriteLine("Name not found. Please try again");
                        continue;
                    }


                }
                //search by number
                else if (firstPrompt == "number")
                {
                    string input = GetUserInput($"Which student would you like to learn more about? (enter a number 1-{names.Count}): ");
                    index = int.Parse(input) - 1;

                    if (index < 0 || index > names.Count - 1)
                    {
                        Console.WriteLine("Invalid input. Please try again");
                        continue;
                    }
                }
                //invalid input message
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    continue;
                }


                string name = names[index];
                string input2 = GetUserInput($"What would you like to learn about {name}? hometown, favoritefood, os (operating system)");
                if (input2 == "hometown")
                {
                    string ht = hometown[index];
                    Console.WriteLine($"{name}'s hometown is {ht}");
                }
                else if(input2 == "os")
                {
                    string os = operatingSystem[index];
                    Console.WriteLine($"{name}'s operating system is {os}");
                }
                else if (input2 == "favoritefood")
                {
                    string ff = foods[index];
                    Console.WriteLine($"{name}'s favoritefood is {ff}");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid input");
                }

                Console.WriteLine("Would you like to learn about another student? y/n ");
                string answerContinue = Console.ReadLine();
                if (answerContinue == "n")
                {
                    break;
                }
            }

            

        }
        //method to print a list for us - which we will proably use a lot
        //Methods are also called Functions
        public static void PrintWholeList(List<string> items)
        {
            for(int iterateList = 0; iterateList < items.Count; iterateList++)
            {
                Console.WriteLine($"{iterateList}: {items[iterateList]}");
            }
        }

        //method for getting user input
        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine().ToLower().Trim();
            return input;
        }

    }
}
