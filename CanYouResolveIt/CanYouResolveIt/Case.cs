using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CanYouResolveIt
{
    class Case
    {
        private char valeur;

        public char Valeur
        {
            get { return valeur; }
            set { valeur = value; }
        }

        private int nbre_hypotheses;

        public int Nbre_hypotheses
        {
            get { return nbre_hypotheses; }
            set { nbre_hypotheses = value; }
        }

        private List<char> hypotheses;

        public List<char> Hypotheses
        {
            get { return hypotheses; }
            set { hypotheses = value; }
        }

        public Case(char _valeur, int _nbr_hypotheses)
        {
            valeur = _valeur;
            nbre_hypotheses = _nbr_hypotheses;
            hypotheses = new List<char>();
        }

        public void ajouterHypothese(char _hypothese)
        {
            hypotheses.Add(_hypothese);
        }

    }
}
