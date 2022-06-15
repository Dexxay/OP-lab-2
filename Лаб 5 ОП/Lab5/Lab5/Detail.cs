using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    internal class Detail
    {
        private string name;
        private int amount;
        private string provider;

        public Detail(string name, int amount, string provider)
        {
            this.name = name;
            this.amount = amount;
            this.provider = provider;
        }

        public string GetName()
        {
            return name;
        }
        public int GetAmount()
        {
            return amount;
        }
        public string GetProvider()
        {
            return provider;
        }

        public override string ToString()
        {
            return name + "(" + amount + ")";
        }
    }
}
