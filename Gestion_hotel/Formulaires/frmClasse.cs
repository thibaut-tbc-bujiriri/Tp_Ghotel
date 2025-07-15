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
    public partial class frmClasse : Form
    {
        public frmClasse()
        {
            InitializeComponent();
        }

        ClsClasse cl = new ClsClasse();

        public void saveClasse(int a)
        {
            cl.Designation = txtDesignClasse.Text;
            cl.Prix = double.Parse(txtPrixClasse.Text);
            cl.RefCategorisation = int.Parse(ClsGlossaire.GetInstance().getcode_Combo("Categorisation", "id", "desgnation", cmbRefCatClasse.Text));

            if (a == 1)
            {
                cl.Id = -1;
                ClsGlossaire.GetInstance().SaveClasse(cl);
                dgvClasse.DataSource = ClsGlossaire.GetInstance().loadData("Classe");
            }
            else if (a == 2)
            {
                cl.Id = int.Parse(txtIdClasse.Text);
                ClsGlossaire.GetInstance().SaveClasse(cl);
                dgvClasse.DataSource = ClsGlossaire.GetInstance().loadData("Classe");
            }
            else if (a == 3)
            {
                ClsGlossaire.GetInstance().DeleteData("Classe", "id", int.Parse(txtIdClasse.Text));
                dgvClasse.DataSource = ClsGlossaire.GetInstance().loadData("Classe");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmClasse_Load(object sender, EventArgs e)
        {
            dgvClasse.DataSource = ClsGlossaire.GetInstance().loadData("Classe");
            ClsGlossaire.GetInstance().loadCombo("Categorisation", "desgnation", cmbRefCatClasse);
        }

        private void btnAddClasse_Click(object sender, EventArgs e)
        {
            saveClasse(1);
        }

        private void btnModClasse_Click(object sender, EventArgs e)
        {
            saveClasse(2);
        }

        private void btnDeleteClasse_Click(object sender, EventArgs e)
        {
            saveClasse(3);
        }

        private void btnActClasse_Click(object sender, EventArgs e)
        {
            txtIdClasse.Text = "";
            txtDesignClasse.Text = "";
            txtPrixClasse.Text = "";
            cmbRefCatClasse.Text = "";
        }

        private void dgvClasse_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                DataGridViewRow row = dgvClasse.Rows[e.RowIndex];
                txtIdClasse.Text = row.Cells["id"].Value.ToString();
                txtDesignClasse.Text = row.Cells["designation"].Value.ToString();
                txtPrixClasse.Text = row.Cells["prix"].Value.ToString();
                cmbRefCatClasse.Text = row.Cells["refCategorisation"].Value.ToString();
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
