using Model.Interface;
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

        public List<IBLItem> NeedModifyBLItems { get; set; }


        public override bool Equals(object obj)
        {
            // 检查传入的对象是否为null以及是否与当前对象类型相同
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            // 将传入对象转换为JsonModifyCommandModel类型
            JsonModifyCommandModel other = (JsonModifyCommandModel)obj;

            // 比较TransactionID和TargetRole是否相同
            return (TransactionID == other.TransactionID) && (TargetRole == other.TargetRole);
        }

    }
}
