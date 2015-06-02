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
using System.Threading;

namespace kotitehtava_14_3_2013
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

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            /** Karvalakkimallin ratkaisu
            * new Thread(() => updateLabel1()).Start();
            * new Thread(() => updateLabel2()).Start();
            * new Thread(() => updateLabel3()).Start();
            **/

            /* Fiksumpi ratkaisu joka säästää koodia huomattavasti koska selvitään yhdellä metodilla
             * Luodaan 3 threadia eri parametreillä käyttäen tuota yhtä updateLabels-metodia
             * */
            new Thread(() => updateLabels(1,10,2000,label1)).Start();
            new Thread(() => updateLabels(20, 40, 1000, label2)).Start();
            new Thread(() => updateLabels(50, 90, 500, label3)).Start();
        }

        // metodi joka ottaa vastaan parametreinä lähtönumeron, loppunumeron, sleep ajan, sekä muutettavan labelin 
        // ja päivittää sen saamiensa parametrien mukaan
        private void updateLabels(int from, int to, int sleep, Label label)
        {
            for (int i = from; i <= to; i++)
            {
                label.Dispatcher.Invoke(new Action(() => label.Content = i));
                Thread.Sleep(sleep);
            }
        }

        /*
         * Karvalakkimallinen ratkaisu
         * 
        private void updateLabel1()
        {
            for (int i = 1; i <= 10; i++)
            {
                label1.Dispatcher.Invoke(new Action(() => label1.Content = i));
                Thread.Sleep(2000);
            }
        }
        private void updateLabel2()
        {
            for (int i = 20; i <= 40; i++)
            {
                label2.Dispatcher.Invoke(new Action(() => label2.Content = i));
                Thread.Sleep(1000);
            }
        }
        private void updateLabel3()
        {
            for (int i = 50; i <= 90; i++)
            {
                label3.Dispatcher.Invoke(new Action(() => label3.Content = i));
                Thread.Sleep(500);
            }
        } */
    }
}
