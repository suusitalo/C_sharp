using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kotitehtava2
{

    public class NumberStorage
    {
        //Luodaan private Dictionary lottorivit jonne eri käyttjäjien lottorivit talletetaan
        private Dictionary<string, List<string>> lottorivit = new Dictionary<string, List<string>>();

        //Dictionaryn setterit ja getterit
        public Dictionary<string, List<string>> Lottorivit
        {
            get { return lottorivit; }
            set { lottorivit = value; }
        }

        // Uuden lottorivin lisäämismetodi, ottaa parametrinä nimen ja rivin numeroita        
        public void LisaaRivi(string nimi, string lottonumerot)
        {
            // tarkistetaan onko Dictionaryssä jo olemassa annetulla nimellä olevan henkilön lottorivejä. 
            // ´Mikäli ei ole, luodaan uusi nimi + numerolista pari. Mikäli on, lisätään olemassaolevaan nimi-keyn kohdalle
            // uusi lottorivi
            if (!Lottorivit.ContainsKey(nimi))
            {
                Lottorivit.Add(nimi, new List<string>());
            }
            Lottorivit[nimi].Add(lottonumerot);  //Ei tarvita elseä, koska tämä rivi suoritetaan jokatapauksessa
        }

        // Lottorivien hakemismetodi, ottaa parametrinä nimen, ja lisää kyseisen käyttäjän kaikki lottorivit List<string>:iin 
        // Tuo lista palautetaan Pääikkunaan ja siellä päivitetään TextBoxiin. Mikäli haettavaa 
        // nimeä ei löydy, tulostaa tekstikenttään "nimeä ei löydy". 
        public List<string> NoudaRivit(string nimi)
        {
                List<string> rivit = new List<string>();
                
                //tarkistetaan löytyykö kyseistä nimeä Dictionarystä
                if (Lottorivit.ContainsKey(nimi))
                {   
                    foreach (string key in Lottorivit[nimi])
                    {
                        rivit.Add(key);
                    }
                }
                else
                {
                    rivit.Add("Nimeä ei löydy");

                }return rivit;
            }
        }
    }


