using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace keepr_c
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}



//TODO:
//Messages if you try to keep when not logged in.
//CHECK ALL FORMS FOR LENGTH LIMITS!!!
//Back button from dashboard to main page
//Go through your app and add extra creation / deletion buttons as appropriate
//Add a means to make private posts public, but once public they CANNOT be deleted!
//Make sure all three buttons are implemented, even if you cannot yet share!
//MAKE SURE YOUR PROGRAM WILL BUILD! (NPM RUN BUILD)

//MOCK DATA:
//Mimick the mock for laughs (usernames, keeps etc.)
//Sweet game art

//EXTRA:
//Tags on keeps and a search function
//Write tests for your components
//Share icon that lets you share to social media