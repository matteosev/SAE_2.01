using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SAE_2._01
{
    class Employe : Crud<Employe>
    {
        public long Id_employe
        {
            get; set;
        }

        public string Nom
        {
            get; set;
        }

        public string Prenom
        {
            get; set;
        }

        public string Num_tel
        {
            get; set;
        }

        public string Mail
        {
            get; set;
        }

        public Employe()
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

        public List<Employe> FindAll()
        {
            List<Employe> liste = new List<Employe>();
            DataAccess access = new DataAccess();
            SqlDataReader reader;
            try
            {
                if (access.openConnection())
                {
                    reader = access.getData("select * from EMPLOYE;");
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Employe unEmploye = new Employe();
                            unEmploye.Id_employe = reader.GetInt32(0);
                            unEmploye.Nom = reader.GetString(1);
                            unEmploye.Prenom = reader.GetString(2);
                            unEmploye.Num_tel = reader.GetString(3);
                            unEmploye.Mail = reader.GetString(4);
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

        public List<Employe> FindBySelection(string criteres)
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
