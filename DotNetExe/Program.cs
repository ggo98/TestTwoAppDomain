using System;
using System.IO;
using System.Reflection;
using SharedLib;

class Program
{
    static void Main()
    {
        string basePath = AppDomain.CurrentDomain.BaseDirectory;

        // Path to custom config file with binding redirects
        string configFilePath = Path.Combine(basePath, "IsolatedAppDomain.config");

        AppDomainSetup setup = new AppDomainSetup
        {
            ApplicationBase = basePath,
            // uncomment for older System.Buffers and System.Memory (the ones in the CnD folder)
            //ConfigurationFile = configFilePath
        };

        AppDomain newDomain = AppDomain.CreateDomain("IsolatedDomain", null, setup);

        string isolatedLibPath = Path.Combine(basePath, "IsolatedLib.dll");

        IWorker worker = (IWorker)newDomain.CreateInstanceFromAndUnwrap(
            isolatedLibPath,
            "IsolatedLib.Worker"
        );

        string result = worker.DoWork(new SomeData() { SomeProp = "somevalue" });
        Console.WriteLine(result);

        AppDomain.Unload(newDomain);
    }
}