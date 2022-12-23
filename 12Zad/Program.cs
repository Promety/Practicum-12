using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12Zad
{
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
        public void Show()
        {
            foreach (int item in IntArray)
                Console.Write("{0} ", item);
        }
        //..........................................................................
        public void ReadArray()
        {
            Console.WriteLine("Введите элементы массива");

                for (int i = 0; i < IntArray.Length; i++)
                {
                    int dop;
                    Console.Write("IntArray[{0}] = ", i);
                    while (!int.TryParse(Console.ReadLine(), out dop))
                        Console.Write("Ошибка введите заново\nIntArray[{0}] = ",i);
                    IntArray[i] = dop;
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

        // операции бинарный *:  домножить все элементы массива на скаляр;
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
            return new Array(array);
        }
        public Array(int[] array)
        {
            IntArray = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                IntArray[i] = array[i];
            }
        }

        public static implicit operator int[](Array obj)
        {
            return obj.IntArray;
        }
        

    }
    class Program
    {
        static void Main(string[] args)
        {
            int z;
            int n;
            Console.WriteLine("Введите размер массива: ");
            while (!int.TryParse(Console.ReadLine(), out n)|| n<1)
                Console.WriteLine("Ошибка введите заново");
            
            Array obj = new Array(n);
           // Console.WriteLine("\nВведите элементы массива с клавиатуры:\n");
            obj.ReadArray();
            obj.Show();
            
            Console.WriteLine("\nОтсортировать элементы массива в порядке возрастания:");
            obj.SortMass();
            obj.Show();

            Console.WriteLine("\nРазмерность массива: " + obj.N);
            Console.WriteLine("\nВведите скаляр, на который домножают элементы ");
            while (!int.TryParse(Console.ReadLine(), out z)|| z==0)
                Console.WriteLine("Ошибка введите заново");
            Console.WriteLine("\nДомножить все элементы массива на скаляр ");
            obj.Scalar = z;
            obj.Show();

            Console.WriteLine("\nОперации ++: одновременно увеличивает значение всех элементов массива на 1:");
            obj++;
            obj.Show();

            Console.WriteLine("\nОперации --: одновременно уменьшает значение всех элементов массива на 1:");
            obj--;
            obj.Show();

            if (!obj) Console.WriteLine("\nМассив не упорядочен по возростанию.");
            else
                Console.WriteLine("\nМассив упорядочен по возростанию.");

            Console.WriteLine("\nОперации бинарный *:  домножить все элементы массива на скаляр (obj * z):");
            obj = obj * z;
            obj.Show();
            Console.WriteLine("\n• преобразования класса массив в одномерный массив (и наоборот).");

            int[] arr = obj;

            arr = (Array)obj;
            Console.WriteLine("\nпреобразованый класс массива в одномерный массив", obj);
            obj.Show();
            Console.WriteLine("\nпреобразованый одномерный массив в класс массива ");
            foreach (var a in arr)
            {
                Console.Write(a + "\t");
            }
            Console.WriteLine("\nВведите индекс элемента к которому хотите обратиться:");
            int index = int.Parse(Console.ReadLine());
            Console.WriteLine("Элемент под этим индексом: " + obj[index]);
        }
    }
}