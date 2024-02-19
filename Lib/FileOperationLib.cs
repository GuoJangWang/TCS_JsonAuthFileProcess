﻿using Lib.Interface;
using Model;
using Model.BaseObject;
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

namespace Lib
{
    public class FileOperationLib : ILibGeneralField
    {
        public string DeployWorkingRoot { get; set; }

        public Dictionary<IBLItem,string> TargetFilePaths { get; set; }

        public List<JsonModifyCommandModel> JsonModifyCommandModels { get; set; }

        public FileOperationLib(List<JsonModifyCommandModel> commandModels)
        {
            this.DeployWorkingRoot = ConfigurationManager.AppSettings["DeployWorkingRoot"];
            this.JsonModifyCommandModels = commandModels;
            this.TargetFilePaths = GetTargetFilePath(JsonModifyCommandModels,DeployWorkingRoot).Data;
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public ServiceResult DocumentOverWriteProcess(JObject newValue)
        {
            var result = new ServiceResult();
            try
            {
                // 將修改後的內容寫回文件
                File.WriteAllText(TargetFilePaths, newValue.ToString());

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
        public ServiceResult<JObject> GetFileJsonObject()
        {
            var result = new ServiceResult<JObject>();
            try
            {
                byte[] fileBytes = File.ReadAllBytes(TargetFilePaths);
                JObject jItem = JObject.Parse(System.Text.Encoding.UTF8.GetString(fileBytes));

                result.Data = jItem;

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private ServiceResult<Dictionary<IBLItem, string>> GetTargetFilePath(List<JsonModifyCommandModel> targetFileName, string dir = null)
        {
            // 檢查目錄是否存在
            var result = new ServiceResult<string>();

            try
            {
                string[] files = Directory.GetFiles(dir, targetFileName, SearchOption.AllDirectories);

                if (files.Length > 0)
                {
                    result.Data = files[0];
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
