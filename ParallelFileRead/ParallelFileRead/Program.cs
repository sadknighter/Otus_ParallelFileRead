// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ParallelFileRead.Services;
using Serilog;

Console.WriteLine("Hello, World!");

IConfigurationBuilder builder = new ConfigurationBuilder();
AppSettingsBuilder.BuildConfig(builder);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Build())
    .Enrich.FromLogContext()
    .WriteTo.Console()
.CreateLogger();

Log.Logger.Information("Application Starting");

//var host = Host.CreateDefaultBuilder()
//    .ConfigureServices((context, services) =>
//    {
//        services.AddTransient<IConsoleUiService, ConsoleUiService>();
//        services.AddTransient<IDigitGenerator, DigitGenerator>();
//        services.AddTransient<IGuessValidator, GuessValidator>();
//    })
//    .UseSerilog()
//    .Build();

//var svc = ActivatorUtilities.CreateInstance<ConsoleUiService>(host.Services);
//svc.Run();

/*
* Прочитать 3 файла параллельно и вычислить количество пробелов в них (через Task).
TODO: Read file parallely method service
TODO: Add work with several files
Написать функцию, принимающую в качестве аргумента путь к папке. Из этой папки параллельно прочитать все файлы и вычислить количество пробелов в них.
TODO: Added user configuring folder, ask do you need it
Замерьте время выполнения кода (класс Stopwatch).

Generate files in folder or user folder.

 */