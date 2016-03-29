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
            XmlSerializer serializer = new XmlSerializer(typeof(List<Car>));
            List<Car> listCar = new List<Car>
            {
                new Car { Name="Astra",Model="Opel"},
                new Car { Name="Astra",Model="Opel"},
                new Car { Name="Astra",Model="Opel"},
                new Car { Name="Astra",Model="Opel"},
                new Car { Name="E100",Model="Mers"},
                new Car { Name="E200",Model="Mers"},
                new Car { Name="AMG",Model="Yagonchi"},

            };

            using (var streamWriter = new StreamWriter("file24.xml"))
            {
                serializer.Serialize(streamWriter, listCar);
            }

            List<Car> carsFromFile = new List<Car>();
            using (TextReader textReader = new StreamReader("file24.xml"))
            {
                carsFromFile = (List<Car>)serializer.Deserialize(textReader);
            }


            foreach (var car in carsFromFile.GroupBy(c => c.Model))
            {
                MessageBox.Show(car.Key + "\t" + car.LongCount().ToString());
            }



        }

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
