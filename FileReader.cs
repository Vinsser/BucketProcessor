using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace BucketProcessor
{
    class FileReader {
        public void Data()
        {
        Console.WriteLine("Hello World! from FileReader class");
        var wh = new AutoResetEvent(false);
        var fsw = new FileSystemWatcher(".");
        fsw.Filter = "bucket.txt";
        fsw.EnableRaisingEvents = true;
            
        try
        {
            // TBA //
            fsw.Changed += (s,e) => wh.Set();
            var fs = new FileStream("bucket.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            // Open the text file using a stream reader.
            using (var sr = new StreamReader(fs))
            {
                string line;
                // Read the stream as a string, and write the string to the console.
                while (true)
                {
                    line = sr.ReadLine();
                    if (line != null && line != "")
                    {
                       //Console.WriteLine(line);
                       //jsonObject.Add("test-key", line);
                       RestWorker.Curl(line);
                    }
                    else
                    {
                       //Console.WriteLine("sleep for 1 sec");
                       wh.WaitOne(1000);
                       //Thread.Sleep(1000);
                    }
                }
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }

        }
    }
}