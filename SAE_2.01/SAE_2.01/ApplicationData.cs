using System;
using System.Collections.Generic;
using System.Text;

namespace SAE_2._01
{
    class ApplicationData
    {
        public static List<DataListView> Liste_DataListView
        {
            get;
            set;
        }

        public static void loadApplicationData()
        {
            //chargement des données
            DataListView dataListView = new DataListView();
            Liste_DataListView = dataListView.FindAll();
        }
    }
}
