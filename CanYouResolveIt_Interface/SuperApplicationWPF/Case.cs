using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperApplicationWPF
{
    public class Case
    {
        private string Symboles;

        public char Valeur { get; set; }

        private List<char> hypotheses;
        public List<char> Hypotheses
        {
            get { return hypotheses; }
            set { hypotheses = value; }
        }

        private int nbre_hypotheses;
        public int Nbre_hypotheses
        {
            get { return nbre_hypotheses; }
            set { nbre_hypotheses = value; }
        }

        public Case() {
        }

        public Case(char p, string Symboles)
        {
            this.Valeur = p;
            this.Symboles = Symboles;
        }

        public Case(char _valeur, int _nbr_hypotheses)
        {
            Valeur = _valeur;
            nbre_hypotheses = _nbr_hypotheses;
            hypotheses = new List<char>();
        }

        public void ajouterHypothese(char _hypothese)
        {
            hypotheses.Add(_hypothese);
        }
    }
}
