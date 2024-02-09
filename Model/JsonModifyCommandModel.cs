using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.SystemEnum;

namespace Model
{
    public class JsonModifyCommandModel
    {
        public JsonModifyCommandModel()
        {

        }

        public string ScreenID { get; set; }

        public JsonAuthType Auth { get; set; } = JsonAuthType.disable;

        public int TargetRole { get; set; } = 99;

        public string TargetFileName { get; set; } = "DepositAccounts.json";

    }
}
