using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WPF_SQL
{
    public class clMedium
    {
        private string vnaam, tnaam, anaam, adres, postcode, plaats, land, opmerking;
        private DateTime geboortedatum, inschrijfdatum;
        private int gebrnr;

        public int GEBRNR
        {
            get { return gebrnr; }
        }

        public string VNAAM
        {
            get { return vnaam; }
            set { vnaam = value; }
        }

        public string TNAAM
        {
            get { return tnaam; }
            set { tnaam = value; }
        }

        public string ANAAM
        {
            get { return anaam; }
            set { anaam = value; }
        }

        public string ADRES
        {
            get { return adres; }
            set { adres = value; }
        }

        public string POSTCODE
        {
            get { return postcode; }
            set { postcode = value; }
        }

        public string LAND
        {
            get { return land; }
            set { land = value; }
        }

        public string OPMERKING
        {
            get { return opmerking; }
            set { opmerking = value; }
        }

        public DateTime GEBOORTEDATUM
        {
            get { return geboortedatum; }
            set { geboortedatum = value; }
        }

        public DateTime INSCHRIJFDATUM
        {
            get { return inschrijfdatum; }
            set { inschrijfdatum = value; }
        }

        public DataTable SelectAll()
        {
            string SQL = "Select * from Gebruikers";
            return clDatabase.ExecuteSelect(SQL);
        }

        public void SelectByID(int Zoek)
        {
            string SQL = "Select * from Gebruikers where Gebrnr =";
            SQL += Zoek;
            DataTable DT = clDatabase.ExecuteSelect(SQL);
            if (DT.Rows.Count == 0)
            {
                gebrnr = -1;
            }
            else
            {
                gebrnr = (int)(DT.Rows[0]["Gebrnr"]);
                vnaam = (string)(DT.Rows[0]["Vnaam"]);
                tnaam = (string)(DT.Rows[0]["Tnaam"]);
                anaam = (string)(DT.Rows[0]["Anaam"]);
                adres = (string)(DT.Rows[0]["Adres"]);
                postcode = (string)(DT.Rows[0]["Postcode"]);
                plaats = (string)(DT.Rows[0]["Plaats"]);
                geboortedatum = (DateTime)(DT.Rows[0]["Geboorte"]);
                inschrijfdatum = (DateTime)(DT.Rows[0]["Inschrijf"]);
            }
        }

        public bool AddRecord()
        {
            string SQL;
            SQL = "insert into Gebruikers (Vnaam, Tnaam, Anaam, Adres,";
            SQL += "Postcode, Plaats, Geboorte, Inschrijf)";
            SQL += "values (";
            SQL += "'" + vnaam + "',";
            SQL += "'" + tnaam + "',";
            SQL += anaam + ",";
            SQL += adres + ",";
            SQL += "'" + postcode + "',";
            SQL += "'" + plaats + "',";
            SQL += "'" + geboortedatum + "', getdate(),";
            SQL += "'" + inschrijfdatum + "', getdate()";
            SQL += ")";
            return clDatabase.ExecuteCommand(SQL);
        }
    }
}
