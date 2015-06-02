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

/*
 1. Tee WPF-ohjelma, jolla voidaan luoda järjestelmään uusia CD-levyjä. Käyttöliittymässä voidaan antaa CD:lle seuraavat tiedot:
    Nimi
    Artisti
    Levyn pituus sekunteina
    Genre (vetovalikolla jokin seuraavista: POP, ROCK, JAZZ, TUNTEMATON)

 2. Nappia painamalla tiedoista luodaan CD-tyyppinen olio. Ohjelmaan tulee siis tehdä tätä varten luokka.
 3. Kun CD-olio on luotu, tulostetaan sen avulla CD-tiedot erilliseen moniriviseen tekstikenttään. 
    Tulosta tiedot ja rivinvaihto edellisten tietojen perään ( textfield.AppendText() )
 4. Lisää tekstikenttään scrollbar, jotta tietoja voidaan selata pystysuunnassa.
 5. Tee lopuksi poikkeushallinta, joka käsittelee vääränmuotoisen levyn pituuden (jos pituus ei ole numeromuodossa). 
    Ohjelma tulostaa erilliseen viesti-ikkunaan virheestä eikä tällöin CD-oliota luoda eikä tietoja tulosteta.
*/
namespace kotitehtävä_27_11_2012
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        //Tallennusnapin painalluksen toiminnot
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //Otetaan talteen tekstikentissä ja comboboxissa olevat tiedot
            string levynnimi = textBoxLevynNimi.Text;
            string artisti = textBoxArtisti.Text;
            int levynkesto = 0;
            ComboBoxItem ComboBoxlevynGenre = (ComboBoxItem)comboBoxGenreSelection.SelectedItem;
            string genre = ComboBoxlevynGenre.Content.ToString();
              
            //Yritetään luoda uusi CD-levy ja lisätä sen tiedot textBoxiin. Mikäli levyn pituuskentässä ei ole int tyyppisiä merkkejä,
            //uutta levyä ei luoda vaan hypätään exceptionhandlingiin
            try
            {
                levynkesto = int.Parse(textBoxLevynPituus.Text);
                Levy newCD = new Levy();
                newCD.createDisk(levynnimi, artisti, genre, levynkesto);
                
                textBoxDiscList.AppendText("Albumin nimi: " + newCD.Nimi);
                textBoxDiscList.AppendText("\nArtisti: " + newCD.Artisti);
                textBoxDiscList.AppendText("\nGenre: " + newCD.Genre);
                textBoxDiscList.AppendText("\nAlbumin kesto: " + newCD.kesto + " sekuntia\n\n");

                //Tyhjennetään levyntietojen syöttökentät
                textBoxLevynNimi.Clear();
                textBoxArtisti.Clear();
                textBoxLevynPituus.Clear();
                comboBoxGenreSelection.Text = "";
            }

            //Otetaan exception kiinni jos numerokentässä ei ole int tyyppisiä merkkejä
            catch (FormatException)
            {
                //Näytetään virhenootti
                MessageBox.Show("Levyn keston täytyy olla kokonaisluku!");
                //Valitaan levyn pituus tekstiboksin tekstit valmiiksi jotta käyttäjä saa yrittää uudestaan leyn pituuden syöttämistä
                textBoxLevynPituus.Focus();
                textBoxLevynPituus.SelectAll() ;
            }
                        
            
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

    }
}
