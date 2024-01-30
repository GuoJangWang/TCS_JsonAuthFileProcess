using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Model
{
    public class DepositAccounts
    {
        public string JsonPath { get;  }

        public JObject JsonObject { get; set; }

        public DepositAccounts()
        {
            this.JsonPath = Path.Combine(ConfigurationManager.AppSettings["JsonPath"], "DepositAccounts.json");
            DummyInitail();
        }

        private void DummyInitail()
        {
            try
            {
                // 讀取 JSON 檔案的內容
                string jsonContent = File.ReadAllText(JsonPath);
                JObject result = JObject.Parse(jsonContent);

                JsonObject = result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
