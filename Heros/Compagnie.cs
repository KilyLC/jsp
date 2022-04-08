using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerosNamespace
{
    class Compagnie
    {
        private string _nom;
        private List<Heros> _heros;

        const int HEROS_MAX = 3;

        public string Nom { get => _nom; }
        internal List<Heros> Heros { get => _heros; }

        public Compagnie(string nom)
        {
            this._nom = nom;
            _heros = new List<Heros>();
        }
        public Compagnie(string nom, List<Heros> heros)
        {
            this._nom = nom;
            foreach (Heros h in heros)
            {
                AjouterHeros(h);
            }
        }

        public void AjouterHeros(Heros h)
        {
            if (_heros.Count < HEROS_MAX)
            {
                _heros.Add(h);
            }
            else
            {
                throw new Exception("Il n'y plus de place dans la compagnie");
            }
        }
    }
}
