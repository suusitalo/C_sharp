using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/* DISCLAIMER: En ole varma ymmärsinkö tehtävänannon oikein, mutta näillä mennään */

namespace kotitehtava_8_11_2012
{
    class Kirja
    {
        private int tunniste = 0; //Kirjan oma tunniste
        private static int id = 0; //Staattinen muuttuja josta kirjakohtainen tunniste otetaan kirjaa luotaessa
        private string nimi; 
        private int sivumaara = 0;
        
        //Tunniste ainoastaan luettava arvo
        public int Tunniste
        {
            get { return tunniste; }
            
        }

        //Staattisen id muuttujan getteri ja setteri
        public static int Id
        {
          get { return id; }
          set { id = value; }
          
        }
                
        public string Nimi
        {
          get { return nimi; }
          set { nimi = value; }
        }
        
        public int Sivumaara
        {
          get { return sivumaara; }
          set { sivumaara = value; }
        }
    
        //Kirjan konstruktori jolle riittää pelkkä kirjan nimi. Laittaa sivumääräksi oletuksen 0. Ketjutettu seuraavaan konstruktoriin
    public Kirja(string nimi):this(nimi,0){
        
    }
        //Kirjan konstruktori jolle riittää kirjan nimi ja sivumäärä. Ketjutettu seuraavaan konstruktoriin
    public Kirja(string nimi, int sivumaara): this(id, nimi, sivumaara)
    {

    }
        //Kirjan konstruktori jonne aiemmat konstruktorit päätyvät. Luo itse kirjan johon ottaa tunnisteen staattisesta id muuttujasta ja kasvattaa id:tä yhdellä.
    public Kirja(int tunniste, string nimi, int sivumaara){
        this.tunniste = id;
        this.nimi = nimi;
        this.sivumaara = sivumaara;
        Id++;
    
    }

        //Kirjan tietojen tulostusmetodi
    public void TulostaKirjatiedot() {
        Console.WriteLine("Kirjan tunniste: " +Tunniste +  ", Kirjan nimi: " +Nimi +", Sivumäärä: " + Sivumaara );
    }
    }
}
