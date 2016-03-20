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
            new UserPreference().UserPreferences.ToList().ForEach(x => x.Value.ForEach(y => Console.WriteLine("Key: " + x.Key + "; ArticleId: " + y.ArticleId + "; Rating: " + y.Rating)));
        }

        public void PrintStepC()
        {
            int userId = 1;

            Console.WriteLine("NearestNeightbor Pearson with user {0}:", userId);
            Console.WriteLine(NearestNeighbour(userId, new UserPreference().UserPreferences, new Pearson()).First());

            Console.WriteLine("NearestNeightbor Euclidean with user {0}:", userId);
            Console.WriteLine(NearestNeighbour(userId, new UserPreference().UserPreferences, new Euclidean()).First());

            Console.WriteLine("NearestNeightbor Cosine with user {0}:", userId);
            Console.WriteLine(NearestNeighbour(userId, new UserPreference().UserPreferences, new Cosine()).First());
        }
        
         
        public void PrintStepD()
        {
            int userId = 4;
            int articleId = 101;
            Console.WriteLine("Predicted Rating of user {0}: with article {1}", userId, articleId);
            Dictionary<int, double> nearestNeighbours = NearestNeighbour(userId, new UserPreference().UserPreferences, new Pearson()).OrderByDescending(x => x.Value).Take(25).ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine(PredictRate(userId, articleId, new UserPreference().UserPreferences, nearestNeighbours));
        }

        public void PrintStepE()
        {
            int userIdx = 7;
            int userIdy = 3;
            int[] userItems = { 101, 103, 106 };
            Dictionary<int, List<UserPreference>> userPreferences = new UserPreference().UserPreferences;
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Stap 1a: NearestNeightbor Pearson with user {0}:", userIdx);
            NearestNeighbour(userIdx, userPreferences, new Pearson()).Where(x => Math.Abs(x.Value) >= (double)new Pearson().treshhold).Take(3).ToList().ForEach(x => Console.WriteLine(x.Key + ":" + Math.Abs(x.Value)));

            Console.WriteLine("Stap 1b: NearestNeightbor Euclidean with user {0}:", userIdx);
            NearestNeighbour(userIdx, userPreferences, new Euclidean()).Where(x => Math.Abs(x.Value) >= (double)new Euclidean().treshhold).Take(3).ToList().ForEach(x => Console.WriteLine(x.Key + ":" + Math.Abs(x.Value)));

            Console.WriteLine("Stap 1c: NearestNeightbor Cosine with user {0}:", userIdx);
            NearestNeighbour(userIdx, userPreferences, new Cosine()).Where(x => Math.Abs(x.Value) >= (double)new Cosine().treshhold).Take(3).ToList().ForEach(x => Console.WriteLine(x.Key + ":" + Math.Abs(x.Value)));

            Console.WriteLine("--------------------------------------------------------------------------------");

            userIdx = 4;
            Console.WriteLine("Stap 2: Pearson coefficient between user {0} and {1}:", userIdy, userIdx);
            Console.WriteLine(new Pearson().Calculate(userPreferences.Where(x => x.Key == userIdy).First().Value, userPreferences.Where(x => x.Key == userIdx).First().Value));

            Console.WriteLine("--------------------------------------------------------------------------------");
            userIdx = 7;

            Console.WriteLine("Stap 3a: Pearson Predicted Rating of nearest Neighbor of user {0} with item {1}:", userIdx, userItems[0]);
            Dictionary<int, double> nearestNeighbours = NearestNeighbour(userIdx, new UserPreference().UserPreferences, new Pearson(), userItems[0]).OrderByDescending(x => x.Value).Take(3).ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine(PredictRate(userIdx, userItems[0], userPreferences, nearestNeighbours));

            Console.WriteLine("Stap 3b: Pearson Predicted Rating of nearest Neighbor of user {0} with item {1}:", userIdx, userItems[1]);
            nearestNeighbours = NearestNeighbour(userIdx, new UserPreference().UserPreferences, new Pearson(), userItems[1]).OrderByDescending(x => x.Value).Take(3).ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine(PredictRate(userIdx, userItems[1], userPreferences, nearestNeighbours));

            Console.WriteLine("Stap 3c: Pearson Predicted Rating of nearest Neighbor of user {0} with item {1}:", userIdx, userItems[2]);
            nearestNeighbours = NearestNeighbour(userIdx, new UserPreference().UserPreferences, new Pearson(), userItems[2]).OrderByDescending(x => x.Value).Take(3).ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine(PredictRate(userIdx, userItems[2], userPreferences, nearestNeighbours));
            Console.WriteLine("--------------------------------------------------------------------------------");
            userIdx = 4;
            Console.WriteLine("Stap 4: Pearson Predicted Rating of nearest Neighbor of user {0} with item {1}:", userIdx, userItems[0]);
            nearestNeighbours = NearestNeighbour(userIdx, new UserPreference().UserPreferences, new Pearson(), userItems[0]).OrderByDescending(x => x.Value).Take(3).ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine(PredictRate(userIdx, userItems[0], userPreferences, nearestNeighbours));

            Console.WriteLine("--------------------------------------------------------------------------------");

            userIdx = 7;
            UserPreference item = new UserPreference { UserId = userIdx, ArticleId = userItems[2], Rating = 2.8f };
            if (userPreferences.ContainsKey(item.UserId))
            {
                userPreferences.Where(x => x.Key == item.UserId).First().Value.Add(item);
            }
            else
            {
                userPreferences.Add(item.UserId, new List<UserPreference> { item });
            }
            Console.WriteLine("Stap 5a: Pearson Predicted Rating of nearest Neighbor of user {0} with article {1} and rating 2.8:", userIdx, userItems[0]);
            nearestNeighbours = NearestNeighbour(userIdx, new UserPreference().UserPreferences, new Pearson(), userItems[0]).OrderByDescending(x => x.Value).Take(3).ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine(PredictRate(userIdx, userItems[0], userPreferences, nearestNeighbours));

            Console.WriteLine("Stap 5b: Pearson Predicted Rating of nearest Neighbor of user {0} with article {1} and rating 2.8 :", userIdx, userItems[1]);
            nearestNeighbours = NearestNeighbour(userIdx, new UserPreference().UserPreferences, new Pearson(), userItems[1]).OrderByDescending(x => x.Value).Take(3).ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine(PredictRate(userIdx, userItems[1], userPreferences, nearestNeighbours));

            Console.WriteLine("--------------------------------------------------------------------------------");
            userPreferences
                         .Where(p => p.Value.Any(c => c.UserId == userIdx))
                         .SelectMany(p => p.Value)
                         .Where(c => c.ArticleId == userItems[2]).First().Rating = 5;
            Console.WriteLine("Stap 6a: Pearson Predicted Rating of nearest Neighbor of user {0} with article {1} and rating 5 :", userIdx, userItems[0]);
            nearestNeighbours = NearestNeighbour(userIdx, new UserPreference().UserPreferences, new Pearson(), userItems[0]).OrderByDescending(x => x.Value).Take(3).ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine(PredictRate(userIdx, userItems[0], userPreferences, nearestNeighbours));

            Console.WriteLine("Stap 6b: Pearson Predicted Rating of nearest Neighbor of user {0} with article {1} and rating 5 :", userIdx, userItems[1]);
            nearestNeighbours = NearestNeighbour(userIdx, new UserPreference().UserPreferences, new Pearson(), userItems[1]).OrderByDescending(x => x.Value).Take(3).ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine(PredictRate(userIdx, userItems[1], userPreferences, nearestNeighbours));

            Console.WriteLine("--------------------------------------------------------------------------------");



        }
           
        public void PrintStepF()
        {

            int userIdx = 186;
            Console.WriteLine("Stap F: Computing the top 8 recommendations of user {0}:", userIdx);

            Dictionary<int, List<UserPreference>> userPreferences = new UserPreference().UserPreferences;
            Dictionary<int, double> nearestNeighbours = NearestNeighbour(userIdx, userPreferences, new Pearson()).Where(x => Math.Abs(x.Value) >= new Pearson().treshhold).OrderByDescending(x => x.Value).Take(25).ToDictionary(x => x.Key, x => x.Value);
            List<int> moviesSeen = new List<int>();
            userPreferences.Where(x => x.Key == userIdx).ToList().ForEach(x => x.Value.ForEach(d => moviesSeen.Add(d.ArticleId)));

            List<int> notSeen = new List<int>();
            foreach(KeyValuePair<int, double> neighbor in nearestNeighbours)
            {
                foreach(KeyValuePair<int, List<UserPreference>> values in userPreferences.Where(x => x.Key == neighbor.Key))
                {
                    foreach(UserPreference value in values.Value)
                    {
                        if (!moviesSeen.Contains(value.ArticleId) && !notSeen.Contains(value.ArticleId))
                        {
                            notSeen.Add(value.ArticleId);
                        }
                    }
                }
            }

            Dictionary<int, double> predictedMovies = new Dictionary<int, double>();
            foreach(int movieId in notSeen)
            {
                predictedMovies.Add(movieId, PredictRate(userIdx, movieId, userPreferences, nearestNeighbours));
            }

            predictedMovies.OrderByDescending(x => x.Value).Take(8).ToDictionary(x=> x.Key, x => x.Value).ToList().ForEach(x => Console.WriteLine(x.Key +":"+ x.Value));
        }

        public void PrintStepG()
        {
            int userIdx = 186;
            Console.WriteLine("Stap G: user {0}:", userIdx);
            Dictionary<int, List<UserPreference>> userPreferences = new UserPreference().UserPreferences;
            Dictionary<int, double> nearestNeighbours = NearestNeighbour(userIdx, userPreferences, new Pearson()).ToDictionary(x => x.Key, x => x.Value);
            List<int> moviesSeen = new List<int>();
            userPreferences.Where(x => x.Key == userIdx).ToList().ForEach(x => x.Value.ForEach(d => moviesSeen.Add(d.ArticleId)));

            List<int> notSeen = new List<int>();
            foreach (KeyValuePair<int, double> neighbor in nearestNeighbours.OrderByDescending(x => x.Value).Take(25).ToDictionary(k => k.Key, k => k.Value))
            {
                foreach (KeyValuePair<int, List<UserPreference>> values in userPreferences.Where(x => x.Key == neighbor.Key))
                {
                    foreach (UserPreference value in values.Value)
                    {
                        if (!moviesSeen.Contains(value.ArticleId) && !notSeen.Contains(value.ArticleId))
                        {
                            notSeen.Add(value.ArticleId);
                        }
                    }
                }
            }

            Dictionary<int, double> predictedMovies = new Dictionary<int, double>();
            foreach (int movieId in notSeen)
            {
                predictedMovies.Add(movieId, PredictRate(userIdx, movieId, userPreferences, nearestNeighbours));
            }

            predictedMovies.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value).Take(8).ToList().ForEach(x => Console.WriteLine(x.Key + ":" + x.Value));
        }

        public void PrintStepH()
        {
            int userIdx = 186;
            Console.WriteLine("Stap F: Computing the top 8 recommendations of user {0}:", userIdx);

            Dictionary<int, List<UserPreference>> userPreferences = new UserPreference().UserPreferences;
            Dictionary<int, double> nearestNeighbours = NearestNeighbour(userIdx, userPreferences, new Pearson()).Where(x => Math.Abs(x.Value) >= new Pearson().treshhold).OrderByDescending(x => x.Value).Take(25).ToDictionary(x => x.Key, x => x.Value);

            List<int> moviesSeen = new List<int>();
            userPreferences.Where(x => x.Key == userIdx).ToList().ForEach(x => x.Value.ForEach(d => moviesSeen.Add(d.ArticleId)));

            List<int> notSeen = new List<int>();
            foreach (KeyValuePair<int, double> neighbor in nearestNeighbours)
            {
                foreach (KeyValuePair<int, List<UserPreference>> values in userPreferences.Where(x => x.Key == neighbor.Key))
                {
                    foreach (UserPreference value in values.Value)
                    {
                        if (!moviesSeen.Contains(value.ArticleId) && !notSeen.Contains(value.ArticleId))
                        {
                            notSeen.Add(value.ArticleId);
                        }
                    }
                }
            }

            Dictionary<int, double> predictedMovies = new Dictionary<int, double>();
            foreach (int movieId in notSeen)
            {
                Dictionary<int, double> nearestNeighboursRatedArticle = nearestNeighbours.Where(x => userPreferences
                       .Where(p => p.Value.Any(c => c.UserId == x.Key))
                       .SelectMany(p => p.Value)
                       .Where(c => c.ArticleId == movieId).Count() > 0).ToDictionary(d => d.Key, d => d.Value);

                if (nearestNeighboursRatedArticle.Count() >= 3)
                {
                    predictedMovies.Add(movieId, PredictRate(userIdx, movieId, userPreferences, nearestNeighboursRatedArticle));
                }
            }

            predictedMovies.OrderByDescending(x => x.Value).Take(8).ToDictionary(x => x.Key, x => x.Value).ToList().ForEach(x => Console.WriteLine(x.Key + ":" + x.Value));
        }

        private Dictionary<int, double> NearestNeighbour(int userId, Dictionary<int, List<UserPreference>> userPreferences, IAlgorithm algorithm, int articleId = 0)
        {
            Dictionary<int, double> neighbour = new Dictionary<int, double>();

            // if articleId is zero then get all the nearestneighbours else get the nearestneighbours which also rated the article
            Dictionary<int, List<UserPreference>>  filteredUserPreferences = (articleId == 0) ? userPreferences.Where(x => x.Key != userId).ToDictionary(d => d.Key, d=> d.Value) : userPreferences.Where(x => x.Key != userId && x.Value.Where(y => y.ArticleId == articleId).Count() > 0).ToDictionary(d => d.Key, d => d.Value);

            foreach (KeyValuePair<int, List<UserPreference>> item in filteredUserPreferences)
            {
                double deci = algorithm.Calculate(userPreferences.Where(x => x.Key == userId).First().Value, userPreferences.Where(x => x.Key == item.Key).First().Value);
                neighbour.Add(item.Key, deci);
            }

            return neighbour.OrderBy(o => o.Value).ToDictionary(x => x.Key, x => x.Value);
        }

        private double PredictRate(int userId , int articleId, Dictionary<int, List<UserPreference>> UserPreferences, Dictionary<int, double> nearestNeighbours)
        {
            Dictionary<int, double> nearestNeighboursRatedArticle = nearestNeighbours.Where(x => UserPreferences
                       .Where(p => p.Value.Any(c => c.UserId == x.Key))
                       .SelectMany(p => p.Value)
                       .Where(c => c.ArticleId == articleId).Count() > 0).ToDictionary(d => d.Key, d => d.Value);

            double total_coefficient = Math.Abs(nearestNeighboursRatedArticle.Sum(x => Math.Abs(x.Value)));
            double predictedRate = 0;

            foreach (KeyValuePair<int, double> neighbor in nearestNeighboursRatedArticle)
            {
                double influenceWeight = InfluenceWeight(Math.Abs(neighbor.Value), total_coefficient);

                UserPreference user = null;
                try
                {
                    // try to get the rating of the user (if exists)
                    user = UserPreferences
                         .Where(p => p.Value.Any(c => c.UserId == neighbor.Key))
                         .SelectMany(p => p.Value)
                         .Where(c => c.ArticleId == articleId).First();
                }
                catch (Exception e) {
                    
                }
                
                // if no user found then make the rating 0
                double rating = user.Rating;
                double weightedRating = WeightedRating(influenceWeight, rating);

                predictedRate += weightedRating;
            }
            return Math.Abs(predictedRate);
        }

        private double InfluenceWeight(double coefficient, double total_coefficient)
        {
            return coefficient / total_coefficient;
        }
        private double WeightedRating(double influenceweight, double rating)
        {
            return influenceweight * rating;
        }


    }
}
