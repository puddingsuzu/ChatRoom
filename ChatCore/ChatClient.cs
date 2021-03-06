using System;
using System.Net.Sockets;

namespace ChatCore
{
    public class ChatClient
    {
        private TcpClient m_client;

        public ChatClient()
        {
        }

        public bool Connect(string address, int port)
        {
            m_client = new TcpClient();

            try
            {
                Console.WriteLine("Connecting to chat server {0}:{1}", address, port);
                m_client.Connect(address, port);

                Console.WriteLine("Connected to chat server");
                return m_client.Connected;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
                return false;
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
                return false;
            }
        }

        public void Disconnect()
        {
            m_client.Close();
            Console.WriteLine("Disconnected");
        }

        public void SendData(string message)
        {
            var requestBuffer = System.Text.Encoding.ASCII.GetBytes(message);

            m_client.GetStream().Write(requestBuffer, 0, requestBuffer.Length);
        }
    }
}