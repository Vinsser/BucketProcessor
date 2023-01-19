using System;

namespace BucketProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press ESC to stop");
            do {
                while (! Console.KeyAvailable) {
                        FileReader fr = new FileReader();
                        fr.Data();
                        //RestWorker.Curl("main call");
                        //Thread.Sleep(5000);
                        //System.Environment.Exit(0); 
            }       
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            //Console.WriteLine("Hello World!");
        }
    }
}
