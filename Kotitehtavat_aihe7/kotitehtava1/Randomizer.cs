using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kotitehtava1
{
    class Randomizer
    {
        //Luodaan private taulukko randomNumbers
        private int[] randomNumbers;

        //Taulukon getterit ja setterit
        public int[] RandomNumbers
        {
            get { return randomNumbers; }
            set { randomNumbers = value; }
        }
        
        
    //´Randomizer luokan metodi, joka ottaa parametrina arvottavien numeroiden lukumäärän
    public void RandomizeNumbers(int numbers){
        
        //Luodaan RandomNumbers taulukko jonka koko on parametrina saatujen lukujen määrä
        RandomNumbers = new int[numbers];

        //Luodaan uusi Random olio. TÄmän on pakko olla for-loopin ulkopuolella koska muuten 
        //arvonnan tuloksena on joka kerta sama luku.
        Random random = new Random();

        for (int i = 0; i < RandomNumbers.Length; i++)
        {
            //Arvotaan luku väliltä 0-1000
            int randomNumber = random.Next(1000);
            RandomNumbers[i] = randomNumber;
            
        }
        
    
    }
    }
}
