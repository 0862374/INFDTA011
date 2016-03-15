using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INFDTA011.Model;

namespace INFDTA011.Algorithms
{
    class Pearson : IAlgorithm
    {
        public double treshhold
        {
            get
            {
                return 0.35;
            }
        }

        public decimal Calculate(List<UserPreference> ratingOne, List<UserPreference> ratingTwo)
        {
            double sum_xy = 0;
            double sum_x = 0;
            double sum_y = 0;
            double sum_x2 = 0;
            double sum_y2 = 0;
            int n = 0;

            for (int i = 0; i < ratingOne.Count; i++)
            {
                if (ratingTwo.Where(x => x.ArticleId == ratingOne.ElementAt(i).ArticleId).Count() > 0)
                {

                    if (i < ratingOne.Count  && i < ratingTwo.Count)

                    { 
                        n++;
                        double x = ratingOne.ElementAt(i).Rating;
                        double y = ratingTwo.ElementAt(i).Rating;
                        
                        sum_xy += x * y;
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

            double denomimator = Math.Sqrt(sum_x2 - (sum_x * sum_x) / n) * Math.Sqrt(sum_y2 - (sum_y * sum_y) / n);

            if (denomimator == 0)
            {
                return 0;
            }
            else
            {
                return (decimal)((sum_xy - (sum_x * sum_y) / n) / denomimator);
            }
        }
    }
}
