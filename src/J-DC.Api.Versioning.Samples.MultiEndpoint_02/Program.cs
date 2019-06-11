using Microsoft.Owin.Hosting;
using System;
using System.Diagnostics;
using System.Threading;

namespace JDC.Api.Versioning.Samples.MultiEndpoint_02 {

    public class Program {
        const string Url = "http://localhost:9007/";
        
        static readonly ManualResetEvent resetEvent = new ManualResetEvent(false);

        public static void Main(string[] args) {
            Console.WriteLine(Properties.Resources.Header);
            Console.CancelKeyPress += OnCancel;

            using (WebApp.Start<Startup>(Url)) {
                Console.WriteLine("Content root path: " + Startup.ContentRootPath);
                Console.WriteLine("Now listening on: " + Url);
                Console.WriteLine("Application started. Press Ctrl+C to shut down.");

                Console.WriteLine("Starting browser with OK urls");
                //--- OK urls ---
                Process.Start(Url + "Data/V1");
               
                Process.Start(Url + "Config/V11");
                
                Thread.Sleep(5000);


                Console.WriteLine("Starting browser with 'Not OK' urls");


                //--- NOT OK urls ---
                Process.Start(Url + "Data/V2");
                Process.Start(Url + "Config/V12");
                //--
                Process.Start(Url + "Config/V1");
                Process.Start(Url + "Config/V2");
                Process.Start(Url + "Data/V11");
                Process.Start(Url + "Data/V12");
                resetEvent.WaitOne();
            }

            Console.CancelKeyPress -= OnCancel;
        }

        static void OnCancel(object sender, ConsoleCancelEventArgs e) {
            Console.Write("Application is shutting down...");
            e.Cancel = true;
            resetEvent.Set();
        }
    }
}