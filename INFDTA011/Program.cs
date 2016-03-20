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
            StartConsole();
           
            
            IAssingment assignmet = new AssignmentOne();

            assignmet.PrintStepB();
            Console.ReadKey();
        }

        static void StartConsole()
        {
            Console.WriteLine("Welcome, choose an character to start the application:");
            Console.WriteLine("[A] Step A Build a TreeMap/Dictionary structure to contain user preferences");
            Console.WriteLine("[B] Step B Import the userItem.data dataset into such structure.");
            Console.WriteLine("[C] Step C Build a TreeMap/Dictionary structure to contain user preferences");
            Console.WriteLine("[D] Step D Import the userItem.data dataset into such structure.");
            Console.WriteLine("[E] Step E Build a TreeMap/Dictionary structure to contain user preferences");
            Console.WriteLine("[F] Step F Import the userItem.data dataset into such structure.");
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
            }

            Console.WriteLine("Click on a button to reselect an option.");
            Console.ReadKey();
            StartConsole();
        }

        
    }
}
