using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kotitehtava_aihe8
{
    class Silta : VerkkoLaite
    {
        private int otsikkodata = 5;

        public int Otsikkodata
        {
            get { return otsikkodata; }
           // set { otsikkodata = value; }
        }

        //AddData metodi overrideaa yläluokan AddData metodin. se ottaa parametrina datamäärän ja lisää siihen oman otsikkodatansa
        public override void AddData(int newData)
        {
            base.AddData(newData+Otsikkodata);
        }
        //AnnaTyyppi metodi overrideaa yläluokan AnnaTyyppi metodin
        public override string AnnaTyyppi()
        {
            return "Silta";
        }
    }
}
