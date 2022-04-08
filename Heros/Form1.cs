using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HerosNamespace
{
    public partial class frmMain : Form
    {
        // Variables
        Random rng;
        Compagnie le_trio_denfer;
        List<Tenue> tenues_mario;
        List<Tenue> tenues_zelda;
        List<Tenue> tenues_pikachu;
        List<Tenue> tenues_isabelle;
        List<Tenue> tenues_cypher;
        List<Tenue> tenues_tachanka;
        Compagnie compagnie_courante;
        List<Compagnie> compagnies;
        int index_compagnie = 0;
        public frmMain()
        {
            InitializeComponent();
            rng = new Random();
            compagnies = new List<Compagnie>();

            le_trio_denfer = new Compagnie("Le trio d'enfer");
            compagnie_courante = le_trio_denfer;

            // Armes
            Arme ak47 = new Arme("AK-47", 40, 67, 15, 30, 2, Properties.Resources.ak47);
            Arme ak74u = new Arme("AK-74u", 58, 54, 13, 30, 2, Properties.Resources.ak74u);
            Arme glock17 = new Arme("Glock-17", 104, 70, 3, 15, 1, Properties.Resources.glock17);
            Arme five_seven = new Arme("Five-SeveN", 110, 65, 3, 8, 1, Properties.Resources.five_seven);

            // Initialisation des Heros
            tenues_mario = new List<Tenue>();
            tenues_mario.Add(new Tenue("Normale", 0, 2, Properties.Resources.mario));
            tenues_mario.Add(new Tenue("Dr. Mario", 10, 5, Properties.Resources.mario_dr));
            tenues_mario.Add(new Tenue("Mariage", 0, 3, Properties.Resources.mario_mariage));
            Heros mario = new Heros("Mario", tenues_mario, tenues_mario[0], ak47, null, 100, 32, 5, le_trio_denfer);
            le_trio_denfer.AjouterHeros(mario);

            tenues_zelda = new List<Tenue>();
            tenues_zelda.Add(new Tenue("Normale", 4, 2, Properties.Resources.zelda_2));
            tenues_zelda.Add(new Tenue("Aventuriere", 15, 3, Properties.Resources.zelda_1));
            Heros zelda = new Heros("Zelda", tenues_zelda, tenues_zelda[0], ak74u, null, 100, 17, 8, le_trio_denfer);
            le_trio_denfer.AjouterHeros(zelda);

            tenues_pikachu = new List<Tenue>();
            tenues_pikachu.Add(new Tenue("Normal", 0, 0, Properties.Resources.pikachu));
            tenues_pikachu.Add(new Tenue("Rey misterio", 0, 1, Properties.Resources.pikachu_rey_misterio));
            tenues_pikachu.Add(new Tenue("Casquette", 0, 1, Properties.Resources.pikachu_cap));
            Heros pikachu = new Heros("Pikachu", tenues_pikachu, tenues_pikachu[0], glock17, five_seven, 150, 46, 15, le_trio_denfer);
            le_trio_denfer.AjouterHeros(pikachu);

            compagnies.Add(le_trio_denfer);

            AfficherCompagnie(compagnie_courante);

            Compagnie compagnie2 = new Compagnie("LES TUEURS");

            tenues_isabelle = new List<Tenue>();
            tenues_isabelle.Add(new Tenue("Tenue 1", 0, 1, Properties.Resources.isabelle));
            tenues_isabelle.Add(new Tenue("Tenue 2", 0, 1, Properties.Resources.isabelle2));
            Heros isabelle = new Heros("Isabelle", tenues_isabelle, tenues_isabelle[0], glock17, five_seven, 100, 1, 1, compagnie2);
            compagnie2.AjouterHeros(isabelle);

            tenues_cypher = new List<Tenue>();
            tenues_cypher.Add(new Tenue("Normal", 14, 6, Properties.Resources.cypher));
            tenues_cypher.Add(new Tenue("Dark", 14, 6, Properties.Resources.cipher_dark));
            Heros cypher = new Heros("Cypher", tenues_cypher, tenues_cypher[0], ak47, null, 100, 5, 5, compagnie2);
            compagnie2.AjouterHeros(cypher);

            tenues_tachanka = new List<Tenue>();
            tenues_tachanka.Add(new Tenue("Normal", 20, 10, Properties.Resources.tachanka));
            tenues_tachanka.Add(new Tenue("Elite", 0, 3, Properties.Resources.tachanka2));
            tenues_tachanka.Add(new Tenue("Lord Tachanka", 30, 13, Properties.Resources.lord_tachanka));
            Heros tachanka = new Heros("Tachanka", tenues_tachanka, tenues_tachanka[0], ak74u, null, 100, 100, 1, compagnie2);
            compagnie2.AjouterHeros(tachanka);

            compagnies.Add(compagnie2);
        }

        // Mettre à jour les compagnies
        private void AfficherCompagnie(Compagnie c)
        {
            // Afficher nom compagnie
            this.lblNomCompagnie.Text = c.Nom;
            
            if (c.Heros.Count >= 1)
            {
                Heros h = c.Heros[0];
                if (h.Arme1 != null) // Vérifier si le héros possède une arme
                {
                    ChangerImageArme1(h.Arme1.Image);
                }
                else
                {
                    ChangerImageArme1(null);
                }
                // Mettre a jour l'affichage
                ChangerImagePerso1(h.Tenue.Image);
                DefinirStats1(h);
            }
            if (c.Heros.Count >= 2)
            {
                Heros h = c.Heros[1];
                if (h.Arme1 != null) // Vérifier si le héros possède une arme
                {
                    ChangerImageArme2(h.Arme1.Image);
                }
                else
                {
                    ChangerImageArme2(null);
                }
                // Mettre a jour l'affichage
                ChangerImagePerso2(h.Tenue.Image);
                DefinirStats2(h);
            }
            if (c.Heros.Count >= 3)
            {
                Heros h = c.Heros[2];
                if (h.Arme1 != null) // Vérifier si le héros possède une arme
                {
                    ChangerImageArme3(h.Arme1.Image);
                }
                else
                {
                    ChangerImageArme3(null);
                }
                // Mettre a jour l'affichage
                ChangerImagePerso3(h.Tenue.Image);
                DefinirStats3(h);
            }
        }

        private void DefinirStats1(Heros h)
        {
            // Vérifier si le héros existe
            if (h != null)
            {
                // Mettre à jour le texte
                lblNom1.Text = "Nom : " + h.Nom;
                lblNomTenue1.Text = "Nom tenue : " + h.Tenue.NomTenue;
                lblNiveauVie1.Text = "Niveau vie : " + h.NiveauVie.ToString();
                lblAttaque1.Text = "Attaque : " + h.Attaque.ToString();
                lblVitesse1.Text = "Vitesse : " + h.Vitesse.ToString();
            }
            else
            {
                // Mettre du texte par défaut
                lblNom1.Text = "Nom : ";
                lblNomTenue1.Text = "Nom tenue : ";
                lblNiveauVie1.Text = "Niveau vie : ";
                lblAttaque1.Text = "Attaque : ";
                lblVitesse1.Text = "Vitesse : ";
            }
        }

        // Pour mettre à jour les différentes PictureBox d'arme
        private void ChangerImageArme1(Image i)
        {
            pibArme1.Image = i;
        }
        private void ChangerImageArme2(Image i)
        {
            pibArme2.Image = i;
        }
        private void ChangerImageArme3(Image i)
        {
            pibArme3.Image = i;
        }




        // Pour mettre à jour les différentes PictureBox de tenue
        private void ChangerImagePerso1(Image i)
        {
            pibPersonnage1.Image = i;
        }
        private void ChangerImagePerso2(Image i)
        {
            pibPersonnage2.Image = i;
        }
        private void ChangerImagePerso3(Image i)
        {
            pibPersonnage3.Image = i;
        }
        private void DefinirStats2(Heros h)
        {
            if (h != null)
            {
                lblNom2.Text = "Nom : " + h.Nom;
                lblNomTenue2.Text = "Nom tenue : " + h.Tenue.NomTenue;
                lblNiveauVie2.Text = "Niveau vie : " + h.NiveauVie.ToString();
                lblAttaque2.Text = "Attaque : " + h.Attaque.ToString();
                lblVitesse2.Text = "Vitesse : " + h.Vitesse.ToString();
            }
            else
            {
                lblNom2.Text = "Nom : ";
                lblNomTenue2.Text = "Nom tenue : ";
                lblNiveauVie2.Text = "Niveau vie : ";
                lblAttaque2.Text = "Attaque : ";
                lblVitesse2.Text = "Vitesse : ";
            }
        }
        private void DefinirStats3(Heros h)
        {
            // Vérifier si le héros existe
            if (h != null)
            {
                // Mettre à jour le texte
                lblNom3.Text = "Nom : " + h.Nom;
                lblNomTenue3.Text = "Nom tenue : " + h.Tenue.NomTenue;
                lblNiveauVie3.Text = "Niveau vie : " + h.NiveauVie.ToString();
                lblAttaque3.Text = "Attaque : " + h.Attaque.ToString();
                lblVitesse3.Text = "Vitesse : " + h.Vitesse.ToString();
            }
            else
            {
                // Mettre du texte par défaut
                lblNom3.Text = "Nom : ";
                lblNomTenue3.Text = "Nom tenue : ";
                lblNiveauVie3.Text = "Niveau vie : ";
                lblAttaque3.Text = "Attaque : ";
                lblVitesse3.Text = "Vitesse : ";
            }
        }

        private void btnArme1_Click(object sender, EventArgs e)
        {
            // S'assurer qu'il y ait une compagnie courante
            if (compagnie_courante == null)
                return;

            // S'assurer qu'il y ait au moins un héros
            if (compagnie_courante.Heros.Count < 1)
                return;

            Heros h = compagnie_courante.Heros[0];
            h.ChangerArme();
            Arme a = h.Arme1;
            // Changer la picturebox en fonction de si l'arme existe ou pas
            if (a != null)
                ChangerImageArme1(h.Arme1.Image);
            else
                ChangerImageArme1(null);
        }

        private void btnArme2_Click(object sender, EventArgs e)
        {
            // S'assurer qu'il y ait une compagnie courante
            if (compagnie_courante == null)
                return;

            // S'assurer qu'il y ait au moins deux héros
            if (compagnie_courante.Heros.Count < 2)
                return;

            Heros h = compagnie_courante.Heros[1];
            h.ChangerArme();
            Arme a = h.Arme1;
            // Changer la picturebox en fonction de si l'arme existe ou pas
            if (a != null)
                ChangerImageArme2(h.Arme1.Image);
            else
                ChangerImageArme2(null);
        }

        private void btnArme3_Click(object sender, EventArgs e)
        {
            // S'assurer qu'il y ait une compagnie courante
            if (compagnie_courante == null)
                return;

            // S'assurer qu'il y ait au moins trois héros
            if (compagnie_courante.Heros.Count < 3)
                return;

            Heros h = compagnie_courante.Heros[2];
            h.ChangerArme();
            Arme a = h.Arme1;
            // Changer la picturebox en fonction de si l'arme existe ou pas
            if (a != null)
                ChangerImageArme3(h.Arme1.Image);
            else
                ChangerImageArme3(null);
        }

        private void btnTenue1_Click(object sender, EventArgs e)
        {
            // S'assurer qu'il y ait une compagnie courante
            if (compagnie_courante == null)
                return;

            // S'assurer qu'il y ait au moins un héros
            if (compagnie_courante.Heros.Count < 1)
                return;

            // Met à jour la tenue selon le héros
            Heros h = compagnie_courante.Heros[0];
            h.BasculerTenue();
            pibPersonnage1.Image = h.Tenue.Image;
            DefinirStats1(h); // Mettre à jour les stats
        }

        private void btnTenue2_Click(object sender, EventArgs e)
        {
            // S'assurer qu'il y ait une compagnie courante
            if (compagnie_courante == null)
                return;

            // S'assurer qu'il y ait au moins deux héros
            if (compagnie_courante.Heros.Count < 2)
                return;

            // Met à jour la tenue selon le héros
            Heros h = compagnie_courante.Heros[1];
            h.BasculerTenue();
            pibPersonnage2.Image = h.Tenue.Image;
            DefinirStats2(h); // Mettre à jour les stats
        }

        private void btnTenue3_Click(object sender, EventArgs e)
        {
            // S'assurer qu'il y ait une compagnie courante
            if (compagnie_courante == null)
                return;

            // S'assurer qu'il y ait au moins trois héros
            if (compagnie_courante.Heros.Count < 3)
                return;

            // Met à jour la tenue selon le héros
            Heros h = compagnie_courante.Heros[2];
            h.BasculerTenue();
            pibPersonnage3.Image = h.Tenue.Image;
            DefinirStats3(h); // Mettre à jour les stats
        }

        private void btnCompagnie_Click(object sender, EventArgs e)
        {
            // Bascule la compagnie courante
            index_compagnie = (index_compagnie + 1) % compagnies.Count;
            compagnie_courante = compagnies[index_compagnie];
            AfficherCompagnie(compagnie_courante);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Message de confirmation pour quitter
            if (MessageBox.Show("Voulez-vous quitter l'application", "Quitter", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}