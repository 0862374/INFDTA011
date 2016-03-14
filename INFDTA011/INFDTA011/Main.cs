using INFDTA011.Model;
using System;
using System.Collections.Generic;
using System.Linq;
/*
namespace INFDTA011
{
    class Main
    {
        Dictionary<int, List<ItemRating>> UserPreferences = new Dictionary<int, List<ItemRating>>();
        public Main()
        {
            UserPreferences = GetUserPreferencesData();
            //Console.WriteLine(Manhattan(UserPreferences.Where(x => x.Key == 5).First().Value, UserPreferences.Where(x => x.Key == 6).First().Value));
            //Dictionary<int, decimal> a = NearestNeighbor(5, UserPreferences, DistanceType.Euclidean);
            //Dictionary<int, float> b = RecommendArticle(1, UserPreferences, DistanceType.Pearson);
            new Assignment().PrintStepC(); 
            Console.ReadKey();
        }

        public enum DistanceType
        {
            Pearson,
            Euclidean,
            Cosine
        }

        private Dictionary<int, decimal> NearestNeighbor(int userId, Dictionary<int, List<ItemRating>> userPreferences, DistanceType distanceType)
        {
            Dictionary<int, decimal> nearestItemRatings = new Dictionary<int, decimal>();

            switch (distanceType)
            {
                case DistanceType.Pearson:
                    foreach (KeyValuePair<int, List<ItemRating>> item in userPreferences.Where(x => x.Key != userId))
                    {
                        decimal deci = Algorithm.Manhattan(userPreferences.Where(x => x.Key == userId).First().Value, userPreferences.Where(x => x.Key == item.Key).First().Value);
                        nearestItemRatings.Add(item.Key, deci);
                    }
                    break;

                case DistanceType.Euclidean:
                    foreach (KeyValuePair<int, List<ItemRating>> item in userPreferences.Where(x => x.Key != userId))
                    {
                        decimal deci = Algorithm.Euclidean(userPreferences.Where(x => x.Key == userId).First().Value, userPreferences.Where(x => x.Key == item.Key).First().Value);
                        nearestItemRatings.Add(item.Key, deci);
                    }
                    break;
            }
            
            return nearestItemRatings.OrderBy(o => o.Value).ToDictionary(x => x.Key, x => x.Value);
        }

        public Dictionary<int, float> RecommendArticle(int userId, Dictionary<int, List<ItemRating>> userPreferences, DistanceType distanceType)
        {
            int nearestUserId = NearestNeighbor(userId, UserPreferences, distanceType).First().Key;
            Dictionary<int, float> articleNotRatedByUser = new Dictionary<int, float>();

            var articleAlreadyRatesByUser = userPreferences.Where(x => x.Key == userId).Select(s => s.Value).First().Select(a => a.ArticleId).ToArray();

            foreach (ItemRating article in userPreferences.Where(x => x.Key == nearestUserId).First().Value.Where(w => !articleAlreadyRatesByUser.Contains(w.ArticleId)))
            {
                articleNotRatedByUser.Add(article.ArticleId, article.Rating);
            }

            return articleNotRatedByUser.OrderByDescending(o => o.Value).ToDictionary(d => d.Key, d => d.Value);
        }

        private Dictionary<int, List<decimal>> Manhattan(List<ItemRating> ratingOne, Dictionary<int, List<ItemRating>> users)
        {
            Dictionary<int, List<decimal>> manhattans = new Dictionary<int, List<decimal>>();
            foreach (KeyValuePair<int, List<ItemRating>> user in users.Where(x => x.Key != ratingOne.First().UserId))
            {
                
                if (manhattans.ContainsKey(ratingOne.First().UserId))
                {
                    manhattans.Where(x => x.Key == ratingOne.First().UserId).First().Value.Add(Algorithm.Manhattan(ratingOne, user.Value));
                }
                else
                {
                    manhattans.Add(ratingOne.First().UserId, new List<decimal> { Algorithm.Manhattan(ratingOne, user.Value) });
                }
                
            }

            return manhattans;
        }

        private Dictionary<int, List<ItemRating>> GetUserPreferencesData()
        {
            Dictionary<int, List<ItemRating>> userPreferences = new Dictionary<int, List<ItemRating>>();
            //System.IO.StreamReader file = new System.IO.StreamReader(@"Data\userItem.data");
            System.IO.StreamReader file = new System.IO.StreamReader(@"Data\test.data");

            string line;
            while ((line = file.ReadLine()) != null)
            {
                ItemRating item = new ItemRating();
                item.UserId = Convert.ToInt32(line.Split(',')[0]);
                item.ArticleId = Convert.ToInt32(line.Split(',')[1]);
                item.Rating = float.Parse(line.Split(',')[2]);
                
                if (userPreferences.ContainsKey(item.UserId))
                {
                    userPreferences.Where(x => x.Key == item.UserId).First().Value.Add(item);
                }
                else
                {
                    userPreferences.Add(item.UserId, new List<ItemRating>{item});
                }
            }

            return userPreferences;
        }
    }
}*/
