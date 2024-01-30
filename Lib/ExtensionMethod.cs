using Model.BaseObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public static class ExtensionMethod
    {
        public static void AddError(this ServiceResult serviceResult,string msg)
        {
			try
			{
				serviceResult.State = false;
				serviceResult.Msg = msg;
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
