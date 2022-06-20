using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;

namespace SAE_2._01
{
    class DataListView : Crud<DataListView>
    {
        public string Libelle_vehicule
        {
            get; set;
        }

        public int ID_vehicule
        {
            get; set;
        }

        public string Libelle_CategorieVehicule
        {
            get; set;
        }

        public string Date_emprunt
        {
            get; set;
        }

        public int ID_employe
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

        public string NumTel_employe
        {
            get; set;
        }

        public string Mail_employe
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
            DataAccess access = new DataAccess();
            SqlDataReader reader;

            try
            {
                if (access.openConnection())
                {
                    bool dateExiste = false;
                    reader = access.getData("SELECT * FROM [IUT-ACY\\dervauxt].DATE_EMPRUNT;");

                    while (!dateExiste && reader.Read())
                    {
                        if (reader.GetDateTime(0).CompareTo(DateTime.Parse(Date_emprunt)) == 0)
                            dateExiste = true;
                    }

                    if (!dateExiste)
                    {
                        CultureInfo provider = CultureInfo.InvariantCulture;
                        access.setData($"INSERT INTO [IUT-ACY\\dervauxt].DATE_EMPRUNT VALUES('{DateTime.ParseExact(Date_emprunt, "dd/MM/yyyy", provider)}');");
                    }

                    access.setData($"INSERT INTO [IUT-ACY\\dervauxt].EMPRUNTE(ID_VEHICULE, DATE_EMPRUNT, ID_EMPLOYE, MISSION_CONCERNEE) VALUES('{ID_vehicule}','{Date_emprunt}','{ID_employe}','{Mission_concernee}');");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Important Message");
            }
        }

        public void Delete()
        {
            DataAccess access = new DataAccess();

            try
            {
                if (access.openConnection())
                {
                    access.setData($"DELETE FROM [IUT-ACY\\dervauxt].EMPRUNTE WHERE ID_VEHICULE = {ID_vehicule} AND DATE_EMPRUNT = '{Date_emprunt}' AND ID_EMPLOYE = {ID_employe};");
                    
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Important Message");
            }
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
                    reader = access.getData("select eprnt.DATE_EMPRUNT, eplye.ID_EMPLOYE, eplye.NOM, eplye.PRENOM, eplye.NUM_TEL, eplye.MAIL, vhicl.ID_VEHICULE, vhicl.LIBELLE_VEHICULE, cat.LIBELLE_CATEGORIE, eprnt.MISSION_CONCERNEE from [IUT-ACY\\dervauxt].EMPRUNTE eprnt join [IUT-ACY\\dervauxt].EMPLOYE eplye on eprnt.ID_EMPLOYE = eplye.ID_EMPLOYE join [IUT-ACY\\dervauxt].VEHICULE vhicl on eprnt.ID_VEHICULE = vhicl.ID_VEHICULE join [IUT-ACY\\dervauxt].CATEGORIE_VEHICULE cat on vhicl.ID_CATEGORIE = cat.ID_CATEGORIE");
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            DataListView unEmprunt = new DataListView();
                            unEmprunt.Date_emprunt = reader.GetDateTime(0).ToString("dd/MM/yyyy");
                            unEmprunt.ID_employe = reader.GetInt32(1);
                            unEmprunt.Nom = reader.GetString(2);
                            unEmprunt.Prenom = reader.GetString(3);
                            unEmprunt.NumTel_employe = reader.GetString(4);
                            unEmprunt.Mail_employe = reader.GetString(5);
                            unEmprunt.ID_vehicule = reader.GetInt32(6);
                            unEmprunt.Libelle_vehicule = reader.GetString(7);
                            unEmprunt.Libelle_CategorieVehicule = reader.GetString(8);


                            if (reader.IsDBNull(9))
                                unEmprunt.Mission_concernee = "";
                            else
                                unEmprunt.Mission_concernee = reader.GetString(9);
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
