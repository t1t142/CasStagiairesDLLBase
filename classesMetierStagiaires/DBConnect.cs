using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;
using classesMetierStagiaires;
using MySql.Data.MySqlClient;
namespace classesMetierStagiaires
{
    public class DBConnect
    {

        private static MySqlConnection cnx = null;
      

        public static MySqlConnection GetConnexion()
        {
          
        string server="localhost";
        string database="cas_stagiaire";
        string uid="root";
        string password="";

              string connectionString;
              connectionString = "SERVER=" + server + ";" + "DATABASE=" +
              database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

          
            if (cnx == null)
            {
                try
                {
                    cnx = new MySqlConnection();
                    cnx.ConnectionString = connectionString;

                    cnx.Open();

                }
                catch (MySqlException ex)
                {
                    //When handling errors, you can your application's response based 
                    //on the error number.
                    //The two most common error numbers when connecting are as follows:
                    //0: Cannot connect to server.
                    //1045: Invalid user name and/or password.
                    /*switch (ex.Number)
                    {
                        case 0:
                            MessageBox.Show("Cannot connect to server.  Contact administrator");
                            break;

                        case 1045:
                            MessageBox.Show("Invalid username/password, please try again");
                            break;

                           
                    }*/
                 
                }
            }
                 
         return cnx;
        }

        public static void CloseConnexion()
        {
            try
            {
                cnx.Close();
                cnx = null;
            }
            catch (MySqlException ex)
            {
               // MessageBox.Show(ex.Message);
               
            }

        }
 
       
        //Insert statement
       
        
    }
}
