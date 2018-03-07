using System.Collections.Generic;

namespace Convolutional_Neural_Network
{
    public interface IExtractLayer
    {
        List<double[,]> Handle(List<double[,]> inputMatrix);
    }
}
