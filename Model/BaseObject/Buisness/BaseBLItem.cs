using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BaseObject.Buisness
{
    public class BaseBLItem
    {
        public string JsonFileName {  get; set; }

        protected string JsonPath { get; set; }

        public JObject JsonObject { get; set; }

        protected void DummyInitail()
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
