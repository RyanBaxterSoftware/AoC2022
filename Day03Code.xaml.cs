using System;
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

namespace AoC2022
{
    /// <summary>
    /// Interaction logic for Day03Code.xaml
    /// </summary>
    public partial class Day03Code : Page
    {
        public Day03Code()
        {
            InitializeComponent();

            string input = HelperFunctions.GetTextFromFile("Day03Input.txt");

            int total = findAllRepeatElements(input);
            HelperFunctions.PrintToViewer(Part1TextBlock, "The final amount after looking in all rucksacks was " + total);

            int badgeTotal = findBadgeNumbers(input);
            HelperFunctions.PrintToViewer(Part2TextBlock, "The total of all badges is " + badgeTotal);
        }

        public int findAllRepeatElements(string input)
        {
            string[] eachLine = input.Split(Environment.NewLine);

            int totalSum = 0;
            foreach (string line in eachLine) {
                List<char> occurencesFirstHalf = new List<char>();
                List<char> occurencesSecondHalf = new List<char>();

                string firstHalf = line.Substring(0, line.Length / 2);
                string secondHalf = line.Substring(line.Length / 2);

                HelperFunctions.PrintToViewer(Part1TextBlock, "Line " + line + " has been split into " + firstHalf + " and " + secondHalf);
                foreach (char c in firstHalf)
                {
                    occurencesFirstHalf.Add(c);
                }
                foreach (char c in secondHalf)
                {
                    occurencesSecondHalf.Add(c);
                }
                foreach (char c in occurencesFirstHalf)
                {
                    if (occurencesSecondHalf.Contains(c))
                    {
                        HelperFunctions.PrintToViewer(Part1TextBlock, "We found a recurring element of " + c);
                        totalSum += translateCharForRucksack(c);
                        break;
                    }
                }
            }
            return totalSum;
        }

        public int findBadgeNumbers(string input)
        {
            string[] eachLine = input.Split(Environment.NewLine);

            int totalSum = 0;

            List<char> occurencesFirstelf = new List<char>();
            List<char> occurencesSecondElf = new List<char>();
            List<char> occurencesThirdElf = new List<char>();
            string firstLine = "";
            string secondLine = "";
            string thirdLine = "";
            for (int x = 0; x < eachLine.Length; x++)
            {
                switch(x%3)
                {
                    case 0: 
                        firstLine = eachLine[x];
                        HelperFunctions.PrintToViewer(Part2TextBlock, "Elf 1: " + firstLine);
                        break;
                    case 1: 
                        secondLine = eachLine[x];
                        HelperFunctions.PrintToViewer(Part2TextBlock, "Elf 2: " + secondLine);
                        break;
                    case 2: 
                        thirdLine = eachLine[x];
                        HelperFunctions.PrintToViewer(Part2TextBlock, "Elf 3: " + thirdLine);
                        foreach (char c in firstLine)
                        {
                            if (secondLine.Contains(c) && thirdLine.Contains(c)) {
                                HelperFunctions.PrintToViewer(Part2TextBlock, "The shared badge value is " + c);
                                totalSum += translateCharForRucksack(c);
                                break;
                            }
                        }
                        firstLine = "";
                        secondLine = "";
                        thirdLine = "";
                        break;
                }
            }
            return totalSum;
        }

        private int translateCharForRucksack(char item)
        {
            int numberValue = (int)item;
            if (numberValue >= 65 && numberValue<= 90) { // Case for upper case characters
                numberValue -= 38;
            } else if (numberValue >= 97 && numberValue <= 122) // case of lower case characters
            {
                numberValue -= 96;
            }
            return numberValue;
        }
    }
}
