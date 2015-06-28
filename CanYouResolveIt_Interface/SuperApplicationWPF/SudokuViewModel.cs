using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SuperApplicationWPF
{
    public class SudokuViewModel
    {
        public string NomApplication { get; set; }

        public ObservableCollection<Grille> GrilleList { get; set; }

        public Grille GrilleSelect { get; set; }

        public SudokuViewModel()
        {
            NomApplication = "Can You Resolve It ?";
            GrilleList = new ObservableCollection<Grille>();
        }


        public void ListInfoSudoku(List<Grille> grille)
        {
            if (GrilleList.Count > 0) {
                // Suppression de tous les lists de sudokus
                GrilleList.Clear();
            }


            foreach (Grille g in grille)
            {

                Grille uneGrille = new Grille
                {
                    Nom = g.Nom,
                    Date = g.Date,
                    Symboles = g.Symboles,
                    Tab = g.Tab
                };
                GrilleList.Add(uneGrille);
            }

        }

    }
}
