using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComponentBasic2_AitorGallardo
{
    public partial class Form1 : Form
    {
        List<double> coinsValue = new List<double>();
        public Form1()
        {
            InitializeComponent();
            for(int i =0; i < 4; i++)
            {
                this.coinsValue.Add(0);
            }           
        }

        private void button2_Click(object sender, EventArgs e) //Adds 0-9 numbers to currentOne
        {
            // textBox1.Text.Substring(0).Equals("0");
            Button button = (Button)sender;
            if (textBox1.Text.Contains("."))
            {
                int commaPos = textBox1.Text.IndexOf(".");
                if (commaPos == 0 && button.Text != ".")
                {
                    textBox1.Text = "0" + textBox1.Text + button.Text;
                }
                else if (button.Text == ".")
                {
                    textBox1.Text = textBox1.Text;
                }
                else if (textBox1.Text.Length == commaPos || textBox1.Text.Length == commaPos + 2 || textBox1.Text.Length == commaPos + 1)
                {
                    textBox1.Text += button.Text;
                }
            }
            else if (textBox1.Text.IndexOf("0") == 0 && textBox1.Text.Length == 1 && button.Text != ".")
            {

                textBox1.Text = button.Text;
            }
            else
            {
                textBox1.Text += button.Text;
            }
        }

        private void deleteAll_Click(object sender, EventArgs e)// Set textBox to 0
        {
            textBox1.Text = "0";
        }

        private void back_Click(object sender, EventArgs e) // Detelete last number
        {
            if(textBox1.Text.Length > 0)
            textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void newCoin_Click(object sender, EventArgs e)
        {
            String valor = Microsoft.VisualBasic.Interaction.InputBox("Add a new currency");
            comboBox1.Items.Add(valor);
        }

        private void deleteCoin_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                int index = comboBox1.Items.IndexOf(comboBox1.SelectedItem);
                comboBox1.Items.Remove(comboBox1.SelectedItem);
                this.coinsValue.RemoveAt(index);
            }

        }

        private void Convert_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedItem != null && textBox1.Text.Length > 0)
            {
                int index = comboBox1.Items.IndexOf(comboBox1.SelectedItem);

                if (this.coinsValue[index] == 0)
                {
                    String currencyValue = Microsoft.VisualBasic.Interaction.InputBox("Introduce ratio convertion. Currency value per 1€");

                    if (currencyValue.Length > 0)
                    {
                        try
                        {
                            this.coinsValue[index] = Double.Parse(currencyValue);
                            textBox1.Text = (Double.Parse(textBox1.Text) * this.coinsValue[index]).ToString();
                        }
                        catch(Exception exception)
                        {
                            MessageBox.Show("Invalid input");
                        }

                    }
                }
                else
                {
                    this.coinsValue[index] = this.coinsValue[index];
                    textBox1.Text = (Math.Round(Double.Parse(textBox1.Text) * this.coinsValue[index], 2)).ToString();
                }
            }
            else if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Error! Select a currency to convert to");
            }
            else
            {
                MessageBox.Show("Error! Insert a value to convert");
            }

        }

    }
}
