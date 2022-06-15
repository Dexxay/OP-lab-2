using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    internal class BinaryTree
    {
        public Node _root;

        public void Add(Detail detail)
        {
            if (_root == null)
                _root = new Node(detail);
            else
                _root.Add(detail);
        }

        public void FindProvider(ref string provider)
        {
            if (_root != null)
                 _root.FindProvider(ref provider);
        }

        public void Display()
        {
            int dashNumber = 50;
            Console.WriteLine("Your tree is: ");
            Console.WriteLine(new String('-', dashNumber) + "\n");

            _root.PrintNode(0);

            Console.WriteLine("\n" + new String('-', dashNumber));
        }
    }
}
