using System;
using System.Collections.Generic;
using System.Text;

namespace ObjClassTesting
{
    public class Ingredient
    {
        public string name;
        public string[] props = new string[2];

        public Ingredient(string name, string prop1, string prop2)
        {
            this.name = name;
            this.props = new string[] { prop1, prop2 };
        }
    }
}
