using System;
using System.Data.SqlClient;
using voluntariado2.Models;
using voluntariado2.Utilities;

namespace voluntariado2.Repositories
{
    public class UserRepository
    {
        public bool CreateUser(UserModel userModel) {
            bool result = false;
            DBContextUtility connection = new DBContextUtility();
            connection.Connect();
            //conexion sql
            String SQL = "INSERT INTO TEST.dbo.[user] (id_role,name,username,password)"
                + "Values (" + userModel.IdRol + ",'" + userModel.Name + "','" + userModel.UserName
                + "','" + userModel.Password + "');";
            using (SqlCommand command = new SqlCommand(SQL, connection.CONN()))
            {
                int comando = command.ExecuteNonQuery();
                if (comando == 1)
                {
                    result= true;
                }
                else
                {
                    result = false;
                }
            }
            connection.Disconnect();
            return result;
        }
            
    }
}