using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SAE_2._01
{
    class Categorie_vehicule : Crud<Categorie_vehicule>
    {
        public long Id_categorie
        {
            get; set;
        }

        public string Libelle_categorie
        {
            get; set;
        }

        public Categorie_vehicule()
        {
        }

        public void Create()
        {
            throw new System.NotImplementedException();
        }

        public void Delete()
        {
            throw new System.NotImplementedException();
        }

        public List<Categorie_vehicule> FindAll()
        {
            List<Categorie_vehicule> liste = new List<Categorie_vehicule>();
            DataAccess access = new DataAccess();
            SqlDataReader reader;
            try
            {
                if (access.openConnection())
                {
                    reader = access.getData("select * from CATEGORIE_VEHICULE;");
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Categorie_vehicule uneCategorie = new Categorie_vehicule();
                            uneCategorie.Id_categorie = reader.GetInt32(0);
                            uneCategorie.Libelle_categorie = reader.GetString(1);
                            liste.Add(uneCategorie);
                        }
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("No rows found.", "Important Message");
                    }
                    reader.Close();
                    access.closeConnection();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Important Message");
            }
            return liste;
        }

        public List<Categorie_vehicule> FindBySelection(string criteres)
        {
            throw new System.NotImplementedException();
        }

        public void Read()
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
