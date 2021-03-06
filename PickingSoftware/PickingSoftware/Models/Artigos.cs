using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlServerCe;

namespace PickingSoftware.Models
{
    public class Artigos
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Cod_Barras { get; set; }

        public static List<Artigos> GetArtigos()
        {
            SqlCeConnection con =
                new SqlCeConnection(@"DataSource=|DataDirectory|\Picking.sdf");
            con.Open();
            string query = "SELECT * FROM Artigos";
            SqlCeCommand cmd = new SqlCeCommand(query, con);
            SqlCeDataReader dr = cmd.ExecuteReader();

            List<Artigos> _tst = new List<Artigos>();
            while (dr.Read())
            {
                _tst.Add(new Artigos
                {
                    ID = (int)dr["ID"],
                    Nome = dr["Nome"].ToString(),
                    Cod_Barras = dr["Cod_Barras"].ToString()
                });
            }
            return _tst;
        }
    }
}