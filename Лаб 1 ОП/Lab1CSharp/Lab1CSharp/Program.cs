using System;
using System.Collections.Generic;
using System.IO;

namespace Lab1CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"E:\КПІ Лаби\ОП 2 семестр\Лаб 1\file.txt";
            string newFilePath = @"E:\КПІ Лаби\ОП 2 семестр\Лаб 1\newFile.txt";

            List<string> text = InputText();
            bool append = ChooseAppendOrNot();
            StreamWriter sw = new StreamWriter(filePath, append);
            FillFile(text, sw);
            sw.Close();

            StreamReader sr = new StreamReader(filePath);
            List<string> newText = ChangeText(sr);

            sw = new StreamWriter(newFilePath);
            FillFile(newText, sw);
            sw.Close();

            Console.WriteLine();

            Console.WriteLine("Original file: ");
            sr = new StreamReader(filePath);
            Console.WriteLine(sr.ReadToEnd());

            Console.WriteLine("New file: ");
            sr = new StreamReader(newFilePath);
            Console.WriteLine(sr.ReadToEnd());
        }

        public static bool ChooseAppendOrNot()
        {
            while (true)
            {
                Console.Write("You want to append or rewrite text? Enter 'a' to append or 'r' to rewrite: ");
                string input = Console.ReadLine().ToLower();
                if (input == "a")
                {
                    return true;
                }
                else if (input == "r")
                {
                    return false;
                }
                Console.Write("Wrong symbol. ");
            }
        }

        public static void FillFile(List<string> text, StreamWriter sw)
        {
            for (int i = 0; i < text.Count; i++)
            {
                sw.WriteLine(text[i]);
            }
        }

        public static List<string> ChangeText(StreamReader sr)
        {
            List<string> newText = new List<string>();
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (line == "")
                {
                    newText.Add("");
                    continue;
                }
                string[] sentences = SeparateSentences(line);
                for (int i = 0; i < sentences.Length; i++)
                {
                    string[] words = SeparateWords(sentences[i]);
                    int minLength = words[0].Length;
                    string minWord = words[0];
                    for (int j = 0; j < words.Length; j++)
                    {
                        if (words[j].Length < minLength)
                        {
                            minLength = words[j].Length;
                            minWord = words[j];
                        }
                    }
                    sentences[i] = sentences[i].Trim() + "  -=The smallest word is: \"" + minWord + "\" and it's length is: " + Convert.ToString(minLength) + " =-";
                    newText.Add(sentences[i]);
                }
            }
            return newText;
        }

        public static List<string> InputText()
        {
            Console.WriteLine("Enter your text: (press CTRL + X and Enter to stop)");
            List<string> text = new List<string>();
            bool flag = true;
            string exitLine = "\u0018";
            while (flag)
            {
                string line = Console.ReadLine();
                if (line == exitLine)
                {
                    flag = false;
                }
                else 
                {
                    text.Add(line);
                }
            }
            return text;
        }

        public static string[] SeparateSentences(string line)
        {
            string[] sentences = line.Split('.', StringSplitOptions.RemoveEmptyEntries);
            return sentences;
        }

        public static string[] SeparateWords(string line)
        {
            char[] separator = new char[] { ',', ' ', ';' };
            string[] words = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            return words;
        }
    }
}
