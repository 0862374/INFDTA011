using System;
using System.Collections.Generic;
using System.Linq;

namespace INFDTA011.Model
{
    class UserPreference
    {
        public int UserId { get; set; }
        public int ArticleId { get; set; }
        public float Rating { get { return this._rating; } set { SetRating(value); } }
        float _rating;

        // Dictonary with user preferences, if _userPreferences is empty the dictionary will be loaded into _userPreferences
        public Dictionary<int, List<UserPreference>> UserPreferences { get { if (_userPreferences == null) { _userPreferences = GetAllUserPreferences(); } return _userPreferences; } set { _userPreferences = GetAllUserPreferences(); } }
        Dictionary<int, List<UserPreference>> _userPreferences;

        // Fills the _rating and throws an exeption if the rate is not between 1 and 5
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

        // This function loads all userPreferences from the Data folder.
        private Dictionary<int, List<UserPreference>> GetAllUserPreferences()
        {
            Dictionary<int, List<UserPreference>> userPreferences = new Dictionary<int, List<UserPreference>>();
            System.IO.StreamReader file = new System.IO.StreamReader(@"Data\userItem.data");
            //System.IO.StreamReader file = new System.IO.StreamReader(@"Data\groupLens.data");

            string line;
            UserPreference item;

            while ((line = file.ReadLine()) != null)
            {
                item = new UserPreference();
                item.UserId = Convert.ToInt32(line.Split(';')[0]);
                item.ArticleId = Convert.ToInt32(line.Split(';')[1]);
                item.Rating = float.Parse(line.Split(';')[2]);

                // if already an key with the user id exists then add it to the list else add it to the dictionary
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
