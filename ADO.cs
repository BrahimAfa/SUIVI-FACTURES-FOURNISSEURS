﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace SUIVI_FACTURES_FOURNISSEURS
{
    public class ADO
    {
        private static string conString = @"Initial catalog=GF; Data source=.\SQLExpress; Integrated Security=True";
        private static SqlConnection con = new SqlConnection(conString);
        private static SqlCommand cmd = new SqlCommand("", con);
        private static SqlDataReader dr;

        public static bool Login(string centre, string user, string password)
        {
            bool isValid = false;

            string req = string.Format("select * from [User] where ville = '{0}' and name_user = '{1}' and password = '{2}'",
                                       centre, user, password);

            cmd.CommandText = req;

            con.Open();

            dr = cmd.ExecuteReader();
            
            isValid = dr.HasRows

            dr.Close();
            con.Close();

            return isValid;
        }
    }
}
