using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace lugares_oficina.src
{
    public class Person(string firstName, string lastName, int dni)
    {
        public StringDictionary personData()
        {
            StringDictionary myDict = new StringDictionary();
            myDict.Add("firstname", firstName);
            myDict.Add("lastname", lastName);
            myDict.Add("dni", dni.ToString());
            return myDict;
        }
    }
}
