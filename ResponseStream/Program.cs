using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace ResponseStream
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Provide resource and  hit [Enter]:\n"); //line terminator character

                WebRequest req = WebRequest.Create(Console.ReadLine());
                WebResponse resp = req.GetResponse();
                Stream stream = resp.GetResponseStream();
                Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
                StreamReader sr = new StreamReader(stream, enc);

                Console.WriteLine("\nResponse Stream Received...\n");
                Thread.Sleep(5000);

                Char[] read = new Char[256];
                int count = sr.Read(read, 0, 256);

                while (count > 0)
                {
                    string str = new string(read, 0, count);
                    Console.Write(str);
                    Thread.Sleep(1000);
                    count = sr.Read(read, 0, 256);
                }

                sr.Close();
                resp.Close();

                Console.WriteLine("Press any key to exit.\n");
                Console.ReadKey();
            }
            catch (Exception)
            {
                Console.WriteLine("\nException encountered...\n");
                Console.WriteLine("Press any key to exit.\n");
                Console.ReadKey();
            }

        }
    }
}
