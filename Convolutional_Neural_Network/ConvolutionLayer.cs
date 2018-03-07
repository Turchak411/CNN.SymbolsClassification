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
            return new List<double[,]>();
        }
    }
}
