using System;
using System.Collections.Generic;
using System.Linq;

namespace INFDTA011.Model
{
    class UserPreference
    {  // variablen vanuit userItem.data dataset 
        public int UserId { get; set; } // van 1 tot 7 users
        public int ArticleId { get; set; }// 101 tot 106 articles
        public float Rating { get { return this._rating; } set { SetRating(value); } } // 1.0 => < 5
        float _rating;


        /// <summary>
        /// Hier wordt een list gemaakt met user voorkeuren.
        /// </summary>
        public Dictionary<int, List<UserPreference>> UserPreferences { get { if (_userPreferences == null) { _userPreferences = GetAllUserPreferences(); } return _userPreferences; } set { _userPreferences = GetAllUserPreferences(); } }
        Dictionary<int, List<UserPreference>> _userPreferences;


        // grens waarde rating moet tussen of gelijk zijn aan 1 of 5.
        private void SetRating(float rate)
        {
            if (rate >= 1 && rate <= 5)
            {
                this._rating = rate;
            }
            else
            {
                throw new System.ArgumentOutOfRangeException("Rating must be between 1 and 5");
            }
        }



        private Dictionary<int, List<UserPreference>> GetAllUserPreferences()
        {
            // import from dataset. 
            Dictionary<int, List<UserPreference>> userPreferences = new Dictionary<int, List<UserPreference>>();
            //System.IO.StreamReader file = new System.IO.StreamReader(@"Data\userItem.data");
            System.IO.StreamReader file = new System.IO.StreamReader(@"Data\test.data");

            string line;
            while ((line = file.ReadLine()) != null)
            {
                UserPreference item = new UserPreference();
                item.UserId = Convert.ToInt32(line.Split(',')[0]);
                item.ArticleId = Convert.ToInt32(line.Split(',')[1]);
                item.Rating = float.Parse(line.Split(',')[2]);

                if (userPreferences.ContainsKey(item.UserId))
                {
                    userPreferences.Where(x => x.Key == item.UserId).First().Value.Add(item);
                }
                else
                {
                    userPreferences.Add(item.UserId, new List<UserPreference> { item });
                }
            }

            return userPreferences;
        }
    }
}
