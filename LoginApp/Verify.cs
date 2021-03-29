using DPFP;
using DPFP.Capture;
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
using System.IO;

namespace LoginApp
{
    public partial class Verify : Form, DPFP.Capture.EventHandler
    {
        //Initialisation
        string sqlquery = String.Empty, response = "";
        SqlConnection conn;
        SqlCommand query;
        SqlDataReader dataReader;
        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        string password = "";
        public Verify(string p)
        {
            password = p;
            InitializeComponent();
        }

        public void OnComplete(object Capture, string ReaderSerialNumber, Sample Sample)
        {
            throw new NotImplementedException();
        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            throw new NotImplementedException();
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            throw new NotImplementedException();
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            throw new NotImplementedException();
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            throw new NotImplementedException();
        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, CaptureFeedback CaptureFeedback)
        {
            throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection();
            conn.ConnectionString = "Data Source=database-3.cjdjsdhihrxl.us-east-1.rds.amazonaws.com,1433;Initial Catalog=UserDetails;User ID=Jayshil;Password=yjayshil";
            conn.Open();
            Console.WriteLine(password);
            sqlquery = $"select * from Templates where secretkey='{password}' and ID=2;";
            query = new SqlCommand(sqlquery, conn);
            dataReader = query.ExecuteReader();
            string[] values = new string[12];
            while (dataReader.Read())
            {
                byte[] b;
                for (int i = 2; i < 10; i++)
                {
                    b = Convert.FromBase64String(dataReader.GetValue(i).ToString().Replace("\n",""));
                    values[i] = System.Text.Encoding.UTF8.GetString(b);
                }
                b = Convert.FromBase64String(dataReader.GetValue(0).ToString());
                values[0] = System.Text.Encoding.UTF8.GetString(b);
                values[1] = dataReader.GetValue(1).ToString();
                values[11] = dataReader.GetValue(11).ToString();

            }
            dataReader.Close();
            query.Dispose();
            conn.Close();
            string[] keys = { values[2],values[3],values[4],values[5],values[6],values[7],values[8],values[9],values[10] };
            PythonScript obj = new PythonScript();

            //File.WriteAllText("D:\\d.txt", values[0]);
            response = obj.run_algo_decrypt("decrypt",keys, values[1],values[0]);
            File.WriteAllText("D:\\results.txt", response,Encoding.UTF8);
            MessageBox.Show("Done");
        }
    }
}
