using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WPF_SQL
{
    class clDatabase
    {
        // 2 methodes:
        // - Lezen uit database
        // - Uitvoeren ander command (update, insert, delete)

        public static DataTable ExecuteSelect(string SQL)
        {
            // Aanmaken van dataset
            // Hierin komt de uitvoer (=dynaset) van de query
            DataSet DS = new DataSet();

            // Aanmaken dataAdapter
            // Deze zorgt voor de vertaling van SQL naar C#
            // Denk maar aan een soort tolk
            SqlDataAdapter DA;

            // Het configureren van de dataAdapter
            DA = new SqlDataAdapter(SQL, clStam.Connstr);

            // Voordat je een dataset gaat gebruiken moet je deze leegmaken
            DS.Clear();

            // Gebruik de dataAdapter om de dataset te vullen
            DA.Fill(DS);

            // Pak uit de dataset de EERSTE tabel omdat de dataset leeg was, is dit het resultaat van de query
            DataTable DT = DS.Tables[0];

            // Geef de datatable terug
            return DT;
        }

        public static bool ExecuteCommand(string SQLInstructie)
        {
            bool retour = true;
            SqlConnection Conn = new SqlConnection(clStam.Connstr);
            SqlCommand Cmd = new SqlCommand(SQLInstructie, Conn);
            try
            {
                Cmd.Connection.Open();
                Cmd.ExecuteNonQuery();
            }
            catch
            {
                retour = false;
            }
            finally
            {
                Conn.Close();
            }
            return retour;
        }
    }
}
