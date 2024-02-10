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

        /// <summary>
        /// 交易代號
        /// </summary>
        public string TransactionID { get; set; }

        /// <summary>
        /// 權限設定
        /// </summary>
        public JsonAuthType Auth { get; set; } = JsonAuthType.disable;

        /// <summary>
        /// 目標角色
        /// </summary>
        public int TargetRole { get; set; }


        //public string TargetFileName { get; set; } = "DepositAccounts.json";

    }
}
