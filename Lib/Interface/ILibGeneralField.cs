using Model;
using Model.BaseObject.Buisness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Interface
{
    public interface ILibGeneralField
    {
        Dictionary<BaseBLItem, JsonModifyCommandModel> JsonModifyCommandModel { get; set; }
    }
}
