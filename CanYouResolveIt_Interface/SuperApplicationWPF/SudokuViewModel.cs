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


        public void ListInfoSudoku(List<Grille> grille)
        {
            foreach (Grille g in grille)
            {
                MessageBox.Show(g.Nom);
                MessageBox.Show(g.Date);
                MessageBox.Show(g.Symboles); 

                Grille uneGrille = new Grille
                {
                    Nom = g.Nom,
                    Date = g.Date,
                    Symboles = g.Symboles
                };
                GrilleList.Add(uneGrille);
            }

            foreach (var g in GrilleList)
            {
                g.InitTabCase();
            }

        }

    }
}
