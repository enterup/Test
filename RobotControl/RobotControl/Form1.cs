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

namespace RobotControl
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        static int forwardSpeed = 0;
        static int backwardSpeed = 0;
        static int rightSpeed = 0;
        static int leftSpeed = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void forwardButton_Click(object sender, EventArgs e)
        {
            String speedString = "";
            if (forwardSpeed == 0 && backwardSpeed == 0)
            {
                speedString = "fw100;\n";
                forwardSpeed = 100;
                stream = client.GetStream();
                Byte[] data = System.Text.Encoding.ASCII.GetBytes("fw100;\n");
                stream.Write(data, 0, data.Length);
               
                return;

            }
            if(forwardSpeed == 100)
            {
                speedString = "fw150;\n";
                forwardSpeed = 150;
                stream = client.GetStream();
                Byte[] data = System.Text.Encoding.ASCII.GetBytes("fw150;\n");
                stream.Write(data, 0, data.Length);
               
                return;
            }
            if (forwardSpeed == 150)
            {
                speedString = "fw200;\n";
                forwardSpeed = 200;
                stream = client.GetStream();
                Byte[] data = System.Text.Encoding.ASCII.GetBytes("fw200;\n");
                stream.Write(data, 0, data.Length);
               
                return;
            }
            if(forwardSpeed == 0 && backwardSpeed == 200)
            {
                speedString = "bw150;\n";
                backwardSpeed = 150;
                stream = client.GetStream();
                Byte[] data = System.Text.Encoding.ASCII.GetBytes("bw150;\n");
                stream.Write(data, 0, data.Length);
               
                return;
            }
            if(forwardSpeed == 0 && backwardSpeed == 150)
            {
                speedString = "bw100;\n";
                backwardSpeed = 100;
                stream = client.GetStream();
                Byte[] data = System.Text.Encoding.ASCII.GetBytes("bw100;\n");
                stream.Write(data, 0, data.Length);
               
                return;
            }
            if(forwardSpeed == 0 && backwardSpeed == 100)
            {
                speedString = "bw000;\n";
                backwardSpeed = 0;
                stream = client.GetStream();
                Byte[] data = System.Text.Encoding.ASCII.GetBytes("bw000;\n");
                stream.Write(data, 0, data.Length);
              
                return;
            }
          
            
           
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            client.Close();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
           
            if(forwardSpeed == 0 && backwardSpeed == 0)
            {
            stream = client.GetStream();
            Byte[] data = System.Text.Encoding.ASCII.GetBytes("bw100;\n");
            stream.Write(data, 0, data.Length);
            backwardSpeed = 100;
            return;
            }
            if(forwardSpeed == 0 && backwardSpeed == 100)
            {
            stream = client.GetStream();
            Byte[] data = System.Text.Encoding.ASCII.GetBytes("bw150;\n");
            stream.Write(data, 0, data.Length);
            backwardSpeed = 150;
            return;
            }
            if (forwardSpeed == 0 && backwardSpeed == 150)
            {
                stream = client.GetStream();
                Byte[] data = System.Text.Encoding.ASCII.GetBytes("bw200;\n");
                stream.Write(data, 0, data.Length);
                backwardSpeed = 200;
                return;
            }
            
            if (forwardSpeed == 200 && backwardSpeed == 0)
            {
                stream = client.GetStream();
                Byte[] data = System.Text.Encoding.ASCII.GetBytes("fw150;\n");
                stream.Write(data, 0, data.Length);
                forwardSpeed = 150;
                return;
            }

            if (forwardSpeed == 150 && backwardSpeed == 0)
            {
                stream = client.GetStream();
                Byte[] data = System.Text.Encoding.ASCII.GetBytes("fw100;\n");
                stream.Write(data, 0, data.Length);
                forwardSpeed = 100;
                return;
            }
            if (forwardSpeed == 100 && backwardSpeed == 0)
            {
                stream = client.GetStream();
                Byte[] data = System.Text.Encoding.ASCII.GetBytes("fw000;\n");
                stream.Write(data, 0, data.Length);
                forwardSpeed = 0;
                backwardSpeed = 0;
                return;
            }
 
        }
        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            stream = client.GetStream();
            Byte[] data = System.Text.Encoding.ASCII.GetBytes("bw000;\n");
            stream.Write(data, 0, data.Length);
            forwardSpeed = 0;
            backwardSpeed = 0;
         
        }

        private void button8_Click(object sender, EventArgs e)
        {
            String serverName = textBox1.Text;
            client = new TcpClient(serverName, 2023);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            stream = client.GetStream();
            Byte[] data = System.Text.Encoding.ASCII.GetBytes("rt100;\n");
            stream.Write(data, 0, data.Length);
          
        }

        private void leftButton_Click(object sender, EventArgs e)
        {
            stream = client.GetStream();
            Byte[] data = System.Text.Encoding.ASCII.GetBytes("lt100;\n");
            stream.Write(data, 0, data.Length);
        
        }

        private void rightButton_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'W')
            {
                forwardButton_Click(sender, e);
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
        }

        private void rightCamButton_Click(object sender, EventArgs e)
        {
         //   webBrowser1.Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          //  webBrowser1.Refresh();
            pictureBox1.LoadAsync("http://192.168.0.44:8081/?action=snapshot");
        }
    }
}
