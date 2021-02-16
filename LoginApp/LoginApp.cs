using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LoginApp
{
    public partial class LoginApp : Form
    {
        SqlConnection conn;
        SqlCommand query;
        SqlDataReader dataReader;

        public LoginApp()
        {
            InitializeComponent();
        }

        private String username, password,sqlquery,response;
        private bool AWS_Button_Checked, GCP_Button_Checked, Azure_Button_Checked;
        private void Login_Button_Click(object sender, EventArgs e)
        {
            username = Username_TxtBox.Text;
            password = Password_TxtBox.Text;

            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = "Data Source=database-3.cjdjsdhihrxl.us-east-1.rds.amazonaws.com,1433;Initial Catalog=UserDetails;User ID=Jayshil;Password=yjayshil";
                conn.Open();
                sqlquery = $"select count(username) from Userdata where username={username} and password={password};";
                query = new SqlCommand(sqlquery,conn);
                dataReader = query.ExecuteReader();
                while (dataReader.Read())
                {
                    response = response + dataReader.GetValue(0);
                }
                if (response != "0")
                {
                    MessageBox.Show("Login Successful");
                }
                else
                {
                    MessageBox.Show("User not Found Please Register");
                }

                // LOAD Fingerprint
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        


    }
}
