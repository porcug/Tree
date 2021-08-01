using System;
using System.Net;

namespace Tree_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            PopulateDb.Populate();
            new Server().Start(IPAddress.Parse("127.0.0.1"));
        }
    }
}
