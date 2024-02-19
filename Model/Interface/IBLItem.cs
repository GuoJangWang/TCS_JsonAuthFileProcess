using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interface
{
    public interface IBLItem
    {
        string JsonFileName { get; set; }

        string JsonPath { get; set; }

        JObject JsonObject { get; set; }

        void DummyInitail();
    }
}
