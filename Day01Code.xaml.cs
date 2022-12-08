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
            string input = File.ReadAllText(System.IO.Path.Combine(directory, "Day01Input.txt"));
            string[] elves = input.Split(Environment.NewLine + Environment.NewLine);
            Day1TextBox.Text = elves.Length.ToString();

            List<int> foodAmounts = new List<int>();

            foreach (string elf in elves)
            {
                int elfFood = 0;
                foreach (string foodItem in elf.Split(Environment.NewLine))
                {
                    elfFood += Int32.Parse(foodItem);
                }
                foodAmounts.Add(elfFood);
                Day1TextBox.Text += Environment.NewLine + "An elf has been totaled to have " + elfFood + " calories total.";
                Day1TextBox.Text += " Total amount of elves is " + foodAmounts.Count;
            }
            int largest = foodAmounts.Max();
            Day1TextBox.Text += Environment.NewLine + "The largest amount that was found is " + largest.ToString();

            foodAmounts.Sort();
            int topThree = foodAmounts[foodAmounts.Count - 1] + foodAmounts[foodAmounts.Count - 2] + foodAmounts[foodAmounts.Count - 3];
            Day2TextBox.Text = Environment.NewLine + "The three largest, however, total at " + topThree.ToString() + " calories.";
        }
    }
}
