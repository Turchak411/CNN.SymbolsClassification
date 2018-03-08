using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convolutional_Neural_Network
{
    public class ResultManager
    {
        private List<Result> m_alphabet;

        public void AddResult(Letter letter, double value)
        {
            m_alphabet.Add(new Result(letter, value));
        }

        public void Sort(bool reverseFlag)
        {
            // TODO
        }
    }
}
