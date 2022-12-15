using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for Day02Code.xaml
    /// </summary>
    public partial class Day02Code : Page
    {
        public Day02Code()
        {
            InitializeComponent();

            rockPaperScissors();
        }

        private void rockPaperScissors()
        {
            string input = HelperFunctions.GetTextFromFile("Day02Input.txt");
            string[] lines = input.Split(Environment.NewLine);

            int totalPoints = 0;
            int correctedPoints = 0;

            foreach (string line in lines)
            {
                string[] plays = line.Split(" ");
                totalPoints += calculateWin(plays[0], plays[1]);
                Part1TextBox.Text += Environment.NewLine + "Current score is " + totalPoints;
                correctedPoints += calculateWinByResult(plays[0], plays[1]);
                Part2TextBox.Text += Environment.NewLine + "Current score is " + totalPoints;
            }
            HelperFunctions.PrintToViewer(Part1TextBox, "Final points total: " + totalPoints.ToString());
            HelperFunctions.PrintToViewer(Part2TextBox, "Final points total: " + correctedPoints.ToString());
            Part1ScrollViewer.ScrollToBottom();
            Part2ScrollViewer.ScrollToBottom();
        }

        private int calculateWin(string opponent, string response)
        {
            int value = 0;
            switch (opponent)
            {
                case "A": // opponent plays rock
                    switch (response)
                    {
                        case "X":
                            value += 1; // for throwing rock
                            value += 3; // for tying
                            break;
                        case "Y":
                            value += 2; // for throwing paper
                            value += 6; // for winning
                            break;
                        case "Z":
                            value += 3; // for throwing scissors
                            value += 0; // for losing
                            break;
                    }
                    break;
                case "B": // opponent plays paper
                    switch (response)
                    {
                        case "X":
                            value += 1; // for throwing rock
                            value += 0; // for losing
                            break;
                        case "Y":
                            value += 2; // for throwing paper
                            value += 3; // for for tying
                            break;
                        case "Z":
                            value += 3; // for throwing scissors
                            value += 6; // for winning
                            break;
                    }
                    break;
                case "C": // opponent plays scissors
                    switch (response)
                    {
                        case "X":
                            value += 1; // for throwing rock
                            value += 6; // for winning
                            break;
                        case "Y":
                            value += 2; // for throwing paper
                            value += 0; // for losing
                            break;
                        case "Z":
                            value += 3; // for throwing scissors
                            value += 3; // for tying
                            break;
                    }
                    break;
            }

            return value;
        }

        private int calculateWinByResult(string opponent, string response)
        {
            int value = 0;
            switch (opponent)
            {
                case "A": // opponent plays rock
                    switch (response)
                    {
                        case "X":
                            value += 3; // for throwing scissors
                            value += 0; // for losing
                            break;
                        case "Y":
                            value += 1; // for throwing rock
                            value += 3; // for tying
                            break;
                        case "Z":
                            value += 2; // for throwing paper
                            value += 6; // for winning
                            break;
                    }
                    break;
                case "B": // opponent plays paper
                    switch (response)
                    {
                        case "X":
                            value += 1; // for throwing rock
                            value += 0; // for losing
                            break;
                        case "Y":
                            value += 2; // for throwing paper
                            value += 3; // for for tying
                            break;
                        case "Z":
                            value += 3; // for throwing scissors
                            value += 6; // for winning
                            break;
                    }
                    break;
                case "C": // opponent plays scissors
                    switch (response)
                    {
                        case "X":
                            value += 2; // for throwing paper
                            value += 0; // for losing
                            break;
                        case "Y":
                            value += 3; // for throwing scissors
                            value += 3; // for tying
                            break;
                        case "Z":
                            value += 1; // for throwing rock
                            value += 6; // for winning
                            break;
                    }
                    break;
            }

            return value;
        }
    }
}
