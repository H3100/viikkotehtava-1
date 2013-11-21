using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AutentikointiDB
/// </summary>
public static class AutentikointiDB
{
    public static string ConnectionString;
    private static SqlConnection myConn;
    private static bool OpenMyConnection()
    {
        try
        {
            myConn = new SqlConnection(ConnectionString);
            myConn.Open();
            return true;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Print(ex.Message);
            return false;
        }
    }
    private static void CloseMyConnection()
    {
        try
        {
            if(myConn != null & myConn.State == System.Data.ConnectionState.Open)
                myConn.Close();
        }
        catch (Exception ex)
        {
           System.Diagnostics.Debug.Print(ex.Message);
        }
    }
    public static bool isUserNameInUse(string username)
    {
        try
        {
            bool loytyy = false;
            if (OpenMyConnection())
            {
                using (SqlCommand command = new SqlCommand("SELECT username FROM accounts WHERE username LIKE @Parametri", myConn))
                {
                    SqlParameter param = new SqlParameter("Parametri", SqlDbType.VarChar);
                    param.Value = username;
                    command.Parameters.Add(param);
                    using(SqlDataReader rdr = command.ExecuteReader())
                    {
                        if (rdr.Read())
                            loytyy = true;
                          // break;
                        else
                            loytyy = false;
                    }
                }
                CloseMyConnection();
                return loytyy;
            }
            else
            {
                throw new Exception("Cannot open myconnection to database");
            }
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    public static bool CreateNewUser(string username, string email, string password, bool hashPassword)
    {
        try
        {
            if (OpenMyConnection())
            {
                string passu = password;
                if (hashPassword)
                    passu = JAMK.ICT.Security.SHA256Hash.getSHA256Hash(passu);
                string sql = string.Format("INSERT INTO accounts VALUES ('{0}','{1}','{2}')", username, email, passu);
                SqlCommand command = new SqlCommand(sql, myConn);
                command.ExecuteNonQuery();
                CloseMyConnection();
                return true;
            }
            else
            {
                throw new Exception("Cannot open myconnection to database");
            }
        }
        catch (Exception ex)
        {
            
            throw;
        }
    }
    public static bool Login(string username, string password)
    {
        // Tarkistetaan käyttäjä ja salasana tietokannasta
        //Kannassa salasana on häshättynä
        // Vaarallinen takaovi, jota ei kannata jättää tuotantokoodiin!
        try
        {
            bool backdoorInUse = false;
            if (backdoorInUse)
            {
                if (username == "jack" && password == "russel")
                {
                    return true;
                }
            }
            // Varsinainen tarkistus tietokannasta
            // ensin "pöljän pojan tarkistus"
            if (username.Length * password.Length == 0)
            {
                throw new Exception("Eipä yritetä tuollaisia");
            }
            else
            {
                // Häshätään käyttäjän antama password
                string hashattyPwd = JAMK.ICT.Security.SHA256Hash.getSHA256Hash(password);
                //Kokeillaan tietokannasta
                if (OpenMyConnection())
                {
                    username += "%";
                    string sqlQuery = @"SELECT count(*) FROM accounts WHERE username LIKE @Parametri AND hashedPassword LIKE @Password";
                    SqlCommand command = new SqlCommand(sqlQuery, myConn);

                    //Lisätään komennolle kaksi parametria
                    SqlParameter param = new SqlParameter("Parametri", SqlDbType.VarChar);
                    param.Value = username;
                    command.Parameters.Add(param);

                    SqlParameter param2 = new SqlParameter("Password", SqlDbType.VarChar);
                    hashattyPwd += "%";
                    param2.Value = hashattyPwd;
                    command.Parameters.Add(param2);

                    //Suoritetaan kysely kantaan
                    int i = (int)command.ExecuteScalar();
                    if (i == 1)
                        return true;
                    else
                        return false;
                }
                else
                {
                    return false;
                }
            }
            //return false;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Print(ex.Message);
            return false;
        }

    }
}