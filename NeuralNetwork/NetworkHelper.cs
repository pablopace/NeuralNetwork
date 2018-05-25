using NeuralNetwork.NeuralNetwork;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NeuralNetwork
{
    public static class NetworkHelper
    {
        public static void ToTreeView(TreeView t, Net nn)
        {
            t.Nodes.Clear();

            TreeNode root = new TreeNode("NeuralNetwork");

            nn.layers.ForEach((layer) =>
            {
                TreeNode lnode = new TreeNode("Layer");

                layer.neuronas.ForEach((neuron) =>
                {
                    TreeNode nnode = new TreeNode("Neuron");
                    nnode.Nodes.Add("Value: " + neuron.a.ToString("0.0000"));

                    if (neuron.dentritas != null)
                    {
                        nnode.Nodes.Add("Bias: " + neuron.bias.ToString("0.0000"));
                        nnode.Nodes.Add("Delta: " + neuron.delta.ToString("0.0000"));
                        //nnode.Nodes.Add("Error: " + neuron..ToString("0.0000000000"));

                        neuron.dentritas.ForEach((dendrite) =>
                        {
                            TreeNode dnode = new TreeNode("Dendrite");
                            dnode.Nodes.Add("Weight: " + dendrite.weight.ToString("0.0000"));
                            nnode.Nodes.Add(dnode);
                        });
                    }


                    lnode.Nodes.Add(nnode);
                });

                root.Nodes.Add(lnode);
            });

            root.ExpandAll();
            t.Nodes.Add(root);
        }

        public static void ToPictureBox(PictureBox p, Net nn)
        {
            int X = 400;
            int Y = 100;

            int neuronWidth = 30;
            int neuronDistance = 50;
            int layerDistance = 100;
            int fontSize = 8;

            int weightOffsetX = 15;
            int weightOffsetY = 15;

            Bitmap b = new Bitmap(p.Width, p.Height);
            Graphics g = Graphics.FromImage(b);

            g.FillRectangle(Brushes.White, g.ClipBounds);

            //dibujo dentritas
            int y = Y;
            foreach (Layer l in nn.layers)
            {
                int x = X - (neuronDistance * (l.neuronas.Count / 2));

                foreach (Neuron n in l.neuronas)
                {
                    if (n.dentritas != null)
                    {
                        for (int d = 0; d < n.dentritas.Count; d++)
                        {
                            /*Color c = Color.FromArgb(
                                (int) Math.Round( Formulas.Sigmoid(n.dentritas[d].weight) / 255d ),
                                (int) Math.Round(Formulas.Sigmoid(n.dentritas[d].weight) * 255d),
                                0 );*/
                            g.DrawLine(Pens.Black, x + weightOffsetX, y + weightOffsetY, X + weightOffsetX - (neuronDistance * (n.dentritas.Count / 2)) + neuronDistance * d, y + weightOffsetY - layerDistance);
                        }
                    }

                    x += neuronDistance;
                }
                y += layerDistance;
            }

            //dibujo neuronas
            y = Y;
            for (int l = 0; l < nn.layers.Count; l++)
            {
                Layer layer = nn.layers[l];

                int x = X - (neuronDistance * (layer.neuronas.Count / 2));

                for (int n = 0; n < layer.neuronas.Count; n++)
                {
                    Neuron neuron = layer.neuronas[n];

                    g.FillEllipse(Brushes.WhiteSmoke, x, y, neuronWidth, neuronWidth);
                    g.DrawEllipse(Pens.Gray, x, y, neuronWidth, neuronWidth);
                    g.DrawString(neuron.a.ToString("0.00"), new Font("Arial", fontSize), Brushes.Black, x + 2, y + (neuronWidth / 2) - 5);

                    x += neuronDistance;
                };

                y += layerDistance;
            };

            p.Image = b;
        }
    }


}
