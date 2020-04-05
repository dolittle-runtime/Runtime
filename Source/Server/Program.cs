﻿// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;
using Dolittle.Hosting.Microsoft;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Dolittle.Runtime.Server
{
    static class Program
    {
        /// <summary>
        /// Main method.
        /// </summary>
        /// <param name="args">Arguments for the process.</param>
        public static async Task Main(string[] args) =>
            await CreateHostBuilder(args)
                .Build()
                .RunAsync().ConfigureAwait(false);

        /// <summary>
        /// Create a host builder.
        /// </summary>
        /// <param name="args">Arguments for the process.</param>
        /// <returns>Host builder to build and run.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var appConfig = new ConfigurationBuilder()
                                    .AddJsonFile("appsettings.json")
                                    .Build();

            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(config => config.AddConfiguration(appConfig))
                .UseDolittle()
                .Build().Services.GetService()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseUrls("http://0.0.0.0:81")
                        .UseEnvironment("Development")
                        .UseStartup<Startup>();
                });
        }
    }
}
