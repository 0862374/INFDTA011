using INFDTA011.Model;
using System.Collections.Generic;

namespace INFDTA011
{
    interface IAlgorithm
    {
        double treshhold { get; }
        double Calculate(List<UserPreference> ratingOne, List<UserPreference> ratingTwo);
    }
}
