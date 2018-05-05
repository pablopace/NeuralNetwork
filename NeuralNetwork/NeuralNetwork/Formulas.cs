using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork.NeuralNetwork
{
    public static class Formulas
    {
        public static double Sigmoid(double x)
        {
            return x< -45.0 ? 0.0 : x > 45.0 ? 1.0 : 1.0 / (1.0 + Math.Exp(-x));
        }

        public static double SigmoidDx(double x)
        {
            return x * (1 - x);
        }


    }
}
