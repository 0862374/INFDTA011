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
                //placeholder for the threshold used in various calculations we then only have to get the threshold needed.
                return 0.35;
            }
        }


        // implemented from the IAlgorithm interface so that the algorithms are generic
        public double Calculate(List<UserPreference> ratingOne, List<UserPreference> ratingTwo)
        {
            double sum_xy = 0;
            double vec_x = 0;
            double vec_y = 0;

            foreach (UserPreference rateOne in ratingOne) // forloop which iterates through all the ratings of the first user
            {
                foreach (UserPreference rateTwo in ratingTwo.Where(x => x.ArticleId == rateOne.ArticleId)) 
                    // forloop which iterates through all the ratings of the targetuser(s) in respect of the articleid
      
                {
                    // Standard Cosine algorithm(similarity) calculate similarity of the first user to the targetuser
                    // First each user rating x times user rating y then divide. Then each rating times itself both target and subject user
                   
                    sum_xy += (rateOne.Rating * rateTwo.Rating);
                    vec_x += Math.Pow(rateOne.Rating, 2);
                    vec_y += Math.Pow(rateTwo.Rating, 2);
                }
            }
            // sqrt * sqrt result leads to cosine of similarity
            // returns the cosine for the specified user/target user 
            return (double)(sum_xy / (Math.Sqrt(vec_x) * Math.Sqrt(vec_y)));
        }
    }
}
