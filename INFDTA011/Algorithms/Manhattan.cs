using System;
using System.Collections.Generic;
using System.Linq;
using INFDTA011.Model;

namespace INFDTA011
{
    class Manhattan : IAlgorithm
    {
        public decimal Calculate(List<UserPreference> ratingOne, List<UserPreference> ratingTwo)
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
