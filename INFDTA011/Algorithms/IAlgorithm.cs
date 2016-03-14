using INFDTA011.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFDTA011
{
    interface IAlgorithm
    {
        decimal Calculate(List<UserPreference> ratingOne, List<UserPreference> ratingTwo);
    }
}
