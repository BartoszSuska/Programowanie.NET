using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad3 {
    class Model {
        public LinkedList<Film> Lista { get; set; } = new LinkedList<Film>(new Film[] {
            new Film() {
                Tytul = "Zielona Mila",
                Rezyser = "Frank Darabont",
                Studio = "Castle Rock Entertainment",
                Nosnik = "DVD",
                DataWydania = DateTime.Parse("24.03.2000")
            },
            new Film() {
                Tytul = "Forrest Gump",
                Rezyser = "Robert Zemeckis",
                Studio = "Paramount Pictures",
                Nosnik = "Blu-ray",
                DataWydania = DateTime.Parse("4.11.1994")
            },
            new Film() {
                Tytul = "Filadelfia",
                Rezyser = "Jonathan Demme",
                Studio = "TriStar Pictures",
                Nosnik = "DVD",
                DataWydania = DateTime.Parse("31.12.1993")
            },
        });

        internal void OtwórzSzczegóły(Film wybrany) {
            szczegoly szczegóły = new szczegoly(wybrany);
            szczegóły.Show();
        }
        internal void DodajNowy() {
            Film nowa = new Film();
            Lista.AddLast(nowa);
            szczegoly szczegóły = new szczegoly(nowa);
            szczegóły.Show();
            /*aktualizowanie widoku samej listy*/
        }
    }
}
