using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kotitehtävä_27_11_2012
{
    class Levy
    {
        public string Nimi;
        public string Artisti;
        public string Genre;
        public int kesto = 0;

        public void createDisk(string Nimi, string Artisti, string Genre, int kesto){
            this.Nimi = Nimi;
            this.Artisti = Artisti;
            this.Genre = Genre;
            this.kesto = kesto;
                        
        }

    }
}
