using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFDTA011.Model
{
    class ItemRating
    {
        // variablen vanuit userItem.data dataset 
        public int UserId {get;set;} // van 1 tot 7 users
        public int ArticleId {get;set;} // 101 tot 106 articles
        public float Rating { get { return this.userRating; } set { SetRating(value); } } // 1.0 => < 5
        float userRating;
        

        // grens waarde rating moet tussen of gelijk zijn aan 1 of 5.
        private void SetRating(float rate)
        {
            if(rate >= 1 && rate <= 5){
                this.userRating = rate;
            }
            else
            {
                throw new System.ArgumentOutOfRangeException("Rating must be between 1 and 5");
            }
        }
    }
        
}
