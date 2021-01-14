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

            var Watcher = new TargetWatcher(EnvSettings.Env.SOURCE_DIRECTORY);

            Watcher.Run();

            Console.ReadKey();
        }
    }
}
