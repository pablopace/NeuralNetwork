using NeuralNetwork.NeuralNetwork;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NeuralNetwork
{
    public partial class Form1 : Form
    {
        Net nn = new Net(0.09, new int[] { 2, 2, 1 });

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
            NetworkHelper.ToPictureBox(pictureBox1, nn, 400, 100);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<DataSet> ds = new List<DataSet>();
            ds.Add(new DataSet(new double[] { 0, 0 }, new double[] { 0 }));
            ds.Add(new DataSet(new double[] { 0, 1 }, new double[] { 1 }));
            ds.Add(new DataSet(new double[] { 1, 0 }, new double[] { 1 }));
            ds.Add(new DataSet(new double[] { 1, 1 }, new double[] { 0 }));

            nn.Train(ds,10);

            Render();
        }

        /*
        private double Xor(int x, int y)
        {
            if (x == 0 && y == 0) return 0d;
            if (x == 1 && y == 0) return 1d;
            if (x == 0 && y == 1) return 1d;
            if (x == 1 && y == 1) return 0d;
            return 0;
        }

        private double And(int x, int y)
        {
            if (x == 0 && y == 0) return 0d;
            if (x == 1 && y == 0) return 0d;
            if (x == 0 && y == 1) return 0d;
            if (x == 1 && y == 1) return 1d;
            return 0;
        }


        private void button4_Click(object sender, EventArgs e)
        {
            List<double> ins = new List<double>();
            ins.Add(0);
            ins.Add(0);

            List<double> ots = new List<double>();
            ots.Add(0);

            for (int i = 0; i < 1; i++)
                nn.Train(ins, ots);

            NetworkHelper.ToTreeView(treeView1, nn);
            NetworkHelper.ToPictureBox(pictureBox1, nn, 400, 100);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<double> ins = new List<double>();
            ins.Add(0);
            ins.Add(1);

            List<double> ots = new List<double>();
            ots.Add(1);

            for (int i = 0; i < 1; i++)
                nn.Train(ins, ots);

            NetworkHelper.ToTreeView(treeView1, nn);
            NetworkHelper.ToPictureBox(pictureBox1, nn, 400, 100);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            List<double> ins = new List<double>();
            ins.Add(1);
            ins.Add(0);

            List<double> ots = new List<double>();
            ots.Add(1);

            for (int i = 0; i < 1; i++)
                nn.Train(ins, ots);

            NetworkHelper.ToTreeView(treeView1, nn);
            NetworkHelper.ToPictureBox(pictureBox1, nn, 400, 100);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            List<double> ins = new List<double>();
            ins.Add(1);
            ins.Add(1);

            List<double> ots = new List<double>();
            ots.Add(0);

            for (int i = 0; i < 1; i++)
                nn.Train(ins, ots);

            NetworkHelper.ToTreeView(treeView1, nn);
            NetworkHelper.ToPictureBox(pictureBox1, nn, 400, 100);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<double> ins = new List<double>();
            ins.Add(0);
            ins.Add(0);

            nn.FeedForward(ins);

            NetworkHelper.ToTreeView(treeView1, nn);
            NetworkHelper.ToPictureBox(pictureBox1, nn, 400, 100);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            List<double> ins = new List<double>();
            ins.Add(0);
            ins.Add(1);

            nn.FeedForward(ins);

            NetworkHelper.ToTreeView(treeView1, nn);
            NetworkHelper.ToPictureBox(pictureBox1, nn, 400, 100);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            List<double> ins = new List<double>();
            ins.Add(1);
            ins.Add(0);

            nn.FeedForward(ins);

            NetworkHelper.ToTreeView(treeView1, nn);
            NetworkHelper.ToPictureBox(pictureBox1, nn, 400, 100);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            List<double> ins = new List<double>();
            ins.Add(1);
            ins.Add(1);

            nn.FeedForward(ins);

            NetworkHelper.ToTreeView(treeView1, nn);
            NetworkHelper.ToPictureBox(pictureBox1, nn, 400, 100);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            List<double> ins = new List<double>();
            List<double> ots = new List<double>();

            for (int j = 0; j < 5000; j++)
            {
                ins.Add(0);
                ins.Add(0);
                ots.Add(Xor(0, 0));
                nn.Train(ins, ots);
                ins.Clear();
                ots.Clear();

                ins.Add(0);
                ins.Add(1);
                ots.Add(Xor(0, 1));
                nn.Train(ins, ots);
                ins.Clear();
                ots.Clear();

                ins.Add(1);
                ins.Add(0);
                ots.Add(Xor(1, 0));
                nn.Train(ins, ots);
                ins.Clear();
                ots.Clear();

                ins.Add(1);
                ins.Add(1);
                ots.Add(Xor(1, 1));
                nn.Train(ins, ots);
                ins.Clear();
                ots.Clear();
            }

            NetworkHelper.ToTreeView(treeView1, nn);
            NetworkHelper.ToPictureBox(pictureBox1, nn, 400, 100);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // por cada capa desde la ultima capa L
            for (int l = nn.Layers.Count - 1; l >= 1; l--)     // i=2,1
            {
                // por cada neurona
                for (int j = 0; j < nn.Layers[l].Neurons.Count; j++)
                {
                    Neuron n = nn.Layers[l].Neurons[j];
                    n.Bias = Convert.ToDouble(Microsoft.VisualBasic.Interaction.InputBox("Bias L" + l + " N" + j), System.Globalization.CultureInfo.InvariantCulture);

                    NetworkHelper.ToTreeView(treeView1, nn);
                    NetworkHelper.ToPictureBox(pictureBox1, nn, 400, 100);

                    for (int k = 0; k < n.Dendrites.Count; k++)
                        n.Dendrites[k].Weight = Convert.ToDouble(Microsoft.VisualBasic.Interaction.InputBox("Weight L" + l + " W" + j + k), System.Globalization.CultureInfo.InvariantCulture);


                    NetworkHelper.ToTreeView(treeView1, nn);
                    NetworkHelper.ToPictureBox(pictureBox1, nn, 400, 100);
                }
            }
        }
        */
    }

}