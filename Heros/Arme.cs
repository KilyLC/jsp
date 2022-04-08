using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HerosNamespace
{
    class Arme
    {
        private string _nomArme;
        private int _niveauAttaque;
        private int _durabilite;
        private int _poids;
        private int _munitions;
        private int _nombreMains;
        private Image _image;

        public string NomArme { get => _nomArme; }
        public int NiveauAttaque { get => _niveauAttaque; }
        public int Durabilite { get => _durabilite; set => _durabilite = value; }
        public int Poids { get => _poids; }
        public int Munitions { get => _munitions; set => _munitions = value; }
        public int NombreMains { get => _nombreMains; }
        public Image Image { get => _image; set => _image = value; }

        public Arme(string nomArme, int niveauAttaque, int durabilite, int poids, int munitions, int nbMains, Image image)
        {
            this._nomArme = nomArme;
            this._niveauAttaque = niveauAttaque;
            this._durabilite = durabilite;
            this._poids = poids;
            this._munitions = munitions;
            this._nombreMains = nbMains;
            this._image = image;
        }
    }
}
