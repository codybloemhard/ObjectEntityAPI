using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectEntityAPI
{
    public class LookupStrInt
    {
        private int[] ints;
        private string[] strings;

        private int size = 0, count = 0;

        public LookupStrInt(int size)
        {
            this.size = size;
            ints = new int[size];
            strings = new string[size];
        }

        public void AddEntry(string name, int value)
        {
            if(count <= size)
            {
                strings[count] = name;
                ints[count] = value;
                count++;
            }
        }

        public int GetEntry(string name)
        {
            int found = -1;

            for (int i = 0; i < count; i++)
            {
                if (strings[i] == name)
                {
                    found = ints[i];
                    break;
                }
            }
            return found;
        }

        public bool HasEntry(string name)
        {
            bool found = false;

            for (int i = 0; i < count; i++)
            {
                if (strings[i] == name)
                {
                    found = true;
                    break;
                }
            }
            return found;
        }
    }
}