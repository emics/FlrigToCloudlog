using System.Net;
using System.Net.Http.Json;
using System.Net.Sockets;
using System.Text;

namespace FlrigToCloudlog
{
    class UdpServer
    {
        private readonly int _port;
        private readonly Thread _serverThread;
        private UdpClient _udpClient;
        private bool _isRunning;

        public UdpServer(int port)
        {
            _port = port;
            _serverThread = new Thread(Listen);
            _isRunning = false;
        }

        public void Start()
        {
            if (!_isRunning)
            {
                _udpClient = new UdpClient(_port);
                _serverThread.Start();
                _isRunning = true;
                Console.WriteLine($"Server UDP in ascolto su porta {_port}");
            }
            else
            {
                Console.WriteLine("Il server è già in esecuzione.");
            }
        }

        public void Stop()
        {
            if (_isRunning)
            {
                _udpClient.Close();
                _serverThread.Join(); // Attende che il thread del server termini
                _isRunning = false;
                Console.WriteLine("Server UDP fermato.");
            }
            else
            {
                Console.WriteLine("Il server non è in esecuzione.");
            }
        }

        private void Listen()
        {
            try
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, _port);
                while (_isRunning)
                {
                    byte[] receivedBytes = _udpClient.Receive(ref endPoint);
                    string receivedData = Encoding.ASCII.GetString(receivedBytes);
                    Console.WriteLine($"Dati ricevuti: {receivedData}");

                    //SendDataToCloud(receivedData);

                    Form1.toDo.Add(new Queue()
                    {
                        txt = receivedData,
                        published = false,
                        send = false
                    });
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine($"Errore nella ricezione dei dati: {e.Message}");
            }
        }        
    }
}
