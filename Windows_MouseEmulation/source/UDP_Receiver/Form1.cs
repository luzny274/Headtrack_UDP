using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Reflection;
using System.IO;

namespace UDP_Receiver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private Socket serverSocket = null;
        private List<EndPoint> clientList = new List<EndPoint>();
        private byte[] byteData = new byte[1024];

        volatile bool running = false;
        bool first = true;


        volatile int selectedX;
        volatile int selectedY;

        volatile bool invertedX;
        volatile bool invertedY;

        volatile int sensitivityX;
        volatile int sensitivityY;

        private void run()
        {
            portNumber.Enabled = false;
            running = true;
            first = true;
            this.serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            this.serverSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            this.serverSocket.Bind(new IPEndPoint(IPAddress.Any, (int)portNumber.Value));
            EndPoint newClientEP = new IPEndPoint(IPAddress.Any, 0);

            this.serverSocket.BeginReceiveFrom(this.byteData, 0, this.byteData.Length, SocketFlags.None, ref newClientEP, DoReceiveFrom, newClientEP);

        }

        private void stop()
        {
            portNumber.Enabled = true;
            running = false;
            this.serverSocket.Close();
        }

        double[] befVals = new double[3];
        double[] vals = new double[3];

        private void DoReceiveFrom(IAsyncResult iar)
        {
            try{
                EndPoint clientEP = new IPEndPoint(IPAddress.Any, 0);
                int dataLen = 0;
                byte[] data = null;
                try{
                    dataLen = this.serverSocket.EndReceiveFrom(iar, ref clientEP);
                    data = new byte[dataLen];
                    Array.Copy(this.byteData, data, dataLen);

                    for (int index = 0; index < 3; index++)
                        vals[index] = BitConverter.ToDouble(data, (index + 3) * sizeof(double));

                    SetControlPropertyThreadSafe(yawLabel,   "Text", "Yaw: "   + string.Format("{0:N2}°", vals[0]));
                    SetControlPropertyThreadSafe(pitchLabel, "Text", "Pitch: " + string.Format("{0:N2}°", vals[1]));
                    SetControlPropertyThreadSafe(rollLabel,  "Text", "Roll: "  + string.Format("{0:N2}°", vals[2]));

                    if (first){
                        first = false;
                        befVals[0] = vals[0]; befVals[1] = vals[1]; befVals[2] = vals[2];
                    }
                    moveCursor();
                    befVals[0] = vals[0]; befVals[1] = vals[1]; befVals[2] = vals[2];
                }
                catch (Exception e){
                    Console.WriteLine(e.Message);
                }
                
            }catch (Exception e){
                Console.WriteLine(e.Message);
            }

            EndPoint newClientEP = new IPEndPoint(IPAddress.Any, 0);
            if(running)
                this.serverSocket.BeginReceiveFrom(this.byteData, 0, this.byteData.Length, SocketFlags.None, ref newClientEP, DoReceiveFrom, newClientEP);
        }

        private void moveCursor()
        {
            double dx = befVals[selectedX] - vals[selectedX];
            double dy = befVals[selectedY] - vals[selectedY];

            if (Math.Abs(dx) > 180.0)
                dx = befVals[selectedX] - vals[selectedX] + ( dx > 0.0 ? -360.0 : 360.0 );
            if (Math.Abs(dy) > 180.0)
                dy = befVals[selectedY] - vals[selectedY] + ( dy > 0.0 ? -360.0 : 360.0);

            dx *= ((double)sensitivityX / 100.0) * (invertedX ? -1.0 : 1.0);
            dy *= ((double)sensitivityY / 100.0) * (invertedY ? -1.0 : 1.0);

            if(double.IsNaN(dx) || double.IsInfinity(dx))
                dx = 0.0;

            if (double.IsNaN(dy) || double.IsInfinity(dy))
                dy = 0.0;

            Cursor.Position = new Point(Cursor.Position.X + (int)dx, Cursor.Position.Y + (int)dy);
        }

        bool loading = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            String[] list = {"Yaw", "Pitch", "Roll"};
            comboBoxX.Items.AddRange(list);
            comboBoxY.Items.AddRange(list);

            comboBoxX.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxY.DropDownStyle = ComboBoxStyle.DropDownList;

            loadSettings();

            selectedX = comboBoxX.SelectedIndex;
            selectedY = comboBoxY.SelectedIndex;
            invertedX = invertX.Checked;
            invertedY = invertY.Checked;
            sensitivityX = SensitivityX.Value;
            sensitivityY = SensitivityY.Value;

            ipLabel.Text = "Local IP Address: " + Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
        }

        private void loadSettings()
        {
            loading = true;
            try {
                using (StreamReader readText = new StreamReader("EmulationSettings.txt"))
                {

                    portNumber.Value = getNumber(readText.ReadLine());

                    comboBoxX.SelectedIndex = getNumber(readText.ReadLine());
                    comboBoxY.SelectedIndex = getNumber(readText.ReadLine());

                    SensitivityX.Value = getNumber(readText.ReadLine());
                    SensitivityY.Value = getNumber(readText.ReadLine());

                    invertX.Checked = getNumber(readText.ReadLine()) == 1 ? true : false;
                    invertY.Checked = getNumber(readText.ReadLine()) == 1 ? true : false;
                }
            }
            catch(Exception e)
            {
                comboBoxX.SelectedIndex = 0;
                comboBoxY.SelectedIndex = 2;

                saveSettings();
                Console.WriteLine(e.Message);
            }
            loading = false;
        }

        private int getNumber(string input)
        {
            Stack<char> stack = new Stack<char>();

            for (var i = input.Length - 1; i >= 0; i--)
            {
                if (!char.IsNumber(input[i]))
                {
                    break;
                }

                stack.Push(input[i]);
            }

            string result = new string(stack.ToArray());
            return int.Parse(result);
        }

        private void saveSettings()
        {
            using (StreamWriter writetext = new StreamWriter("EmulationSettings.txt"))
            {
                writetext.WriteLine("Port: " + portNumber.Value);
                writetext.WriteLine("SelectedX: " + comboBoxX.SelectedIndex);
                writetext.WriteLine("SelectedY: " + comboBoxY.SelectedIndex);

                writetext.WriteLine("SensitivityX: " + SensitivityX.Value);
                writetext.WriteLine("SensitivityY: " + SensitivityY.Value);

                writetext.WriteLine("InvertX: " + (invertX.Checked ? 1 : 0));
                writetext.WriteLine("InvertY: " + (invertY.Checked ? 1 : 0));
            }

        }

        private delegate void SetControlPropertyThreadSafeDelegate(Control control, string propertyName, object propertyValue);

        public static void SetControlPropertyThreadSafe(
                Control control,
                string propertyName,
                object propertyValue)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SetControlPropertyThreadSafeDelegate
                (SetControlPropertyThreadSafe),
                new object[] { control, propertyName, propertyValue });
            }
            else
            {
                control.GetType().InvokeMember(
                    propertyName,
                    BindingFlags.SetProperty,
                    null,
                    control,
                    new object[] { propertyValue });
            }
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (running){
                stop();
                button1.Text = "Start";
                button1.ForeColor = Color.Green;
            }
            else
            {
                button1.Text = "Stop";
                button1.ForeColor = Color.Red;
                run();
            }
        }

        private void comboBoxX_SelectedIndexChanged(object sender, EventArgs e){
            selectedX = comboBoxX.SelectedIndex;
            if (!loading) saveSettings();
        }
        private void comboBoxY_SelectedIndexChanged(object sender, EventArgs e){
            selectedY = comboBoxY.SelectedIndex;
            if (!loading) saveSettings();
        }

        private void invertX_CheckedChanged(object sender, EventArgs e){
            invertedX = invertX.Checked;
            if (!loading) saveSettings();
        }

        private void invertY_CheckedChanged(object sender, EventArgs e){
            invertedY = invertY.Checked;
            if (!loading) saveSettings();
        }

        private void SensitivityX_Scroll(object sender, ScrollEventArgs e){
            sensitivityX = SensitivityX.Value;
            if (!loading) saveSettings();
        }

        private void SensitivityY_Scroll(object sender, ScrollEventArgs e){
            sensitivityY = SensitivityY.Value;
            if(!loading) saveSettings();
        }

        private void portNumber_ValueChanged(object sender, EventArgs e)
        {
            if (!loading) saveSettings();
        }
    }

}
