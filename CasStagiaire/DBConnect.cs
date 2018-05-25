using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using classesMetierStagiaires;
using MySql.Data.MySqlClient;
namespace CasStagiaire
{
    class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "cas_stagiaire";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public void SelectStagiaire(MSection laSection)
        {
            string query = "SELECT * FROM mstagiaire";

          
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    Boolean afpa = false;
                    MStagiaire nouveauStagiaire;
                    if (dataReader["type"].ToString() == "DE")
                    {
                        // instancier un stagiaire spécialisé DE et lui affecter toutes ses propriétés
                       if (dataReader["remu_afpa"].ToString() == "1")
                        {
                            afpa = true;
                        }


                        nouveauStagiaire = new MStagiaireDE(
                               int.Parse(dataReader["numosia"].ToString()),
                               dataReader["nom"].ToString(),
                                dataReader["prenom"].ToString(),
                                 dataReader["rue"].ToString(),
                                 dataReader["ville"].ToString(),
                                 dataReader["codepostal"].ToString(),
                                int.Parse(  dataReader["nbrenotes"].ToString()),
                                double.Parse(dataReader["pointsnotes"].ToString()),
                                 afpa);

                        laSection.Ajouter(nouveauStagiaire);
                        nouveauStagiaire = null;
                    }


                    if (dataReader["type"].ToString() == "CIF")
                    {
                        // instancier un stagiaire spécialisé DE et lui affecter toutes ses propriétés
                       

                        nouveauStagiaire = new MStagiaireCIF(
                               int.Parse(dataReader["numosia"].ToString()),
                               dataReader["nom"].ToString(),
                                dataReader["prenom"].ToString(),
                                 dataReader["rue"].ToString(),
                                 dataReader["ville"].ToString(),
                                 dataReader["codepostal"].ToString(),
                                  int.Parse(dataReader["nbrenotes"].ToString()),
                                double.Parse(dataReader["pointsnotes"].ToString()),
                                 dataReader["fongecif"].ToString(),
                                  dataReader["typecif"].ToString()

                                 );

                        laSection.Ajouter(nouveauStagiaire);
                        nouveauStagiaire = null;
                    }

                }
            

            //close Data Reader
            dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
              
            }
           
        }
        //Insert statement
        public void InsertStagiaire(MStagiaire st)
        {
            
            String type;
            String typecif;
            String fongecif;
            String remuafpa;

            string query = "INSERT INTO eleve VALUES(Null, @Nom, @Prenom,  @NumOsia, @Rue, @CodePostal, @Ville, @PointsNotes, @NbreNotes, @Type, @TypeCif, @FongeCif, @RemuAfpa)";

            if (st is MStagiaireCIF)
            {
                MStagiaireCIF st;
                type = "CIF";
                typecif = st.TypeCifStagiaire;
            }
            else
            {
                type = "DE";
            }

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.Parameters.AddWithValue("@Nom", st.NomStagiaire);
                cmd.Parameters.AddWithValue("@Prenom", st.PrenomStagiaire);
                cmd.Parameters.AddWithValue("@NumOsia", st.NumOsiaStagiaire);
                cmd.Parameters.AddWithValue("@Rue", st.RueStagiaire);
                cmd.Parameters.AddWithValue("@CodePostal", st.CodePostalStagiaire);
                cmd.Parameters.AddWithValue("@Ville", st.VilleStagiaire);
                cmd.Parameters.AddWithValue("@PointsNotes", st.PointsNotes);
                cmd.Parameters.AddWithValue("@NbreNotes", st.NbreNotes);
                cmd.Parameters.AddWithValue("@Type", type);
                cmd.Parameters.AddWithValue("@TypeCif", typecif);
                cmd.Parameters.AddWithValue("@FongeCif", fongecif);
                cmd.Parameters.AddWithValue("@RemuAfpa", remuafpa);
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Update statement
        public void UpdateEleve()
        {
            string query = "UPDATE eleve SET name='Joe', age='22' WHERE id='John Smith'";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Delete statement
        public void DeleteEleve(int id)
        {
            string query = "DELETE FROM eleve WHERE id=" + id;

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        //Select statement
        public DataSet SelectEleve()
        {
            string query = "SELECT * FROM eleve";



            DataSet ds = new DataSet(); ;
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                ds = new DataSet();
                adap.Fill(ds);



                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return ds;
            }
            return ds;
        }
        public DataSet SelectCours(int id)
        {
            string query = "SELECT * FROM cours  WHERE id=" + id;



            DataSet ds = new DataSet(); ;
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                ds = new DataSet();
                adap.Fill(ds);



                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return ds;
            }
            return ds;
        }
        public DataSet RechercheEleve(String nom)
        {
            string query = "SELECT * FROM eleve WHERE nom LIKE '%" + nom + "%'";



            DataSet ds = new DataSet();
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                ds = new DataSet();
                adap.Fill(ds);



                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return ds;
            }
            return ds;
        }
        //Count statement
        public int Count()
        {
            string query = "SELECT Count(*) FROM tableinfo";
            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }

        //Backup
        public void Backup()
        {
        }

        //Restore
        public void Restore()
        {
        }
        public static DBConnect conn = new DBConnect();

    }

}
