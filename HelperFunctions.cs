using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AoC2022
{
    struct HelperFunctions
    {
        public static void PrintToViewer(TextBlock textBlock, string text)
        {
            textBlock.Text += Environment.NewLine + text;
        }

        public static string GetTextFromFile(string filename)
        {
            string directory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            return File.ReadAllText(System.IO.Path.Combine(directory, filename));
        }
    }
}
