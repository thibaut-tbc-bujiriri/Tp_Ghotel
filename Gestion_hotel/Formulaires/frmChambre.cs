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
    public partial class frmChambre : Form
    {
        public frmChambre()
        {
            InitializeComponent();
        }

        ClsChambre ch = new ClsChambre();

        public void saveChambre(int a)
        {
            ch.Numero = int.Parse(txtNumChambre.Text);
            ch.Contact = txtContChambre.Text;
            ch.RefClasse = int.Parse(ClsGlossaire.GetInstance().getcode_Combo("Classe", "id", "designation", cmbRefClasseChambre.Text));

            if (a == 1)
            {
                try
                {
                    if (txtNumChambre.Text == "" || txtContChambre.Text == "" || cmbRefClasseChambre.Text == "")
                    {
                        MessageBox.Show("Veuillez remplir tous les champs", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        ch.Id = -1;
                        MessageBox.Show("Chambre Ajoutée avec succès", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClsGlossaire.GetInstance().SaveChambre(ch);
                        dgvChambre.DataSource = ClsGlossaire.GetInstance().loadData("Chambre");
                    }
                }catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            else if (a == 2)
            {
                if (txtNumChambre.Text == "" || txtContChambre.Text == "" || cmbRefClasseChambre.Text == "")
                {
                    MessageBox.Show("Veuillez remplir tous les champs", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ch.Id = int.Parse(txtIdChambre.Text);
                    MessageBox.Show("Chambre modifiée avec succès", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClsGlossaire.GetInstance().SaveChambre(ch);
                    dgvChambre.DataSource = ClsGlossaire.GetInstance().loadData("Chambre");
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChambre_Load(object sender, EventArgs e)
        {
            dgvChambre.DataSource = ClsGlossaire.GetInstance().loadData("Chambre");
            ClsGlossaire.GetInstance().loadCombo("Classe", "designation", cmbRefClasseChambre);
        }

        private void btnActChambre_Click(object sender, EventArgs e)
        {
            txtIdChambre.Text = "";
            txtNumChambre.Text = "";
            txtContChambre.Text = "";
            cmbRefClasseChambre.Text = "";
        }

        private void btnAddChambre_Click(object sender, EventArgs e)
        {
            saveChambre(1);
        }

        private void btnModChambre_Click(object sender, EventArgs e)
        {
            saveChambre(2);
        }

        private void dgvChambre_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvChambre.Rows[e.RowIndex];
                txtIdChambre.Text = row.Cells["id"].Value.ToString();
                txtNumChambre.Text = row.Cells["numero"].Value.ToString();
                txtContChambre.Text = row.Cells["contact"].Value.ToString();
                cmbRefClasseChambre.Text = row.Cells["refClasse"].Value.ToString();
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
