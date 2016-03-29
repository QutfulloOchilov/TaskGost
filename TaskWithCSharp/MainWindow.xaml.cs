using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Serialization;
namespace TaskWithCSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void uiTask24_Click(object sender, RoutedEventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));

            List<Car> cars = new List<Car>
            {
                 new Car { Name="Astra",Model="Opel"},
                    new Car { Name="Astra",Model="Opel"},
                    new Car { Name="Astra",Model="Opel"},
                    new Car { Name="Astra",Model="Opel"},
                    new Car { Name="E100",Model="Mers"},
                    new Car { Name="E200",Model="Mers"},
                    new Car { Name="AMG",Model="Yagonchi"}
            };


            var newPersoin = new Person()
            {
                FirstName = "Qutfullo",
                LastName = "Ochilov",
                Cars = cars
            };

            var newPersoin1 = new Person()
            {
                FirstName = "Manucher",
                LastName = "Sattorov",
                Cars = cars
            };

            var newPersoin2 = new Person()
            {
                FirstName = "Maftuna",
                LastName = "Ganieva",
                Cars = cars
            };

            List<Person> persons = new List<Person> { newPersoin, newPersoin1, newPersoin2 };
            using (var streamWriter = new StreamWriter("file24.xml"))
            {
                serializer.Serialize(streamWriter, persons);
            }

            List<Person> personFromFile = new List<Person>();
            using (TextReader textReader = new StreamReader("file24.xml"))
            {
                personFromFile = (List<Person>)serializer.Deserialize(textReader);
            }

            string result = "";
            foreach (var item in personFromFile)
            {
                result += item.FirstName + " " + item.LastName + " ";
                foreach (var car in item.Cars.GroupBy(c => c.Model))
                {
                    result += car.Key + " " + car.Count()+" ";
                }
                result += "\n";

            }
            MessageBox.Show(result);


        }

        private void uiTask1_Click(object sender, RoutedEventArgs e)
        {
            int a = 2;
            int b = a * a;
            MessageBox.Show(b.ToString());
            a = b * a;
            MessageBox.Show(a.ToString());
            b = a * b;
            MessageBox.Show(b.ToString());
            a = b * b;
            MessageBox.Show(a.ToString());
            b = a * b;
            MessageBox.Show(b.ToString());



        }

        private void uiTask15_Click(object sender, RoutedEventArgs e)
        {
            int[] numbers = new int[] { 1, 3, 2, 4, 6, 5, 8, 7, 9, 11, 10 };

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (i == numbers.Length - 1)
                {
                    continue;
                }

                if (numbers[i] > numbers[i + 1])
                {
                    int maxNumer = numbers[i + 1];
                    numbers[i + 1] = numbers[i];
                    numbers[i] = maxNumer;
                }

            }
            int[] natija = numbers;
        }

        private void uiTask2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void uiTask3_Click(object sender, RoutedEventArgs e)
        {
            int number = 123;
            int sum = 0;
            int counter = 0;
            while (number > 0)
            {
                counter++;
                sum = sum + number % 10;
                number = number / 10;
            }
            MessageBox.Show("Summa = " + sum);
            MessageBox.Show("Count = " + counter);

        }

        private void uiTask9_Click(object sender, RoutedEventArgs e)
        {
            int E = 2;
            int k = 10;
            int[] a = new int[k];
            for (int i = 0; i < k - 1; i++)
            {
                if (i == 0)
                {
                    a[i] = 2;
                }
                else
                {
                    a[i] = (2 + 1) / a[i - 1];
                }
            }
            List<int> numbersWithIf = new List<int>();
            for (int i = 0; i < k - 1; i++)
            {
                if (i > 0)
                {

                    if (Math.Exp(a[i] - a[i - 1]) < E)
                    {
                        numbersWithIf.Add(a[i]);
                    }
                }
            }

            MessageBox.Show(numbersWithIf.Min().ToString());
        }

        private void uiTask23_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    [XmlRoot(nameof(Person))]
    public class Person
    {
        [XmlAttribute]
        public string FirstName { get; set; }

        [XmlAttribute]
        public string LastName { get; set; }

        [XmlArray()]
        public List<Car> Cars { get; set; }
    }




    [XmlRoot(nameof(Car))]
    public class Car
    {
        [XmlAttribute(nameof(Name))]
        public string Name { get; set; }

        [XmlAttribute(nameof(Model))]
        public string Model { get; set; }
    }
}
