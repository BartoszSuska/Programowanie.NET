using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NET_INIS4_PR2._2_z2
{
    public class Dane : INotifyPropertyChanged
    {
        bool
            flagaUłamka = false,
            flagaPrzecinka = false,
            flagaWyniku = false,
            flagaUjemnegoZnaku = false
            ;
        double wynik = 0;
        string poprzednie;
        double?
            pierwsza = null,
            druga = null
            ;
        string działanie = null;
        public string Wynik
        {
            get { 
                if(flagaUjemnegoZnaku && wynik == 0)
                    return "-" + Convert.ToString(wynik);
                else
                    return Convert.ToString(wynik);
            }
            set
            {
                wynik = Convert.ToDouble(value);
                OnPropertyChanged();
            }
        }

        public string Poprzednie {
            get {
                return poprzednie;
            }
            set {
                poprzednie = value;
                OnPropertyChanged();
            }
        }

        public void Dopisz(string znak)
        {
            if (flagaWyniku)
                Zeruj();
            if (znak == ",")
                if (flagaUłamka)
                    ;
                else
                    flagaPrzecinka = true;
            else if (flagaPrzecinka)
            {
                Wynik += "," + znak;
                flagaPrzecinka = false;
                flagaUłamka = true;
            }
            else
                Wynik += znak;
        }
        public void ZmieńZnak()
        {
            if (flagaWyniku)
                Zeruj();
            flagaUjemnegoZnaku = !flagaUjemnegoZnaku;
            Wynik = Convert.ToString(-wynik);
        }
        public void Zeruj()
        {
            flagaPrzecinka = flagaPrzecinka = flagaWyniku = flagaUjemnegoZnaku = false;
            druga = null;
            Wynik = "0";
        }
        public void Resetuj()
        {
            Zeruj();
            pierwsza = null;
            działanie = null;
        }
        public void Działanie(string działanie)
        {
            if (pierwsza == null)
            {
                pierwsza = wynik;
                this.działanie = działanie;
                if (działanie == "sqrt") {
                    Poprzednie = pierwsza.ToString() + " " + działanie;
                    Wynik = Convert.ToString(Math.Sqrt(pierwsza.Value));
                    flagaWyniku = true;
                    flagaUłamka = false;
                }
                else if (działanie == "!") {
                    Poprzednie = pierwsza.ToString() + "" + działanie;
                    Wynik = Convert.ToString(Silnia(pierwsza.Value));
                    flagaWyniku = true;
                    flagaUłamka = false;
                }
                else if (działanie == "log") {
                    Poprzednie = działanie + "" + pierwsza.ToString();
                    Wynik = Convert.ToString(Math.Log10(pierwsza.Value));
                    flagaWyniku = true;
                    flagaUłamka = false;
                }
                else if (działanie == "1/x") {
                    Poprzednie = działanie + " " + pierwsza.ToString();
                    Wynik = Convert.ToString(1 / pierwsza);
                    flagaWyniku = true;
                    flagaUłamka = false;
                }
                else if (działanie == "R+") {
                    Poprzednie = działanie + " " + pierwsza.ToString();
                    Wynik = Convert.ToString(Math.Ceiling(pierwsza.Value));
                    flagaWyniku = true;
                    flagaUłamka = false;
                }
                else if (działanie == "R-") {
                    Poprzednie = działanie + " " + pierwsza.ToString();
                    Wynik = Convert.ToString(Math.Floor(pierwsza.Value));
                    flagaWyniku = true;
                    flagaUłamka = false;
                }
                else {
                    Zeruj();
                }
            }
            else
            {
                druga = wynik;
                Wykonaj();
                this.działanie = działanie;
            }

            flagaUłamka = false;
        }
        public void Wykonaj()
        {

            if (działanie == null)
                return;
            else if (druga == null)
                druga = wynik;

            if (działanie == "+")
                Wynik = Convert.ToString(pierwsza + druga);
            else if (działanie == "-")
                Wynik = Convert.ToString(pierwsza - druga);
            else if (działanie == "*")
                Wynik = Convert.ToString(pierwsza * druga);
            else if (działanie == "/")
                Wynik = Convert.ToString(pierwsza / druga);
            else if (działanie == "^")
                Wynik = Convert.ToString(Math.Pow(pierwsza.Value, druga.Value));
            else if (działanie == "/%")
                Wynik = Convert.ToString(pierwsza % druga);
            else if (działanie == "%")
                Wynik = Convert.ToString(pierwsza / 100 * druga);

            flagaWyniku = true;
            flagaUłamka = false;
            Poprzednie = pierwsza.ToString() + " " + działanie.ToString() + " " + druga.ToString();

            pierwsza = wynik;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        protected double Silnia(double n) {
            n = Math.Round(n);
            if (n > 1) {
                return Silnia(n - 1) * n;
            }
            else {
                return 1;
            }
        }
    }
}
