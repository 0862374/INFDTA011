using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFDTA011.Model
{
    class ItemRating
    {
        public int UserId {get;set;}
        public int ArticleId {get;set;}
        public float Rating { get { return this._rating; } set { SetRating(value); } }
        float _rating;
        
        private void SetRating(float rate)
        {
            if(rate >= 1 && rate <= 5){
                this._rating = rate;
            }
            else
            {
                throw new System.ArgumentOutOfRangeException("Rating must be between 1 and 5");
            }
        }
    }
        
}
