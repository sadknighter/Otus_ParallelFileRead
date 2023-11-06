// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ParallelFileRead.Interfaces;
using ParallelFileRead.Services;
using Serilog;

IConfigurationBuilder builder = new ConfigurationBuilder();
AppSettingsBuilder.BuildConfig(builder);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Build())
    .Enrich.FromLogContext()
    .WriteTo.Console()
.CreateLogger();

Log.Logger.Information("Application Starting");

var host = Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) =>
    {
        services.AddTransient<IAppSettingsReader, AppSettingsReader>();
        services.AddTransient<IAppSettingsChanger, AppSettingsChanger>();
        services.AddTransient<IFilesGenerator, FilesGenerator>();
        services.AddTransient<ISymbolCounter, SymbolCounter>();
        services.AddTransient<IParallelFileActionService, ParallelFileActionService>();
        services.AddTransient<IFileActionService, FileActionService>();
        services.AddTransient<IConfigurationValidator, ConfigurationValidator>();
        services.AddTransient<IConsoleUiService, ConsoleUiService>();
    })
    .UseSerilog()
    .Build();

var svc = ActivatorUtilities.CreateInstance<ConsoleUiService>(host.Services);
svc.Run();


/*
* Прочитать 3 файла параллельно и вычислить количество пробелов в них (через Task).
TODO: Read file parallely method service
TODO: Add work with several files
Написать функцию, принимающую в качестве аргумента путь к папке. Из этой папки параллельно прочитать все файлы и вычислить количество пробелов в них.
TODO: Added user configuring folder, ask do you need it
Замерьте время выполнения кода (класс Stopwatch).

Generate files in folder or user folder.

 */