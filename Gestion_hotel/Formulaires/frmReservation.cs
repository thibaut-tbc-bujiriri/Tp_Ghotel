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
    public partial class frmReservation : Form
    {
        public frmReservation()
        {
            InitializeComponent();
        }

        ClsReservation res = new ClsReservation();

        public void saveReservation(int a)
        {
            try
            {
                res.RefClient = int.Parse(ClsGlossaire.GetInstance().getcode_Combo("Client", "id", "noms", cmbRefClient.Text));
                res.RefChabre = int.Parse(ClsGlossaire.GetInstance().getcode_Combo("Chambre", "id", "numero", cmbRefChambre.Text));
                res.DateEntree = DateTime.Parse(txtDateEntree.Text);

                if (a == 1)
                {
                    res.Id = -1;
                    ClsGlossaire.GetInstance().SaveReservation(res);
                    dgvReserv.DataSource = ClsGlossaire.GetInstance().loadData("Reservation");
                }
                else if (a == 2)
                {
                    res.Id = int.Parse(txtIdReserv.Text);
                    ClsGlossaire.GetInstance().SaveReservation(res);
                    dgvReserv.DataSource = ClsGlossaire.GetInstance().loadData("Reservation");
                }
                else if (a == 3)
                {
                    ClsGlossaire.GetInstance().DeleteData("Reservation", "id", int.Parse(txtIdReserv.Text));
                    dgvReserv.DataSource = ClsGlossaire.GetInstance().loadData("Reservation");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmReservation_Load(object sender, EventArgs e)
        {
            dgvReserv.DataSource = ClsGlossaire.GetInstance().loadData("Reservation");
            ClsGlossaire.GetInstance().loadCombo("Client", "noms", cmbRefClient);
            ClsGlossaire.GetInstance().loadCombo("Chambre", "numero", cmbRefChambre);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActReserv_Click(object sender, EventArgs e)
        {
            txtIdReserv.Text = "";
            cmbRefClient.Text = "";
            cmbRefChambre.Text = "";
            txtDateEntree.Text = "";
        }

        private void btnAddReserv_Click(object sender, EventArgs e)
        {
            saveReservation(1);
        }

        private void btnModReserv_Click(object sender, EventArgs e)
        {
            saveReservation(2);
        }

        private void btnDeleteReserv_Click(object sender, EventArgs e)
        {

        }

        private void dgvReserv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvReserv.Rows[e.RowIndex];
                txtIdReserv.Text = row.Cells["id"].Value.ToString();
                cmbRefClient.Text = row.Cells["refClient"].Value.ToString();
                cmbRefChambre.Text = row.Cells["refChabre"].Value.ToString();
                txtDateEntree.Text = row.Cells["dateEntree"].Value.ToString();
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void RechercherReservation(string motCle)
        {
            try
            {
                string query = @"
            SELECT R.id, R.refClient, R.refChabre, R.dateEntree, C.noms AS NomClient, CH.numero AS NumeroChambre
            FROM Reservation R
            INNER JOIN Client C ON R.refClient = C.id
            INNER JOIN Chambre CH ON R.refChabre = CH.id
            WHERE C.noms LIKE @motCle OR CH.numero LIKE @motCle OR R.dateEntree LIKE @motCle";

                SqlConnection con = new SqlConnection(ClsConnexion.Way);
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@motCle", "%" + motCle + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvReserv.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de recherche : " + ex.Message);
            }
        }


        private void txtSearchReserv_TextChanged(object sender, EventArgs e)
        {
            RechercherReservation(txtSearchReserv.Text);
        }
    }
}
