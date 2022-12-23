using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _12zadForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        class Array
        {
            private int[] IntArray;
            private int n;
            public Array(int n)
            {
                this.n = n;
                IntArray = new int[n];
            }


            //..........................................................................
            public void Show(TextBox textBox)
            {
                foreach (int item in IntArray)
                    textBox.Text += "   " + item;
            }
            //..........................................................................
            public void ReadArray(string[] array)
            {

                for (int i = 0; i < IntArray.Length; i++)
                {

                    IntArray[i] = int.Parse(array[i]);
                }
            }
            //..........................................................................
            public int N
            {
                get
                {
                    return n;
                }
            }
            //..........................................................................
            public void SortMass()//сортировка
            {
                int temp = 0;
                for (int j = 0; j < IntArray.Length - 1; j++)
                {
                    for (int i = 0; i < IntArray.Length - 1; i++)
                    {
                        if (IntArray[i] > IntArray[i + 1])
                        {
                            temp = IntArray[i + 1];
                            IntArray[i + 1] = IntArray[i];
                            IntArray[i] = temp;
                        }
                    }
                }
            }


            public int Size
            {
                get { return IntArray.Length; }
            }
            //..........................................................................
            public int Scalar
            {
                set
                {
                    for (int i = 0; i < IntArray.Length; i++)
                    {
                        IntArray[i] *= value;
                    }
                }
            }
            //Индексатор, позволяющий по индексу обращаться к соответствующему элементу массива.
            public int this[int index]
            {
                get { return IntArray[index]; }
            }

            //операции ++ (--): одновременно увеличивает (уменьшает) значение всех элементов массива на 1;
            public static Array operator ++(Array array)
            {
                Array obj = new Array(array.IntArray.Length);
                for (int i = 0; i < array.IntArray.Length; i++)
                {
                    obj.IntArray[i] = array.IntArray[i] + 1;
                }
                return obj;
            }

            public static Array operator --(Array array)
            {
                Array obj = new Array(array.IntArray.Length);
                for (int i = 0; i < array.IntArray.Length; i++)
                {
                    obj.IntArray[i] = array.IntArray[i] - 1;
                }
                return obj;
            }

            //операции !: возвращает значение true, если элементы массива не упорядочены по возрастанию, иначе false;
            public static bool operator !(Array array)
            {
                bool a = false;
                for (int i = 0; i < array.IntArray.Length - 1; i++)
                    if (array.IntArray[i] > array.IntArray[i + 1])
                        a = true;
                return a;
            }

            // операции бинарный *: домножить все элементы массива на скаляр;
            public static Array operator *(Array array, int scal)
            {
                for (int i = 0; i < array.IntArray.Length; i++)
                {
                    array.IntArray[i] *= scal;
                }
                return array;
            }

            

            //преобразования класса массив в одномерный массив (и наоборот)
            public static implicit operator Array(int[] array)
            {
                Array obj = new Array(array.Length);
                array.CopyTo(obj.IntArray, 0);
                return obj;
            }

            public static implicit operator int[](Array obj)
            {
                return obj.IntArray;
            }


        }


        Array obj;
        int n;
        string[] array;
        int[] arr;
        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(numericUpDown1.Text, out n) || n < 1)
            {
                MessageBox.Show("Ошибка введите заново");
                return;
            }
            obj = new Array(n);

            textBox1.Visible = true;
            label2.Visible = true;
            button2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            if (!int.TryParse(numericUpDown2.Text, out int z))
            {
                MessageBox.Show("Ошибка введите заново");
                return;
            }
            obj.Scalar = z;
            textBox4.Visible = true;
            obj.Show(textBox4);
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
            button9.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            obj++;
            obj.Show(textBox4);


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Visible = false;
            textBox2.Visible = false;
            label4.Visible = false;
            textBox1.Visible = false;
            label2.Visible = false;
            button2.Visible = false;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox4.Visible = false;
            textBox3.Visible = false;
            label5.Visible = false;
            numericUpDown2.ReadOnly = true;
            numericUpDown2.Visible = false;
            button3.Visible = false;
            label6.Visible = false;
            
           
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
           textBox4.Text = "";
            obj--;
            obj.Show(textBox4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!obj) MessageBox.Show("\nМассив не упорядочен по возростанию.");
            else
                MessageBox.Show("\nМассив упорядочен по возростанию.");
        }
      //int[] arr = new int[3];


        private void button6_Click(object sender, EventArgs e)
        {
            arr = new int[n];
            textBox4.Text = "";
            arr = (Array)obj;
            foreach (var a in arr)
                textBox4.Text += " " + a;
        }
        
        private void button7_Click(object sender, EventArgs e)
        {
             textBox4.Text = "";
            obj = (int[])arr;
            obj.Show(textBox4);
        }

        private void button8_Click(object sender, EventArgs e)
        {
           
            int z = int.Parse(numericUpDown2.Text);
            textBox4.Text = "";
            obj = obj * z;
            obj.Show(textBox4);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            array = textBox1.Text.Split(' ');
            obj.ReadArray(array);
            textBox2.Visible = true;
            textBox3.Visible = true;
            numericUpDown2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            
            label6.Visible = true;
            button3.Visible = true;

            obj.Show(textBox2);

            obj.SortMass();
            obj.Show(textBox3);
            numericUpDown2.Value = obj.N;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int index = int.Parse(numericUpDown3.Text);
            textBox5.Text +="Элемент под этим индексом: " + obj[index];
        }
    }
}

