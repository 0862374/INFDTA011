using System;
using System.Collections.Generic;
using System.Linq;
using INFDTA011.Model;

namespace INFDTA011
{
    class Euclidean : IAlgorithm
    {
        public double treshhold
        {
            get
            {
                //placeholder for the threshold used in various calculations we then only have to get the threshold needed.
                return 0.35;
            }
        }
        // implemented from the IAlgorithm interface so that the algorithms are generic
        public double Calculate(List<UserPreference> ratingOne, List<UserPreference> ratingTwo)
        {
            // Setting default distance
            double distance = 0;

            //forloop
            foreach (UserPreference rateOne in ratingOne)
            {
                foreach (UserPreference rateTwo in ratingTwo.Where(x => x.ArticleId == rateOne.ArticleId))
                {
                    //calculates by squaring² foreach rate minus the second rating
                    // 
                    distance += Math.Pow(rateOne.Rating - rateTwo.Rating,2);
                }
            }
            // Returns euclidean distance
            return Math.Sqrt(distance);
        }
    }
}
