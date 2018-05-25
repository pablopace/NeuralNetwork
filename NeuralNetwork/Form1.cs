using NeuralNetwork.NeuralNetwork;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NeuralNetwork
{
    public partial class Form1 : Form
    {
        Net nn = new Net(0.9, new int[] { 1, 10, 10});

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Render();
        }

        private void Render()
        {
            NetworkHelper.ToTreeView(treeView1, nn);
            NetworkHelper.ToPictureBox(pictureBox1, nn);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<DataSet> ds = new List<DataSet>();
            ds.Add(new DataSet(new double[] { 0.0 }, new double[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 }));
            ds.Add(new DataSet(new double[] { 0.1 }, new double[] { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 }));
            ds.Add(new DataSet(new double[] { 0.2 }, new double[] { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 }));
            ds.Add(new DataSet(new double[] { 0.3 }, new double[] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 }));
            ds.Add(new DataSet(new double[] { 0.4 }, new double[] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 }));
            ds.Add(new DataSet(new double[] { 0.5 }, new double[] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 }));
            ds.Add(new DataSet(new double[] { 0.6 }, new double[] { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 }));
            ds.Add(new DataSet(new double[] { 0.7 }, new double[] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 }));
            ds.Add(new DataSet(new double[] { 0.8 }, new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 }));
            ds.Add(new DataSet(new double[] { 0.9 }, new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 }));

            nn.Train(ds, 1000);

            Render();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            nn.Feedforward(new DataSet(new double[] { 0.0 }, new double[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 }));
            Render();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            nn.Feedforward(new DataSet(new double[] { 0.1 }, new double[] { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 }));
            Render();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            nn.Feedforward(new DataSet(new double[] { 0.2 }, new double[] { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 }));
            Render();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            nn.Feedforward(new DataSet(new double[] { 0.3 }, new double[] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 }));
            Render();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            nn.Feedforward(new DataSet(new double[] { 0.4 }, new double[] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 }));
            Render();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            nn.Feedforward(new DataSet(new double[] { 0.5 }, new double[] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 }));
            Render();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            nn.Feedforward(new DataSet(new double[] { 0.6 }, new double[] { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 }));
            Render();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            nn.Feedforward(new DataSet(new double[] { 0.7 }, new double[] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 }));
            Render();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            nn.Feedforward(new DataSet(new double[] { 0.8 }, new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 }));
            Render();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            nn.Feedforward(new DataSet(new double[] { 0.9 }, new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 }));
            Render();
        }


        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                // por cada capa desde la ultima capa L
                for (int l = nn.layers.Count - 1; l >= 1; l--)     // i=2,1
                {
                    // por cada neurona
                    for (int j = 0; j < nn.layers[l].neuronas.Count; j++)
                    {
                        Neuron n = nn.layers[l].neuronas[j];
                        n.bias = Convert.ToDouble(Microsoft.VisualBasic.Interaction.InputBox("Bias L" + l + " N" + j), System.Globalization.CultureInfo.InvariantCulture);

                        Render();

                        for (int k = 0; k < n.dentritas.Count; k++)
                            n.dentritas[k].weight = Convert.ToDouble(Microsoft.VisualBasic.Interaction.InputBox("Weight L" + l + " W" + j + k), System.Globalization.CultureInfo.InvariantCulture);

                        Render();
                    }
                }
            }
            catch (Exception)
            {


            }
        }

        private void ResiezePictureNet(object sender, EventArgs e)
        {
            Render();
        }
    }
}