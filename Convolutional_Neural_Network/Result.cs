using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convolutional_Neural_Network
{
    public struct Result
    {
        public Letter _letter;
        public double _value;

        public Result(Letter letter, double value)
        {
            _letter = letter;
            _value = value;
        }
    }
}
