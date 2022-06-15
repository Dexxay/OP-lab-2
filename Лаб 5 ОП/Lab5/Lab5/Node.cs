using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    internal class Node
    {
        private Detail _detail;
        private Node _leftNode;
        private Node _rightNode;
        public Node(Detail detail)
        {
            _detail = detail;
        }
        public void Add(Detail detail)
        {
            if (detail.GetAmount() >= _detail.GetAmount())
            {
                if (_rightNode == null)
                {
                    _rightNode = new Node(detail);
                }
                else
                {
                    _rightNode.Add(detail);
                }
            }
            else
            {
                if (_leftNode == null)
                {
                    _leftNode = new Node(detail);
                }
                else
                {
                    _leftNode.Add(detail);
                }
            }
        }
        public void PrintNode(int space)
        {
            if (_detail == null)
                return;

            if (_rightNode != null)
                _rightNode.PrintNode(++space);
            else
                space++;

            for (int i = 0; i < space; i++)
            {
                Console.Write("\t");
            }
            Console.WriteLine(_detail.ToString());

            if (_leftNode != null)
                _leftNode.PrintNode(space);
        }
        public void FindProvider(ref string provider)
        {
            if (_rightNode != null)
                _rightNode.FindProvider(ref provider);
            else
                provider = _detail.GetProvider();
        }
    }
}
