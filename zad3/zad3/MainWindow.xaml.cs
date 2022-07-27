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

namespace zad3 {
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        Model model = new Model();
        public MainWindow() {
            InitializeComponent();
            DataContext = model;
        }

        private void Szczegóły(object sender, RoutedEventArgs e) {
            FrameworkElement parent = (FrameworkElement)((FrameworkElement)sender).Parent;
            ListBox lista = (ListBox)parent.FindName("ListaDoWybrania");
            Film wybrany = (Film)lista.SelectedItem;
            if (wybrany != null)
                model.OtwórzSzczegóły(wybrany);
        }
        private void DodajNowy(object sender, RoutedEventArgs e) {
            model.DodajNowy();
        }
    }
}
