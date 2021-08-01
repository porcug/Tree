using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Tree_view.ViewModel
{
    class Root 
    {
        String serverAddress;
        int port;
        
        public Root(String serverAddress)
        {
            this.serverAddress = serverAddress;
             port = 9999;
        }
        public Root(String ServerAddress,int Port)
        {
            this.serverAddress = ServerAddress;
            port = Port;
        }
       
      
        public ReadOnlyCollection<TreeItem> getChildrens(String parentId="0")
        {
            TcpClient client = new TcpClient(serverAddress, port);
            List<TreeItem> childrens = new List<TreeItem>();
            client.GetStream().Write(Encoding.UTF8.GetBytes(parentId));
            client.GetStream().Flush();
            Byte[] buffer = new Byte[1024];
            int read = 0;
            String recived = "";
            client.ReceiveTimeout = 500;
            do
            {
                try
                {
                    read = client.GetStream().Read(buffer);
                } catch { read = 0; }
                if (read > 0)
                    recived += Encoding.UTF8.GetString(buffer, 0, read);
            } while (read > 0);
            client.Close();
            String[] items = recived.Split("\r\n");
            foreach (string item in items)
            {
                String[] componments = item.Split("\n");
                if (componments.Length < 2)
                    continue;
                if (componments[0].Equals("T"))
                {
                    childrens.Add(new Task(this, componments.Skip(1).ToArray()));
                }
                if (componments[0].Equals("S"))
                {
                    childrens.Add(new Step(this, componments.Skip(1).ToArray()));
                }
            }
            return new ReadOnlyCollection<TreeItem>(childrens);
        }
      
    }
}
