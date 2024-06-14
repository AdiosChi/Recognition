using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using System.Threading;

public class listener : MonoBehaviour
{
    Thread thread;
    public int connectionPort = 25001;
    TcpListener server;
    TcpClient client;
    bool running;
    public static string dataReceived = "";


    void Start()
    {
        // Receive on a separate thread so Unity doesn't freeze waiting for data
        DontDestroyOnLoad(this.gameObject);
        ThreadStart ts = new ThreadStart(GetData);
        thread = new Thread(ts);
        thread.Start();
    }

    void GetData()
    {
        // Create the server
        server = new TcpListener(IPAddress.Any, connectionPort);
        server.Start();

        // Create a client to get the data stream
        client = server.AcceptTcpClient();

        // Start listening
        running = true;
        while (running)
        {
            Connection();
        }
        server.Stop();
    }

    void Connection()
    {
        // Read data from the network stream
        NetworkStream nwStream = client.GetStream();
        byte[] buffer = new byte[client.ReceiveBufferSize];
        int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);
        dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead);
    }

    // Use-case specific function, need to re-write this to interpret whatever data is being sent


    void Update()
    {


    }
}