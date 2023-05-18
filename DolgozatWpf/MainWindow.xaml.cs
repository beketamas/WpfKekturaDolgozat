using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DolgozatWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Szakasz> lista = new List<Szakasz>();
        public MainWindow()
        {
            InitializeComponent();
            StreamReader str = new StreamReader("kektura.txt");
            while (!str.EndOfStream) 
            {
                lista.Add(new Szakasz(str.ReadLine()));
            }
            dgTablauzat.ItemsSource = lista;

            Szakasz.NehezsegMegadas(lista);
            File.WriteAllLines("utvonal.txt", lista.Select(x => $"{x.Nev};{x.Tavolsag};{x.TengerszintFeletti};{x.Nehezseg}"));
        }

        private void btnSzamlalo_Click(object sender, RoutedEventArgs e)
        {
            lblAllomanySzam.Content = string.Join("", lista.Count());
        }

        private void btnKereses_Click(object sender, RoutedEventArgs e)
        {
            /// <summary>
            /// A datagridben írja ki a túrák leírását
            /// </summary>
            if (tbErtek.Text != null)
            {
                lblEredmeny.Content = $"{lista.Count(x => x.IdoTartam <= int.Parse(tbErtek.Text))} db túrára volt találat";

                var lista2 = lista.Where(x => x.IdoTartam <= int.Parse(tbErtek.Text));

                dgTablauzat.ItemsSource = "";
                dgTablauzat.ItemsSource = lista2;
                dgTablauzat.Items.Refresh();
            }
            else 
            {
                MessageBox.Show("Adjon meg egy értéket a fenti textboxba!");
            }
            
        }

        private void btnGomb_Click(object sender, RoutedEventArgs e)
        {
            lbTeljesitesiAtlag.Content = $"{Math.Round(lista.Where(x => x.Nev.Contains("Pilis")).Average(x => x.IdoTartam))} perc";
        }

        private void btnLeghosszabb_Click(object sender, RoutedEventArgs e)
        {
            var leghosszabbUt = lista.MaxBy(x => x.Tavolsag);
            lblLegosszabb.Content = $"{leghosszabbUt.Nev};{leghosszabbUt.Tavolsag};{leghosszabbUt.IdoTartam}";
        }
    }
}
