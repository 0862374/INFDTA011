using INFDTA011.Model;
using INFDTA011.Assignments;
using INFDTA011.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;


namespace INFDTA011
{
    class AssignmentOne : IAssingment
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
            int userId = 1;

            Console.WriteLine("NearestNeightbor Pearson with user {0}:", userId);
            Console.WriteLine(NearestNeighbor(userId, new UserPreference().UserPreferences, new Pearson()).First());

            Console.WriteLine("NearestNeightbor Euclidean with user {0}:", userId);
            Console.WriteLine(NearestNeighbor(userId, new UserPreference().UserPreferences, new Euclidean()).First());

            Console.WriteLine("NearestNeightbor Cosine with user {0}:", userId);
            Console.WriteLine(NearestNeighbor(userId, new UserPreference().UserPreferences, new Cosine()).First());
        }
        
         
        public void PrintStepD()
        {
            PredictRate(2, 101, new UserPreference().UserPreferences);
            throw new NotImplementedException();
        }

        public void PrintStepE()
        {
            throw new NotImplementedException();
        }

        public void PrintStepF()
        {
            throw new NotImplementedException();
        }

        public void PrintStepG()
        {
            throw new NotImplementedException();
        }

        private Dictionary<int, decimal> NearestNeighbor(int userId, Dictionary<int, List<UserPreference>> userPreferences, IAlgorithm algorithm)
        {
            Dictionary<int, decimal> nearestItemRatings = new Dictionary<int, decimal>();

            foreach (KeyValuePair<int, List<UserPreference>> item in userPreferences.Where(x => x.Key != userId))
            {
                decimal deci = algorithm.Calculate(userPreferences.Where(x => x.Key == userId).First().Value, userPreferences.Where(x => x.Key == item.Key).First().Value);
                nearestItemRatings.Add(item.Key, deci);
            }

            return nearestItemRatings.OrderBy(o => o.Value).ToDictionary(x => x.Key, x => x.Value);
        }

        private decimal PredictRate(int userID , int itemID, Dictionary<int, List<UserPreference>> UserPreferences)
        {
            Dictionary<int, decimal> nearestNeighbor = NearestNeighbor(userID, UserPreferences, new Pearson()).Take(3).ToDictionary(x => x.Key, x => x.Value);
           
            foreach (KeyValuePair<int, List<UserPreference>> user in UserPreferences.Where(x => x.Key != userID))
            {

            }
            return 0;
        }

    }
}
