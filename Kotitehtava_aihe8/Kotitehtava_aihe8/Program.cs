using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kotitehtava_aihe8
{
    class Program
    {
        static void Main(string[] args)
        {
            Reititin R1 = new Reititin();
            Toistin T1 = new Toistin();
            Silta S1 = new Silta();
            R1.AddData(200);
            R1.AddData(200);
            T1.AddData(200);
            S1.AddData(200);
                         
            Console.WriteLine(R1.AnnaTyyppi()+":" +R1.Data + "kbit");
            Console.WriteLine(T1.AnnaTyyppi() + ":" + T1.Data + "kbit");
            Console.WriteLine(S1.AnnaTyyppi() + ":" + S1.Data + "kbit");
            
        }
    }
}
/**
 * Järjestelmässä on rajapinta Laite. Laitteiden tulee toteuttaa metodi AnnaTyyppi, joka palauttaa
laitteen tyypin tekstinä.
 * 
o Järjestelmässä on Laite-rajapinnan toteuttava Verkkolaite, jolla on kenttä data(kbit).Luokassa on 
myös metodi AddData.Oletuksena tämä metodi vain lisää verkkolaitteen dataa annetulla määrällä. 
Metodi on virtuaalinen.

o Lisäksi Verkkolaite toteuttaa pakollisen AnnaTyyppi-metodin palauttamalla  ”Verkkolaite”. 
Verkkolaite sallii myös aliluokkien ylikirjoittaa metodin(virtuaalinen).
 
o Verkkolaitetta ei voida luoda suoraan, vaan laitteen tulee olla aina jokin seuraavista  Reititin, 
Toistin, Silta

o Kukin laite ylikirjoittaa metodin AddData. Laite lisää parametrina saamaansa dataan otsikkodatan 
ja välittää sitten päivitetyn datan yläluokan metodille (base.AddData).  Kullakin laitteella on oma 
otsikkodatansa:
o Reititin: 145kbit
o Toistin: 25kbit
o Silta: 5kbit
o Verkkolaite-luokalla tulee olla myös get-ominaisuuden Otsikko määritys. Kukin laite toteuttaa sen 
omalla tavallaan palauttaen oman otsikkodatansa arvon
 * */
