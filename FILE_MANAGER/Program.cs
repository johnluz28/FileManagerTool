using System;
using System.Windows.Forms;
using FILE_MANAGER.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FILE_MANAGER
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //set up json convert default settings 
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            Application.Run(new Home());
        }
    }
}
