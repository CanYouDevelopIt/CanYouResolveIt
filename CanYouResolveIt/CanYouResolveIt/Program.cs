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
            
            string cheminFichier;
            SudokuManager monSudokuManager = new SudokuManager();
            List<Grille> grilleChargees = null;

                if (args.Length > 0)
                {
                    cheminFichier = args[0];
                }
                else
                {
                    Console.WriteLine("Veuillez saisir le chemin jusqu'au Sudoku à résoudre :");
                    //cheminFichier = Console.ReadLine();
                    cheminFichier = "C:\\Users\\Jeremy\\Desktop\\ESGI\\4A AL\\C#\\Sudoku\\resoudreSudokuOne.sud";
                }

                if (File.Exists(cheminFichier))
                {
                    if (Path.GetExtension(cheminFichier) == ".sud")
                    {
                        grilleChargees = monSudokuManager.chargementFichier(cheminFichier);

                        foreach (Grille g in grilleChargees)
                        {
                            g.print();
                            g.resoudreSudoku(0);
                            g.print();

                            string messageErreur = g.verifierGrille();
                            //if (messageErreur != "")
                            //{
                            //    Console.WriteLine(messageErreur);
                            //}

                        }

                    }
                    else { Console.WriteLine("L'extension du fichier est incorrecte."); }
                }
                else { Console.WriteLine("Le Sudoku résolu est introuvable."); }
      
        }
    }
}
