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
        public static double Euclidean(List<UserPreference> ratingOne, List<UserPreference> ratingTwo)
        {
            double distance = 0;

            foreach (UserPreference rateOne in ratingOne)
            {
                foreach (UserPreference rateTwo in ratingTwo.Where(x => x.ArticleId == rateOne.ArticleId))
                {
                    distance += (double)Math.Pow(rateOne.Rating - rateTwo.Rating, 2);
                }
            }
            return (double)Math.Sqrt((double)distance);
        }

        public static double Cosine(List<UserPreference> ratingOne, List<UserPreference> ratingTwo)
        {
            /*
            //cos(x, y) x = ( sum of all ratings of first user in respect of the articleids) 
            // y = (sum of all ratings of target user in respect of the articleids) 
            // User with Articleid1 with rating1 times target User with articleid1 with rating 1.
            // Example matrix( x= 4.a , 4.b , 1.c, 3.d) y=(4.e , 2.f , 3.g , 5.h);
            // cos of x . y =  (4.a * 4.e 4.b * 2.f 1.c * 3.g ,3.d * 5.h) = 42 / x * y(154 = cos similarity of(0.27)
            */

            double distance = 0;

            foreach (UserPreference rateOne in ratingOne)
            {

                foreach (UserPreference rateTwo in ratingTwo.Where(x => x.ArticleId == rateOne.ArticleId))
                {

                    distance += (double)Math.Pow(rateOne.Rating - rateTwo.Rating, 2);
                }
            }
            return (double)Math.Sqrt((double)distance);
        }

        public static double Manhattan(List<UserPreference> ratingOne, List<UserPreference> ratingTwo)
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
