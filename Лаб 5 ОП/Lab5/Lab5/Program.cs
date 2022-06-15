using System;

namespace Lab5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Input input = new Input();
            BinaryTree tree = input.InputTree();
            tree.Display();

            string ProviderOfMaxAmount = "";
            tree.FindProvider(ref ProviderOfMaxAmount);
            Console.WriteLine("Provider of max amount of details: " + ProviderOfMaxAmount);
        }
    }
}
