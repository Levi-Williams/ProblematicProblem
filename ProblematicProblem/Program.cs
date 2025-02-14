using System;
using System.Collections.Generic;
using System.Threading;


namespace ProblematicProblem

{
    class Program
    {
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };


        static void Main(string[] args)
        {
            Random rng = new Random();
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            bool cont = true;
            var contResp = Console.ReadLine().ToLower();

            if (contResp == "yes") { cont = true; }
            else if (contResp == "no") { cont = false; }
            if (cont == false)
            {
                Console.WriteLine("Goodbye then!");
                Environment.Exit(0);
            }

            Console.WriteLine();
            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();
            Console.WriteLine();
            Console.Write("What is your age? ");
            int userAge = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Would you like to see the current list of activities? Yes/No: ");
            var seeLR = Console.ReadLine().ToLower();
            bool seeList = false;

            if (seeLR == "yes") { seeList = true; }
            if (seeLR == "no") { seeList = false; }

            if (seeList == true)
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }
                Console.WriteLine();

                Console.Write("Would you like to add any activities before we generate one? yes/no: ");

                var addAct = Console.ReadLine().ToLower();
                bool addToList = false;
                if (addAct == "yes") { addToList = true; }

                Console.WriteLine();
                while (addToList == true)
                {
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();
                    activities.Add(userAddition);
                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Would you like to add more? yes/no: ");
                    var toAddMore = Console.ReadLine();
                    if (toAddMore == "yes") { addToList = true; }
                    else { addToList = false; }

                }
            }
            if (seeList == false)
            {
                Console.Write("Would you like to add any activities before we generate one? yes/no: ");

                var addAct2 = Console.ReadLine().ToLower();
                bool addToList2 = false;
                if (addAct2 == "yes") { addToList2 = true; }


                Console.WriteLine();
                while (addToList2 == true)
                {
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();
                    activities.Add(userAddition);
                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Would you like to add more? yes/no: ");
                    var toAddMore = Console.ReadLine();
                    if (toAddMore == "yes") { addToList2 = true; }
                    else { addToList2 = false; }

                }
            }

            while (cont == true)
            {
                Console.Write("Connecting to the database");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();
                Console.Write("Choosing your random activity");
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();
                int randomNumber = rng.Next(activities.Count);
                string randomActivity = activities[randomNumber];
                if (userAge < 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("We need to pick something else!");
                    activities.Remove(randomActivity);

                    int randomNumber1 = rng.Next(activities.Count);
                    string randomActivity2 = activities[randomNumber1];

                    Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity2}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                    Console.WriteLine();
                    var userLastResponse2 = Console.ReadLine().ToLower();
                    if (userLastResponse2 == "redo") { activities.Remove(randomActivity2); cont = true; }
                    if (userLastResponse2 == "keep") { cont = false; Console.WriteLine($"Enjoy your {randomActivity}, goodbye now!"); ; };
                }

                else
                {
                    Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                    Console.WriteLine();
                    var userLastResponse = Console.ReadLine().ToLower();
                    if (userLastResponse == "redo") { activities.Remove(randomActivity); cont = true; }
                    if (userLastResponse == "keep") { cont = false; Console.WriteLine($"Enjoy your {randomActivity}, goodbye now!"); ; };
                }

            }

        }
    }
}
    
