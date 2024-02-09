using Common;
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

        public static void AddError<T>(this ServiceResult<T> serviceResult, string msg)
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

        public static int ToEnumIntVal<T>(this Enum targetEnum)
        {
            try
            {
                var result = Enum.Parse(typeof(T), targetEnum.ToString());
                return (int)result;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
