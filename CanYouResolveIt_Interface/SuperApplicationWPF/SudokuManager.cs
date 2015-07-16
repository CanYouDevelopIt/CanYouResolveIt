using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace SuperApplicationWPF
{
    class SudokuManager
    {
        private List<Grille> sudokuResolus;
        private List<Grille> sudokuAResoudre;

        internal List<Grille> SudokuResolus
        {
            get { return sudokuResolus; }
            set { sudokuResolus = value; }
        }

        public SudokuManager()
        {
            sudokuResolus = new List<Grille>();
            sudokuAResoudre = new List<Grille>();
        }

        internal void ajouterSudokuResolu(Grille g)
        {
            sudokuResolus.Add(g);
        }

        internal List<Grille> chargementFichier(string cheminFichier)
        {
            List<Grille> grillesChargees = new List<Grille>();

            StreamReader fichier = new StreamReader(cheminFichier);
            string ligne;
            int nbLigneMax = 0;
            int nbLigneGrille = 0;
            Grille g = null;
            int i = 0;

            while ((ligne = fichier.ReadLine()) != null)
            {

                if (ligne.Contains("--------------"))
                {
                    nbLigneMax = 0;
                    nbLigneGrille = 1;
                    i = 0;
                    g = new Grille();
                }
                else { nbLigneGrille++; }

                if (nbLigneGrille == 2) { g.Nom = ligne;  }
                if (nbLigneGrille == 3) { g.Date = ligne; }

                if (nbLigneGrille == 4)
                {
                    g.Symboles = ligne;


                    g.Tab = new Case[g.Symboles.Length][];


                    nbLigneMax = 4 + g.Symboles.Length;
                }

                if (nbLigneGrille > 4)
                {
                    if (ligne.Length != g.Symboles.Length)
                    {
                        Console.WriteLine("Le format du fichier est incorrect.");
                        return null;
                    }

                    g.Tab[i] = new Case[g.Symboles.Length];

                    for (int j = 0; j < g.Symboles.Length; j++)
                    {
                        String valeur = ligne.Substring(j, 1);
                        Case c = new Case(valeur[0], 1);
                        c.ajouterHypothese(valeur[0]);

                        g.Tab[i][j] = c;
                    }
                    i++;

                }

                if (nbLigneGrille == nbLigneMax)
                {
                    grillesChargees.Add(g);
                }

            }

            return grillesChargees;
        }

        internal void ajouterSudokuAResoudre(Grille g)
        {
            sudokuAResoudre.Add(g);
        }

        internal Grille genererSudoku()
        {

            Grille g = null;

            g = new Grille();
            g.Nom = "Sudoku Généré";
            //g.Date = new DateTime();
            g.Symboles = "123456789";

            Random rand = new Random();

            int nbCasesVides = 0;

            g.Tab = new Case[g.Symboles.Length][];
            for (int i = 0; i < g.Symboles.Length; i++)
            {
                g.Tab[i] = new Case[g.Symboles.Length];
                for (int j = 0; j < g.Symboles.Length; j++)
                {
                    g.Tab[i][j] = new Case('.', g.Symboles);
                }
            }

            g.resoudreSudoku(0);

            while (nbCasesVides < rand.Next(40, 60))
            {
                int x = rand.Next(0, g.Symboles.Length);
                int j = rand.Next(0, g.Symboles.Length);

                if(g.Tab[x][j].Valeur != '.'){
                    g.Tab[x][j].Valeur = '.';
                    nbCasesVides++;
                }

            }

            sudokuAResoudre.Add(g);
            return g;
        }

    }
}
