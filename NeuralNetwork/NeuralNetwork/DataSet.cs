using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork.NeuralNetwork
{
    public class DataSet
    {
        public double[] inputs;
        public double[] outputs;

        public DataSet(double[] inputs, double[] outputs)
        {
            this.inputs = inputs;
            this.outputs = outputs;
        }

    }
}
