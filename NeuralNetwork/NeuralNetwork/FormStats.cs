using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuralNetwork
{
    public partial class FormStats : Form
    {
        public FormStats()
        {
            InitializeComponent();
        }

        public void ChangeText(string t)
        {
            richTextBox1.Text = "";
            richTextBox1.Text = t;
        }

        public void AddText(string v)
        {
            richTextBox1.Text = richTextBox1.Text + v + "\n";
        }
    }
}
