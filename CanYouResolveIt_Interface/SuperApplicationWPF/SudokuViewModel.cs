using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperApplicationWPF
{
    public class SudokuViewModel
    {
        public string NomApplication { get; set; }

        public ObservableCollection<Grille> GrilleList { get; set; }

        public Grille GrilleSelect { get; set; }
        public SudokuViewModel()
        {
            NomApplication = "Can You Resolve It";
            GrilleList = new ObservableCollection<Grille>();
            GrilleList.Add(new Grille
            {
                Nom = "Grille 1",
                Date = "2015, 06, 17",
                Symboles = "123456789"
            });

            foreach (var grille in GrilleList)
            {
                grille.InitTabCase();
            }
        }

        internal void ListInfoSudoku(List<Grille> grille)
        {
            GrilleList = new ObservableCollection<Grille>();

            foreach (Grille g in grille)
            {
                GrilleList.Add(new Grille
                {
                    Nom = g.Nom,
                    Date = g.Date,
                    Symboles = g.Symboles
                });
            }

        }

    }
}
