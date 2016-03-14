
using INFDTA011.Model;
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
            //new Main();
            //new Assignment().PrintStepC();
            Console.ReadKey();

            IAlgorithm algorithm = new Cosine();
            UserPreference userPreference = new UserPreference();
            Dictionary<int, List<UserPreference>> userPreferences = userPreference.UserPreferences;

            int userId = 1;

            foreach (KeyValuePair<int, List<UserPreference>> item in userPreferences.Where(x => x.Key != userId))
            {
                decimal deci = algorithm.Calculate(userPreferences.Where(x => x.Key == userId).First().Value, userPreferences.Where(x => x.Key == item.Key).First().Value);

                Console.WriteLine("item:" + item.Key + ";Score:"+deci);
                
            }
            Console.ReadKey();
        }
    }
}
