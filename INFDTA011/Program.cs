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
            Console.WriteLine("Druk op een toets op de applicatie te starten...");
            Console.ReadKey();

            IAlgorithm algorithm = new Cosine();
            UserPreference userPreference = new UserPreference();
            Dictionary<int, List<UserPreference>> userPreferences = userPreference.UserPreferences;

            int userId = 1;

            foreach (KeyValuePair<int, List<UserPreference>> item in userPreferences.Where(x => x.Key != userId))
            {
                decimal deci = algorithm.Calculate(userPreferences.Where(x => x.Key == userId).First().Value, userPreferences.Where(x => x.Key == item.Key).First().Value);

                //Console.WriteLine("item:" + item.Key + ";Score:"+deci);
                
            }

            NearestNeighbor(1, userPreferences, new Cosine()).ToList().ForEach(x => Console.WriteLine(x.Value));
            Console.ReadKey();
        }

        public static Dictionary<int, decimal> NearestNeighbor(int userId, Dictionary<int, List<UserPreference>> userPreferences, IAlgorithm algorithm)
        {
            Dictionary<int, decimal> nearestItemRatings = new Dictionary<int, decimal>();

            foreach (KeyValuePair<int, List<UserPreference>> item in userPreferences.Where(x => x.Key != userId))
            {
                decimal deci = Algorithm.Manhattan(userPreferences.Where(x => x.Key == userId).First().Value, userPreferences.Where(x => x.Key == item.Key).First().Value);
                nearestItemRatings.Add(item.Key, deci);
            }
        
            return nearestItemRatings.OrderBy(o => o.Value).ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
