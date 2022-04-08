using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace HerosNamespace
{
    class Compagnie
    {
        private string _nom;
        private List<Heros> _heros;
        private Image _arriere_plan = null;

        const int HEROS_MAX = 3;

        public string Nom { get => _nom; }
        internal List<Heros> Heros { get => _heros; }
        public Image ArrierePlan { get => _arriere_plan; }

        public Compagnie(string nom)
        {
            this._nom = nom;
            _heros = new List<Heros>();
        }
        public Compagnie(string nom, List<Heros> heros) : this(nom)
        {
            this._nom = nom;
            foreach (Heros h in heros)
            {
                AjouterHeros(h);
            }
        }

        public Compagnie(string nom, List<Heros> heros, Image arriere_plan) : this(nom, heros)
        {
            DefinirArrierePlan(arriere_plan);
        }

        public void DefinirArrierePlan(Image img)
        {
            this._arriere_plan = img;
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
