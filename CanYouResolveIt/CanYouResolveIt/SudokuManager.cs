using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CanYouResolveIt
{
    class SudokuManager
    {

        private List<Grille> sudokuResolus;

        internal List<Grille> SudokuResolus
        {
            get { return sudokuResolus; }
            set { sudokuResolus = value; }
        }

        public SudokuManager()
        {
            sudokuResolus = new List<Grille>();
        }

        internal void ajouterSudokuResolu(Grille g)
        {
            sudokuResolus.Add(g);
        }

    }
}
