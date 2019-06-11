using Microsoft.Owin.Hosting;
using System;
using System.Diagnostics;
using System.Threading;

namespace JDC.Api.Versioning.Samples.SingleEndpoint {

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
                Process.Start(Url + "Data/V1");
                Process.Start(Url + "Data/V2");
                Process.Start(Url + "Data/V1/Value");
                Process.Start(Url + "Data/V2/Value");
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