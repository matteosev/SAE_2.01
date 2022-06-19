using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SAE_2._01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lv1.ItemsSource = ApplicationData.Liste_DataListView;
        }

        private void btnConsulter_Click(object sender, RoutedEventArgs e)
        {
            ConsulterWindow consulterWindow = new ConsulterWindow();
            DataListView data = (DataListView)lv1.SelectedItem;
            consulterWindow.textblocDate.Text = data.Date_emprunt;
            consulterWindow.textblocMission.Text = data.Mission_concernee;
            consulterWindow.textblocIDemploye.Text = data.ID_employe.ToString();
            consulterWindow.textblocNomEmploye.Text = data.Nom;
            consulterWindow.textblocPrenomEmploye.Text = data.Prenom;
            consulterWindow.textblocNumEmploye.Text = data.NumTel_employe;
            consulterWindow.textblocMailEmploye.Text = data.Mail_employe;
            consulterWindow.textblocIDvehicule.Text = data.ID_vehicule.ToString();
            consulterWindow.textblocLibelleVehicule.Text = data.Libelle_vehicule;
            consulterWindow.textblocCategorieVehicule.Text = data.Libelle_CategorieVehicule;

            consulterWindow.Owner = this;
            consulterWindow.Show();
        }

        private void btnCreer_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = DateTime.Parse(txtDate.Text);
            int idEmploye = int.Parse(txtEmploye.Text);
            int idVehicule = int.Parse(txtVehicule.Text);
            string mission = txtMission.Text;

            DataListView newEmprunteItem = new DataListView();
            newEmprunteItem.Date_emprunt = date.ToShortDateString();
            newEmprunteItem.ID_employe = idEmploye;
            newEmprunteItem.ID_vehicule = idVehicule;
            newEmprunteItem.Mission_concernee = mission;

            newEmprunteItem.Create();
        }
    }
}
