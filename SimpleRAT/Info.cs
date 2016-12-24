using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

/* This is the class where our information for our client will be stored. */
/* I would also like to give credits to xSilent for helping me. */

public class Info
{
    // --- Variables (Public) --- \\
    public Socket sock;
    public Guid ID;
    public string RemoteAddress;
    public byte[] buffer = new byte[8192];
    // --- Variables (Public) ---\\
    public Info(Socket sock)
    {
        this.sock = sock; /* Self explanatory */
        ID = Guid.NewGuid(); /* This is the ID. It's not needed, but I added it just in case. */
        RemoteAddress = sock.RemoteEndPoint.ToString(); /* Stores the remote IP address into our string, RemoteAddress */
    }

    public void Send(string data)
    {
        /* You can guess this feature! */
        byte[] buffer = Encoding.ASCII.GetBytes(data);
        sock.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback((ar) =>
        {
            sock.EndSend(ar);
        }), buffer);
    }
}
