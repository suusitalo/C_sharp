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
using System.Collections;
using MySql.Data.MySqlClient;
using MySql.Data.Common;
using System.Data;
using System.IO;


/*Loppuprojektin vaatimukset:
* lisää projektiin mySQL connector : Projektin nimen kohdalla oikea nappi - Add reference - Browse tab - C:\Program Files (x86)\MySQL\MySQL Connector Net 6.8.3\Assemblies\v4.0 - OK
* importtaa mySQL kirjastot : using MySql.Data.MySqlClient;
*
- joko mysql tai MS access tietokantaa käyttäen
- projektin tulee sisältää yhteyden koodista kantaan ja kyselyiden käytön monipuolisesti.
	-esim: join, group, suodatuksia, anonyymit luokat/muuttujat, useiden sarakkeiden/taulujen haku
	- taulut saa luoda valmiiksi tietokantaan, mutta myös uusien taulujen ja kenttien luominen, muokkaaminen ja poisto vois olla hyvä
	- mielellään WPF muodossa (GUI)
- Haluatko hakea tietoa olioihin (datan tietorakenne koodissa)
- Ohjelmaa voi pohtia myös laajennettavuuden kannalta: 
	- Tehdäänkö hakutoiminnoista helposti muokattavia (tehdäänkö haku erilliseen luokkaan metodien avulla)
	- kantayhteys yms omiin luokkiinsa
 * 
 * 
 * Tehtäväsi on tehdä tilausten hallintaa varten ohjelma. Tilaustiedot talletetaan tietokantaan. 
 Tee käyttöliittymä mielellään graafisena. 
 Tietokannassa on taulu Tilaukset, joka sisältää tilauksen ID-numeron, tilaajan nimen sekä tuote 
ID:n. ID-numero on perusavain. Pidetään tehtävä hallinnassa siten, että yhdessä tilauksessa voi olla 
vain yksi tuote. 
 * 
 Lisäksi tietokannassa on taulu nimeltä Tuotteet, joka sisältää tuote ID:n sekä sitä vastaavan 
tuotteen nimen. Tämän taulun voi valmiiksi täyttää hallintaohjelmassa erilaisilla tuotteilla. 
Tilaukset ja Tuote –taulujen yhteys on luonnollisesti tuote Id, joten tee sitä varten viiteavain. 
(Halutessasi voit mahdolistaa myös uusien tuotteiden lisäämisen käyttöliittymässä, mutta tämä ei 
ole välttämätöntä). 
 * 
 Käyttöliittymässä käyttäjä voi tehdä uusia tilauksia ja tilauksen tiedot talletetaan aina tietokantaan. 
Voit itse olla luova sen suhteen, millaisen käyttöliittymän ja hallinnan teet. 
 * 
 Lisäksi käyttäjä voi tehdä hakutoimintoja. Voit esim. tehdä tilauksien tietojen hakua tilaajan nimen 
perusteella. 
 * 
 Toiveena on, että tehtävässä käytettäisiin tietokannan muokkaamista sekä hakukomentoja ja lisäksi 
myös JOIN-komentoa taulujen tietojen yhdistämiseen haussa. 
 * 
 Pohdi tehtävänantoa myös siltä kannalta, että ohjelmaa voitaisiin laajentaa tarvittaessa helposti 
Laajentamisella voidaan tarkoittaa vaikkapa uusien toimintojen(tietokantatoimintojen) lisäämistä 
tai uuden tietokannan käyttöönottoa.Voit esim. jakaa loogisesti tomintoja metodeihin ja luokkiin
 * 
 * 
 * 
 * */

namespace Lopputyö
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
           InitializeComponent();
           getProducts();
           getTilaajat();
        }

        private void haeTilauksetButton_Click(object sender, RoutedEventArgs e)
        {
            getOrders();
        }

        private void quitButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            insertOrders();
            
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {

        }
        public void getProducts()
        {
            //Luodaan mysql yhteys
            string sqlCon = "Server=93.174.192.5;Database=xuusitalo;Uid=xuusitalo;Pwd=xuusitalo;";
            MySqlConnection connection = new MySqlConnection(sqlCon);
            connection.Open();

            //Luodaan mysql komento
            string getProducts = @"SELECT TuoteNimi FROM Tuotteet;";

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = getProducts;

            // Luodaan adapteri
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            //Luodaan datasetti ja täytetään se hakutuloksilla
            DataSet dset = new DataSet();
            adapter.Fill(dset, "Tuotteet");

            //Haetaan tulostaulu edelliselle haulle
            DataTable dt = dset.Tables["Tuotteet"];

            //Käydään kaikki rivit läpi tulostaulusta
            foreach (DataRow row in dt.Rows)
            {
                //Käydään läpi kaikki tulosrivin sarakkeet
                foreach (DataColumn column in dt.Columns)
                {
                    //Lisätään rivin sisältä textfieldiin
                    tuotteetComboBox.Items.Add(row[column].ToString());
                }
            }
            //Suljetaan yhteys
            connection.Close();

        }

        public void getTilaajat()
        {
            //tyhjennetään tilaajatCombobox ja lisätään siihen default arvo
            tilaajatComboBox.Items.Clear();
            tilaajatComboBox.Items.Add("Hae kaikki tilaukset");
            tilaajatComboBox.SelectedIndex = 0;
            
            //Luodaan mysql yhteys
            string sqlCon = "Server=93.174.192.5;Database=xuusitalo;Uid=xuusitalo;Pwd=xuusitalo;";
            MySqlConnection connection = new MySqlConnection(sqlCon);
            connection.Open();

            //Luodaan mysql komento
            string getTilaajat = @"SELECT DISTINCT TilaajanNimi FROM Tilaukset;";

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = getTilaajat;

            // Luodaan adapteri
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            //Luodaan datasetti ja täytetään se hakutuloksilla
            DataSet dset = new DataSet();
            adapter.Fill(dset, "Tilaajat");

            //Haetaan tulostaulu edelliselle haulle
            DataTable dt = dset.Tables["Tilaajat"];

            //Käydään kaikki rivit läpi tulostaulusta
            foreach (DataRow row in dt.Rows)
            {
                //Käydään läpi kaikki tulosrivin sarakkeet
                foreach (DataColumn column in dt.Columns)
                {
                    //Lisätään rivin sisältä textfieldiin
                    tilaajatComboBox.Items.Add(row[column].ToString());
                }
            }
            //Suljetaan yhteys
            connection.Close();

        }

        public void getOrders()
        {
            //tyhjennetään tilausnäyttö
            Tuotteet.Clear();
            // laitetaan TextViewiin "otsikot" paikoilleen 
            Tuotteet.AppendText("|  TilausID  |   Tilaajan Nimi   |   Tilattu Tuote | \n" );

            //Luodaan mysql yhteys
            string sqlCon = "Server=93.174.192.5;Database=xuusitalo;Uid=xuusitalo;Pwd=xuusitalo;";
            MySqlConnection connection = new MySqlConnection(sqlCon);
            connection.Open();

            //Luodaan mysql komento
            string haeTilaukset;
            if (tilaajatComboBox.SelectedIndex == 0)
            {
                haeTilaukset = @"SELECT Tilaukset.TilausID, Tilaukset.TilaajanNimi, Tuotteet.TuoteNimi FROM Tilaukset
            INNER JOIN Tuotteet
            ON Tilaukset.TuoteID=Tuotteet.TuoteID ORDER BY Tilaukset.TilausID;";
            }
            else
            {
                haeTilaukset = @"SELECT Tilaukset.TilausID, Tilaukset.TilaajanNimi, Tuotteet.TuoteNimi FROM Tilaukset
            INNER JOIN Tuotteet
            ON Tilaukset.TuoteID=Tuotteet.TuoteID WHERE Tilaukset.TilaajanNimi=@tilaajanNimi ORDER BY Tilaukset.TilausID;";
            }

            string tilaajanNimi = tilaajatComboBox.Text;
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = haeTilaukset;
            command.Parameters.AddWithValue("@tilaajanNimi", tilaajanNimi);


            // Luodaan adapteri
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            //Luodaan datasetti ja täytetään se hakutuloksilla
            DataSet dset = new DataSet();
            adapter.Fill(dset, "Tuotteet");

            //Haetaan tulostaulu edelliselle haulle
            DataTable dt = dset.Tables["Tuotteet"];

            //Käydään kaikki rivit läpi tulostaulusta
            foreach (DataRow row in dt.Rows)
            {

                //Käydään läpi kaikki tulosrivin sarakkeet
                foreach (DataColumn column in dt.Columns)
                {
                    //Lisätään rivin sisältö textfieldiin
                    Tuotteet.AppendText("|  " + row[column].ToString() + "      ");
                }
                Tuotteet.AppendText("\n");
            }
            //Suljetaan yhteys
            connection.Close();
            

        }
        public void insertOrders()
        {
            int largestTilausID = 0;

            //Luodaan mysql yhteys
            string sqlCon = "Server=93.174.192.5;Database=xuusitalo;Uid=xuusitalo;Pwd=xuusitalo;";
            MySqlConnection connection = new MySqlConnection(sqlCon);
            connection.Open();

            //Selvitetään tämänhetken suurin tilausID
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT MAX(TilausID) FROM Tilaukset";

            // Luetaan arvo
            MySqlDataReader reader = command.ExecuteReader();

            //Luodaan datasetti ja täytetään se hakutuloksilla
            while (reader.Read())
            {
                largestTilausID = reader.GetInt32(0);
                largestTilausID++;
            }
            reader.Close();

            //Luodaan mysql komento tilauksen tekemiseen
            MySqlCommand ordercommand = connection.CreateCommand();
            ordercommand.CommandText = "INSERT INTO Tilaukset(TilausID,TilaajanNimi,TuoteID) VALUES (@TilausID,@TilaajanNimi, @TuoteID)";
            ordercommand.Parameters.AddWithValue("@TilausID", largestTilausID);
            string tilaajanNimi = tilaajanNimiTextBox.Text;
            ordercommand.Parameters.AddWithValue("@TilaajanNimi", tilaajanNimi);
            ordercommand.Parameters.AddWithValue("@TuoteID", tuotteetComboBox.SelectedIndex);
            
            MessageBox.Show("Tilaus Lisätty tietokantaan!" );
            
            // Ajetaan käsky
            ordercommand.ExecuteNonQuery();
            
            //Suljetaan yhteys
            connection.Close();

            //päivitetään tilaajien Nimilista ja tilaukset
            getTilaajat();
            if (Tuotteet.Text != "")
            {
                getOrders();
            }
            tuotteetComboBox.SelectedIndex = -1;
            tilaajanNimiTextBox.Text = "";

        }

        
        
    }
}
