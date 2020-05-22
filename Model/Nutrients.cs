using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOwnApi.Model
{
    public class Nutrients
    {
        public double ENERC_KCAL { get; set; }
        public double PROCNT { get; set; }
        public double FAT { get; set; }
        public double CHOCDF { get; set; }
        public void Round()
        {
            ENERC_KCAL = Math.Round(ENERC_KCAL, 3);
            PROCNT = Math.Round(PROCNT, 3);
            FAT = Math.Round(FAT, 3);
            CHOCDF = Math.Round(CHOCDF, 3);
        }
    }
}
    