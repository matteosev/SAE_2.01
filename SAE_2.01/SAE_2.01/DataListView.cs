using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SAE_2._01
{
    class DataListView : Crud<DataListView>
    {
        public string Libelle_vehicule
        {
            get; set;
        }

        public string Date_emprunt
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

        public string Mission_concernee
        {
            get; set;
        }

        public DataListView()
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

        public List<DataListView> FindAll()
        {
            List<DataListView> liste = new List<DataListView>();
            DataAccess access = new DataAccess();
            SqlDataReader reader;
            try
            {
                if (access.openConnection())
                {
                    reader = access.getData("select eprnt.DATE_EMPRUNT, eplye.NOM, eplye.PRENOM, vhicl.LIBELLE_VEHICULE, eprnt.MISSION_CONCERNEE from [IUT-ACY\\dervauxt].EMPRUNTE eprnt join [IUT-ACY\\dervauxt].EMPLOYE eplye on eprnt.ID_EMPLOYE = eplye.ID_EMPLOYE join [IUT-ACY\\dervauxt].VEHICULE vhicl on eprnt.ID_VEHICULE = vhicl.ID_VEHICULE");
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            DataListView unEmprunt = new DataListView();
                            unEmprunt.Date_emprunt = reader.GetDateTime(0).ToString("dd/MM/yyyy");
                            unEmprunt.Nom = reader.GetString(1);
                            unEmprunt.Prenom = reader.GetString(2);
                            unEmprunt.Libelle_vehicule = reader.GetString(3);
                            if (reader.IsDBNull(4))
                                unEmprunt.Mission_concernee = "";
                            else
                                unEmprunt.Mission_concernee = reader.GetString(4);
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

        public List<DataListView> FindBySelection(string criteres)
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
