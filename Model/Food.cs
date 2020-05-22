using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOwnApi.Model
{
    public class Food
    {
        public string label { get; set; }
        public Nutrients nutrients { get; set; }
        public void Round()
        {
            nutrients.Round();
        }
    }
}
