using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAE_2._01;
using System;
using System.Collections.Generic;
using System.Text;

namespace SAE_2._01.Tests
{
    [TestClass()]
    public class DataListViewTests
    {
        private DataListView data_DateNull;
        private DataListView data_IDemployeNull;
        private DataListView data_IDvehiculeNull;


        [TestInitialize()]
        public void ResaInitialize()
        {
            data_DateNull = new DataListView();
            data_IDemployeNull = new DataListView();
            data_IDvehiculeNull = new DataListView();

            data_DateNull.ID_employe = 1;
            data_DateNull.ID_vehicule = 1;

            data_IDemployeNull.Date_emprunt = "01/01/2022";
            data_IDemployeNull.ID_vehicule = 1;

            data_IDvehiculeNull.Date_emprunt = "01/01/2022";
            data_IDvehiculeNull.ID_employe = 1;
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Create_DateNull_Test()
        {
            data_DateNull.Create();
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void Create_IDemployeNull_Test()
        {
            data_IDemployeNull.Create();
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void Create_IDvehiculeNull_Test()
        {
            data_IDvehiculeNull.Create();
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Delete_DateNull_Test()
        {
            data_DateNull.Delete();
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void Delete_IDemployeNull_Test()
        {
            data_IDemployeNull.Delete();
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void Delete_IDvehiculeNull_Test()
        {
            data_IDvehiculeNull.Delete();
        }
    }
}