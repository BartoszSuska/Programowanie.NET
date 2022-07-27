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
using System.Windows.Shapes;

namespace zad3 {
    /// <summary>
    /// Logika interakcji dla klasy szczegoly.xaml
    /// </summary>
    public partial class szczegoly : Window {

        Film film;
        public szczegoly(Film film) {
            this.film = film;
            DataContext = film;
            InitializeComponent();
        }

        private void Zamknij(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}
