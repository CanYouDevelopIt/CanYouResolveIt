using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CanYouResolveIt
{
    class Grille
    {
        private string nom;

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        private string date;

        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        private string symboles;

        public string Symboles
        {
            get { return symboles; }
            set { symboles = value; }
        }

        private Case[][] tab;

        internal Case[][] Tab
        {
            get { return tab; }
            set { tab = value; }
        }

        public string verifierGrille()
        {
            bool[] tabVerification = new bool[symboles.Length];
            String messageErreur = "";
            bool caractereTrouve;

            //Verification par ligne + caracteres 
            for (int i = 0; i < symboles.Length; i++)
            {
                for (int j = 0; j < tabVerification.Length; j++)
                {
                    tabVerification[j] = false;
                }
                for (int j = 0; j < symboles.Length; j++)
                {
                    caractereTrouve = false;
                    for (int k = 0; k < symboles.Length; k++)
                    {
                        if (tab[i][j].Valeur == symboles[k])
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
            for (int i = 0; i < symboles.Length; i++)
            {
                for (int j = 0; j < tabVerification.Length; j++)
                {
                    tabVerification[j] = false;
                }
                for (int j = 0; j < symboles.Length; j++)
                {
                    for (int k = 0; k < symboles.Length; k++)
                    {
                        if (tab[j][i].Valeur == symboles[k])
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
            int longueurBloc = (int)Math.Sqrt(symboles.Length);

            for (int i = 0; i < symboles.Length; i += longueurBloc)
            {
                for (int j = 0; j < symboles.Length; j += longueurBloc) //PAR BLOC
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

                            for (int m = 0; m < symboles.Length; m++)
                            {
                                if (tab[ligne][colonne].Valeur == symboles[m])
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

            return messageErreur;
        }
    }
}
