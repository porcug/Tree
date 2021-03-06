using System;
using System.Collections.Generic;

using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Tree_Server
{
    class Server
    {
        TcpListener server = null;
      public void Start(
        IPAddress localAddr , Int32 port = 9999 ) { 
         try
            {
      // Set the TcpListener on port 13000.
             

        // TcpListener server = new TcpListener(port);
        server = new TcpListener(localAddr, port);

        // Start listening for client requests.
        server.Start();

      // Buffer for reading data
      Byte[] bytes = new Byte[1024];
        String data = "";

      // Enter the listening loop.
      while(true)
      {
        Console.Write("Waiting for a connection... ");

        // Perform a blocking call to accept requests.
        // You could also use server.AcceptSocket() here.
        TcpClient client = server.AcceptTcpClient();
        Console.WriteLine("Connected!");

        data = "";

        // Get a stream object for reading and writing
        NetworkStream stream = client.GetStream();

        int i;

        // Loop to receive all the data sent by the client.
        while((i = stream.Read(bytes, 0, bytes.Length))!=0)
        {
          // Translate data bytes to a ASCII string.
          data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
          Console.WriteLine("Received: {0}", data);

                        // Process the data sent by the client.
                        data = Item.getItems(data);

          byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

        // Send back a response.
        stream.Write(msg, 0, msg.Length);
                        stream.Flush();
    //      Console.WriteLine("Sent: {0}", data);
        }

    // Shutdown and end connection
    client.Close();
      }
    }
    catch (SocketException e)
{
    Console.WriteLine("SocketException: {0}", e);
}
finally
{
    // Stop listening for new clients.
    server.Stop();
}

Console.WriteLine("\nHit enter to continue...");
Console.Read();
  }
    }
}

