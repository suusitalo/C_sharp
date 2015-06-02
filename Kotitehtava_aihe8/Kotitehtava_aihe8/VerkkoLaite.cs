using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kotitehtava_aihe8
{
    //interface Laite jonka Verkkolaite ja sitäkautta kaikki luokat aliluokat toteuttaa
    interface ILaite
    {
        string AnnaTyyppi();
    }

    //Verkkolaite luokka joka toteuttaa ILaite interfacen. Verkkolaite luokka on abstract jotta siitä ei sellaisenaan voi luoda oliota
    abstract class VerkkoLaite : ILaite
    {
        private int data = 0;
        private string otsikko;

        public string Otsikko
        {
            get { return otsikko; }
           // set { otsikko = value; }
        }

        public int Data
        {
            get { return data; }
            set { data = value; }
        }
      
      
        public virtual void AddData(int newData)
        {
            Data += newData;
           
        }

        public virtual string AnnaTyyppi()
        {
            return "Verkkolaite";
        }

        

    }
}
