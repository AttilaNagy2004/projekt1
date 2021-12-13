using System;
using System.Collections.Generic;
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
using System.IO;

namespace Projekt1
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

        private void ujhozzaad_Click(object sender, RoutedEventArgs e)
        {
            CheckBox kijelolt = new CheckBox();
            kijelolt.Checked += new RoutedEventHandler(feladatbe_Checked);
            kijelolt.Unchecked += new RoutedEventHandler(feladat2_Unchecked);
            kijelolt.Content = szoveg1.Text;
            lista.Items.Add(kijelolt);
            szoveg1.Clear();
        }

        private void feladatbe(object sender, RoutedEventArgs e)
        {

        }

        private void feladatbe_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox feladat1 = (CheckBox)sender;
            feladat1.FontStyle = FontStyles.Italic;
            feladat1.Foreground = Brushes.Gray;
        }

        private void feladat2_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox feladat2 = (CheckBox)sender;
            feladat2.FontStyle = FontStyles.Normal;
            feladat2.Foreground = Brushes.Black;
        }

        private void kijeloltrorol_Click(object sender, RoutedEventArgs e)
        {
            CheckBox feladat2 = (CheckBox)lista.SelectedItem;
            lista.Items.Remove(feladat2);
            kuka.Items.Add(feladat2);
        }

        private void kijeloltvissza_Click(object sender, RoutedEventArgs e)
        {
            CheckBox kukavissza = (CheckBox)kuka.SelectedItem;
            kuka.Items.Remove(kukavissza);
            lista.Items.Add(kukavissza);
        }

        private void kijelolttorolvegleg_Click(object sender, RoutedEventArgs e)
        {
            CheckBox delete = (CheckBox)kuka.SelectedItem;
            kuka.Items.Remove(delete);
        }

        private void MainWindow1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            List<string> checkboxok = new List<string>();
            foreach (CheckBox x in lista.Items)
            {
                int allapot = 0;
                if (x.IsChecked == true)
                    allapot = 1;
                string cbJellemzoje = x.Content.ToString() + ";" + allapot;
                checkboxok.Add(cbJellemzoje);
            }
            File.WriteAllLines("tarolo.txt", checkboxok);

            List<string> checkbox = new List<string>();
            foreach (CheckBox y in kuka.Items)
            {
                int allapot1 = 0;
                if (y.IsChecked == true)
                    allapot1 = 1;
                string cbJellemzoje1 = y.Content.ToString() + ";" + allapot1;
                checkbox.Add(cbJellemzoje1);
            }
            File.WriteAllLines("tarolo1.txt", checkbox);
        }

        private void MainWindow1_Activated(object sender, EventArgs e)
        {
            lista.Items.Clear();
            var be = File.ReadAllLines("tarolo.txt");
            foreach (var x in be)
            {
                CheckBox uj = new CheckBox();
                uj.Content = x.Split(';')[0];
                uj.IsChecked = x.Split(';')[1] == "1" ? true : false;
                lista.Items.Add(uj);
            }

            kuka.Items.Clear();
            var be1 = File.ReadAllLines("tarolo1.txt");
            foreach (var y in be1)
            {
                CheckBox uj1 = new CheckBox();
                uj1.Content = y.Split(';')[0];
                uj1.IsChecked = y.Split(';')[1] == "1" ? true : false;
                kuka.Items.Add(uj1);
            }
        }
    }
}
