using System;
using System.Collections.Generic;
using System.Text;

namespace SAE_2._01
{
    class ApplicationData
    {
        public static List<Categorie_vehicule> Liste_Categorie_vehicule
        {
            get;
            set;
        }

        public static List<Date_emprunt> Liste_Date_emprunt
        {
            get;
            set;
        }

        public static List<Employe> Liste_Employe
        {
            get;
            set;
        }

        public static List<Emprunte> Liste_Emprunte
        {
            get;
            set;
        }

        public static List<Vehicule> Liste_Vehicule
        {
            get;
            set;
        }

        public static void loadApplicationData()
        {
            //chargement des tables

            Categorie_vehicule categorie_vehicule = new Categorie_vehicule();
            Date_emprunt date_emprunt = new Date_emprunt();
            Employe employe = new Employe();
            Emprunte emprunte = new Emprunte();
            Vehicule vehicule = new Vehicule();

            Liste_Categorie_vehicule = categorie_vehicule.FindAll();
            Liste_Date_emprunt = date_emprunt.FindAll();
            Liste_Employe = employe.FindAll();
            Liste_Emprunte = emprunte.FindAll();
            Liste_Vehicule = vehicule.FindAll();
        }
    }
}
