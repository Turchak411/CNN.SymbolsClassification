using System;
using System.Collections.Generic;

namespace Convolutional_Neural_Network
{
    public class ConvolutionLayer : IExtractLayer
    {
        private FiltersDB m_filtersList;

        private ConvolutionLayer() { }

        public ConvolutionLayer(List<FilterName> filtersToImport)
        {
            m_filtersList = new FiltersDB(filtersToImport);
        }

        public List<double[,]> Handle(List<double[,]> inputMatrix)
        {
            // TODO: Осуществление свертки и отправка в т. вызова
            List<double[,]> convMatrix = new List<double[,]>();

            for (int i = 0; i < inputMatrix.Count; i++)
            {
                for (int k = 0; k < m_filtersList.GetFiltersCount(); k++)
                {
                    double[,] filter = m_filtersList.GetFilter(k);

                    convMatrix.Add(ImposeFilter(inputMatrix[i], filter));
                }
            }

            return new List<double[,]>();
        }

        private double[,] ImposeFilter(double[,] matrix, double[,] filter)
        {
            double[,] convoluteMatrix = null;

            // Проверка необходимости падинга 
            // (разрядность обрабатыеваемой матрицы должна делиться на разрядность фильтра без остатка)
            int matrixDimY = matrix.GetLength(0);
            int matrixDimX = matrix.GetLength(1);

            if ((matrixDimY % filter.GetLength(0) != 0) || (matrixDimX % filter.GetLength(1) != 0))
            {
                double[,] newMatrix = null;
                // Калибровка по вертикали:
                while (matrix.GetLength(0) % filter.GetLength(0) != 0)
                {
                    newMatrix = new double[matrix.GetLength(0) + 1, matrix.GetLength(1)];
                    Array.Copy(matrix, newMatrix, newMatrix.GetLength(0));
                }

                matrix = newMatrix;

                // Калибровка по вертикали:
                while (matrix.GetLength(1) % filter.GetLength(1) != 0)
                {
                    newMatrix = new double[matrix.GetLength(0), matrix.GetLength(1) + 1];
                    Array.Copy(matrix, newMatrix, newMatrix.GetLength(1));
                }

                matrix = newMatrix;
            }

            // Свертка:
            convoluteMatrix = new double[matrixDimY - filter.GetLength(0), matrixDimX - filter.GetLength(1)];

            for (int i = 0; i < matrixDimY - filter.GetLength(0); i++)
            {
                for (int k = 0; k < matrixDimX - filter.GetLength(1); k++)
                {
                    convoluteMatrix[i, k] = ImposeFilterFrame(matrix, filter, i, k);
                }
            }

            return convoluteMatrix;
        }

        private double ImposeFilterFrame(double[,] matrix, double[,] filter, int relIndexY, int relIndexX)
        {
            double sumValue = 0;

            for(int i = 0; i < filter.GetLength(0); i++)
            {
                for (int k = 0; k < filter.GetLength(1); k++)
                {
                    sumValue += matrix[relIndexY, relIndexX]  * filter[i, k];
                }
            }

            return sumValue;
        }
    }
}
