using INFDTA011.Model;
using System.Collections.Generic;

namespace INFDTA011
{
    //Interface of Algorithms which explicitly forces this body structure for all algorithms
    interface IAlgorithm
    {
        double treshhold { get; }
        double Calculate(List<UserPreference> ratingOne, List<UserPreference> ratingTwo);
    }
}
