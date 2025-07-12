using Gestion_hotel.Classes;
using Gestion_hotel.Formulaires;
using Microsoft.Data.SqlClient;
using System.Drawing;

namespace Gestion_hotel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = null;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ptBox_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bienvenu dans notre hotel !", "Accueil", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            frmClient client = new frmClient();
            client.ShowDialog();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frmReservation res = new frmReservation();
            res.ShowDialog();
        }
    }
}
