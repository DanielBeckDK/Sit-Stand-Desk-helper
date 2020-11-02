using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO.Ports;
using System.Management;

namespace DeskBuddyApplication
{
    public partial class DeskBuddyForm : Form
    {       

        private string dbComPort; 
      //private SerialPort myPort = new SerialPort("COM3", 115200, Parity.None, 8, StopBits.One); //A new port object to receive distance data from the DeskBuddy
        private SerialPort myPort;
        private string dataIn; //String variable to hold the distance data received from the DeskBuddy
        private DateTime dt; //DateTime variable to timestamp the received distance data

        private static string cnString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\Daniel\Desktop\OneDrive\Kea ITT\Afsluttende projekt\Pc software kode\DeskBuddyApplication\DeskBuddyApplication\Database1.mdf';Integrated Security=True";


        private SqlConnection dbConnection = new SqlConnection(cnString);
        private SqlDataAdapter adapter = new SqlDataAdapter();

        private string RedValue;
        private string GreenValue;
        private string BlueValue;

        private string combinedValue;


        public DeskBuddyForm()
        {
            InitializeComponent();
            comboBoxChartRange.SelectedItem = "Day"; //Set the comboBox to initialize with Hour as the chosen option

            dbComPort = AutodetectDeskBuddyPort();
            if (dbComPort != null)
            {
                myPort = new SerialPort(dbComPort, 115200, Parity.None, 8, StopBits.One);

                myPort.DataReceived += MyPort_DataReceived;
                try
                {
                    myPort.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error opening port");
                }

            }
        }

        private void MyPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            dataIn = myPort.ReadLine();

            dt = DateTime.Now;
            dbConnection.Open();

            using (var insertCmd = new SqlCommand(@"INSERT INTO Measurements (Distance,DateTime) VALUES (@Distance,@DateTime)", dbConnection))
            {
                insertCmd.Parameters.Add("@Distance", SqlDbType.VarChar).Value = dataIn;
                insertCmd.Parameters.Add("@DateTime", SqlDbType.DateTime).Value = dt;

                insertCmd.ExecuteNonQuery();
            }

            dbConnection.Close();
        }

        private void buttonColorAction_Click(object sender, EventArgs e) //Method that listens for an event, in this instance a click event, executes when buttonColorAction is clicked
        {

            colorDialogAction.ShowDialog(); //Show the coloroptions window when button is clicked

            pictureBoxActionColor.BackColor = colorDialogAction.Color; //Changes the background color of a picturebox to allow the user to see the chosen color

            Color actionColor = colorDialogAction.Color;

            RedValue = actionColor.R.ToString();
            GreenValue = actionColor.G.ToString();
            BlueValue = actionColor.B.ToString();

            combinedValue = RedValue + "-" + GreenValue + "-" + BlueValue;
            myPort.WriteLine("<9" + combinedValue + ">");

        }

        private void buttonColorStay_Click(object sender, EventArgs e)
        {
            colorDialogStay.ShowDialog();
            
            pictureBoxStayColor.BackColor = colorDialogStay.Color;

            Color stayColor = colorDialogAction.Color;

            RedValue = stayColor.R.ToString();
            GreenValue = stayColor.G.ToString();
            BlueValue = stayColor.B.ToString();

            combinedValue = RedValue + "-" + GreenValue + "-" + BlueValue;
            myPort.WriteLine("<7" + combinedValue + ">");
        }

        private void comboBoxChartRange_SelectedIndexChanged(object sender, EventArgs e) //Method that listens for, and executes when the comboBox selected item changes
        {

            if (comboBoxChartRange.Text == "Hour") //Executes the containing code when the user selects hour with the comboBox
            {
                List<DateTime> dates = new List<DateTime>();
                using (SqlCommand selectCmd = new SqlCommand("SELECT * FROM Measurements where DateTime between 11/27/2019 And 11/27/2019", dbConnection))
                {
                    dbConnection.Open();
                    using (SqlDataReader reader = selectCmd.ExecuteReader())
                    {
                        // Check is the reader has any rows at all before starting to read.
                        if (reader.HasRows)
                        {
                            // Read advances to the next row.
                            while (reader.Read())
                            {
                                DateTime sdate = new DateTime();
                                sdate = reader.GetDateTime(reader.GetOrdinal("DateTime"));      
                                dates.Add(sdate);
                                textBox1.AppendText(sdate.ToString());
                            }
                        }
                    }
                }
                //chartPositions.Series["Sitting"].Points.Clear();
                //chartPositions.Series["Standing"].Points.Clear();
                //chartPositions.ChartAreas[0].AxisX.Title = "Time spent in either position";
                //chartPositions.ChartAreas[0].AxisY.Title = "Minutes";
                //chartPositions.Series["Sitting"].Points.AddXY("", "100");
                //chartPositions.Series["Standing"].Points.AddXY("", "80");
            }
            if (comboBoxChartRange.Text == "Day")
            {


            }
            else if (comboBoxChartRange.Text == "Week")
            {

            }
            else if (comboBoxChartRange.Text == "Month")
            {

            }
            else if (comboBoxChartRange.Text == "Year")
            {

            }
        }

        private string AutodetectDeskBuddyPort()
        {

            ManagementScope connectionScope = new ManagementScope();
            SelectQuery serialQuery = new SelectQuery("SELECT * FROM Win32_SerialPort");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(connectionScope, serialQuery);

            try
            {
                foreach (ManagementObject item in searcher.Get())
                {
                    string desc = item["Description"].ToString();
                    string deviceId = item["DeviceID"].ToString();

                    if (desc.Contains("Silicon Labs CP210x USB to UART Bridge"))
                    {
                        return deviceId;
                    }
                }
            }
            catch (ManagementException e)
            {
                MessageBox.Show(e.Message, "The Device does not seem to be connected");
            }

            return null;
        }

        private void DeskBuddyForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.Measurements' table. You can move, or remove it, as needed.
            this.measurementsTableAdapter.Fill(this.database1DataSet.Measurements);

        }
    }
}
