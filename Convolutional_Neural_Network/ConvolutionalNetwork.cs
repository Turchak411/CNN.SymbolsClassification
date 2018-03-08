using System.Collections.Generic;

namespace Convolutional_Neural_Network
{
    public class ConvolutionalNeuralNetwork : NeuralNetwork
    {
        private Extractor m_extractor;

        private ConvolutionalNeuralNetwork() { }

        public ConvolutionalNeuralNetwork(string extractorLayersScheme, List<List<FilterName>> convFilters, int[] neuronsNumberByLayers, int receptorsNumber, FileManager fileManager)
        {
            m_extractor = new Extractor(extractorLayersScheme, convFilters);

            Layer firstLayer = new Layer(neuronsNumberByLayers[0], receptorsNumber, 0, fileManager);
            m_layerList.Add(firstLayer);

            for (int i = 1; i < neuronsNumberByLayers.Length; i++)
            {
                Layer layer = new Layer(neuronsNumberByLayers[i], neuronsNumberByLayers[i - 1], i, fileManager);
                m_layerList.Add(layer);
            }
        }

        public double[] Handle(double[,] data)
        {
            double[] dataSet = m_extractor.Extract(data);

            return base.Handle(dataSet);
        }

        public void Teach(double[,] data, double[] rightAnwser, double learningSpeed)
        {
            double[] dataSet = m_extractor.Extract(data);
            base.Teach(dataSet, rightAnwser, learningSpeed);
        }
    }
}
