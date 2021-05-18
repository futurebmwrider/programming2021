using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Lab01_WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static int[] createIntRandomArray(int size, int from, int to)
        {
            int[] data = new int[size];
            var random = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < size; ++i)
            {
                data[i] = random.Next(from, to);
            }
            return data;
        }
        public int[] arr = createIntRandomArray(10, 0, 100);

        public void Min(object ara)
        {
            int[] arr = (int[])ara;
            textBox1.Invoke((MethodInvoker)delegate
            {
                progressBar1.Visible = true;
                progressBar1.Value = 0;
                progressBar1.Maximum = arr.Length;
                progressBar1.Step = 1;
            });
            int result = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (result > arr[i])
                {
                    result = arr[i];
                }
                textBox1.Invoke((MethodInvoker)delegate {
                    Thread.Sleep(100);
                    progressBar1.PerformStep();
                });
            }
            textBox1.Invoke((MethodInvoker)delegate { textBox1.Text = Convert.ToString(result); });
        }
        public void Max(object ara)
        {
            int[] arr = (int[])ara;
            textBox3.Invoke((MethodInvoker)delegate
            {
                progressBar3.Visible = true;
                progressBar3.Value = 0;
                progressBar3.Maximum = arr.Length;
                progressBar3.Step = 1;
            });
            int result = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (result < arr[i])
                {
                    result = arr[i];
                }
                textBox3.Invoke((MethodInvoker)delegate
                {
                    progressBar3.PerformStep();
                    Thread.Sleep(100);
                });
            }
            textBox3.Invoke((MethodInvoker)delegate { textBox3.Text = Convert.ToString(result); });
        }
        public void Avg(object ara)
        {
            int[] arr = (int[])ara;
            textBox2.Invoke((MethodInvoker)delegate {
                progressBar2.Visible = true;
                progressBar2.Maximum = arr.Length;
                progressBar2.Value = 0;
                progressBar2.Step = 1;
            });
            int result = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                result += arr[i];
                textBox2.Invoke((MethodInvoker)delegate
                {
                    progressBar2.PerformStep();
                    Thread.Sleep(100);
                });
            }
            result = result / 10;
            textBox2.Invoke((MethodInvoker)delegate { textBox2.Text = Convert.ToString(result); });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread t1 = new Thread(new ParameterizedThreadStart(Min));
            t1.Start(arr);
            Thread.Sleep(1000);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread t2 = new Thread(new ParameterizedThreadStart(Avg));
            t2.Start(arr);
            Thread.Sleep(1000);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Thread t3 = new Thread(new ParameterizedThreadStart(Max));
            t3.Start(arr);
            Thread.Sleep(1000);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Thread t1 = new Thread(new ParameterizedThreadStart(Min));
            t1.Start(arr);
            Thread.Sleep(1000);
        
            Thread t2 = new Thread(new ParameterizedThreadStart(Avg));
            t2.Start(arr);
            Thread.Sleep(1000);

            Thread t3 = new Thread(new ParameterizedThreadStart(Max));
            t3.Start(arr);
            Thread.Sleep(1000);
        }
    }
}
