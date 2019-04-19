using BusinessLogicLibrary.AlgoritmRatings;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLibrary
{
    public class Rating : IRating
    {
        int cat1;
        int cat2;
        int ples;
        int arro;
        int domi;

        public int Category1 => cat1;

        public int Category2 => cat2;

        public bool IABIsDivergent
        {
            get;
            set;
        }

        public int Pleasure => ples;

        public int Arrousel => arro;

        public int Dominance => domi;

        public bool PADIsDivergent
        {
            get;
            set;
        }

        public void setAll(int Cat1, int Cat2, int Ples, int Arro, int Domi)
        {
            this.cat1 = Cat1;
            this.cat2 = Cat2;
            this.ples = Ples;
            this.arro = Arro;
            this.domi = Domi;
                
        }
    }
}
