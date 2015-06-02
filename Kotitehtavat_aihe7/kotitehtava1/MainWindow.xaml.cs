using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace kotitehtava1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Tee sovellus, jossa käyttäjältä kysytään kuinka monta lukua hän haluaa, että arvotaan. 
    /// Arvotut luvut talletetaan valitsemaasi koosteeseen ja tulostetaan käyttäjälle 
    /// päinvastaisessa järjestyksessä kuin ne lisättiin. Sovellus voi olla WPF- tai konsolisovellus. 
    /// Esim. seuraavasta linkistä voi katsoa mallia satunnaisluvun luontiin.
    /// http://stackoverflow.com/questions/2706500/how-to-generate-random-int-number-c
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        //Käsittelyt "arvo numerot" napin painamiselle
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            int numbers = 0;
            //Yritetään parsia numberAmount textbox kentästä montako numeroa arvotaan
            try
            {
                numbers = int.Parse(numberAmount.Text);
            }
            //Mikäli ei onnistu (kentässä ei ole numeroa) otetaan kiinni exception ja pompautetaan ruudulle messagebox.
            catch (Exception)
            {
                MessageBox.Show("Sinun täytyy antaa _NUMERO_ !!");
            }

            //Luodaan uusi Randomizer olio jolle annetaan parametrinä arvottavien numeroiden määrä
            //randomizer arpoo luvut int tyypin taulukkoon nimeltään RandomNumbers
            Randomizer randomizer = new Randomizer();
            randomizer.RandomizeNumbers(numbers);

            //Luetaan randomizer olion RandomNumbers taulukosta sinne sijoitetut numerot käänteisessä järjestyksessä ja 
            //Lisätään luvut NumberList tekstikenttään. Aiemmin arvotut luvut jäävät tekstikenttään AppendText metodia 
            //käytettäessä
            for (int i = numbers; i > 0; i--) 
            {
                NumberList.AppendText(randomizer.RandomNumbers[i-1] + " , ");
            }
            NumberList.AppendText("\n");
        }

        //"Lopeta" Napin käsittelyt
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void NumberList_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
