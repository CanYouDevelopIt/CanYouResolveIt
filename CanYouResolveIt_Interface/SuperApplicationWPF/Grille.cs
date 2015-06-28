using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperApplicationWPF
{
    public class Grille
    {
        public string Nom { get; set; }
        public string Date { get; set; }
        public string Symboles { get; set; }
        public int Taille { get { return Symboles.Length; } }

        private Case[][] tab;

        internal Case[][] Tab
        {
            get { return tab; }
            set { tab = value; }
        }


          public string verifierGrille()
        {
            bool[] tabVerification = new bool[Symboles.Length];
            String messageErreur = "";
            bool caractereTrouve;

            //Verification par ligne + caracteres 
            for (int i = 0; i < Symboles.Length; i++)
            {
                for (int j = 0; j < tabVerification.Length; j++)
                {
                    tabVerification[j] = false;
                }
                for (int j = 0; j < Symboles.Length; j++)
                {
                    caractereTrouve = false;
                    for (int k = 0; k < Symboles.Length; k++)
                    {
                        if (tab[i][j].Valeur == Symboles[k])
                        {
                            caractereTrouve = true;
                            if (!tabVerification[k])
                            {
                                tabVerification[k] = true;
                            }
                            else
                            {
                                messageErreur += "- La valeur " + tab[i][j].Valeur + " apparaît plus d'une fois sur la ligne " + i + "\n";
                            }
                        }
                    }
                    if (!caractereTrouve)
                    {
                        messageErreur += "- La valeur '" + tab[i][j].Valeur + "' sur la ligne " + i + " est incorrecte \n";
                    }
                }
            }

            //Verification par colonne
            for (int i = 0; i < Symboles.Length; i++)
            {
                for (int j = 0; j < tabVerification.Length; j++)
                {
                    tabVerification[j] = false;
                }
                for (int j = 0; j < Symboles.Length; j++)
                {
                    for (int k = 0; k < Symboles.Length; k++)
                    {
                        if (tab[j][i].Valeur == Symboles[k])
                        {
                            if (!tabVerification[k])
                            {
                                tabVerification[k] = true;
                            }
                            else
                            {
                                messageErreur += "- La valeur " + tab[j][i].Valeur + " apparaît plus d'une fois sur la colonne " + i + "\n";
                            }
                        }
                    }
                }
            }

            //Vérification par bloc
            int longueurBloc = (int)Math.Sqrt(Symboles.Length);

            for (int i = 0; i < Symboles.Length; i += longueurBloc)
            {
                for (int j = 0; j < Symboles.Length; j += longueurBloc) //PAR BLOC
                {

                    for (int k = 0; k < tabVerification.Length; k++)
                    {
                        tabVerification[k] = false;
                    }

                    for (int k = 0; k < longueurBloc; k++)
                    {
                        int ligne = i + k;
                        for (int l = 0; l < longueurBloc; l++)
                        {
                            int colonne = j + l;

                            for (int m = 0; m < Symboles.Length; m++)
                            {
                                if (tab[ligne][colonne].Valeur == Symboles[m])
                                {
                                    if (!tabVerification[m])
                                    {
                                        tabVerification[m] = true;
                                    }
                                    else
                                    {
                                        messageErreur += "- La valeur " + tab[ligne][colonne].Valeur + " apparaît plus d'une fois sur un bloc " + "\n";
                                    }
                                }
                            }

                        }

                    }

                }
            }

            if (messageErreur.Equals(""))
                return "La Grille est Correcte";

            return messageErreur;
        }

        internal void print()
        {
            Console.WriteLine("-------------------");
            Console.WriteLine(Nom);
            Console.WriteLine(Date);
            Console.WriteLine(Symboles + " | Taille : " + Symboles.Length);
            for (int i = 0; i < Symboles.Length; i++)
            {
                for (int j = 0; j < Symboles.Length; j++)
                {
                    Console.Write(Tab[i][j].Valeur);
                }
                Console.WriteLine("");
            }
        }

        internal bool absentSurLigne(char val, int i)
        {
            for (int j = 0; j < Symboles.Length; j++)
                if (tab[i][j].Valeur == val)
                    return false;
            return true;
        }

        internal bool absentSurColonne(char val, int j)
        {
            for (int i = 0; i < Symboles.Length; i++)
                if (tab[i][j].Valeur == val)
                    return false;
            return true;
        }

        internal bool absentSurBloc(char val, int i, int j)
        {
            int longueurBloc = (int)Math.Sqrt(Symboles.Length);
            int _i = i - (i % longueurBloc);
            int _j = j - (j % longueurBloc);

            for (i = _i; i < _i + longueurBloc; i++)
                for (j = _j; j < _j + longueurBloc; j++)
                    if (tab[i][j].Valeur == val)
                        return false;

            return true;
        }

        internal bool resoudreSudoku(int position)
        {
            if (position == Symboles.Length * Symboles.Length)
                return true;

            int i = position / Symboles.Length;
            int j = position % Symboles.Length;

            if (tab[i][j].Valeur != '.')
                return resoudreSudoku(position + 1);

            for (int k = 0; k < Symboles.Length; k++)
            {
                if (absentSurLigne(Symboles[k], i) && absentSurColonne(Symboles[k], j) && absentSurBloc(Symboles[k], i, j))
                {
                    tab[i][j].Valeur = Symboles[k];
                    if (resoudreSudoku(position + 1))
                        return true;
                }
            }
            tab[i][j].Valeur = '.';

            return false;
        }

    }
}
