﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork.NeuralNetwork
{
    public class Net
    {
        public List<Layer> layers;
        double learningRate;
        FormStats stats;


        public Net(double learningRate, int[] layers )
        {
            if (layers.Length < 2) throw new System.ArgumentException("La red debe contener al menos 3 capas");

            this.learningRate = learningRate;
            this.layers = new List<Layer>();

            //primera layer
            Layer primera = new Layer(layers[0]);
            this.layers.Add(primera);
            
            // primera hidden layer
            Layer primeraHidden = new Layer(layers[1]);
            this.layers.Add(new Layer(layers[1], primera));

            //hidden layers and last
            for (int i = 2; i < layers.Length; i++)
            {
                this.layers.Add(new Layer(layers[i], this.layers[i - 1]));
            }

        }

       
        public void Train(List<DataSet> sets, int epocas)
        {
            stats = new FormStats();
            stats.Show();

            for (int i = 0; i < epocas; i++)
            {
                int j = 0;
                foreach (DataSet ds in sets)
                {
                    Feedforward(ds);
                    stats.ChangeText("Epoca: " + (i + 1).ToString() + "\n" +
                        "Muestra: " + j++ + "\n " +
                        "Error: " + Backpropagation(ds).ToString());

                    stats.Refresh();

                }
            }
        }


        public void Feedforward(DataSet ds)
        {
            if (ds.inputs.Length != layers[0].neuronas.Count)
                throw new System.Exception("La cantidad de inputs en el DataSet difiere con la " +
                    "cant de neuronas en la primer capa");

            int i = 0;
            layers[0].neuronas.ForEach(n => n.a = ds.inputs[i++]);
            layers.Skip<Layer>(1).ToList<Layer>().ForEach(l => l.Activacion());
        }


        string Backpropagation(DataSet ds)
        {
            if (ds.outputs.Length != layers[layers.Count - 1].neuronas.Count)
                throw new System.Exception("La cantidad de outputs en el DataSet difiere con la " +
                    "cant de neuronas en la ultima capa");

            //calculo delta en la ultima capa. 
            int j = 0;
            layers[layers.Count - 1].neuronas.ForEach(n => n.Delta(ds.outputs[j++]));

            // calculo delta en las capas intermedias hacia atras
            for (int i = layers.Count - 2; i >= 1; i--)
            {
                layers[i].neuronas.ForEach(n => n.Delta());
            }

            // update todos los weights y bias
            for (int i = layers.Count - 1; i >= 1; i--)
            {
                layers[i].neuronas.ForEach(n => n.Update(learningRate));
            }

            string ret = layers[layers.Count - 1].neuronas.Sum(n => Math.Pow(n.error, 2)).ToString() + "\n";

            int k = 0;
            foreach (Neuron n in layers[layers.Count - 1].neuronas)
            {
                ret += (k++).ToString() + ": " + n.error.ToString() + "\n";
            }
            return ret;
        }
    }
}
