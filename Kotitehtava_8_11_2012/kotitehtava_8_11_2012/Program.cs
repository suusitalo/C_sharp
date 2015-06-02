using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kotitehtava_8_11_2012
{
    class Program
    {
        static void Main(string[] args)
        {
            //Luodaan kirjat
            Kirja tuntematon = new Kirja("tuntematon sotilas"); //ei anneta sivumäärää -> oletuksena sivumäärä 0
            Kirja moukarimies = new Kirja("Sledgehammer", 521);
            Kirja terasmies = new Kirja("Teräsmiehen muistelmat", 254);
            Kirja ruusunen = new Kirja("Prinsessa Ruusunen", 328);

            //tulostetaan kirjan tiedot
            tuntematon.TulostaKirjatiedot();
            moukarimies.TulostaKirjatiedot();
            terasmies.TulostaKirjatiedot();
            ruusunen.TulostaKirjatiedot();
        }
    }
}
