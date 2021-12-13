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
            if (System.IO.File.Exists("text.txt"))
            {
                string xaml = System.IO.File.ReadAllText("text.txt");
                object content = System.Windows.Markup.XamlReader.Parse(xaml);
                this.Content = content;
            }
    }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            string xaml = System.Windows.Markup.XamlWriter.Save(this.Content);
            System.IO.File.WriteAllText("text.txt", xaml);
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

    }
}
