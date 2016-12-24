using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

/* This is our Listener. We will use this to accept in-coming connections and store them in Info.cs */
/* I would like to give credits to xSilent for helping me. */

class Listener
{
    Socket s;
    string IP;
    public List<Info> clients;
    //--- Events ---\\
    public delegate void ReceivedEventHandler(Listener l, Info i, string received);
    public event ReceivedEventHandler Received;
    public delegate void DisconnectedEventHandler(Listener l, Info i);
    public event DisconnectedEventHandler Disconnected;
    //--- Events ---\\
    bool listening = false;
    public Listener()
    {
        clients = new List<Info>();
        s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    }

    public bool Running
    {
        /* This returns a boolean value to see if our listener is already active or not. */
        get { return listening; }
    }

    public void BeginListen(int port)
    {
        /* Basic listening method */
        s.Bind(new IPEndPoint(IPAddress.Any, port));
        s.Listen(100);
        s.BeginAccept(new AsyncCallback(AcceptCallback), s);
        listening = true;
    }

    public void StopListen()
    {
        /* Is this method not obvious enough? */
        if (listening == true)
        {
            s.Close();
        }
    }

    void AcceptCallback(IAsyncResult ar)
    {
        /* This is where we'll be accepting connections. */
        Socket handler = (Socket)ar.AsyncState;
        Socket sock = handler.EndAccept(ar);
        Info i = new Info(sock);
        clients.Add(i);

        Console.WriteLine("New Connection: " + i.ID.ToString());
        sock.BeginReceive(i.buffer, 0, i.buffer.Length, SocketFlags.None, new AsyncCallback(ReadCallback), i); /* For the clients that are connected, they will begin reading incoming data */
        handler.BeginAccept(new AsyncCallback(AcceptCallback), handler); /* This will loop back to the AcceptCallback and accept more connections. */
    }

    void ReadCallback(IAsyncResult ar)
    {
        /* This is where we'll be handling in-coming data */
        Info i = (Info)ar.AsyncState;
        try
        {
            /* A simple If-statement. It says that if our variable(int) rec is not empty, it will parse the data. If it's empty, then it will disconnect the client from the server. */
            int rec = i.sock.EndReceive(ar);
            if (rec != 0)
            {
                string data = Encoding.ASCII.GetString(i.buffer, 0, rec);
                Received(this, i, data);
            }
            else
            {
                Disconnected(this, i);
                return;
            }

            i.sock.BeginReceive(i.buffer, 0, i.buffer.Length, SocketFlags.None, new AsyncCallback(ReadCallback), i); /* Loops it so more data can come in. */
        }
        catch
        {
            /* If any errors come out, it'll disconnect the client. */
            Disconnected(this, i);
            i.sock.Close();
            clients.Remove(i);
        }
    }
}
