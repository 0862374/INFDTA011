using INFDTA011.Model;
using INFDTA011.Assignments;
using System;
using System.Linq;
using System.Collections.Generic;
using INFDTA011.Algorithms;

namespace INFDTA011
{
    class Program
    {
        static void Main(string[] args)
        {
            //StartConsole();
            StartConsoleTwo();

            Console.ReadKey();
        }

        static void StartConsole()
        {
            Console.WriteLine("Welcome, choose an character to start the application:");
            Console.WriteLine("[A] Step A Build a TreeMap/Dictionary structure to contain user preferences");
            Console.WriteLine("[B] Step B Import the userItem.data dataset into such structure.");
            Console.WriteLine("[C] Step C Implement the nearest neighbours algorithm");
            Console.WriteLine("[D] Step D implement the comoputation of the predicted rating.");
            Console.WriteLine("[E] Step E Apply the algorithm to the small dataset imported at point B.");
            Console.WriteLine("[F] Step F Implement the computation of the n top recommendations for a user.");
            Console.WriteLine("[G] Step G import the MovieLens 100k dataset.");
            Console.WriteLine("[H] Step H Implement the computation of the n top recommendations for a user with prediction 3.");
            ConsoleKeyInfo keyPressed = Console.ReadKey();

            IAssingment assignment = new AssignmentOne();

            switch (keyPressed.KeyChar)
            {
                case 'a':
                    assignment.PrintStepA();
                    break;
                case 'b':
                    assignment.PrintStepB();
                    break;
                case 'c':
                    assignment.PrintStepC();
                    break;
                case 'd':
                    assignment.PrintStepD();
                    break;
                case 'e':
                    assignment.PrintStepE();
                    break;
                case 'f':
                    assignment.PrintStepF();
                    break;
                case 'g':
                    assignment.PrintStepG();
                    break;
                case 'h':
                    assignment.PrintStepH();
                    break;
            }

            Console.WriteLine("Click on a button to reselect an option.");
            Console.ReadKey();
            StartConsole();
        }

        static void StartConsoleTwo()
        {
            Console.WriteLine("Welcome, choose an character to start the application:");
            Console.WriteLine("[A] Step A Computing deviations");
            Console.WriteLine("[B] Step B Import the userItem.data dataset into such structure.");
            Console.WriteLine("[C] Step C Implement the nearest neighbours algorithm");
            Console.WriteLine("[D] Step D implement the comoputation of the predicted rating.");
            Console.WriteLine("[E] Step E Apply the algorithm to the small dataset imported at point B.");
            Console.WriteLine("[F] Step F Implement the computation of the n top recommendations for a user.");
            Console.WriteLine("[G] Step G import the MovieLens 100k dataset.");
            Console.WriteLine("[H] Step H Implement the computation of the n top recommendations for a user with prediction 3.");
            ConsoleKeyInfo keyPressed = Console.ReadKey();

            IAssingment assignment = new AssignmentTwo();
            Console.WriteLine();

            switch (keyPressed.KeyChar)
            {
                case 'a':
                    assignment.PrintStepA();
                    break;
                case 'b':
                    assignment.PrintStepB();
                    break;
                case 'c':
                    assignment.PrintStepC();
                    break;
                case 'd':
                    assignment.PrintStepD();
                    break;
                case 'e':
                    assignment.PrintStepE();
                    break;
                case 'f':
                    assignment.PrintStepF();
                    break;
                case 'g':
                    assignment.PrintStepG();
                    break;
                case 'h':
                    assignment.PrintStepH();
                    break;
            }

            Console.WriteLine("Click on a button to reselect an option.");
            Console.ReadKey();
            StartConsoleTwo();
        }


    }
}
