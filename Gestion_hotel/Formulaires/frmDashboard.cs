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
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            frmClient cl = new frmClient();
            PnlMenu.Visible = false;
            cl.ShowDialog();
            PnlMenu.Visible = true;
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            frmReservation res = new frmReservation();
            PnlMenu.Visible = false;
            res.ShowDialog();
            PnlMenu.Visible = true;
        }

        private void btnChambre_Click(object sender, EventArgs e)
        {
            frmChambre ch = new frmChambre();
            PnlMenu.Visible = false;
            ch.ShowDialog();
            PnlMenu.Visible = true;
        }

        private void btnClasse_Click(object sender, EventArgs e)
        {
            frmClasse cl = new frmClasse();
            PnlMenu.Visible = false;
            cl.ShowDialog();
            PnlMenu.Visible = true;
        }

        private void btnCategorisation_Click(object sender, EventArgs e)
        {
            frmCategorisation cat = new frmCategorisation();
            PnlMenu.Visible = false;
            cat.ShowDialog();
            PnlMenu.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPnlMenu_Click(object sender, EventArgs e)
        {
            if (PnlMenu.Visible)
            {
                PnlMenu.Visible = false;
            }
            else
            {
                PnlMenu.Visible = true;
            }
        }
    }
}
