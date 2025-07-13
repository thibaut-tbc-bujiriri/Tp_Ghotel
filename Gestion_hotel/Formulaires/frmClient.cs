using Gestion_hotel.Classes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_hotel.Formulaires
{
    public partial class frmClient : Form
    {
        public frmClient()
        {
            InitializeComponent();
        }

        ClsClient client = new ClsClient();

        public void saveClient(int a)
        {
            client.Noms = txtNomClient.Text;
            client.Adresse = txtAdresseClient.Text;
            client.Contact = txtContactClient.Text;

            if (a == 1)
            {
                if (txtNomClient.Text == "" || txtAdresseClient.Text == "" || txtContactClient.Text == "")
                {
                    MessageBox.Show("Veuillez remplir tous les champs", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    client.Id = -1;
                    ClsGlossaire.GetInstance().SaveClient(client);
                    dgvClient.DataSource = ClsGlossaire.GetInstance().loadData("Client");
                    MessageBox.Show("Client Enregistré avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                }

            }
            else if (a == 2)
            {
                if (txtNomClient.Text == "" || txtAdresseClient.Text == "" || txtContactClient.Text == "")
                {
                    MessageBox.Show("Veuillez remplir tous les champs", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    client.Id = int.Parse(txtIdClient.Text);
                    ClsGlossaire.GetInstance().SaveClient(client);
                    dgvClient.DataSource = ClsGlossaire.GetInstance().loadData("Client");
                    MessageBox.Show("Client Modifié avec succès", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                }
            }
            else if (a == 3)
            {
                if (txtNomClient.Text == "" || txtAdresseClient.Text == "" || txtContactClient.Text == "")
                {
                    MessageBox.Show("Veuillez remplir tous les champs", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ClsGlossaire.GetInstance().DeleteData("Client", "id", int.Parse(txtIdClient.Text));
                    MessageBox.Show("Client Supprimé avec succès", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvClient.DataSource = ClsGlossaire.GetInstance().loadData("Client");
                    clear();
                }
            }
        }

        private void frmClient_Load(object sender, EventArgs e)
        {
            dgvClient.DataSource = ClsGlossaire.GetInstance().loadData("Client");
        }

        private void btnActClient_Click(object sender, EventArgs e)
        {
            txtIdClient.Text = "";
            txtNomClient.Text = "";
            txtAdresseClient.Text = "";
            txtContactClient.Text = "";
        }
        public void clear()
        {
            txtIdClient.Text = "";
            txtNomClient.Text = "";
            txtAdresseClient.Text = "";
            txtContactClient.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            saveClient(1);
        }

        private void btnModClient_Click(object sender, EventArgs e)
        {
            saveClient(2);
        }

        private void btnDeleteClient_Click(object sender, EventArgs e)
        {
            saveClient(3);
        }

        private void dgvClient_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvClient.Rows[e.RowIndex];
                txtIdClient.Text = row.Cells["id"].Value.ToString();
                txtNomClient.Text = row.Cells["noms"].Value.ToString();
                txtAdresseClient.Text = row.Cells["adresse"].Value.ToString();
                txtContactClient.Text = row.Cells["contact"].Value.ToString();
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void RechercherClient(string motCle)
        {
            try
            {
                string query = @"
            SELECT id, noms, adresse, contact
            FROM Client
            WHERE noms LIKE @motCle 
               OR adresse LIKE @motCle 
               OR contact LIKE @motCle";

                SqlConnection con = new SqlConnection(ClsConnexion.Way);
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@motCle", "%" + motCle + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvClient.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de recherche client : " + ex.Message);
            }
        }


        private void txtRechercheClient_TextChanged(object sender, EventArgs e)
        {
            RechercherClient(txtRechercheClient.Text);
        }
    }
}
