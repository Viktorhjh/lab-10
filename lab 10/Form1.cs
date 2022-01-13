using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_10
{
    public partial class Form1 : Form
    {
        int index, indexer;      
        List<Person> people = new List<Person>(3);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (index)
            {
                case 0:
                    Trojka<int> trojkaInt = new Trojka<int>(int.Parse(textBox1.Text),
                int.Parse(textBox2.Text), int.Parse(textBox3.Text));
                    label1.Text = trojkaInt.ToString();
                    break;

                case 1:
                    Trojka<string> trojkaStr = new Trojka<string>(textBox1.Text,
                textBox2.Text, textBox3.Text);
                    label1.Text = trojkaStr.ToString();
                    break;

                case 2:
                    Trojka<double> trojkaDouble = new Trojka<double>(double.Parse(textBox1.Text),
                double.Parse(textBox2.Text), double.Parse(textBox3.Text));
                    label1.Text = trojkaDouble.ToString();
                    break;

                case 3:
                    Trojka<Person> trojkaPerson = new Trojka<Person>(people[0], people[1], people[2]);
                    label1.Text = $"{trojkaPerson.A.name} {trojkaPerson.A.surname} {trojkaPerson.A.age}\n" +
                        $"{trojkaPerson.B.name} {trojkaPerson.B.surname} {trojkaPerson.B.age}\n" +
                        $"{trojkaPerson.C.name} {trojkaPerson.C.surname} {trojkaPerson.C.age}";
                    break;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            label1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (people.Count < 3)
            {
                people.Add(new Person(textBox1.Text, textBox2.Text, int.Parse(textBox3.Text)));
            }
            else
            {                
                people.RemoveAt(people.Count);
            }            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexer = comboBox1.SelectedIndex;            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = comboBox2.SelectedIndex;
        }
    }

    public class Person
    {
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }
        public Person(string n, string s, int a)
        {
            name = n;
            surname = s;
            age = a;
        }
    }

    public class Trojka<T>
    {
        public T A { get; set; }
        public T B { get; set; }
        public T C { get; set; }

        public Trojka(T a, T b, T c)
        {
            A = a;
            B = b;
            C = c;
        }

        public override string ToString()
        {
            return $"({A.ToString()}, {B.ToString()}, {C.ToString()})";
        }

        public T this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return A;
                    case 1: return B;
                    case 2: return C;
                    default: throw new Exception("Unknown index");
                }                
            }
            set
            {
                switch (index)
                {
                    case 0:
                        A = value;
                        break;
                    case 1:
                        B = value;
                        break;
                    case 2:
                        C = value;
                        break;
                }
            }        
        }
    }
}
/*
konstruktor z trzema parametrami,
właściwości A, B, C, które pozwolą "dostać się" do tych trzech wartości,
nadpisaną metodę ToString( ), która zwróci napis w postaci "(A, B, C)",
indekser (trojka[0] => A, trojka[1] => B, trojka[2] => C),
metodę Sort( ), która ustawi wartości w kolejności rosnącej.
*/