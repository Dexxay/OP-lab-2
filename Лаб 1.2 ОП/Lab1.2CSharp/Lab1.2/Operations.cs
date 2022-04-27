using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab1._2
{
    class Operations
    {
        public static List<CallInfo> InputInfo()
        {
            List<CallInfo> infoList = new List<CallInfo>();
            Console.WriteLine("Enter information about phone calls: (format: +XX0XXXXXXXXX HH:MM HH:MM), type Ctrl + X to stop");
            string exitLine = "\u0018";
            while (true)
            {
                Console.Write("\t");
                string line = Console.ReadLine();
                if (line == exitLine)
                {
                    Console.WriteLine();
                    return infoList;
                }
                else if (CallInfo.TryCreateFromString(line, out CallInfo result))
                {
                    infoList.Add(result);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error. Wrong input format");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }

        public static bool ChooseAppendOrNot(string path)
        {

            if (File.Exists(path))
            {
                while (true)
                {
                    Console.WriteLine("Do you want to add new info to existing file or clear it? (enter 'a' or 'c')");
                    Console.Write("\t");
                    string input = Console.ReadLine();
                    if (input == "a")
                    {
                        return true;
                    }
                    else if (input == "c")
                    {
                        return false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong symbol. Try again");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
            }
            return true;
        }

        public static void SaveInfo(string path, List<CallInfo> infoList, bool appendOrNot)
        {
            if (!appendOrNot)
            {
                File.Delete(path);
            }
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Append)))
            {
                foreach (CallInfo callInfo in infoList)
                {
                    writer.Write(callInfo.GetPhoneNumber());
                    writer.Write(callInfo.GetStartMinute());
                    writer.Write(callInfo.GetEndMinute());
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("File has been successfully written");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }

        public static List<CallInfo> ReadInfo(string path)
        {
            List<CallInfo> infoList = new List<CallInfo>();
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    string number = reader.ReadString();
                    string startTime = reader.ReadString();
                    string endTime = reader.ReadString();
                    infoList.Add(new CallInfo(number, startTime, endTime));
                }
            }
            return infoList;
        }

        public static void ShowInfo(List<CallInfo>info)
        {
            Console.WriteLine("Saved info: ");
            for (int i = 0; i < info.Count; i++)
            {
                Console.WriteLine($" {info[i].GetPhoneNumber()} {info[i].GetStartMinute()} {info[i].GetEndMinute()}; Payment : {info[i].Payment}");
            }
            Console.WriteLine();
        }

        public static List<CallInfo> DeleteShortest(List<CallInfo> info)
        {
            for (int i = 0; i < info.Count; i++)
            {
                if (info[i].Duration < 3)
                {
                    info.Remove(info[i]);
                    i--;
                }
            }
            return info;
        }

    }
}
