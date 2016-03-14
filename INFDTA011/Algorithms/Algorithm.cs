using INFDTA011.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFDTA011
{
    class Algorithm
    {
        public static decimal Euclidean(List<UserPreference> ratingOne, List<UserPreference> ratingTwo)
        {
            decimal distance = 0;

            foreach (UserPreference rateOne in ratingOne)
            {
                foreach (UserPreference rateTwo in ratingTwo.Where(x => x.ArticleId == rateOne.ArticleId))
                {
                    distance += (decimal)Math.Pow(rateOne.Rating - rateTwo.Rating, 2);
                }
            }
            return (decimal)Math.Sqrt((double)distance);
        }
        public static decimal Cosine(List<UserPreference> ratingOne, List<UserPreference> ratingTwo)
        {
            decimal distance = 0;

            foreach (UserPreference rateOne in ratingOne)
            {
                foreach (UserPreference rateTwo in ratingTwo.Where(x => x.ArticleId == rateOne.ArticleId))
                {
                    distance += (decimal)Math.Pow(rateOne.Rating - rateTwo.Rating, 2);
                }
            }
            return (decimal)Math.Sqrt((double)distance);
        }

        public static decimal Manhattan(List<UserPreference> ratingOne, List<UserPreference> ratingTwo)
        {
            decimal distance = 0;

            foreach (UserPreference rateOne in ratingOne)
            {
                foreach (UserPreference rateTwo in ratingTwo.Where(x => x.ArticleId == rateOne.ArticleId))
                {
                    distance += Math.Abs((decimal)(rateOne.Rating - rateTwo.Rating));
                }
            }

            return distance;
        }
    }
}
