using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace voluntariado2.Utilities
{
    public class DBContextUtility
    {
        static string SERVER = "LV310";
        static string DB_NAME = "";
        static string DB_USER = "";
        static string DB_PASSWORD = "";

        static string Conn = "Server=LV310;Database=Voluntariado;Integrated Security=True;";
        //static string Conn = @"Data source=.\SQLEXPRESS;Initial catalog=users; Integrate security=true";

        //mi conexion:
        SqlConnection conn=new SqlConnection(Conn);

        //procedimiento que abre la conexion sqlserver
        public void Connect()
        {
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //procedimiento que cierra la conexion sqlserver
        public void Disconnect()
        {
            conn.Close();
        }

        //funcion que devuelve la conexion sqlserver
        public SqlConnection CONN()
        {
            return conn;
        }
    }
}