/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Lopputyö
{
    [Serializable()]
    class Tuote : ISerializable
    {
        public string TuotteenNimi { get; set; }
        public int TuoteId { get; set; }

    public Tuote()
    {
    }

    public Tuote(int id, string tuotteennimi)
    {
        this.TuoteId = id;
        this.TuotteenNimi = tuotteennimi;
    }

    public Tuote(SerializationInfo info, StreamingContext context)
    {
        this.TuoteId = (int)info.GetValue("TuoteID", typeof(int));
        this.TuotteenNimi = (string)info.GetValue("TuoteNimi", typeof(string));
       
    }



        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("TuoteID", this.TuoteId);
            info.AddValue("TuoteNimi", this.TuotteenNimi);
            
        
        }
    }
}
*/

