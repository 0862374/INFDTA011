using INFDTA011.Model;
using INFDTA011.Assignments;
using INFDTA011.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading;
using System.Threading.Tasks;
using System.Drawing;


namespace INFDTA011
{
    class AssignmentTwo : IAssingment
    {
        public void PrintStepA()
        {
            // user and article to calculate rating for
            int userId = 7;
            int articleId = 106;

            var userPreferences = new UserPreference().UserPreferences;
            var deviationMatrix = CalculateDeviationMatrix(userPreferences);

            double rating = PredictRate(deviationMatrix, userId, articleId, userPreferences);

            Console.WriteLine("Rating for user {0} with article {1}: {2}", userId, articleId, rating);
        }

        public void PrintStepB()
        {
            // user and article to calculate rating for
            int userId = 186;

            Console.WriteLine("Reading files...");
            var userPreferences = new UserPreference().UserPreferences;

            Console.WriteLine("Calculating deviationmatrix...");
            // create an list with all articles wich are rated by the user
            List<int> articlesRated = new List<int>();
            userPreferences.Where(x => x.Key == userId).ToList().ForEach(x => x.Value.ForEach(d => articlesRated.Add(d.ArticleId)));

            // create an list with all articles wich are not rated by the user
            List<int> articlesNotRated = GetArticlesNotRated(userId, userPreferences, articlesRated);
            var deviationMatrix = CalculateDeviationMatrix(userPreferences, articlesNotRated);

            Console.WriteLine("Creating recommendations...");
            var topRecommendations = CalculateTopRecommendations(userId, userPreferences, deviationMatrix, 5);

            foreach(var recommendation in topRecommendations)
            {
                Console.WriteLine("Rating for user {0} with article {1}: {2}", userId, recommendation.Key, recommendation.Value);
            }
            
        }

        public void PrintStepC()
        {
            // user and article to calculate rating for
            int userId = 7;

            var userPreferences = new UserPreference().UserPreferences;
            var deviationMatrix = CalculateDeviationMatrix(userPreferences);

            userPreferences.Where(x => x.Key == 3).First().Value.Add(new UserPreference { ArticleId = 105, Rating = 4, UserId = 3 });
            deviationMatrix.UpdateDeviationMatrix(deviationMatrix.Deviations, userPreferences, 105);

            var topRecommendations = CalculateTopRecommendations(userId, userPreferences, deviationMatrix, 30);

            foreach (var recommendation in topRecommendations)
            {
                Console.WriteLine("Rating for user {0} with article {1}: {2}", userId, recommendation.Key, recommendation.Value);
            }
        }
        
        public void PrintStepD()
        {
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
        public void PrintStepH()
        {
            throw new NotImplementedException();
        }

        private Dictionary<int, double> CalculateTopRecommendations(int userId, Dictionary<int, List<UserPreference>> userPreferences, DeviationMatrix deviationMatrix, int topN = 1)
        {
            // create an list with all articles wich are rated by the user
            List<int> articlesRated = new List<int>();
            userPreferences.Where(x => x.Key == userId).ToList().ForEach(x => x.Value.ForEach(d => articlesRated.Add(d.ArticleId)));

            // create an list with all articles wich are not rated by the user
            List<int> articlesNotRated = GetArticlesNotRated(userId, userPreferences, articlesRated);

            // predict the ratings of the articles
            Dictionary<int, double> predictedArticles = new Dictionary<int, double>();
            foreach (int articleId in articlesNotRated)
            {
                predictedArticles.Add(articleId, PredictRate(deviationMatrix, userId, articleId, userPreferences));
            }

            // return the predicted rates ordered by rating descending and take the topN items
            return predictedArticles.OrderByDescending(x => x.Value).Take(topN).ToDictionary(x => x.Key, x => x.Value);
        }

        private List<int> GetArticlesNotRated(int userId, Dictionary<int, List<UserPreference>> userPreferences, List<int> articlesRated)
        {
            List<int> articlesnotRated = new List<int>();

            foreach (var user in userPreferences)
            {
                foreach (var values in userPreferences.Where(x => x.Key == user.Key))
                {
                    foreach (UserPreference value in values.Value)
                    {
                        // if article not rated and not already in list then add to list
                        if (!articlesRated.Contains(value.ArticleId) && !articlesnotRated.Contains(value.ArticleId))
                        {
                            articlesnotRated.Add(value.ArticleId);
                        }
                    }
                }
            }

            return articlesnotRated;
        }

        private double PredictRate(DeviationMatrix deviationMatrix, int userId, int articleId, Dictionary<int, List<UserPreference>> userPreferences)
        {
            // predict rating
            double calculation = 0;
            int items = 0;
            foreach (var userPreference in userPreferences.Where(x => x.Key == userId).First().Value)
            {
                try {
                    DeviationMatrix.Deviation deviation = deviationMatrix.Deviations.Where(x => x.ArticleOne == articleId && x.ArticleTwo == userPreference.ArticleId).First();

                    calculation += ((userPreference.Rating + deviation.Difference) * deviation.Items);
                    items += deviation.Items;
                }
                catch (Exception e) { }
            }

            double rating = (calculation / items);

            return rating;
        }

        private DeviationMatrix CalculateDeviationMatrix(Dictionary<int, List<UserPreference>> userPreferences, List<int> articlesNotRated = null)
        {
            DeviationMatrix deviationMatrix = new DeviationMatrix();
            List<int> articles;
            var allArticles = deviationMatrix.GetArticleIds(userPreferences).Distinct().ToList();
            List<int> deviationsAlreadyCalculated = new List<int>();

            if(articlesNotRated == null)
            {
                articles = deviationMatrix.GetArticleIds(userPreferences).Distinct().ToList();
            } else
            {
                articles = articlesNotRated;
            }

            /*Parallel.ForEach(articles, (article) =>
            {
                if (deviationsAlreadyCalculated.Where(x => x == article).Count() > 0)
                {
                    deviationMatrix.Deviations.Where(x => x.ArticleTwo == article).ToList().
                        ForEach(x => deviationMatrix.Deviations.Add(
                            new DeviationMatrix.Deviation
                            {
                                ArticleOne = x.ArticleTwo,
                                ArticleTwo = x.ArticleOne,
                                Difference = Math.Abs(x.Difference),
                                Items = x.Items
                            }));
                }
                else {
                    allArticles.Where(i => i != article).ToList().ForEach(x => deviationMatrix.Deviations.Add(deviationMatrix.CalculateDeviation(userPreferences, article, x)));
                    deviationsAlreadyCalculated.Add(article);
                }
            });*/

            // calculate the deviation for every article
            foreach (int article in articles)
            {
                if (deviationsAlreadyCalculated.Where(x => x == article).Count() > 0)
                {
                    deviationMatrix.Deviations.Where(x => x.ArticleTwo == article).ToList().
                        ForEach(x => deviationMatrix.Deviations.Add(
                            new DeviationMatrix.Deviation
                            {
                                ArticleOne = x.ArticleTwo,
                                ArticleTwo = x.ArticleOne,
                                Difference = Math.Abs(x.Difference),
                                Items = x.Items
                            }));
                }
                else {
                    allArticles.Where(i => i != article).ToList().ForEach(x => deviationMatrix.Deviations.Add(deviationMatrix.CalculateDeviation(userPreferences, article, x)));
                    deviationsAlreadyCalculated.Add(article);
                }
            }

            return deviationMatrix;
        }
        
    }
}
