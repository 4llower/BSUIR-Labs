using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.Json.Serialization;

namespace ETL_Extract.Helpers
{
    static public class EnvSettings
    {
        public class Environment {
            public string SOURCE_DIRECTORY { get; set; }
            public string TARGET_DIRECTORY { get; set; }
        }

        public static Environment Env;

        private static readonly string pathToSettings = "../../../appsettings.json";
        // use at launch application
        static public void Initialize()
        {
            StreamReader stream = new StreamReader(pathToSettings);
            Env = JsonConvert.DeserializeObject<Environment>(stream.ReadToEnd());
        }
    }
}
