using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork.NeuralNetwork
{
    public class Neuron
    {
        public double bias;
        public double a; //activacion 
        public List<Dentrite> dentritas;
        List<Dentrite> outputDentrites;
        public double delta;
        static Random random = new Random();

        public Neuron()
        {

        }

        public Neuron(Layer anterior) : this()
        {
            dentritas = new List<Dentrite>();
            bias = random.NextDouble() * (1 - (-1)) + (-1);

            foreach (Neuron n in anterior.neuronas)
            {
                dentritas.Add(new Dentrite(n, this));
            }
        }

        public void Activacion()
        {
            a = Formulas.Sigmoid(bias + dentritas.Sum(d => d.weight * d.inputNeuron.a));
        }

        public void Delta(DataSet ds)
        {
            int i = 0;
            delta = 2 * (a - ds.outputs[i++]) * Formulas.SigmoidDx(a);
        }

        public void Delta()
        {
            delta = outputDentrites.Sum(d => d.weight * d.outputNeuron.delta)* Formulas.SigmoidDx(a);
        }
    }
}
