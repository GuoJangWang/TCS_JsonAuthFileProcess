﻿using Model.BaseObject.Buisness;
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

        public DepositAccounts()
        {
            this.JsonPath = Path.Combine(ConfigurationManager.AppSettings["JsonPath"], "DepositAccounts.json");
            DummyInitail();
        }
    }
}
