using System;
using System.Collections.Generic;
using System.Linq;
using INFDTA011.Model;

namespace INFDTA011
{
    class Manhattan : IAlgorithm
    {
        public double treshhold
        {
            get
            {
                return 0.35;
            }
        }

        public double Calculate(List<UserPreference> ratingOne, List<UserPreference> ratingTwo)
        {
            double distance = 0;

            foreach (UserPreference rateOne in ratingOne)
            {
                foreach (UserPreference rateTwo in ratingTwo.Where(x => x.ArticleId == rateOne.ArticleId))
                {
                    distance += Math.Abs((double)(rateOne.Rating - rateTwo.Rating));
                }
            }

            return distance;
        }
    }
}
