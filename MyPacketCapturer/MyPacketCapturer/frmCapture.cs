using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PacketDotNet;
using SharpPcap;

namespace MyPacketCapturer
{
    public partial class frmCapture : Form
    {
        CaptureDeviceList devices; //List of devices for this computer
        public static ICaptureDevice device; //Device to be used
        public static string stringPackets = ""; //Data that is captured
        static int numPackets = 0;
        frmSend fSend; //Send form

        public frmCapture()
        {
            InitializeComponent();

            //Get the list of devices
            devices = CaptureDeviceList.Instance;


            //Make sure that there is at least one device
            if(devices.Count < 1)
            {
                MessageBox.Show("No Capture Devices Found");
                Application.Exit();
            }

            //Add devices to combo box
            foreach(ICaptureDevice dev in devices)
            {
                cmbDevices.Items.Add(dev.Description);
            }

            //Get the second device and displpay in combo box
            device = devices[3];
            cmbDevices.Text = device.Description;

            //Register our handler function to the 'packet arrival' event
            device.OnPacketArrival += new SharpPcap.PacketArrivalEventHandler(device_OnPacketArrival);

            //Open the device for capturing
            int readTimeoutMiliseconds = 1000;
            device.Open(DeviceMode.Promiscuous, readTimeoutMiliseconds);

        }

        private static void device_OnPacketArrival(object sender, CaptureEventArgs packet)
        {
            //Increments the number of packets captured
            numPackets++;

            //Put the packet number in the capture window
            stringPackets += "Packet number: " + numPackets;
            stringPackets += Environment.NewLine;

            //Parsing the packets


            //Array to store our data
            byte[] data = packet.Packet.Data;

            //Keep track of number of bytes displayed per line
            int byteCounter = 0;

            stringPackets += "Destination MAC Address: ";
            //Parsing the packets
            foreach(byte b in data)
            {
                //Add byte to our string in hex
                if(byteCounter <=13) stringPackets += b.ToString("x2") + " ";
                byteCounter++;

                switch (byteCounter)
                {
                    case 6: stringPackets += Environment.NewLine;
                        stringPackets += "Source MAC Address: ";
                        break;
                    case 12:
                        stringPackets += Environment.NewLine;
                        stringPackets += "EtherType: ";
                        break;
                    case 14: if (data[12] == 8)
                        {
                            if (data[13] == 0) stringPackets += "(IP)";
                            if (data[13] == 6) stringPackets += "(ARP)";
                        }
                        //stringPackets += Environment.NewLine;
                        break;
                }
            }

            stringPackets += Environment.NewLine;
            stringPackets += Environment.NewLine;

            byteCounter = 0;
            stringPackets += "Raw Data" + Environment.NewLine;

            //Process each byte in our capture packet
            foreach (byte b in data)
            {
                //Add byte to our string in hex
                stringPackets += b.ToString("x2") + " ";
                byteCounter++;

                if (byteCounter == 16)
                {
                    byteCounter = 0;
                    stringPackets += Environment.NewLine;
                }
            }
            stringPackets += Environment.NewLine;
            stringPackets += Environment.NewLine;
        }

        

        private void txtCaptureData_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            try
            {
                if(btnStartStop.Text == "Start")
                {
                    device.StartCapture();
                    timer1.Enabled = true;
                    btnStartStop.Text = "Stop";
                } 
                else
                {
                    device.StopCapture();
                    timer1.Enabled = false;
                    btnStartStop.Text = "Start";
                }
            }
            catch(Exception exc)
            {

            }
        }

        //Dump packet data from stringPackets to text box
        private void timer1_Tick(object sender, EventArgs e)
        {
            txtCaptureData.AppendText(stringPackets);
            stringPackets = "";
            txtNumPackets.Text = Convert.ToString(numPackets);
        }

        private void cmbDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            device = devices[cmbDevices.SelectedIndex];
            cmbDevices.Text = device.Description;

            //Register our handler function to the 'packet arrival' event
            device.OnPacketArrival += new SharpPcap.PacketArrivalEventHandler(device_OnPacketArrival);

            //Open the device for capturing
            int readTimeoutMiliseconds = 1000;
            device.Open(DeviceMode.Promiscuous, readTimeoutMiliseconds);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text Files|*.txt|All Files|*.*";
            saveFileDialog1.Title = "Save the Captured Packets";
            saveFileDialog1.ShowDialog();

            //Check to see if file name was given
            if (saveFileDialog1.FileName != "")
            {
                System.IO.File.WriteAllText(saveFileDialog1.FileName, txtCaptureData.Text);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text Files|*.txt|All Files|*.*";
            openFileDialog1.Title = "Open the Captured Packets";
            openFileDialog1.ShowDialog();

            //Check to see if file name was given
            if (openFileDialog1.FileName != "")
            {
                txtCaptureData.Text = System.IO.File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void sendWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSend.instantiations < 1) //only one may open at a time
            {
                fSend = new frmSend();
                fSend.Show();
            }
        }
    }
}
