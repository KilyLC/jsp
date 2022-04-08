using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerosNamespace
{
    class Heros
    {
        private string _nom;
        private Tenue _tenue = null;
        private List<Tenue> _tenuesPossibles;
        private Arme _arme1 = null;
        private Arme _arme2 = null;
        private int _niveauVie;
        private int _attaque;
        private int _vitesse;
        private Compagnie _compagnie = null;
        private Arme _armeCourante = null;

        private int _indexTenue = 0;

        public Heros(string nom, List<Tenue> tenuesPossibles, Tenue tenue, Arme arme1, Arme arme2, int niveauVie, int attaque, int vitesse, Compagnie compagnie)
        {
            this._nom = nom;
            this._tenuesPossibles = tenuesPossibles;
            DefinirTenue(tenue);
            DefinirArme1(arme1);
            DefinirArme2(arme2);
            this._niveauVie = niveauVie;
            this._attaque = attaque;
            this._vitesse = vitesse;
        }

        public string Nom { get => _nom; }
        internal Tenue Tenue { get => _tenue; }
        internal Arme Arme1 { get => _arme1; }
        internal Arme Arme2 { get => _arme2; }
        public int NiveauVie { get => _niveauVie;}
        public int Attaque { get => _attaque; }
        public int Vitesse { get => _vitesse; }
        internal Compagnie Compagnie { get => _compagnie;  }
        internal List<Tenue> TenuesPossibles { get => _tenuesPossibles; }
        internal Arme ArmeCourante { get => _armeCourante; }

        public void DefinirArme1(Arme a)
        {
            if (a != null && this._arme2 != null && this._arme2.NombreMains == 2) throw new Exception("Vous n'avez pas de main libre");
            this._arme1 = a;
            this._armeCourante = a;
        }

        public void DefinirArme2(Arme a)
        {
            if (a != null && this._arme1 != null && this._arme1.NombreMains == 2) throw new Exception("Vous n'avez pas de main libre");
            this._arme2 = a;
        }

        // Bascule entre les deux armes
        public void ChangerArme()
        {
            Arme temp = this._arme1;
            this._arme1 = this._arme2;
            this._arme2 = temp;
        }

        public void DefinirTenue(Tenue t)
        {
            if (TenuesPossibles.Contains(t))
            {
                _tenue = t;
            }
            else
            {
                throw new Exception("La tenue n'est pas disponible");
            }
        }

        public void BasculerTenue()
        {
            _indexTenue = (_indexTenue + 1) % _tenuesPossibles.Count;
            _tenue = _tenuesPossibles[_indexTenue];
        }
    }
}
