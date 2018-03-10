using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convolutional_Neural_Network
{
    public class ResultManager
    {
        private List<Result> m_alphabet = new List<Result>();

        public void AddResult(string letter, double value)
        {
            m_alphabet.Add(new Result(letter, value));
        }

        public void AddRange(double[] values)
        {
            for(int i = 0; i < values.Length; i++)
            {
                try
                {
                    m_alphabet.Add(new Result(Enum.GetName(typeof(Letter), i), values[i]));
                }
                catch { }
            }
        }

        public void Sort(bool reverseFlag)
        {
            // Сортировка по убыванию пузырьком:
            SortByValue();

            if(reverseFlag)
            {
                m_alphabet.Reverse();
            }
        }

        private void SortByValue()
        {
            for(int j = 0; j < m_alphabet.Count; j++)
            {
                int f = 0;
                for (int i = 0; i < m_alphabet.Count - j - 1; i++)
                {
                    if(m_alphabet[i]._value > m_alphabet[i + 1]._value)
                    {
                        Result tempResult = m_alphabet[i];
                        m_alphabet[i] = m_alphabet[i + 1];
                        m_alphabet[i + 1] = tempResult;
                        f = 1;
                    }
                }
            }
        }

        public Result GetResult(int index)
        {
            return m_alphabet[index];
        }
    }
}
