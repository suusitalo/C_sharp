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

namespace Kotitehtava2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /*Tee WPF-sovellus, jossa voidaan lisätä tietylle käyttäjälle nimen perusteella lottorivejä. 
    Sovelluksessa voidaan myös milloin tahansa tulostaa nimen perusteella käyttäjän lottorivit. 
    Käytä tietojen talletukseen koosteita
 
    Vinkki: Dictionaryyn voidaan tallettaa myös avaimella lista arvoja:
    Dictionary<string, List<string>> lottorivit 
    */

    /// </summary>
    public partial class MainWindow : Window
    {
        NumberStorage numberStorage = new NumberStorage();
               
        public MainWindow()
        {
            InitializeComponent();
        }

        //Rivin lisäysnapin käsittelyt
        private void buttonLisaaRivi_Click(object sender, RoutedEventArgs e)
        {
            //tarkistetaan ettei nimikenttä tai annettu rivikenttä ole tyhjiä.  
            if (textBoxNimiLisaa.Text != "" && textBoxLottorivi.Text != "" )
            {
                string nimi = textBoxNimiLisaa.Text;
                string lottorivi = textBoxLottorivi.Text;
              
                //Tyhjennetään annettu lottorivi jotta tuplaklikkauksella sama rivi ei tallentuisi kahdesti
                textBoxLottorivi.Clear();
                numberStorage.LisaaRivi(nimi,lottorivi);
            }
            else
            {
                MessageBox.Show("Nimi eikä lottorivi kentät eivät saa olla tyhjiä!");
            }
        }

        //Lottorivin tulostusnapin käsittelyt
        private void buttonTulostaRivit_Click(object sender, RoutedEventArgs e)
        {
            //tarkistetaan ettei haettavan nimen kenttä ole tyhjä
            if (textBoxNimiNouda.Text != "")
            {
                string nimi = textBoxNimiNouda.Text;
                List<string> haettuRivi = numberStorage.NoudaRivit(nimi);

                //tyhjennetään edelliset noudetut rivit tekstikentästä
                textBoxTulostetutRivit.Clear();
                
                foreach (string key in haettuRivi)
                {
                    textBoxTulostetutRivit.AppendText(key + "\n");
                }             
                
            }
            else
            {
                MessageBox.Show("Noudettava nimi ei voi olla tyhjä!");
            }
        }
        
    }
}
