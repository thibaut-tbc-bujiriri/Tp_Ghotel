using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_hotel.Classes
{
    internal class ClsGlossaire
    {
        public static ClsGlossaire _instance = null;

        public static ClsGlossaire GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ClsGlossaire();
            }
            return _instance;
        }

        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataAdapter dt = null;
        SqlDataReader dr = null;

        public void InitialiseConnexion()
        {
            try
            {
                con = new SqlConnection(ClsConnexion.Way);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de Connexion " + ex.Message);
            }

        }

        //INSERTIONS

        public void SaveClient(ClsClient Cli)
        {
            try
            {
                InitialiseConnexion();
                con.Open();
                cmd = new SqlCommand("EXEC saveClient @id, @nom,@adresse,@contact", con);
                cmd.Parameters.AddWithValue("@id", Cli.Id);
                cmd.Parameters.AddWithValue("@Nom", Cli.Noms);
                cmd.Parameters.AddWithValue("@Adresse", Cli.Adresse);
                cmd.Parameters.AddWithValue("@Contact", Cli.Contact);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SaveCategorisation(ClsCategorisation Cli)
        {
            try
            {
                InitialiseConnexion();
                con.Open();
                cmd = new SqlCommand("EXEC saveCategorisation @id,@desgnation", con);
                cmd.Parameters.AddWithValue("@id", Cli.Id);
                cmd.Parameters.AddWithValue("@desgnation", Cli.Desgnation);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SaveReservation(ClsReservation Cli)
        {
            try
            {
                InitialiseConnexion();
                con.Open();
                cmd = new SqlCommand("EXEC saveReservation @id,@refClient,@refChabre,@dateEntree", con);
                cmd.Parameters.AddWithValue("@id", Cli.Id);
                cmd.Parameters.AddWithValue("@refClient", Cli.RefClient);
                cmd.Parameters.AddWithValue("@refChabre", Cli.RefChabre);
                cmd.Parameters.AddWithValue("@dateEntree", Cli.DateEntree);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SaveChambre(ClsChambre Cli)
        {
            try
            {
                InitialiseConnexion();
                con.Open();
                cmd = new SqlCommand("EXEC saveChambre @id,@numero,@contact,@refClasse", con);
                cmd.Parameters.AddWithValue("@id", Cli.Id);
                cmd.Parameters.AddWithValue("@numero", Cli.Numero);
                cmd.Parameters.AddWithValue("@contact", Cli.Contact);
                cmd.Parameters.AddWithValue("@refClasse", Cli.RefClasse);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SaveClasse(ClsClasse Cli)
        {
            try
            {
                InitialiseConnexion();
                con.Open();
                cmd = new SqlCommand("EXEC saveClasse @id,@designation,@prix,@refCategorisation", con);
                cmd.Parameters.AddWithValue("@id", Cli.Id);
                cmd.Parameters.AddWithValue("@designation", Cli.Designation);
                cmd.Parameters.AddWithValue("@prix", Cli.Prix);
                cmd.Parameters.AddWithValue("@refCategorisation", Cli.RefCategorisation);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public DataTable loadData(string nomTable)
        {

            InitialiseConnexion();
            if (!con.State.ToString().ToLower().Equals("open")) con.Open();
            DataTable table = new DataTable();
            dt = new SqlDataAdapter("select * from " + nomTable + "", con);
            dt.Fill(table);
            con.Close();

            return table;
        }

        //DELETE
        public void DeleteData(string nomTale, string champId, int id)
        {
            try
            {
                InitialiseConnexion();
                con.Open();
                cmd = new SqlCommand("delete from " + nomTale + " where " + champId + " = @Id", con);
                cmd.Parameters.AddWithValue("@Nom", id);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //CHARGEMENT DES COMBOBOX
        public void loadCombo(string nomTable, string nomchamp, System.Windows.Forms.ComboBox comb1)
        {
            InitialiseConnexion();
            if (!con.State.ToString().ToLower().Equals("open")) con.Open();
            DataTable table = new DataTable();
            dt = new SqlDataAdapter("SELECT " + nomchamp + " FROM " + nomTable + "", con);
            try
            {
                DataTable dt1 = new DataTable();
                dt.Fill(dt1);

                foreach (DataRow dr in dt1.Rows)
                {
                    comb1.Items.Add(dr[nomchamp]);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur" + ex);
            }

            con.Close();
        }

        //ACCEDER AUS COMBOBOX

        public string getcode_Combo(string nomTable, string nomChampId, string nomChamp, string valeur)
        {
            string IdData = "";
            try
            {
                InitialiseConnexion();
                if (!con.State.ToString().ToLower().Equals("open")) con.Open();
                cmd = new SqlCommand("select " + nomChampId + " from " + nomTable + " where " + nomChamp + "=@a", con);
                cmd.Parameters.AddWithValue("@a", valeur);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    IdData = (dr[nomChampId].ToString());
                }
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return IdData;
        }

    }
}
