using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pole_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            try
            {
                int ncisel = Convert.ToInt32(numericUpDown1.Value);
                int[] pole1 = new int[ncisel];

                Random rnd = new Random();

                int j = 0;
                for (int i = 0; i < ncisel; i++)
                {
                    pole1[i] = rnd.Next(32, 128);
                    listBox1.Items.Add((char)(pole1[i]));

                    if (pole1[i] >= 48 && pole1[i] <= 57 || pole1[i] >= 65 && pole1[i] <= 90 || pole1[i] >= 97 && pole1[i] <= 120)
                    {
                        //textBox1.Lines[j] = pole1[i].ToString();
                        //listBox2.Items.Add((char)(pole1[i]));
                        j++;
                    }
                }

                int[] pole2 = new int[j];

                int prvnivyskyt = 0;
                bool prvni = false;
                int poslednivyskyt = 0;
                j = 0;
                for (int i = 0; i < ncisel; i++)
                {
                    if (pole1[i] >= 48 && pole1[i] <= 57 || pole1[i] >= 65 && pole1[i] <= 90 || pole1[i] >= 97 && pole1[i] <= 120)
                    {
                        pole2[j] = pole1[i];
                        if (pole2[j] == 87)
                        {
                            if (prvni == false)
                            {
                                prvnivyskyt = j;
                                prvni = true;
                            }
                            poslednivyskyt = j;
                        }
                        j++;
                    }

                }
                if(prvnivyskyt != 0)
                {
                    label4.Text = "" + prvnivyskyt+1;
                    label5.Text = "" + poslednivyskyt+1;
                }
                else
                {
                    label4.Text = "neni";
                    label5.Text = "neni";
                }

                foreach (char o in pole2)
                {
                    listBox2.Items.Add(o);
                }

                pole2 = pole2.Distinct().ToArray();
                Array.Reverse(pole2);

                foreach (char o in pole2)
                {
                    listBox3.Items.Add(o);
                }
                /*for (int i = 0; i < j; i++)
                {
                    textBox1.Lines[i] = ((char)pole2[i]).ToString();
                }*/
            }
            catch
            {

            }


        }
    }
}
