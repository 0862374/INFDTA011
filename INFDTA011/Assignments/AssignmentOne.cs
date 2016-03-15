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
            int userId = 4;
            int articleId = 101;
            Console.WriteLine("Predicted Rating of user {0}: with article {1}", userId, articleId);
            Console.WriteLine(PredictRate(userId, articleId, new UserPreference().UserPreferences));
        }

        public void PrintStepE()
        {
            int userIdx = 7;
            int userIdy = 3;
            int [] userItems = { 101, 103, 106 };
            Dictionary<int, List<UserPreference>> userPreferences = new UserPreference().UserPreferences;

            Console.WriteLine("Stap 1: NearestNeightbor Pearson with user {0}:", userIdx);
            NearestNeighbor(userIdx, userPreferences, new Pearson()).Where(x => Math.Abs(x.Value) >= (decimal)new Pearson().treshhold).Take(3).ToList().ForEach(x => Console.WriteLine(x.Key + ":" + Math.Abs(x.Value)));

            Console.WriteLine("Stap 1: NearestNeightbor Euclidean with user {0}:", userIdx);
            NearestNeighbor(userIdx, userPreferences, new Euclidean()).Where(x => Math.Abs(x.Value) >= (decimal)new Euclidean().treshhold).Take(3).ToList().ForEach(x => Console.WriteLine(x.Key + ":" + Math.Abs(x.Value)));

            Console.WriteLine("Stap 1: NearestNeightbor Cosine with user {0}:", userIdx);
            NearestNeighbor(userIdx, userPreferences, new Cosine()).Where(x => Math.Abs(x.Value) >= (decimal)new Cosine().treshhold).Take(3).ToList().ForEach(x => Console.WriteLine(x.Key + ":" + Math.Abs(x.Value)));

            userIdx = 4;
            Console.WriteLine("Stap 2: Pearson coefficient between user {0} and {1}:", userIdy, userIdx);
            Console.WriteLine(new Pearson().Calculate(userPreferences.Where(x => x.Key == userIdy).First().Value, userPreferences.Where(x => x.Key == userIdx).First().Value));

            userIdx = 7;
            
            Console.WriteLine("Stap 3: Pearson Predicted Rating of nearest Neighbor of user {0} with item {1}:", userIdx, userItems[0]);
            Console.WriteLine(PredictRate(userIdx, userItems[0], userPreferences));

            Console.WriteLine("Stap 3: Pearson Predicted Rating of nearest Neighbor of user {0} with item {1}:", userIdx, userItems[1]);
            Console.WriteLine(PredictRate(userIdx, userItems[1], userPreferences) + " " + userItems[1]);

            Console.WriteLine("Stap 3: Pearson Predicted Rating of nearest Neighbor of user {0} with item {1}:", userIdx, userItems[2]);
            Console.WriteLine(PredictRate(userIdx, userItems[2], userPreferences));



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
            decimal total_coefficient = Math.Abs(nearestNeighbor.Sum(x => x.Value));
            decimal predictedRate = 0;

            foreach (KeyValuePair<int, decimal> neighbor in nearestNeighbor)
            {

                decimal influenceWeight = InfluenceWeight(Math.Abs(neighbor.Value), total_coefficient);
                decimal rating = (decimal)UserPreferences.Where(x => x.Key == neighbor.Key).First().Value.First().Rating;
                decimal weightedRating = WeightedRating(influenceWeight, rating);

                predictedRate += weightedRating;
            }
            return Math.Abs(predictedRate);
        }

        private decimal InfluenceWeight(decimal coefficient, decimal total_coefficient)
        {
            return coefficient / total_coefficient;
        }
        private decimal WeightedRating(decimal influenceweight, decimal rating)
        {
            return influenceweight * rating;
        }


    }
}
