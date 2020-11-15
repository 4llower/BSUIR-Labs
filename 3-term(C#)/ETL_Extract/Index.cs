using ETL_Extract.Helpers;
using ETL_Extract.Lib;
using System;

namespace ETL_Extract
{
    class Index
    {
        static void Main(string[] args)
        {
            EnvSettings.Initialize();
            Monitoring.Run();
            Console.ReadKey();
        }
    }
}
