using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_3_Sem_2
{
    class Server
    {
        public Server()
        {

        }

        /// <summary>
        /// Start the server running on the given IP and Port on a separate thread, combined with parsing the data
        /// </summary>
        public void Run()
        {

            try
            {
                //I have port 42069 on my router forwarded, so
                //outside clients can also connect and test the server (for assessment, anyone can communicate with it)
                const string ADDRESS = "192.168.1.180";
                const int PORT = 555;

                IPAddress ip = IPAddress.Parse(ADDRESS);
                IPEndPoint localEndPoint = new IPEndPoint(ip, PORT);
                Socket listener = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                // Bind to the endpoint
                listener.Bind(localEndPoint);// Start listening
                listener.Listen(10);


                while (true)
                {

                    Console.WriteLine("Ready");
                    // Get the next connection from the queue or wait    
                    Socket clientSocket = listener.Accept();
                    // Setup streams to read    
                    NetworkStream networkStream = new NetworkStream(clientSocket);
                    StreamReader streamReader = new StreamReader(networkStream);
                    StreamWriter streamWriter = new StreamWriter(networkStream);

                    if (clientSocket.Connected)
                    {
                        Form1.listBoxItems.Add("Server: WELCOME");
                        streamWriter.WriteLine("WELCOME");
                        streamWriter.Flush();
                    }
                    // Keep reading until disconnect
                    string line = streamReader.ReadLine();
                    Form1.listBoxItems.Add("Client: " + line);
                    Console.WriteLine("Client says: " + line);

                    bool secondBreak = false;
                    bool err = false;
                    while (line != null)
                    {
                        Sensor sensor = new Sensor();
                        //if (secondBreak) break; //last edit
                        bool stop = false;
                        bool breakOnce = false;
                        if (line == "START")
                        {

                            Form1.listBoxItems.Add("Server: NAME");
                            streamWriter.WriteLine("NAME");
                            streamWriter.Flush();
                            string s = streamReader.ReadLine();
                            Form1.listBoxItems.Add("Client: " + s);
                            Console.WriteLine("Client says: " + s);
                            if (s == "STOP")
                            {

                                break;
                            }
                            sensor.name = s;
                            Form1.listBoxItems.Add("Server: ACK");
                            streamWriter.WriteLine("ACK");
                            streamWriter.Flush();
                            while (line != "STOP")
                            {
                                if (breakOnce) break;
                                again:
                                line = streamReader.ReadLine();
                                Form1.listBoxItems.Add("Client: " + line);
                                Console.WriteLine("Client says: " + line);
                                switch (line)
                                {
                                    case "STOP":
                                        stop = true;
                                        break;

                                    case "DATA":
                                        if (sensor.isRecordable(false))
                                        {
                                            err = true;
                                            secondBreak = true;
                                            breakOnce = true;
                                            line = "STOP";
                                            s = "STOP";
                                            break;
                                        }
                                        Form1.listBoxItems.Add("Server: UNIT");
                                        streamWriter.WriteLine("UNIT");
                                        streamWriter.Flush();
                                        string unit = streamReader.ReadLine();
                                        Form1.listBoxItems.Add("Client: " + unit);
                                        Console.WriteLine("Client says: " + unit);
                                        if (unit == "celcius" || unit == "pascal" || unit == "lumen" || unit == "volt")
                                        {
                                            sensor.unit = unit;

                                            Form1.listBoxItems.Add("Server: VALUE");
                                            streamWriter.WriteLine("VALUE");
                                            streamWriter.Flush();
                                            string transitionS = streamReader.ReadLine();
                                            transitionS = transitionS.Replace(".", ",");            //SYSTEM DEPENDANT !!! I dont know how to make it for every system to work..
                                            Form1.listBoxItems.Add("Client: " + transitionS);
                                            Console.WriteLine("Client says: " + transitionS);
                                            if (double.TryParse(transitionS, out double value))
                                            {
                                                sensor.value = value;
                                                Form1.listBoxItems.Add("Server: ACK");
                                                streamWriter.WriteLine("ACK");
                                                streamWriter.Flush();
                                            }
                                            else
                                            {
                                                if (transitionS == "STOP")
                                                {

                                                    line = transitionS;
                                                    secondBreak = true;
                                                    breakOnce = true;
                                                    break;

                                                }
                                                else
                                                {
                                                    Form1.listBoxItems.Add("Server: ERR");
                                                    streamWriter.WriteLine("ERR");
                                                    streamWriter.Flush();
                                                    goto again;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            err = true;
                                            line = "STOP";
                                            stop = true;
                                        }
                                        break;

                                    default:
                                        err = true;
                                        line = "STOP";
                                        stop = true;
                                        break;
                                }
                                if (stop)
                                {
                                    secondBreak = true;
                                    break;
                                }
                                else secondBreak = false;
                            }
                            sensor.isRecordable(true);
                        }
                        else if (line == "STOP")
                        {
                            if (err)
                            {
                                Form1.listBoxItems.Add("Server: ERR");
                                streamWriter.WriteLine("ERR");
                                streamWriter.Flush();

                                err = false;
                            }
                            else
                            {
                                sensor.isRecordable(true);
                                Form1.listBoxItems.Add("Server: ACK");
                                streamWriter.WriteLine("ACK");
                                streamWriter.Flush();
                            }
                            break;
                        }
                        else
                        {
                            Form1.listBoxItems.Add("Server: ERR");
                            streamWriter.WriteLine("ERR");
                            streamWriter.Flush();

                            break;
                        }
                    }
                    // Client disconnected  
                    Form1.listBoxItems.Add("-------Client Disconnected-------");
                    Console.WriteLine("Client disconnected");
                    clientSocket.Close();
                    networkStream.Close();
                    streamReader.Close();
                    streamWriter.Close();
                }
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("This Socket is already taken");
            }
        }
    }
}
