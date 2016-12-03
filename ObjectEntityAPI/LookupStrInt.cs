using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectEntityAPI
{
    public class LookupStrInt
    {
        private int size = 0, count = 0;
        private Dictionary<string, int> table;

        public LookupStrInt(int size)
        {
            this.size = size;
            table = new Dictionary<string, int>();
        }

        public void AddEntry(string name, int value)
        {
            if(count < size)
            {
                table.Add(name, value);
                count++;
            }
        }

        public int GetEntry(string name)
        {
            return table[name];
        }

        public bool HasEntry(string name)
        {
            int s = -1;
            s += table[name];
            if (s != -1)
                return true;
            else
                return false;
        }
    }
}