using System;
using System.Collections.Generic;
using System.Linq;
using INFDTA011.Model;

namespace INFDTA011
{
    class Cosine : IAlgorithm
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
            double sum_xy = 0;
            double vec_x = 0;
            double vec_y = 0;

            foreach (UserPreference rateOne in ratingOne)
            {
                foreach (UserPreference rateTwo in ratingTwo.Where(x => x.ArticleId == rateOne.ArticleId))
                {
                    sum_xy += (rateOne.Rating * rateTwo.Rating);
                    vec_x += Math.Pow(rateOne.Rating, 2);
                    vec_y += Math.Pow(rateTwo.Rating, 2);
                }
            }
            return (double)(sum_xy / (Math.Sqrt(vec_x) * Math.Sqrt(vec_y)));
        }
    }
}
