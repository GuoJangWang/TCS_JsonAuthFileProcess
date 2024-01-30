using Model.BaseObject.Buisness;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MainMenu : BaseBLItem
    {

        public MainMenu()
        {
            this.JsonPath = Path.Combine(ConfigurationManager.AppSettings["MainMenuPath"]);
            DummyInitail();
        }

        
    }
}
