using Model.BaseObject;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class FileOperationLib
    {
        public string DeployWorkingRoot { get; set; }
        public FileOperationLib()
        {
            this.DeployWorkingRoot = ConfigurationManager.AppSettings["DeployWorkingRoot"];
        }

        /// <summary>
        /// TODO實作
        /// </summary>
        /// <returns></returns>
        public ServiceResult DocumentOverWriteProcess()
        {
            var result = new ServiceResult();
            try
            {

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ServiceResult<JObject> GetFileJsonObject(string targetFileName)
        {
            var result = new ServiceResult<JObject>();
            try
            {


                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
