using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convolutional_Neural_Network
{
    public class Extractor
    {
        private List<IExtractLayer> m_layers;

        private Extractor() { }

        public Extractor(string layersScheme, List<List<FilterName>> convLayersFilters)
        {
            m_layers = new List<IExtractLayer>();

            for (int i = 0, currentFilterUse = 0; i < layersScheme.Length; i++)
            {
                switch (layersScheme[i])
                {
                    case 'c':
                        CreateConvLayer(convLayersFilters[currentFilterUse]);
                        currentFilterUse++;
                        break;
                    case 'p':
                    default:
                        CreatePoolLayer();
                        break;
                }
            }
        }

        private void CreateConvLayer(List<FilterName> filtersToImport)
        {
            m_layers.Add(new ConvolutionLayer(filtersToImport));
        }

        private void CreatePoolLayer()
        {
            m_layers.Add(new MaxPoolingLayer());
        }

        public double[] Extract(double[,] matrix)
        {
            // TODO
            return null;
        }
    }
}
