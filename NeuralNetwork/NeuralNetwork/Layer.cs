using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork.NeuralNetwork
{
    public class Layer
    {
        public List<Neuron> neuronas;

        //para la primera capa
        public Layer(int cantNeuronas)
        {
            neuronas = new List<Neuron>();

            for (int i = 0; i < cantNeuronas; i++)
            {
                neuronas.Add(new Neuron());
            }
        }

        //para las capas que no son la primera
        public Layer(int cantNeuronas, Layer anterior)
        {
            neuronas = new List<Neuron>();

            for (int i = 0; i < cantNeuronas; i++)
            {
                neuronas.Add(new Neuron(anterior));
            }
        }

        public void Activacion()
        {
            neuronas.ForEach(n => n.Activacion());
        }
    }
}
