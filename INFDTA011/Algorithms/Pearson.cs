using System;
using System.Collections.Generic;
using System.Linq;
using INFDTA011.Model;

namespace INFDTA011.Algorithms
{
    class Pearson : IAlgorithm
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
            //setting variables for calculation
            double sum_xy = 0; 
            double sum_x = 0;
            double sum_y = 0;
            double sum_x2 = 0;
            double sum_y2 = 0;
            int n = 0;

            //Iterates at each element and gets count of all elements
            for (int i = 0; i < ratingOne.Count; i++)
            {
                //Here we check an article id in list 2 matches an article id in list 1 where the element equals
                // the forloop count and if the count is greater that zero.
                if (ratingTwo.Where(x => x.ArticleId == ratingOne.ElementAt(i).ArticleId).Count() > 0)
                {

                    if (i < ratingOne.Count  && i < ratingTwo.Count)

                    { 
                        // the n is n items / subjects 
                        n++;
                        // all the items which equals the index get the rating and put it in x and y
                        double x = ratingOne.ElementAt(i).Rating;
                        double y = ratingTwo.ElementAt(i).Rating;
                        
                        sum_xy += x * y; // basic calculation
                        sum_x += x;
                        sum_y += y;
                        sum_x2 += x * x; 
                        sum_y2 += y * y;


                    }
                }
            }
            if (n == 0)
            {
                return 0;
            }

            // X1 = The sum of N times x² X2 = the sum² of x  

            // Y1 = The sum of N times y² Y2 = the sum² of y   
            // Sqrt (X - X1 divided by N) * sqrt (Y - Y1 divided by N)

            // xysum = sum(totalx * totaly)  xysum - sum of x * sum of y divided by N  / Sqrt (X - X1 divided by N) * sqrt (Y - Y1 divided by N)

        
            double denomimator = Math.Sqrt(sum_x2 - (sum_x * sum_x) / n) * Math.Sqrt(sum_y2 - (sum_y * sum_y) / n);

            if (denomimator == 0)
            {
                return 0;
            }
            else
            {
                return (double)((sum_xy - (sum_x * sum_y) / n) / denomimator);
            }
        }
    }
}
