using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SAE_2._01
{
    class Vehicule : Crud<Vehicule>
    {
        public long Id_vehicule
        {
            get; set;
        }

        public long Id_categorie
        {
            get; set;
        }

        public string Libelle_vehicule
        {
            get; set;
        }

        public Vehicule()
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

        public List<Vehicule> FindAll()
        {
            List<Vehicule> liste = new List<Vehicule>();
            DataAccess access = new DataAccess();
            SqlDataReader reader;
            try
            {
                if (access.openConnection())
                {
                    reader = access.getData("select * from dbo.VEHICULE;");
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Vehicule unEmploye = new Vehicule();
                            unEmploye.Id_vehicule = reader.GetInt64(0);
                            unEmploye.Id_categorie = reader.GetInt64(1);
                            unEmploye.Libelle_vehicule = reader.GetString(2);
                            liste.Add(unEmploye);
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

        public List<Vehicule> FindBySelection(string criteres)
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
