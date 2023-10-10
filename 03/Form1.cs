using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Statistics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "C# Source Files (*.cs)|*.cs";
            openFileDialog.Title = "Select a C# Source File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileContent = File.ReadAllText(filePath);

                int originalLineCount = GetLineCount(fileContent);
                int originalWordCount = GetWordCount(fileContent);

                // Remove empty lines and comments
                string formattedContent = RemoveEmptyLinesAndComments(fileContent);

                int formattedLineCount = GetLineCount(formattedContent);
                int formattedWordCount = GetWordCount(formattedContent);

                label1.Text = originalLineCount.ToString();
                label2.Text = originalWordCount.ToString();
                label3.Text = formattedLineCount.ToString();
                label4.Text = formattedWordCount.ToString();

                DisplayWordFrequency(formattedContent);
            }
        }

        private int GetLineCount(string content)
        {
            return content.Split('\n').Length;
        }

        private int GetWordCount(string content)
        {
            string[] words = Regex.Split(content, @"\W+");
            return words.Length;
        }

        private string RemoveEmptyLinesAndComments(string content)
        {
            string[] lines = content.Split('\n');
            List<string> cleanedLines = new List<string>();

            foreach (string line in lines)
            {
                string trimmedLine = line.Trim();

                if (!string.IsNullOrWhiteSpace(trimmedLine) && !trimmedLine.StartsWith("//"))
                {
                    cleanedLines.Add(trimmedLine);
                }
            }

            return string.Join("\n", cleanedLines);
        }

        private void DisplayWordFrequency(string content)
        {
            string[] words = Regex.Split(content, @"\W+");

            var wordFrequency = words
                .Where(word => !string.IsNullOrWhiteSpace(word))
                .GroupBy(word => word)
                .Select(group => new { Word = group.Key, Count = group.Count() })
                .OrderByDescending(item => item.Count);

            listBox1.Items.Clear();

            foreach (var item in wordFrequency)
            {
                listBox1.Items.Add($"{item.Word}: {item.Count}");
            }
        }

    }
}