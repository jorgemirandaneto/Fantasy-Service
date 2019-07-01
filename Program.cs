using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FantasyServer;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Fantasy_Service {
    public class Program {
        public static void Main (string[] args) {
            CreateWebHostBuilder (args).Build ().Run ();
        }

        public static IWebHostBuilder CreateWebHostBuilder (string[] args) =>
            WebHost.CreateDefaultBuilder (args)
            .UseStartup<Startup> ()
            .UseKestrel ((context, options) => {
                var port = Environment.GetEnvironmentVariable ("PORT");
                if (!string.IsNullOrEmpty (port)) {
                    options.ListenAnyIP (int.Parse (port));
                }
            });
    }
}