using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INFDTA011.Model;

namespace INFDTA011
{
    class AlgorithmDecorator : IAlgorithm
    {
        protected IAlgorithm decoratedAlgorithm;

        public AlgorithmDecorator(IAlgorithm decoratedAlgorithm)
        {
            this.decoratedAlgorithm = decoratedAlgorithm;
        }

        public double treshhold
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public double Calculate(List<UserPreference> ratingOne, List<UserPreference> ratingTwo)
        {
            return decoratedAlgorithm.Calculate(ratingOne, ratingTwo);
        }
    }
}
