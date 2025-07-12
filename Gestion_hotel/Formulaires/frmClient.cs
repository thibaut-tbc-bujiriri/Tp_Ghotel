using Gestion_hotel.Classes;
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
