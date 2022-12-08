using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
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

namespace AoC2022
{
    /// <summary>
    /// Interaction logic for Day01Code.xaml
    /// </summary>
    public partial class Day01Code : Page
    {
        public Day01Code()
        {
            InitializeComponent();

            CalorieCounter();
        }

        public void CalorieCounter()
        {
            string directory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            Day1TextBox.Text = directory;
            string input = System.IO.File.ReadAllText(System.IO.Path.Combine(directory, "Day01Input.txt"));
            Day1TextBox.Text = input;
        }
    }
}
