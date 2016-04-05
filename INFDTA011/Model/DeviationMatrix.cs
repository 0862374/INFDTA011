using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFDTA011.Model
{
    class DeviationMatrix
    {
        public List<Deviation> Deviations { get; set; } = new List<Deviation>();

        public void UpdateDeviationMatrix(List<Deviation> deviations, Dictionary<int, List<UserPreference>> userPreferences, int articleId)
        {
            DeviationMatrix deviationMatrix = new DeviationMatrix();
            var articles = deviationMatrix.GetArticleIds(userPreferences).Distinct().ToList();

            // calculate the deviation for every article
            foreach (int article in articles)
            {
                articles.Where(i => i != article).ToList().ForEach(x => deviationMatrix.Deviations.Add(CalculateDeviation(userPreferences, article, x)));
            }

            foreach(var deviation in deviationMatrix.Deviations.Where(x => x.ArticleOne == articleId || x.ArticleTwo == articleId))
            {
                Deviation tempDeviation = CalculateDeviation(userPreferences, deviation.ArticleOne, deviation.ArticleTwo);
                Deviations.Where(x => x.ArticleOne == deviation.ArticleOne && x.ArticleTwo == deviation.ArticleTwo).First().Difference = tempDeviation.Difference;
                Deviations.Where(x => x.ArticleOne == deviation.ArticleOne && x.ArticleTwo == deviation.ArticleTwo).First().items = tempDeviation.items;
            }
            
        }

        public Deviation CalculateDeviation(Dictionary<int, List<UserPreference>> userPreferences, int articleOne, int articleTwo)
        {
            Deviation deviation = new Deviation();

            deviation.ArticleOne = articleOne;
            deviation.ArticleTwo = articleTwo;
            if (articleOne == articleTwo)
            {
                deviation.Difference = 0;
                deviation.items = 0;

                return deviation;
            }

            foreach (KeyValuePair<int, List<UserPreference>> item in userPreferences)
            {
                if (item.Value.Any(x => x.ArticleId == articleOne) && item.Value.Any(x => x.ArticleId == articleTwo))
                {
                    double ratingOne = item.Value.Where(x => x.ArticleId == articleOne).First().Rating;
                    double ratingTwo = item.Value.Where(x => x.ArticleId == articleTwo).First().Rating;
                    deviation.items++;

                    deviation.Difference += (ratingOne - ratingTwo);

                }
            }

            deviation.Difference = (deviation.Difference / deviation.items);
            return deviation;
        }

        public List<int> GetArticleIds(Dictionary<int, List<UserPreference>> userPreferences)
        {
            List<int> articles = new List<int>();

            foreach(KeyValuePair<int, List<UserPreference>> item in userPreferences)
            {
                foreach(UserPreference userPreference in item.Value)
                {
                    articles.Add(userPreference.ArticleId);
                }
            }
            return articles;
        }
    }
}
