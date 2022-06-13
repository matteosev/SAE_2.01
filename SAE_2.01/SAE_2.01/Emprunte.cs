using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SAE_2._01
{
    class Emprunte : Crud<Emprunte>
    {
        public long Id_vehicule
        {
            get; set;
        }

        public string Date_emprunt
        {
            get; set;
        }

        public long Id_employe
        {
            get; set;
        }

        public string Mission_concernee
        {
            get; set;
        }

        public Emprunte()
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

        public List<Emprunte> FindAll()
        {
            List<Emprunte> liste = new List<Emprunte>();
            DataAccess access = new DataAccess();
            SqlDataReader reader;
            try
            {
                if (access.openConnection())
                {
                    reader = access.getData("select * from dbo.EMPRUNTE;");
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Emprunte unEmprunt = new Emprunte();
                            unEmprunt.Id_vehicule = reader.GetInt64(0);
                            unEmprunt.Date_emprunt = reader.GetString(1);
                            unEmprunt.Id_employe = reader.GetInt64(2);
                            unEmprunt.Mission_concernee = reader.GetString(3);
                            liste.Add(unEmprunt);
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

        public List<Emprunte> FindBySelection(string criteres)
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
