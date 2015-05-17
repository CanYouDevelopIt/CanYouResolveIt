using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CanYouResolveIt
{
    class Program
    {
        static void Main(string[] args)
        {
            //C:\Users\Jeremy\Desktop\ESGI\4A AL\C#\Sudoku\Fichier de sudoku résolution (version du 15 04 2015).sud
            //C:\Users\Jeremy\Desktop\ESGI\4A AL\C#\Sudoku\Fichier de sudoku résolution.sud

            bool fichierCorrect = false;
            string cheminFichier;
            string ligne;
            int nbLigneMax = 0;
            int nbLigneGrille = 0;
            SudokuManager monSudokuManager = new SudokuManager();

            while (!fichierCorrect)
            {
                if (args.Length > 0)
                {
                    cheminFichier = args[0];
                    fichierCorrect = true;
                }
                else
                {
                    Console.WriteLine("Veuillez saisir le chemin jusqu'au Sudoku résolu :");
                    //cheminFichier = Console.ReadLine();
                    cheminFichier = "C:\\Users\\Jeremy\\Desktop\\ESGI\\4A AL\\C#\\Sudoku\\Fichier de sudoku résolution (version du 15 04 2015).sud";
                }

                if (File.Exists(cheminFichier))
                {
                    if (Path.GetExtension(cheminFichier) == ".sud")
                    {

                        StreamReader fichier = new StreamReader(cheminFichier);
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

                            if (nbLigneGrille == 2) { g.Nom = ligne; }
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
                                    return;
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
                                string messageErreur = g.verifierGrille();

                                if (messageErreur == "")
                                {
                                    Console.WriteLine(g.Nom + " : Aucune erreur");
                                    monSudokuManager.ajouterSudokuResolu(g);
                                }
                                else
                                {
                                    Console.WriteLine(g.Nom + " contient les erreurs suivantes :");
                                    Console.WriteLine(messageErreur);
                                }
                            }

                        }
                        fichierCorrect = true;
                    }
                    else { Console.WriteLine("L'extension du fichier est incorrecte."); }
                }
                else { Console.WriteLine("Le Sudoku résolu est introuvable."); }
            }
        }
    }
}
