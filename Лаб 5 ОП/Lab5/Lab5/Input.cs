using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    internal class Input
    {
        public BinaryTree InputTree()
        {
            BinaryTree tree = new BinaryTree();

            int nodesAmount = InputAmount("Enter nodes amount: ");
            Console.WriteLine();
            for (int i = 0; i < nodesAmount; i++)
            {
                Console.WriteLine($"{i+1}) detail: ");
                tree.Add(InputDetail());
                Console.WriteLine();
            }
            return tree;
        }

        private Detail InputDetail()
        {
            string name = InputString("Enter name of detail: ");
            int amount = InputAmount("Enter amount of details: ");
            string provider = InputString("Enter the provider of details: ");
            return new Detail(name, amount, provider);
        }

        private int InputAmount(string message)
        {
            int minAmount = 1;
            Console.Write(message);
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int amount) && amount >= minAmount)
                    return amount;
                else
                    Console.Write("Wrong input. Try again: ");
            }
        }

        private string InputString(string message)
        {
            Console.Write(message);
            while (true)
            {
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                    return input;
                else
                    Console.Write("Wrong input. Try again: ");
            }
        }
    }
}
