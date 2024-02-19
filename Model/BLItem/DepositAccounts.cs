using Model.BaseObject.Buisness;
using Model.Interface;
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
    public class DepositAccounts : BaseBLItem
    {

        public DepositAccounts(string fileName)
        {
            this.JsonPath = Path.Combine(ConfigurationManager.AppSettings["JsonPath"], fileName);
            DummyInitail();
        }
    }
}
