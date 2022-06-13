using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SAE_2._01
{
    class Date_emprunt : Crud<Date_emprunt>
    {
        public long Date
        {
            get; set;
        }

        public Date_emprunt()
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

        public List<Date_emprunt> FindAll()
        {
            List<Date_emprunt> liste = new List<Date_emprunt>();
            DataAccess access = new DataAccess();
            SqlDataReader reader;
            try
            {
                if (access.openConnection())
                {
                    reader = access.getData("select * from dbo.DATE_EMPRUNT;");
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Date_emprunt uneDate = new Date_emprunt();
                            uneDate.Date = reader.GetInt64(0);
                            liste.Add(uneDate);
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

        public List<Date_emprunt> FindBySelection(string criteres)
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
