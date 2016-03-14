using INFDTA011.Model;
using System;
using System.Collections.Generic;
using System.Linq;


namespace INFDTA011
{
    class Assignment
    {
        public void PrintStepA()
        {
            String stepText = new UserPreference().UserPreferences.ToString();
            Console.WriteLine(stepText);
        }

        public void PrintStepB()
        {
            String stepText = String.Format("Data is imported, an total of {0} users found.", new UserPreference().UserPreferences.Count);
            Console.WriteLine(stepText);
        }

        public void PrintStepC()
        {
            Console.WriteLine("NearestNeightbor Pearson with user 5:");
            Console.WriteLine(NearestNeighbor(5, new UserPreference().UserPreferences, DistanceType.Pearson).First());

            Console.WriteLine("NearestNeightbor Pearson with user 5:");
            Console.WriteLine(NearestNeighbor(5, new UserPreference().UserPreferences, DistanceType.Euclidean).First());

           Console.WriteLine("NearestNeightbor Cosine with user 5:");
            Console.WriteLine(NearestNeighbor(5, new UserPreference().UserPreferences, DistanceType.Cosine).First());
        }
        public enum DistanceType
        {
            Pearson,
            Euclidean,
            Cosine
        }
        private Dictionary<int, decimal> NearestNeighbor(int userId, Dictionary<int, List<UserPreference>> userPreferences, DistanceType distanceType)
        {
            Dictionary<int, decimal> nearestItemRatings = new Dictionary<int, decimal>();

            switch (distanceType)
            {
                case DistanceType.Pearson:
                    foreach (KeyValuePair<int, List<UserPreference>> item in userPreferences.Where(x => x.Key != userId))
                    {
                        decimal deci = Algorithm.Manhattan(userPreferences.Where(x => x.Key == userId).First().Value, userPreferences.Where(x => x.Key == item.Key).First().Value);
                        nearestItemRatings.Add(item.Key, deci);
                    }
                    break;

                case DistanceType.Euclidean:
                    foreach (KeyValuePair<int, List<UserPreference>> item in userPreferences.Where(x => x.Key != userId))
                    {
                        decimal deci = Algorithm.Euclidean(userPreferences.Where(x => x.Key == userId).First().Value, userPreferences.Where(x => x.Key == item.Key).First().Value);
                        nearestItemRatings.Add(item.Key, deci);
                       
                    }
                    break;

                case DistanceType.Cosine: 
                    foreach(KeyValuePair<int, List<UserPreference>> item in userPreferences.Where(x => x.Key != userId))
                    {
                        decimal deci = Algorithm.Cosine(userPreferences.Where(x => x.Key == userId).First().Value, userPreferences.Where(x => x.Key == item.Key).First().Value);
                        nearestItemRatings.Add(item.Key, deci);
                    }
                    break; 
            }

            return nearestItemRatings.OrderBy(o => o.Value).ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
