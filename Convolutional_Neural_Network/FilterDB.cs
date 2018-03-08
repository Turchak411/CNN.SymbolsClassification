using System;
using System.IO;
using System.Collections.Generic;

namespace Convolutional_Neural_Network
{
    public class FiltersDB
    {
        // README: In this DB uses 5x5 filters

        private List<double[,]> m_filtersList = new List<double[,]>();
        private string m_dbFilePath;

        private FiltersDB() { }

        public FiltersDB(List<FilterName> filtersToImport)
        {
            m_dbFilePath = "filtersDB.txt";
            ImportFilters(filtersToImport);
        }

        private void ImportFilters(List<FilterName> filtersToImport)
        {
            using (StreamReader fileReader = new StreamReader(m_dbFilePath))
            {
                for (int i = 0; !fileReader.EndOfStream; i++)
                {
                    string[] filterText = fileReader.ReadLine().Split(' ');

                    FilterName filterEnum = (FilterName)Enum.Parse(typeof(FilterName), filterText[0]);

                    if (filtersToImport.Contains(filterEnum))
                    {
                        double[,] filterMatrix = ConvertToMatrix(filterText);

                        m_filtersList.Add(filterMatrix);
                    }
                }
            }
        }

        private double[,] ConvertToMatrix(string[] filter)
        {
            int matrixDim = Convert.ToInt32(Math.Sqrt(filter.Length - 1));
            double[,] filterMatrix = new double[matrixDim, matrixDim];

            for (int i = 0, j = 0; i < matrixDim; i++)
            {
                for (int k = 0; k < matrixDim; k++, j++)
                {
                    filterMatrix[i, k] = Convert.ToInt32(filter[j + 1]);
                }
            }

            return filterMatrix;
        }

        public double[,] GetFilter(int index)
        {
            return m_filtersList[index];
        }

        public int GetFiltersCount()
        {
            return m_filtersList.Count;
        }
    }

    public enum FilterName { Relief, EdgeSelection, StrengthenEdge, Blur, Clarity };    // TODO Возможно пересмотреть пару фильтров
}
