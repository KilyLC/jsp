using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HerosNamespace
{
    class Tenue
    {
        private string _nomTenue;
        private int _niveauDefense;
        private float _poids;
        private Image _image;

        public string NomTenue { get => _nomTenue; }
        public int NiveauDefense { get => _niveauDefense; }
        public float Poids { get => _poids; }
        public Image Image { get => _image; }

        public Tenue(string nom, int defense, float poids, Image image)
        {
            this._nomTenue = nom;
            this._niveauDefense = defense;
            this._poids = poids;
            this._image = image;
        }
    }
}
