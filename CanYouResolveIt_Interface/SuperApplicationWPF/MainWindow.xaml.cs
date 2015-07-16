using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SuperApplicationWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<Grille> grilleChargees = new List<Grille>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = App.ViewModelSudoku;
        }

        private void Chargement_sudoku(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Sudoku files (*.sud, *.sudx) | *.sud; *.sudx;";
            if (openFileDialog.ShowDialog() == true)
            {
                SudokuManager monSudokuManager = new SudokuManager();
                grilleChargees = monSudokuManager.chargementFichier(openFileDialog.FileName);

                App.ViewModelSudoku.ListInfoSudoku(grilleChargees);
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FrontGrille.Children.Clear();
            FrontGrille.RowDefinitions.Clear();
            FrontGrille.ColumnDefinitions.Clear();
            FrontGrille.ShowGridLines = true;

            Grille g = App.ViewModelSudoku.GrilleSelect;
            if (g != null) {
                    for (int i = 0; i < g.Taille; i++) {
                        FrontGrille.RowDefinitions.Add(new RowDefinition());
                        FrontGrille.ColumnDefinitions.Add(new ColumnDefinition());
                    }

                    for(int i=0;i<g.Taille;i++){
                        for (int j = 0; j < g.Taille; j++)
                        {
                            char val = g.Tab[i][j].Valeur;
                            if (val == '.')
                            {
                                Rectangle r = new Rectangle();
                                r.Fill = new SolidColorBrush(Colors.LemonChiffon);
                                r.ToolTip = g.Tab[i][j].Hypotheses;
                                Grid.SetRow(r, i);
                                Grid.SetColumn(r, j);
                                FrontGrille.Children.Add(r);
                            }
                            else{
                            Button tb = new Button();
                            tb.Background = Brushes.Khaki;
                            tb.Click += tb_click;
                            tb.Content = g.Tab[i][j].Valeur.ToString();
                            Grid.SetRow(tb, i);
                            Grid.SetColumn(tb,j);
                            FrontGrille.Children.Add(tb);
                            }
			        }
            }
            }
        }

        private void tb_click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show(sender.ToString());
        }

        private void Resoudre_sudoku(object sender, RoutedEventArgs e)
        {
            Grille g = App.ViewModelSudoku.GrilleSelect;
            if (g.resoudreSudoku(0))
            {
               // MessageBox.Show("Sudoku Résolu");
                refreshGrille(g);
            }

        }

        private void Verifier_sudoku(object sender, RoutedEventArgs e)
        {
            Grille g = App.ViewModelSudoku.GrilleSelect;
            if (g != null)
            { 
                MessageBox.Show(g.verifierGrille());
                refreshGrille(g);
            }
        }

        private void Generer_sudoku(object sender, RoutedEventArgs e)
        {
            SudokuManager monSudokuManager = new SudokuManager();
            Grille g = monSudokuManager.genererSudoku();
            grilleChargees.Add(g);
            App.ViewModelSudoku.ListInfoSudoku(grilleChargees);
        }

        private void refreshGrille(Grille g)
        {
            for (int i = 0; i < g.Taille; i++)
            {
                for (int j = 0; j < g.Taille; j++)
                {
                    char val = g.Tab[i][j].Valeur;
                    if (val == '.')
                    {
                        Rectangle r = new Rectangle();
                        r.Fill = new SolidColorBrush(Colors.LemonChiffon);
                        r.ToolTip = g.Tab[i][j].Hypotheses;
                        Grid.SetRow(r, i);
                        Grid.SetColumn(r, j);
                        FrontGrille.Children.Add(r);
                    }
                    else
                    {
                        Button tb = new Button();
                        tb.Background = Brushes.Khaki;
                        tb.Click += tb_click;
                        tb.Content = g.Tab[i][j].Valeur.ToString();
                        Grid.SetRow(tb, i);
                        Grid.SetColumn(tb, j);
                        FrontGrille.Children.Add(tb);
                    }
                }
            }
        }

    }
}
