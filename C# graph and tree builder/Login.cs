using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace NEA_graph_and_tree_builder
{
    public partial class Login : Form
    {
        
        public Login()
        {
            InitializeComponent();
        }

        private void bttn_createLogin_Click(object sender, EventArgs e)
        {
            if (tb_username.Text != "" && tb_password.Text != "")        //checks to see if boxes are blank if not calls the addusername and addpassword functions
            {
                addpassword(); //calls the add password and add username functions

                addusername();
            }
            else
            {
                MessageBox.Show("one or more fields are empty"); //catches the error of an empty input box
            
            }






            
        }


        private void addpassword() //uses an Database connection and uses an SQL command to place the password in a database
        {
            try
            {
                OleDbConnection databaseconnection = new OleDbConnection(@"Provider=Microsoft.JET.OLEDB.4.0;Data Source=logins.mdb"); //creates database connection
                databaseconnection.Open();

                string q = "INSERT INTO tbl_Password ([Password]) values(@parameter1)"; //create an INSERT querey to the database

                OleDbCommand addpassword = new OleDbCommand(q, databaseconnection);
                addpassword.Parameters.Add(new OleDbParameter("@parameter1", tb_password.Text)); //adds the parameters to the query


                addpassword.ExecuteNonQuery(); //executes the querey 

                databaseconnection.Close();
            }
            catch
            { }
        }
        private void addusername() //uses an Database connection and uses an SQL command to place the username in a database
        {
            try
            {
                OleDbConnection databaseconnection = new OleDbConnection(@"Provider=Microsoft.JET.OLEDB.4.0;Data Source=logins.mdb");//creates database connection
                databaseconnection.Open();
                string q = "INSERT INTO tbl_Username ([Username],[Password]) values(@parameter1,@parameter2);";//create an INSERT querey to the database

                OleDbCommand addpassword = new OleDbCommand(q, databaseconnection);
                addpassword.Parameters.Add(new OleDbParameter("@parameter1", tb_username.Text));
                addpassword.Parameters.Add(new OleDbParameter("@parameter2", tb_password.Text));//adds the parameters to the query
                MessageBox.Show("Login sucessfully created");

                addpassword.ExecuteNonQuery(); //executes the querey 
                databaseconnection.Close();
            }
            catch { }
        }

        private void bttn_login_Click(object sender, EventArgs e)  //checks to see if boxes are empty else calls checklogin function
        {


            if (tb_username.Text != "" && tb_password.Text != "")
            {
                checklogin(); 

            }
            else
            {

                MessageBox.Show("one or more fields are empty"); //catches the error of an empty input box

            }

        }
        private void checklogin() //Creates a database connection and uses SQL commands to retrieve the username and password associated to check against the input username and password
        {
            OleDbConnection databaseconnection = new OleDbConnection(@"Provider=Microsoft.JET.OLEDB.4.0;Data Source=logins.mdb"); //creates a connection to the database 
            databaseconnection.Open();
            OleDbCommand searchusername = new OleDbCommand("SELECT Username FROM tbl_Username WHERE Username = @username AND tbl_Username.Password = @password", databaseconnection); //creates a select querey to the database for the password and username
            searchusername.Parameters.Add(new OleDbParameter("@username", tb_username.Text)); //adding the parameters
            searchusername.Parameters.Add(new OleDbParameter("@password", tb_password.Text));
            OleDbDataReader results = searchusername.ExecuteReader(); //executes querey
            if (results.HasRows)
            {
                MessageBox.Show("Welcome"); //outputs a confirmation message if the username and password are found
                this.Hide();
                frm_menu frm = new frm_menu();
                frm.Show();

            }
            else
            {
                MessageBox.Show("username or password is incorrect"); //returns a message if they cannot be found
            
            }
        }

       

       
    }
}
