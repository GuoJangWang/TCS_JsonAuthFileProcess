using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class JsonModifyCommandModel
    {
        public JsonModifyCommandModel()
        {
                
        }

        public string ScreenID { get; set; } = "CustomerInfo/062000";

        public bool Auth { get; set; }

        public int TargetRole { get; set; } = 99;

        public string TargetFile { get; set; } = "DepositAccounts.json";

    }
}
