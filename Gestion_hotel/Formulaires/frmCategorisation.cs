using Gestion_hotel.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_hotel.Formulaires
{
    public partial class frmCategorisation : Form
    {
        public frmCategorisation()
        {
            InitializeComponent();
        }

        ClsCategorisation cat = new ClsCategorisation();

        public void saveCategorisation(int a)
        {
            cat.Desgnation = txtDesignCategorie.Text;

            if (a == 1)
            {
                cat.Id = -1;
                ClsGlossaire.GetInstance().SaveCategorisation(cat);
                dgvCategorie.DataSource = ClsGlossaire.GetInstance().loadData("Categorisation");
            }
            else if (a == 2)
            {
                cat.Id = int.Parse(txtIDCategorie.Text);
                ClsGlossaire.GetInstance().SaveCategorisation(cat);
                dgvCategorie.DataSource = ClsGlossaire.GetInstance().loadData("Categorisation");
            }
            else if (a == 3)
            {
                ClsGlossaire.GetInstance().DeleteData("Categorisation", "id", int.Parse(txtIDCategorie.Text));
                dgvCategorie.DataSource = ClsGlossaire.GetInstance().loadData("Categorisation");
            }
        }

        private void btnActCategorie_Click(object sender, EventArgs e)
        {
            txtIDCategorie.Text = "";
            txtDesignCategorie.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCategorisation_Load(object sender, EventArgs e)
        {
            dgvCategorie.DataSource = ClsGlossaire.GetInstance().loadData("Categorisation");
        }

        private void btnAddCategorie_Click(object sender, EventArgs e)
        {
            saveCategorisation(1);
        }

        private void btnModCategorie_Click(object sender, EventArgs e)
        {
            saveCategorisation(2);
        }

        private void btnDeleteCategorie_Click(object sender, EventArgs e)
        {
            saveCategorisation(3);
        }

        private void RechercherCategorisation(string motCle)
        {
            try
            {
                string query = @"
            SELECT C.id, C.desgnation
            FROM Categorisation C
            INNER JOIN Categorisation G ON C.desgnation = C.id
            WHERE C.desgnation LIKE @motCle";

                SqlConnection con = new SqlConnection(ClsConnexion.Way);
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@motCle", "%" + motCle + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvCategorie.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de recherche : " + ex.Message);
            }
        }

        private void txtRechercheCategorie_TextChanged(object sender, EventArgs e)
        {
            RechercherCategorisation(txtRechercheCategorie.Text);
        }

        private void dgvCategorie_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvCategorie.Rows[e.RowIndex];
                txtIDCategorie.Text = row.Cells["id"].Value.ToString();
                txtDesignCategorie.Text = row.Cells["desgnation"].Value.ToString();
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
