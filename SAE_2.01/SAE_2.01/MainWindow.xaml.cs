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
            if (lv1.SelectedItem == null)
            {
                MessageBox.Show("selectionner la reservation a consulter", "erreur selection", 0, MessageBoxImage.Error);
            }
            else
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
        }

        private void btnCreer_Click(object sender, RoutedEventArgs e)
        {
            bool erreur = true;
            DateTime date;
            if (!DateTime.TryParse(txtDate.Text, out date)){
                MessageBox.Show("date au format jj/mm/aaaa", "erreur date" , 0, MessageBoxImage.Error);
                erreur = false;
            }
            int idEmploye; 
            if (!int.TryParse(txtEmploye.Text, out idEmploye)){
                MessageBox.Show("l'idEmployé doit être un chiffre (sans espace)", "erreur idEmploye", 0, MessageBoxImage.Error);
                erreur = false;
            }
            int idVehicule; 
            if (!int.TryParse(txtVehicule.Text,out idVehicule))
            {
                MessageBox.Show("l'idVehicule doit être un chiffre (sans espace)", "erreur idVehicule", 0, MessageBoxImage.Error);
                erreur = false;
            }
            string mission = txtMission.Text;
            if (erreur)
            {
                DataListView newEmprunteItem = new DataListView();
                newEmprunteItem.Date_emprunt = date.ToShortDateString();
                newEmprunteItem.ID_employe = idEmploye;
                newEmprunteItem.ID_vehicule = idVehicule;
                newEmprunteItem.Mission_concernee = mission;

                newEmprunteItem.Create();
                ApplicationData.loadApplicationData();
                lv1.ItemsSource = ApplicationData.Liste_DataListView;
                txtDate.Text = "";
                txtEmploye.Text = "";
                txtVehicule.Text = "";
                txtMission.Text = "";
            }
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (lv1.SelectedItem == null)
            {
                MessageBox.Show("selectionner la reservation a supprimer", "erreur selection", 0, MessageBoxImage.Error);
            }
            else
            {
                DataListView data = (DataListView)lv1.SelectedItem;
                data.Delete();
                ApplicationData.loadApplicationData();
                lv1.ItemsSource = ApplicationData.Liste_DataListView;
            }
        }

        private void btnConsulterID_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
